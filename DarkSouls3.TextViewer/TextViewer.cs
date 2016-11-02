using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
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
            LoadMatisseProFont();

            for (var i = 0; i < checkedListBoxItems.Items.Count; i++)
                checkedListBoxItems.SetItemChecked(i, true);

            loadData("ds3.json");
        }

        void listBoxContainerContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (ContainerContent)listBoxContainerContent.SelectedItem;
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

        void listBoxContainers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var container = (Container) listBoxContainers.SelectedItem;
            var data = new List<ContainerContent>();
            listBoxContainerContent.DataSource =
                container.Content.Select(it => new ContainerContent(it.Key, it.Value)).ToArray();
        }

        void listBoxConversations_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (Conversation)listBoxConversations.SelectedItem;
            var template = @"
<head>
  <style>
    body {{ font: normal 20px 'FOT-Matisse ProN M'; }}
    .sub {{ font-size: 75% }}
  </style>
</head>
<body>
  <h1>{0}</h1>
  <p>{1}</p>
  <p class='sub'>DLC: {2}<p>
</body>";
            webBrowserConversation.DocumentText = string.Format(template,
                item.Id,
                EscapeHtml(item.Text),
                item.Dlc);
        }

        void DarkSouls3TextViewer_Load(object sender, EventArgs e)
        {
            listBoxConversations.Font = new Font("FOT-Matisse ProN M", 8.25f);
        }

        private void LoadMatisseProFont()
        {
            var myFonts = new PrivateFontCollection();
            myFonts.AddFontFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FOT-MatissePro-DB.otf"));
        }

        string EscapeHtml(string s)
        {
            return s.Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\"", "&quot;")
                .Replace("'", "	&apos;")
                .Replace("\n", "<br>");
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

        void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (ViewerItem)listBoxItems.SelectedItem;
            var template = @"
<head>
  <style>
    body {{ font: normal 20px 'FOT-Matisse ProN M'; }}
    .sub {{ font-size: 75% }}
  </style>
</head>
<body>
  <h1>{0}</h1>
  <h2>{1}</h2>
  <p>{2}</p>
  <p class='sub'>ID: {3}, DLC: {4}, Parent: {5}</p>
</body>";
            webBrowserItem.DocumentText = string.Format(template,
                item,
                EscapeHtml(item.Item.Description),
                EscapeHtml(item.Item.Knowledge),
                item.Item.Id,
                item.Item.Dlc,
                item.Parent);
        }

        void checkedListBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateItemList();
        }

        void refreshLists()
        {
            updateItemList();
            updateConversationList();
            updateContainerList();
        }

        void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lang = comboBoxLanguage.SelectedItem.ToString();
            refreshLists();
        }

        void updateItemList()
        {
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
            listBoxItems.DataSource = items.OrderBy(item => item.Item.Name).ToArray();
        }

        void updateConversationList()
        {
            var lang = _ds3.Languages[_lang];
            listBoxConversations.DataSource = lang.Conversations.Values.ToArray();
        }

        void updateContainerList()
        {
            var lang = _ds3.Languages[_lang];
            listBoxContainers.DataSource = lang.Containers.Values.ToArray();
        }

        private bool loadData(string filename)
        {
            try
            {
                _ds3 = JSONHelper.Deserialize<DarkSouls3Text>(File.ReadAllText(filename, new UTF8Encoding(false)));
                tabControlMain.Enabled = true;
            }
            catch
            {
                tabControlMain.Enabled = false;
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
    }
}
