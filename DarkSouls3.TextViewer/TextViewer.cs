using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DarkSouls3.Structures;

namespace DarkSouls3.TextViewer
{
    public partial class DarkSouls3TextViewer : Form
    {
        private DarkSouls3Text _ds3;
        private string _lang;
        private ExpressionParser _filter;
        private CultureInfo _culture;

        public DarkSouls3TextViewer()
        {
            InitializeComponent();
            Load += DarkSouls3TextViewer_Load;
            comboBoxLanguage.SelectedIndexChanged += comboBoxLanguage_SelectedIndexChanged;
            checkedListBoxItems.SelectedIndexChanged += checkedListBoxItems_SelectedIndexChanged;
            listBoxItems.SelectedIndexChanged += listBoxItems_SelectedIndexChanged;
            listBoxConversations.SelectedIndexChanged += listBoxConversations_SelectedIndexChanged;
            listBoxContainers.SelectedIndexChanged += listBoxContainers_SelectedIndexChanged;
            listBoxContainerContent.SelectedIndexChanged += listBoxContainerContent_SelectedIndexChanged;
            AcceptButton = buttonApply;
            try
            {
                LoadMatisseProFont();
            }
            catch
            {
            }

            for (var i = 0; i < checkedListBoxItems.Items.Count; i++)
                checkedListBoxItems.SetItemChecked(i, true);

            loadData("ds3.json");
        }

        void DarkSouls3TextViewer_Load(object sender, EventArgs e)
        {
            listBoxConversations.Font = new Font("FOT-Matisse ProN M", 8.25f);
        }

        CultureInfo ToCulture(string dsLang)
        {
            if (dsLang.Length == 5)
            {
                try
                {
                    return CultureInfo.GetCultureInfo(dsLang.Substring(0, 2) + "-" + dsLang.Substring(3, 2));
                }
                catch
                {
                    return CultureInfo.CurrentCulture;
                }
            }
            return CultureInfo.CurrentCulture;
        }

        void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lang = comboBoxLanguage.SelectedItem.ToString();
            _culture = ToCulture(_lang);
            refreshLists();
        }

        void checkedListBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateItemList();
        }

        void listBoxContainers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var container = (Container) listBoxContainers.SelectedItem;
            var data = new List<ContainerContent>();
            try
            {
                listBoxContainerContent.DataSource =
                    container.Content.Where(MatchesFilter)
                        .Select(it => new ContainerContent(it.Key, it.Value))
                        .ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter error");
            }
        }

        private void LoadMatisseProFont()
        {
            var fontFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FOT-MatissePro-DB.otf");
            if (!File.Exists(fontFile))
                return;
            var myFonts = new PrivateFontCollection();
            myFonts.AddFontFile(fontFile);
        }

        void refreshLists()
        {
            updateItemList();
            updateConversationList();
            updateContainerList();
        }

        void updateItemList()
        {
            webBrowserItem.DocumentText = "";
            var items = new List<ViewerItem>();
            var lang = _ds3.Languages[_lang];
            foreach (var item in checkedListBoxItems.CheckedItems)
            {
                switch (item.ToString())
                {
                    case "Accessory":
                        items.AddRange(lang.Accessory.Values.Select(i => new ViewerItem("Accessory", i)));
                        break;
                    case "Armor":
                        items.AddRange(lang.Armor.Values.Select(i => new ViewerItem("Armor", i)));
                        break;
                    case "Item":
                        items.AddRange(lang.Item.Values.Select(i => new ViewerItem("Item", i)));
                        break;
                    case "Magic":
                        items.AddRange(lang.Magic.Values.Select(i => new ViewerItem("Magic", i)));
                        break;
                    case "Weapon":
                        items.AddRange(lang.Weapon.Values.Select(i => new ViewerItem("Weapon", i)));
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            try
            {
                listBoxItems.DataSource = items.Where(MatchesFilter).OrderBy(item => item.Item.Name).ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter error");
            }
        }

        void updateConversationList()
        {
            webBrowserConversation.DocumentText = "";
            var lang = _ds3.Languages[_lang];
            try
            {
                listBoxConversations.DataSource = lang.Conversations.Values.Where(MatchesFilter).ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter error");
            }
        }

        void updateContainerList()
        {
            webBrowserContainer.DocumentText = "";
            var lang = _ds3.Languages[_lang];
            listBoxContainerContent.DataSource = new object[0];
            try
            {
                listBoxContainers.DataSource = lang.Containers.Values.Where(MatchesFilter).ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter error");
            }
        }

        string EscapeHtml(string s)
        {
            return s.Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\"", "&quot;")
                .Replace("\n", "<br>");
        }

        void listBoxContainerContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (ContainerContent) listBoxContainerContent.SelectedItem;
            var template = @"
<head>
  <style>
    body {{ font: normal 20px 'FOT-Matisse ProN M'; }}
  </style>
</head>
<body>
  <h1>{0}</h1>
  <p>{1}</p>
</body>";
            webBrowserContainer.DocumentText = string.Format(template,
                item.Id,
                EscapeHtml(item.Text));
        }

        void listBoxConversations_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (Conversation) listBoxConversations.SelectedItem;
            var template = @"
<head>
  <style>
    body {{ font: normal 20px 'FOT-Matisse ProN M'; }}
    .sub {{ font-size: 65% }}
  </style>
</head>
<body>
  <h1>{0}</h1>
  <p>{1}</p>
  <p class='sub'>{{{0}}} dlc{2}<p>
</body>";
            webBrowserConversation.DocumentText = string.Format(template,
                item.Id,
                EscapeHtml(item.Text),
                item.Dlc);
        }

        void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (ViewerItem) listBoxItems.SelectedItem;
            var template = @"
<head>
  <style>
    body {{ font: normal 20px 'FOT-Matisse ProN M'; }}
    .sub {{ font-size: 65% }}
  </style>
</head>
<body>
  <h1>{0}</h1>
  <h2>{1}</h2>
  <p>{2}</p>
  <p class='sub'>{{{3}}} {{{4}}} dlc{5}</p>
</body>";
            webBrowserItem.DocumentText = string.Format(template,
                item,
                EscapeHtml(item.Item.Description),
                EscapeHtml(item.Item.Knowledge),
                item.Parent,
                item.Item.Id,
                item.Item.Dlc);
        }

        private void enableControls(bool enabled)
        {
            tabControlMain.Enabled = enabled;
            comboBoxLanguage.Enabled = enabled;
            textBoxFilter.Enabled = enabled;
            buttonApply.Enabled = enabled;
            buttonHelp.Enabled = enabled;
        }

        private bool loadData(string filename)
        {
            try
            {
                _ds3 = JSONHelper.Deserialize<DarkSouls3Text>(File.ReadAllText(filename, new UTF8Encoding(false)));
                enableControls(true);
            }
            catch
            {
                enableControls(false);
                return false;
            }
            comboBoxLanguage.Items.AddRange(_ds3.Languages.Keys.ToArray());
            if (comboBoxLanguage.Items.Count > 1)
                comboBoxLanguage.SelectedIndex = 1; //engUS
            return true;
        }

        private void buttonLoadData_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "JSON Files (*.json)|*.json",
                FileName = "ds3.json",
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory,
                Title = "Select JSON"
            };
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            if (loadData(dialog.FileName))
                MessageBox.Show("Data loaded!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to load data...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        bool MatchesFilter(string text, string filter)
        {
            return _culture.CompareInfo.IndexOf(text, filter, CompareOptions.IgnoreCase) >= 0;
        }

        bool MatchesFilter(string text)
        {
            if (_filter == null)
                return true;
            return _filter.Calculate(filter => MatchesFilter(text, filter));
        }

        bool MatchesFilter(GenericItem item, string parent = "")
        {
            var builder = new StringBuilder();
            if (parent.Length > 0)
                builder.AppendFormat("{{{0}}}", parent);
            builder.AppendFormat("{{{0}}}", item.Id);
            builder.AppendFormat("dlc{0}", item.Dlc);
            builder.AppendLine();
            builder.Append(item.Name.Replace("\n", " "));
            builder.Append(item.Description.Replace("\n", " "));
            builder.Append(item.Knowledge.Replace("\n", " "));
            return MatchesFilter(builder.ToString());
        }

        bool MatchesFilter(ViewerItem item)
        {
            return MatchesFilter(item.Item, item.Parent);
        }

        bool MatchesFilter(Conversation conversation)
        {
            var builder = new StringBuilder();
            builder.AppendFormat("{{{0}}}", conversation.Id);
            builder.AppendFormat("dlc{0}", conversation.Dlc);
            builder.AppendLine();
            builder.Append(conversation.Text.Replace("\n", " "));
            return MatchesFilter(builder.ToString());
        }

        bool MatchesFilter(KeyValuePair<string, string> it)
        {
            var builder = new StringBuilder();
            builder.AppendFormat("{{{0}}}", it.Key);
            builder.AppendLine();
            builder.Append(it.Value.Replace("\n", " "));
            return MatchesFilter(builder.ToString());
        }

        bool MatchesFilter(Container container)
        {
            foreach (var c in container.Content)
                if (MatchesFilter(c))
                    return true;
            return false;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            try
            {
                _filter = new ExpressionParser(textBoxFilter.Text);
                _filter.Calculate(str => true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid filter!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            refreshLists();
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Dark Souls 3 Text Viewer
This tool helps you view all in-game text of Dark Souls 3.

Filters
You can use filters to find relevant information. Text
is compared case-insensitive and you can combine
multiple filters with operators & (AND) | (OR) ~ (NOT).

- Identifiers can be found with '{id}'
- DLC version can be found with 'dlcN'
- Item type can be found with '{type}'

Operators are evaluated in the following order:

1. Parentheses
2. NOT
3. AND
4. OR

Examples
Filter: aldrich|deep
Effect: Everything containing 'aldrich' or 'deep'

Filter: god&swamp
Effect: Everything containing 'god' and 'swamp'

Filter: aldrich&deep|children
Effect: With braces: aldrich&(deep|children)

Filter: {1200}
Effect: Matches text with ID 1200

Filter: magic&~{Magic}
Effect: All non-{Magic} items containing 'magic'", "Help");
        }

        private void linkBonfireSideChat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.bonfireside.chat");
        }

        private void buttonGraph_Click(object sender, EventArgs e)
        {
            string[] blacklist;
            var file = "blacklist_" + comboBoxLanguage.SelectedItem + ".txt";
            try
            {
                blacklist = File.ReadAllLines(file);
            }
            catch
            {
                MessageBox.Show("Could not find " + file);
                blacklist = null;
            }
            var analysis = new Analysis(blacklist);
            var items = new List<string>();
            var builder = new StringBuilder();
            foreach (var it in listBoxItems.Items)
            {
                builder.Clear();
                var item = (ViewerItem) it;
                builder.AppendLine(item.Item.Name);
                builder.AppendLine(item.Item.Description);
                builder.AppendLine(item.Item.Knowledge);
                items.Add(builder.ToString().ToLower(_culture));
            }
            MessageBox.Show("Built items!");
            foreach (var item in items)
                analysis.AddText(item);
            MessageBox.Show("Built nodes!");
            analysis.Prepare();
            MessageBox.Show("Prepared matrix!");
            foreach(var item in items)
                analysis.ConnectText(item);
            MessageBox.Show("Connected items!");
            File.WriteAllText("graph.dot", analysis.ToDot());
            MessageBox.Show("Done!");
        }
    }

    public class ContainerContent
    {
        public string Id;
        public string Text;

        public ContainerContent(string id, string text)
        {
            Id = id;
            Text = text;
        }

        public override string ToString()
        {
            var split = Text.Split('\n')[0].Split(' ');
            var quote = new StringBuilder();
            quote.Append(split[0]);
            for (var i = 1; i < split.Length && quote.Length < 20; i++)
            {
                quote.Append(' ');
                quote.Append(split[i]);
            }
            if (quote.Length < Text.Length && !quote.ToString().EndsWith("..."))
                quote.Append("...");
            return string.Format("{0} \"{1}\"", Id, quote);
        }
    }

    public class ViewerItem
    {
        public string Parent;
        public GenericItem Item;

        public ViewerItem(string parent, GenericItem item)
        {
            Parent = parent;
            Item = item;
        }

        public override string ToString()
        {
            return Item.ToString();
        }
    }
}
