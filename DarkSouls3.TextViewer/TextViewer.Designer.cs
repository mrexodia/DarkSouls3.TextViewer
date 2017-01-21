namespace DarkSouls3.TextViewer
{
    partial class DarkSouls3TextViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLoadData = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageItems = new System.Windows.Forms.TabPage();
            this.splitContainerItems = new System.Windows.Forms.SplitContainer();
            this.checkedListBoxItems = new System.Windows.Forms.CheckedListBox();
            this.listBoxItems = new System.Windows.Forms.ListBox();
            this.webBrowserItem = new System.Windows.Forms.WebBrowser();
            this.tabPageConversations = new System.Windows.Forms.TabPage();
            this.splitContainerConversations = new System.Windows.Forms.SplitContainer();
            this.listBoxConversations = new System.Windows.Forms.ListBox();
            this.webBrowserConversation = new System.Windows.Forms.WebBrowser();
            this.tabPageContainers = new System.Windows.Forms.TabPage();
            this.splitContainerContainers = new System.Windows.Forms.SplitContainer();
            this.splitContainerContainerLists = new System.Windows.Forms.SplitContainer();
            this.listBoxContainers = new System.Windows.Forms.ListBox();
            this.listBoxContainerContent = new System.Windows.Forms.ListBox();
            this.webBrowserContainer = new System.Windows.Forms.WebBrowser();
            this.tabPageAnalysis = new System.Windows.Forms.TabPage();
            this.linkLabelGephi = new System.Windows.Forms.LinkLabel();
            this.buttonGraph = new System.Windows.Forms.Button();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.labelFilter = new System.Windows.Forms.Label();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.linkBonfireSideChat = new System.Windows.Forms.LinkLabel();
            this.linkLabelCreatedBy = new System.Windows.Forms.LinkLabel();
            this.tabControlMain.SuspendLayout();
            this.tabPageItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerItems)).BeginInit();
            this.splitContainerItems.Panel1.SuspendLayout();
            this.splitContainerItems.Panel2.SuspendLayout();
            this.splitContainerItems.SuspendLayout();
            this.tabPageConversations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerConversations)).BeginInit();
            this.splitContainerConversations.Panel1.SuspendLayout();
            this.splitContainerConversations.Panel2.SuspendLayout();
            this.splitContainerConversations.SuspendLayout();
            this.tabPageContainers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerContainers)).BeginInit();
            this.splitContainerContainers.Panel1.SuspendLayout();
            this.splitContainerContainers.Panel2.SuspendLayout();
            this.splitContainerContainers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerContainerLists)).BeginInit();
            this.splitContainerContainerLists.Panel1.SuspendLayout();
            this.splitContainerContainerLists.Panel2.SuspendLayout();
            this.splitContainerContainerLists.SuspendLayout();
            this.tabPageAnalysis.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLoadData
            // 
            this.buttonLoadData.Location = new System.Drawing.Point(12, 12);
            this.buttonLoadData.Name = "buttonLoadData";
            this.buttonLoadData.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadData.TabIndex = 0;
            this.buttonLoadData.Text = "Load data";
            this.buttonLoadData.UseVisualStyleBackColor = true;
            this.buttonLoadData.Click += new System.EventHandler(this.buttonLoadData_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageItems);
            this.tabControlMain.Controls.Add(this.tabPageConversations);
            this.tabControlMain.Controls.Add(this.tabPageContainers);
            this.tabControlMain.Controls.Add(this.tabPageAnalysis);
            this.tabControlMain.Location = new System.Drawing.Point(12, 41);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(902, 420);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabPageItems
            // 
            this.tabPageItems.Controls.Add(this.splitContainerItems);
            this.tabPageItems.Location = new System.Drawing.Point(4, 22);
            this.tabPageItems.Name = "tabPageItems";
            this.tabPageItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageItems.Size = new System.Drawing.Size(894, 394);
            this.tabPageItems.TabIndex = 0;
            this.tabPageItems.Text = "Items";
            this.tabPageItems.UseVisualStyleBackColor = true;
            // 
            // splitContainerItems
            // 
            this.splitContainerItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerItems.Location = new System.Drawing.Point(0, 0);
            this.splitContainerItems.Name = "splitContainerItems";
            // 
            // splitContainerItems.Panel1
            // 
            this.splitContainerItems.Panel1.Controls.Add(this.checkedListBoxItems);
            this.splitContainerItems.Panel1.Controls.Add(this.listBoxItems);
            // 
            // splitContainerItems.Panel2
            // 
            this.splitContainerItems.Panel2.Controls.Add(this.webBrowserItem);
            this.splitContainerItems.Size = new System.Drawing.Size(894, 394);
            this.splitContainerItems.SplitterDistance = 250;
            this.splitContainerItems.TabIndex = 0;
            // 
            // checkedListBoxItems
            // 
            this.checkedListBoxItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxItems.CheckOnClick = true;
            this.checkedListBoxItems.FormattingEnabled = true;
            this.checkedListBoxItems.Items.AddRange(new object[] {
            "Accessory",
            "Armor",
            "Item",
            "Magic",
            "Weapon"});
            this.checkedListBoxItems.Location = new System.Drawing.Point(6, 6);
            this.checkedListBoxItems.Name = "checkedListBoxItems";
            this.checkedListBoxItems.Size = new System.Drawing.Size(241, 79);
            this.checkedListBoxItems.TabIndex = 2;
            // 
            // listBoxItems
            // 
            this.listBoxItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxItems.FormattingEnabled = true;
            this.listBoxItems.HorizontalScrollbar = true;
            this.listBoxItems.Location = new System.Drawing.Point(6, 85);
            this.listBoxItems.Name = "listBoxItems";
            this.listBoxItems.Size = new System.Drawing.Size(241, 303);
            this.listBoxItems.TabIndex = 1;
            // 
            // webBrowserItem
            // 
            this.webBrowserItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserItem.Location = new System.Drawing.Point(3, 0);
            this.webBrowserItem.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserItem.Name = "webBrowserItem";
            this.webBrowserItem.Size = new System.Drawing.Size(637, 394);
            this.webBrowserItem.TabIndex = 0;
            // 
            // tabPageConversations
            // 
            this.tabPageConversations.Controls.Add(this.splitContainerConversations);
            this.tabPageConversations.Location = new System.Drawing.Point(4, 22);
            this.tabPageConversations.Name = "tabPageConversations";
            this.tabPageConversations.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConversations.Size = new System.Drawing.Size(894, 394);
            this.tabPageConversations.TabIndex = 1;
            this.tabPageConversations.Text = "Conversations";
            this.tabPageConversations.UseVisualStyleBackColor = true;
            // 
            // splitContainerConversations
            // 
            this.splitContainerConversations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerConversations.Location = new System.Drawing.Point(0, 0);
            this.splitContainerConversations.Name = "splitContainerConversations";
            // 
            // splitContainerConversations.Panel1
            // 
            this.splitContainerConversations.Panel1.Controls.Add(this.listBoxConversations);
            // 
            // splitContainerConversations.Panel2
            // 
            this.splitContainerConversations.Panel2.Controls.Add(this.webBrowserConversation);
            this.splitContainerConversations.Size = new System.Drawing.Size(894, 394);
            this.splitContainerConversations.SplitterDistance = 250;
            this.splitContainerConversations.TabIndex = 0;
            // 
            // listBoxConversations
            // 
            this.listBoxConversations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxConversations.FormattingEnabled = true;
            this.listBoxConversations.HorizontalScrollbar = true;
            this.listBoxConversations.Location = new System.Drawing.Point(6, 6);
            this.listBoxConversations.Name = "listBoxConversations";
            this.listBoxConversations.Size = new System.Drawing.Size(241, 381);
            this.listBoxConversations.TabIndex = 0;
            // 
            // webBrowserConversation
            // 
            this.webBrowserConversation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserConversation.Location = new System.Drawing.Point(3, 0);
            this.webBrowserConversation.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserConversation.Name = "webBrowserConversation";
            this.webBrowserConversation.Size = new System.Drawing.Size(637, 394);
            this.webBrowserConversation.TabIndex = 0;
            // 
            // tabPageContainers
            // 
            this.tabPageContainers.Controls.Add(this.splitContainerContainers);
            this.tabPageContainers.Location = new System.Drawing.Point(4, 22);
            this.tabPageContainers.Name = "tabPageContainers";
            this.tabPageContainers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageContainers.Size = new System.Drawing.Size(894, 394);
            this.tabPageContainers.TabIndex = 2;
            this.tabPageContainers.Text = "Containers";
            this.tabPageContainers.UseVisualStyleBackColor = true;
            // 
            // splitContainerContainers
            // 
            this.splitContainerContainers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerContainers.Location = new System.Drawing.Point(3, 3);
            this.splitContainerContainers.Name = "splitContainerContainers";
            // 
            // splitContainerContainers.Panel1
            // 
            this.splitContainerContainers.Panel1.Controls.Add(this.splitContainerContainerLists);
            // 
            // splitContainerContainers.Panel2
            // 
            this.splitContainerContainers.Panel2.Controls.Add(this.webBrowserContainer);
            this.splitContainerContainers.Size = new System.Drawing.Size(888, 388);
            this.splitContainerContainers.SplitterDistance = 416;
            this.splitContainerContainers.TabIndex = 0;
            // 
            // splitContainerContainerLists
            // 
            this.splitContainerContainerLists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerContainerLists.Location = new System.Drawing.Point(0, 0);
            this.splitContainerContainerLists.Name = "splitContainerContainerLists";
            // 
            // splitContainerContainerLists.Panel1
            // 
            this.splitContainerContainerLists.Panel1.Controls.Add(this.listBoxContainers);
            // 
            // splitContainerContainerLists.Panel2
            // 
            this.splitContainerContainerLists.Panel2.Controls.Add(this.listBoxContainerContent);
            this.splitContainerContainerLists.Size = new System.Drawing.Size(416, 388);
            this.splitContainerContainerLists.SplitterDistance = 202;
            this.splitContainerContainerLists.TabIndex = 0;
            // 
            // listBoxContainers
            // 
            this.listBoxContainers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxContainers.FormattingEnabled = true;
            this.listBoxContainers.HorizontalScrollbar = true;
            this.listBoxContainers.Location = new System.Drawing.Point(3, 3);
            this.listBoxContainers.Name = "listBoxContainers";
            this.listBoxContainers.Size = new System.Drawing.Size(196, 381);
            this.listBoxContainers.TabIndex = 0;
            // 
            // listBoxContainerContent
            // 
            this.listBoxContainerContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxContainerContent.FormattingEnabled = true;
            this.listBoxContainerContent.Location = new System.Drawing.Point(3, 3);
            this.listBoxContainerContent.Name = "listBoxContainerContent";
            this.listBoxContainerContent.Size = new System.Drawing.Size(204, 381);
            this.listBoxContainerContent.TabIndex = 0;
            // 
            // webBrowserContainer
            // 
            this.webBrowserContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserContainer.Location = new System.Drawing.Point(0, 0);
            this.webBrowserContainer.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserContainer.Name = "webBrowserContainer";
            this.webBrowserContainer.Size = new System.Drawing.Size(468, 388);
            this.webBrowserContainer.TabIndex = 0;
            // 
            // tabPageAnalysis
            // 
            this.tabPageAnalysis.Controls.Add(this.linkLabelGephi);
            this.tabPageAnalysis.Controls.Add(this.buttonGraph);
            this.tabPageAnalysis.Location = new System.Drawing.Point(4, 22);
            this.tabPageAnalysis.Name = "tabPageAnalysis";
            this.tabPageAnalysis.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAnalysis.Size = new System.Drawing.Size(894, 394);
            this.tabPageAnalysis.TabIndex = 3;
            this.tabPageAnalysis.Text = "Analysis";
            this.tabPageAnalysis.UseVisualStyleBackColor = true;
            // 
            // linkLabelGephi
            // 
            this.linkLabelGephi.AutoSize = true;
            this.linkLabelGephi.Location = new System.Drawing.Point(88, 12);
            this.linkLabelGephi.Name = "linkLabelGephi";
            this.linkLabelGephi.Size = new System.Drawing.Size(201, 13);
            this.linkLabelGephi.TabIndex = 1;
            this.linkLabelGephi.TabStop = true;
            this.linkLabelGephi.Text = "You can use Gephi to visualize graph.dot";
            this.linkLabelGephi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGephi_LinkClicked);
            // 
            // buttonGraph
            // 
            this.buttonGraph.Location = new System.Drawing.Point(7, 7);
            this.buttonGraph.Name = "buttonGraph";
            this.buttonGraph.Size = new System.Drawing.Size(75, 23);
            this.buttonGraph.TabIndex = 0;
            this.buttonGraph.Text = "Graph";
            this.buttonGraph.UseVisualStyleBackColor = true;
            this.buttonGraph.Click += new System.EventHandler(this.buttonGraph_Click);
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(157, 14);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(58, 21);
            this.comboBoxLanguage.TabIndex = 2;
            // 
            // labelLanguage
            // 
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Location = new System.Drawing.Point(93, 17);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(58, 13);
            this.labelLanguage.TabIndex = 3;
            this.labelLanguage.Text = "Language:";
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(259, 14);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(272, 20);
            this.textBoxFilter.TabIndex = 4;
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Location = new System.Drawing.Point(221, 17);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(32, 13);
            this.labelFilter.TabIndex = 5;
            this.labelFilter.Text = "Filter:";
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(537, 12);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 6;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(618, 12);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(75, 23);
            this.buttonHelp.TabIndex = 7;
            this.buttonHelp.Text = "Help!";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // linkBonfireSideChat
            // 
            this.linkBonfireSideChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkBonfireSideChat.AutoSize = true;
            this.linkBonfireSideChat.Location = new System.Drawing.Point(766, 9);
            this.linkBonfireSideChat.Name = "linkBonfireSideChat";
            this.linkBonfireSideChat.Size = new System.Drawing.Size(148, 13);
            this.linkBonfireSideChat.TabIndex = 8;
            this.linkBonfireSideChat.TabStop = true;
            this.linkBonfireSideChat.Text = "Dedicated to Bonfireside Chat";
            this.linkBonfireSideChat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBonfireSideChat_LinkClicked);
            // 
            // linkLabelCreatedBy
            // 
            this.linkLabelCreatedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelCreatedBy.AutoSize = true;
            this.linkLabelCreatedBy.Location = new System.Drawing.Point(780, 25);
            this.linkLabelCreatedBy.Name = "linkLabelCreatedBy";
            this.linkLabelCreatedBy.Size = new System.Drawing.Size(134, 13);
            this.linkLabelCreatedBy.TabIndex = 9;
            this.linkLabelCreatedBy.TabStop = true;
            this.linkLabelCreatedBy.Text = "Created by Duncan Ogilvie";
            this.linkLabelCreatedBy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCreatedBy_LinkClicked);
            // 
            // DarkSouls3TextViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 473);
            this.Controls.Add(this.linkLabelCreatedBy);
            this.Controls.Add(this.linkBonfireSideChat);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.labelFilter);
            this.Controls.Add(this.textBoxFilter);
            this.Controls.Add(this.labelLanguage);
            this.Controls.Add(this.comboBoxLanguage);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.buttonLoadData);
            this.Name = "DarkSouls3TextViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dark Souls 3 Text Viewer";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageItems.ResumeLayout(false);
            this.splitContainerItems.Panel1.ResumeLayout(false);
            this.splitContainerItems.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerItems)).EndInit();
            this.splitContainerItems.ResumeLayout(false);
            this.tabPageConversations.ResumeLayout(false);
            this.splitContainerConversations.Panel1.ResumeLayout(false);
            this.splitContainerConversations.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerConversations)).EndInit();
            this.splitContainerConversations.ResumeLayout(false);
            this.tabPageContainers.ResumeLayout(false);
            this.splitContainerContainers.Panel1.ResumeLayout(false);
            this.splitContainerContainers.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerContainers)).EndInit();
            this.splitContainerContainers.ResumeLayout(false);
            this.splitContainerContainerLists.Panel1.ResumeLayout(false);
            this.splitContainerContainerLists.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerContainerLists)).EndInit();
            this.splitContainerContainerLists.ResumeLayout(false);
            this.tabPageAnalysis.ResumeLayout(false);
            this.tabPageAnalysis.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadData;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageItems;
        private System.Windows.Forms.TabPage tabPageConversations;
        private System.Windows.Forms.TabPage tabPageContainers;
        private System.Windows.Forms.SplitContainer splitContainerItems;
        private System.Windows.Forms.ListBox listBoxItems;
        private System.Windows.Forms.WebBrowser webBrowserItem;
        private System.Windows.Forms.CheckedListBox checkedListBoxItems;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.SplitContainer splitContainerConversations;
        private System.Windows.Forms.ListBox listBoxConversations;
        private System.Windows.Forms.WebBrowser webBrowserConversation;
        private System.Windows.Forms.SplitContainer splitContainerContainers;
        private System.Windows.Forms.SplitContainer splitContainerContainerLists;
        private System.Windows.Forms.ListBox listBoxContainers;
        private System.Windows.Forms.ListBox listBoxContainerContent;
        private System.Windows.Forms.WebBrowser webBrowserContainer;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.LinkLabel linkBonfireSideChat;
        private System.Windows.Forms.TabPage tabPageAnalysis;
        private System.Windows.Forms.Button buttonGraph;
        private System.Windows.Forms.LinkLabel linkLabelCreatedBy;
        private System.Windows.Forms.LinkLabel linkLabelGephi;
    }
}

