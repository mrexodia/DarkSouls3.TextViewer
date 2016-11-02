using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace DarkSouls3.Structures
{
    [DataContract]
    public class GenericItem
    {
        [DataMember(Name = "id", Order = 0)]
        public string Id;

        [DataMember(Name = "dlc", Order = 1)]
        public int Dlc = 0;

        [DataMember(Name = "name", Order = 2)]
        public string Name = "";

        [DataMember(Name = "description", Order = 3)]
        public string Description = "";

        [DataMember(Name = "knowledge", Order = 4)]
        public string Knowledge = "";

        public override string ToString()
        {
            return Name.Length == 0 ? Id : Name;
        }
    }

    [DataContract]
    public class Container
    {
        [DataMember(Name = "name")]
        public string Name;

        [DataMember(Name = "content")]
        public Dictionary<string, string> Content = new Dictionary<string, string>();
    }

    [DataContract]
    public class Conversation
    {
        [DataMember(Name = "id")]
        public string Id;

        [DataMember(Name = "text")]
        public string Text;

        [DataMember(Name = "dlc")]
        public int Dlc = 0;

        public override string ToString()
        {
            return Id;
        }
    }

    [DataContract]
    public class Language
    {
        [DataMember(Name = "accessory")]
        public Dictionary<string, GenericItem> Accessory = new Dictionary<string, GenericItem>();

        [DataMember(Name = "armor")]
        public Dictionary<string, GenericItem> Armor = new Dictionary<string, GenericItem>();

        [DataMember(Name = "item")]
        public Dictionary<string, GenericItem> Item = new Dictionary<string, GenericItem>();

        [DataMember(Name = "magic")]
        public Dictionary<string, GenericItem> Magic = new Dictionary<string, GenericItem>();

        [DataMember(Name = "weapon")]
        public Dictionary<string, GenericItem> Weapon = new Dictionary<string, GenericItem>();

        [DataMember(Name = "conversations")]
        public Dictionary<string, Conversation> Conversations = new Dictionary<string, Conversation>();

        [DataMember(Name = "containers")]
        public Dictionary<string, Container> Containers = new Dictionary<string, Container>();
    }

    [DataContract]
    public class DarkSouls3Text
    {
        [DataMember(Name = "languages")]
        public Dictionary<string, Language> Languages = new Dictionary<string, Language>();
    }

    public static class JSONHelper
    {
        public static string Serialize<T>(T obj)
        {
            var serializer = new DataContractJsonSerializer(obj.GetType(), new DataContractJsonSerializerSettings
            {
                UseSimpleDictionaryFormat = true
            });
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, obj);
            string retVal = Encoding.UTF8.GetString(ms.ToArray());
            ms.Dispose();
            return retVal;
        }

        public static T Deserialize<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            var serializer = new DataContractJsonSerializer(obj.GetType(), new DataContractJsonSerializerSettings
            {
                UseSimpleDictionaryFormat = true
            });
            obj = (T)serializer.ReadObject(ms);
            ms.Close();
            ms.Dispose();
            return obj;
        }
    }
}
