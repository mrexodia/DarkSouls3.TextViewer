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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DarkSouls3TextViewer));
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
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.labelLanguage = new System.Windows.Forms.Label();
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
            this.tabPageContainers.Location = new System.Drawing.Point(4, 22);
            this.tabPageContainers.Name = "tabPageContainers";
            this.tabPageContainers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageContainers.Size = new System.Drawing.Size(894, 431);
            this.tabPageContainers.TabIndex = 2;
            this.tabPageContainers.Text = "Containers";
            this.tabPageContainers.UseVisualStyleBackColor = true;
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
            // DarkSouls3TextViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 473);
            this.Controls.Add(this.labelLanguage);
            this.Controls.Add(this.comboBoxLanguage);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.buttonLoadData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
    }
}

