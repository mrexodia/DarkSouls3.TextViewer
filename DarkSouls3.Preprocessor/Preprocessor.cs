using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using DarkSouls3.Structures;

namespace DarkSouls3.Preprocessor
{
    static class Preprocessor
    {
        static void RenameFiles()
        {
            var jp_en = File.ReadAllLines("jp_en_filenames.txt");
            var translate = jp_en.Select(t => t.Split('\t')).ToDictionary(split => split[0], split => split[1]);
            var files = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*.fmg", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var fname = Path.GetFileName(file);
                if (!translate.ContainsKey(fname))
                {
                    Console.WriteLine("Skipping {0}", file);
                    continue;
                }
                File.Move(file, file.Replace(fname, translate[fname]));
            }
        }

        static void ExtractFiles()
        {
            //Register BinderTool.exe to open *.fmg files
            var files = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*.fmg", SearchOption.AllDirectories);
            foreach (var file in files)
                System.Diagnostics.Process.Start(file);
        }

        static Dictionary<string, string> ParseContainer(string file)
        {
            var lines = File.ReadAllLines(file, new UTF8Encoding(false));
            var dict = new Dictionary<string, string>();
            foreach (var line in lines)
            {
                var split = line.Split('\t');
                var trim = split[1].Replace("\\r", "\r").Replace("\\n", "\n").Replace("\\t", "\t").Trim();
                if (trim.Length == 0)
                    continue;
                dict[split[0]] = trim;
            }
            return dict;
        }

        static Dictionary<string, Container> ParseContainers(IEnumerable<string> files)
        {
            var dict = new Dictionary<string, Container>();
            foreach (var file in files)
            {
                var name = Path.GetFileNameWithoutExtension(file);
                dict.Add(name, new Container
                {
                    Name = name,
                    Content = ParseContainer(file)
                });
            }
            return dict;
        }

        static void ExtractRawJson()
        {
            var languages = Directory.EnumerateDirectories(AppDomain.CurrentDomain.BaseDirectory + @"\INTERROOT_win64\msg");
            var ds3text = new DarkSouls3Text();
            foreach (var language in languages)
            {
                var files = Directory.EnumerateFiles(language, "*.txt", SearchOption.AllDirectories);
                var name = Path.GetFileName(language);
                ds3text.Languages.Add(name, new Language
                {
                    Containers = ParseContainers(files)
                });
            }
            File.WriteAllText("ds3raw.json", JSONHelper.Serialize(ds3text), new UTF8Encoding(false));
        }

        static Container RetrieveContainer(Language lang, string key)
        {
            Container c;
            if (lang.Containers.TryGetValue(key, out c))
                lang.Containers.Remove(key);
            return c;
        }

        static List<Container> RetrieveContainers(Language lang, string key)
        {
            return new List<Container>
            {
                RetrieveContainer(lang, key),
                RetrieveContainer(lang, key + "_dlc1"),
                RetrieveContainer(lang, key + "_dlc2")
            };
        }

        public delegate void AssignItemValue(GenericItem item, string value);

        static void AssignItems(Dictionary<string, GenericItem> dict, IEnumerable<Container> containers, AssignItemValue assignItemValue)
        {
            foreach (var container in containers)
            {
                if (container == null)
                    continue;
                foreach (var itemIt in container.Content)
                {
                    if (!dict.ContainsKey(itemIt.Key))
                    {
                        var newItem = new GenericItem();
                        var dlcIndex = container.Name.IndexOf("_dlc", StringComparison.Ordinal);
                        if (dlcIndex != -1)
                            newItem.Dlc = int.Parse(container.Name[dlcIndex + "_dlc".Length].ToString());
                        newItem.Id = itemIt.Key;
                        dict[itemIt.Key] = newItem;
                    }
                    assignItemValue(dict[itemIt.Key], itemIt.Value);
                }
            }
        }

        static Dictionary<string, GenericItem> ParseGenericItems(Language lang, string prefix)
        {
            var dict = new Dictionary<string, GenericItem>();
            AssignItems(dict, RetrieveContainers(lang, prefix + "name"), (item, value) => item.Name = value);
            AssignItems(dict, RetrieveContainers(lang, prefix + "description"), (item, value) => item.Description = value);
            AssignItems(dict, RetrieveContainers(lang, prefix + "knowledge"), (item, value) => item.Knowledge = value);
            return dict;
        }

        static Dictionary<string, Conversation> ParseConversations(Language lang)
        {
            var dict = new Dictionary<string, Conversation>();
            var containers = RetrieveContainers(lang, "Conversation");
            foreach (var container in containers)
            {
                if (container == null)
                    continue;
                var keys = container.Content.Keys.Where(id => !container.Content[id].Equals("(dummyText)")).Select(s => int.Parse(s)).ToArray();
                Array.Sort(keys);
                if (keys.Length == 0)
                    continue;
                for (var i = 0; i < keys.Length;)
                {
                    var id = keys[i];
                    var prevId = id;
                    var builder = new StringBuilder();
                    builder.Append(container.Content[keys[i].ToString()]);
                    i++;
                    for (; i < keys.Length && keys[i] == prevId + 1; i++)
                    {
                        prevId++;
                        builder.Append('\n');
                        builder.Append(container.Content[keys[i].ToString()]);
                    }
                    var conversation = new Conversation
                    {
                        Id = id.ToString(),
                        Text = builder.ToString()
                    };
                    var dlcIndex = container.Name.IndexOf("_dlc", StringComparison.Ordinal);
                    if (dlcIndex != -1)
                        conversation.Dlc = int.Parse(container.Name[dlcIndex + "_dlc".Length].ToString());
                    dict.Add(conversation.Id, conversation);
                }
            }
            return dict;
        }

        static void ExtractJson()
        {
            var ds3raw = JSONHelper.Deserialize<DarkSouls3Text>(File.ReadAllText("ds3raw.json", new UTF8Encoding(false)));
            foreach (var langIt in ds3raw.Languages)
            {
                var lang = langIt.Value;
                lang.Accessory = ParseGenericItems(lang, "Accessories ");
                lang.Armor = ParseGenericItems(lang, "Armor ");
                lang.Item = ParseGenericItems(lang, "Item ");
                lang.Magic = ParseGenericItems(lang, "Magic ");
                lang.Weapon = ParseGenericItems(lang, "Weapon ");
                lang.Conversations = ParseConversations(lang);
            }
            File.WriteAllText("ds3.json", JSONHelper.Serialize(ds3raw), new UTF8Encoding(false));
        }

        static void Main(string[] args)
        {
            //Console.OutputEncoding = System.Text.Encoding.Unicode;
            ExtractJson();
            Console.WriteLine("done");
        }
    }
}
