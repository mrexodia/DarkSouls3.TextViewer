using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace Structures
{
    [DataContract]
    public class GenericItem
    {
        [DataMember(Name = "id")]
        public string Id;

        [DataMember(Name = "name")]
        public string Name = "";

        [DataMember(Name = "description")]
        public string Description = "";

        [DataMember(Name = "knowledge")]
        public string Knowledge = "";

        [DataMember(Name = "dlc")]
        public int Dlc = 0;
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
}
