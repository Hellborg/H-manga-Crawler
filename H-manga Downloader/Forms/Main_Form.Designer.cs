using System.ComponentModel;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace Crawler2._0.Forms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.tabcontrolMain = new System.Windows.Forms.TabControl();
            this.TabpageInfo = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ClearFilterButton = new System.Windows.Forms.Button();
            this.ApplyFilterButton = new System.Windows.Forms.Button();
            this.FilterCheckbox_downloaded = new System.Windows.Forms.CheckBox();
            this.groupBoxTags = new System.Windows.Forms.GroupBox();
            this.labelFilteredOut = new System.Windows.Forms.Label();
            this.FilterCheckbox_12 = new System.Windows.Forms.CheckBox();
            this.FilterCheckbox_11 = new System.Windows.Forms.CheckBox();
            this.FilterCheckbox_10 = new System.Windows.Forms.CheckBox();
            this.FilterCheckbox_9 = new System.Windows.Forms.CheckBox();
            this.FilterCheckbox_8 = new System.Windows.Forms.CheckBox();
            this.FilterCheckbox_7 = new System.Windows.Forms.CheckBox();
            this.FilterCheckbox_6 = new System.Windows.Forms.CheckBox();
            this.FilterCheckbox_5 = new System.Windows.Forms.CheckBox();
            this.FilterCheckbox_4 = new System.Windows.Forms.CheckBox();
            this.FilterCheckbox_3 = new System.Windows.Forms.CheckBox();
            this.FilterCheckbox_2 = new System.Windows.Forms.CheckBox();
            this.TagCheckbox_1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TextboxCustomFilter = new System.Windows.Forms.TextBox();
            this.numericFilterPageCount = new System.Windows.Forms.NumericUpDown();
            this.CheckboxFilterByPages = new System.Windows.Forms.CheckBox();
            this.TagListbox = new System.Windows.Forms.ListBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblTags = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.lblPages = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TabpageOptions = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.createSiteFolderCheckbox = new System.Windows.Forms.CheckBox();
            this.LabelExampleName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NamingSchemeTextbox = new System.Windows.Forms.TextBox();
            this.CreateSubfoldersCheckbox = new System.Windows.Forms.CheckBox();
            this.SelectFolderButton = new System.Windows.Forms.Button();
            this.SelectedPathTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveOptionsButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textboxRememberedFilter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericRetryTime = new System.Windows.Forms.NumericUpDown();
            this.SaveCoversCheckbox = new System.Windows.Forms.CheckBox();
            this.TabpageDownloads = new System.Windows.Forms.TabPage();
            this.TabcontrolDownloads = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ListviewCurrentDownloads = new System.Windows.Forms.ListView();
            this.NameColumn_1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusColumn_1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PercentageColumn_1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PagesColumn_1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ListviewCompletedDownloads = new System.Windows.Forms.ListView();
            this.NameColumn_3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusColumn_3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CompletedOnColumn_3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeColumn_3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextmenuMangalist = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolstripItemGotoGallery = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolstripItemDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextmenuTags = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TagToolstripFilterByThis = new System.Windows.Forms.ToolStripMenuItem();
            this.showMangasWithoutThisTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip_Main = new System.Windows.Forms.StatusStrip();
            this.ToolstripProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.ToolstripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ContextmenuCompletedDownloads = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemGoTo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenyItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.WebsiteDropdown = new System.Windows.Forms.ComboBox();
            this.ListviewMangas = new BrightIdeasSoftware.FastObjectListView();
            this.titleColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.pageColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tabcontrolMain.SuspendLayout();
            this.TabpageInfo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBoxTags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFilterPageCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.TabpageOptions.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRetryTime)).BeginInit();
            this.TabpageDownloads.SuspendLayout();
            this.TabcontrolDownloads.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.ContextmenuMangalist.SuspendLayout();
            this.ContextmenuTags.SuspendLayout();
            this.StatusStrip_Main.SuspendLayout();
            this.ContextmenuCompletedDownloads.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListviewMangas)).BeginInit();
            this.SuspendLayout();
            // 
            // DownloadButton
            // 
            this.DownloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DownloadButton.Location = new System.Drawing.Point(124, 27);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(202, 26);
            this.DownloadButton.TabIndex = 1;
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabcontrolMain
            // 
            this.tabcontrolMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabcontrolMain.Controls.Add(this.TabpageInfo);
            this.tabcontrolMain.Controls.Add(this.TabpageOptions);
            this.tabcontrolMain.Controls.Add(this.TabpageDownloads);
            this.tabcontrolMain.Location = new System.Drawing.Point(332, 27);
            this.tabcontrolMain.Name = "tabcontrolMain";
            this.tabcontrolMain.SelectedIndex = 0;
            this.tabcontrolMain.Size = new System.Drawing.Size(774, 634);
            this.tabcontrolMain.TabIndex = 4;
            // 
            // TabpageInfo
            // 
            this.TabpageInfo.Controls.Add(this.groupBox3);
            this.TabpageInfo.Controls.Add(this.TagListbox);
            this.TabpageInfo.Controls.Add(this.lblInfo);
            this.TabpageInfo.Controls.Add(this.lblTags);
            this.TabpageInfo.Controls.Add(this.lblLanguage);
            this.TabpageInfo.Controls.Add(this.lblPages);
            this.TabpageInfo.Controls.Add(this.lblTitle);
            this.TabpageInfo.Controls.Add(this.pictureBox1);
            this.TabpageInfo.Location = new System.Drawing.Point(4, 22);
            this.TabpageInfo.Name = "TabpageInfo";
            this.TabpageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.TabpageInfo.Size = new System.Drawing.Size(766, 608);
            this.TabpageInfo.TabIndex = 0;
            this.TabpageInfo.Text = "Information";
            this.TabpageInfo.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.ClearFilterButton);
            this.groupBox3.Controls.Add(this.ApplyFilterButton);
            this.groupBox3.Controls.Add(this.FilterCheckbox_downloaded);
            this.groupBox3.Controls.Add(this.groupBoxTags);
            this.groupBox3.Controls.Add(this.numericFilterPageCount);
            this.groupBox3.Controls.Add(this.CheckboxFilterByPages);
            this.groupBox3.Location = new System.Drawing.Point(9, 316);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(751, 286);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter";
            // 
            // ClearFilterButton
            // 
            this.ClearFilterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearFilterButton.Location = new System.Drawing.Point(563, 251);
            this.ClearFilterButton.Name = "ClearFilterButton";
            this.ClearFilterButton.Size = new System.Drawing.Size(88, 29);
            this.ClearFilterButton.TabIndex = 23;
            this.ClearFilterButton.Text = "Clear filter";
            this.ClearFilterButton.UseVisualStyleBackColor = true;
            this.ClearFilterButton.Click += new System.EventHandler(this.ClearFilterButton_Click);
            // 
            // ApplyFilterButton
            // 
            this.ApplyFilterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyFilterButton.Location = new System.Drawing.Point(657, 251);
            this.ApplyFilterButton.Name = "ApplyFilterButton";
            this.ApplyFilterButton.Size = new System.Drawing.Size(88, 29);
            this.ApplyFilterButton.TabIndex = 22;
            this.ApplyFilterButton.Text = "Apply filter";
            this.ApplyFilterButton.UseVisualStyleBackColor = true;
            this.ApplyFilterButton.Click += new System.EventHandler(this.ApplyFilterButton_Click);
            // 
            // FilterCheckbox_downloaded
            // 
            this.FilterCheckbox_downloaded.AutoSize = true;
            this.FilterCheckbox_downloaded.Location = new System.Drawing.Point(6, 251);
            this.FilterCheckbox_downloaded.Name = "FilterCheckbox_downloaded";
            this.FilterCheckbox_downloaded.Size = new System.Drawing.Size(199, 17);
            this.FilterCheckbox_downloaded.TabIndex = 21;
            this.FilterCheckbox_downloaded.Text = "Filter out already downloaded manga";
            this.FilterCheckbox_downloaded.UseVisualStyleBackColor = true;
            // 
            // groupBoxTags
            // 
            this.groupBoxTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTags.Controls.Add(this.labelFilteredOut);
            this.groupBoxTags.Controls.Add(this.FilterCheckbox_12);
            this.groupBoxTags.Controls.Add(this.FilterCheckbox_11);
            this.groupBoxTags.Controls.Add(this.FilterCheckbox_10);
            this.groupBoxTags.Controls.Add(this.FilterCheckbox_9);
            this.groupBoxTags.Controls.Add(this.FilterCheckbox_8);
            this.groupBoxTags.Controls.Add(this.FilterCheckbox_7);
            this.groupBoxTags.Controls.Add(this.FilterCheckbox_6);
            this.groupBoxTags.Controls.Add(this.FilterCheckbox_5);
            this.groupBoxTags.Controls.Add(this.FilterCheckbox_4);
            this.groupBoxTags.Controls.Add(this.FilterCheckbox_3);
            this.groupBoxTags.Controls.Add(this.FilterCheckbox_2);
            this.groupBoxTags.Controls.Add(this.TagCheckbox_1);
            this.groupBoxTags.Controls.Add(this.label5);
            this.groupBoxTags.Controls.Add(this.TextboxCustomFilter);
            this.groupBoxTags.Location = new System.Drawing.Point(6, 42);
            this.groupBoxTags.Name = "groupBoxTags";
            this.groupBoxTags.Size = new System.Drawing.Size(739, 203);
            this.groupBoxTags.TabIndex = 20;
            this.groupBoxTags.TabStop = false;
            this.groupBoxTags.Text = "Tags";
            // 
            // labelFilteredOut
            // 
            this.labelFilteredOut.AutoSize = true;
            this.labelFilteredOut.Location = new System.Drawing.Point(304, 180);
            this.labelFilteredOut.Name = "labelFilteredOut";
            this.labelFilteredOut.Size = new System.Drawing.Size(62, 13);
            this.labelFilteredOut.TabIndex = 17;
            this.labelFilteredOut.Text = "Filtered out ";
            // 
            // FilterCheckbox_12
            // 
            this.FilterCheckbox_12.AutoSize = true;
            this.FilterCheckbox_12.Location = new System.Drawing.Point(102, 134);
            this.FilterCheckbox_12.Name = "FilterCheckbox_12";
            this.FilterCheckbox_12.Size = new System.Drawing.Size(63, 17);
            this.FilterCheckbox_12.TabIndex = 16;
            this.FilterCheckbox_12.Text = "Lingerie";
            this.FilterCheckbox_12.ThreeState = true;
            this.FilterCheckbox_12.UseVisualStyleBackColor = true;
            // 
            // FilterCheckbox_11
            // 
            this.FilterCheckbox_11.AutoSize = true;
            this.FilterCheckbox_11.Location = new System.Drawing.Point(102, 111);
            this.FilterCheckbox_11.Name = "FilterCheckbox_11";
            this.FilterCheckbox_11.Size = new System.Drawing.Size(69, 17);
            this.FilterCheckbox_11.TabIndex = 15;
            this.FilterCheckbox_11.Text = "Pregnant";
            this.FilterCheckbox_11.ThreeState = true;
            this.FilterCheckbox_11.UseVisualStyleBackColor = true;
            // 
            // FilterCheckbox_10
            // 
            this.FilterCheckbox_10.AutoSize = true;
            this.FilterCheckbox_10.Location = new System.Drawing.Point(102, 88);
            this.FilterCheckbox_10.Name = "FilterCheckbox_10";
            this.FilterCheckbox_10.Size = new System.Drawing.Size(84, 17);
            this.FilterCheckbox_10.TabIndex = 14;
            this.FilterCheckbox_10.Text = "Uncensored";
            this.FilterCheckbox_10.ThreeState = true;
            this.FilterCheckbox_10.UseVisualStyleBackColor = true;
            // 
            // FilterCheckbox_9
            // 
            this.FilterCheckbox_9.AutoSize = true;
            this.FilterCheckbox_9.Location = new System.Drawing.Point(102, 65);
            this.FilterCheckbox_9.Name = "FilterCheckbox_9";
            this.FilterCheckbox_9.Size = new System.Drawing.Size(69, 17);
            this.FilterCheckbox_9.TabIndex = 13;
            this.FilterCheckbox_9.Text = "Bondage";
            this.FilterCheckbox_9.ThreeState = true;
            this.FilterCheckbox_9.UseVisualStyleBackColor = true;
            // 
            // FilterCheckbox_8
            // 
            this.FilterCheckbox_8.AutoSize = true;
            this.FilterCheckbox_8.Location = new System.Drawing.Point(102, 42);
            this.FilterCheckbox_8.Name = "FilterCheckbox_8";
            this.FilterCheckbox_8.Size = new System.Drawing.Size(87, 17);
            this.FilterCheckbox_8.TabIndex = 12;
            this.FilterCheckbox_8.Text = "Masturbation";
            this.FilterCheckbox_8.ThreeState = true;
            this.FilterCheckbox_8.UseVisualStyleBackColor = true;
            // 
            // FilterCheckbox_7
            // 
            this.FilterCheckbox_7.AutoSize = true;
            this.FilterCheckbox_7.Location = new System.Drawing.Point(102, 19);
            this.FilterCheckbox_7.Name = "FilterCheckbox_7";
            this.FilterCheckbox_7.Size = new System.Drawing.Size(60, 17);
            this.FilterCheckbox_7.TabIndex = 11;
            this.FilterCheckbox_7.Text = "English";
            this.FilterCheckbox_7.ThreeState = true;
            this.FilterCheckbox_7.UseVisualStyleBackColor = true;
            // 
            // FilterCheckbox_6
            // 
            this.FilterCheckbox_6.AutoSize = true;
            this.FilterCheckbox_6.Location = new System.Drawing.Point(6, 134);
            this.FilterCheckbox_6.Name = "FilterCheckbox_6";
            this.FilterCheckbox_6.Size = new System.Drawing.Size(47, 17);
            this.FilterCheckbox_6.TabIndex = 10;
            this.FilterCheckbox_6.Text = "Anal";
            this.FilterCheckbox_6.ThreeState = true;
            this.FilterCheckbox_6.UseVisualStyleBackColor = true;
            // 
            // FilterCheckbox_5
            // 
            this.FilterCheckbox_5.AutoSize = true;
            this.FilterCheckbox_5.Location = new System.Drawing.Point(6, 111);
            this.FilterCheckbox_5.Name = "FilterCheckbox_5";
            this.FilterCheckbox_5.Size = new System.Drawing.Size(50, 17);
            this.FilterCheckbox_5.TabIndex = 9;
            this.FilterCheckbox_5.Text = "MILF";
            this.FilterCheckbox_5.ThreeState = true;
            this.FilterCheckbox_5.UseVisualStyleBackColor = true;
            // 
            // FilterCheckbox_4
            // 
            this.FilterCheckbox_4.AutoSize = true;
            this.FilterCheckbox_4.Location = new System.Drawing.Point(6, 88);
            this.FilterCheckbox_4.Name = "FilterCheckbox_4";
            this.FilterCheckbox_4.Size = new System.Drawing.Size(44, 17);
            this.FilterCheckbox_4.TabIndex = 8;
            this.FilterCheckbox_4.Text = "Yuri";
            this.FilterCheckbox_4.ThreeState = true;
            this.FilterCheckbox_4.UseVisualStyleBackColor = true;
            // 
            // FilterCheckbox_3
            // 
            this.FilterCheckbox_3.AutoSize = true;
            this.FilterCheckbox_3.Location = new System.Drawing.Point(6, 65);
            this.FilterCheckbox_3.Name = "FilterCheckbox_3";
            this.FilterCheckbox_3.Size = new System.Drawing.Size(71, 17);
            this.FilterCheckbox_3.TabIndex = 7;
            this.FilterCheckbox_3.Text = "Groupsex";
            this.FilterCheckbox_3.ThreeState = true;
            this.FilterCheckbox_3.UseVisualStyleBackColor = true;
            // 
            // FilterCheckbox_2
            // 
            this.FilterCheckbox_2.AutoSize = true;
            this.FilterCheckbox_2.Location = new System.Drawing.Point(6, 42);
            this.FilterCheckbox_2.Name = "FilterCheckbox_2";
            this.FilterCheckbox_2.Size = new System.Drawing.Size(63, 17);
            this.FilterCheckbox_2.TabIndex = 6;
            this.FilterCheckbox_2.Text = "Blowjob";
            this.FilterCheckbox_2.ThreeState = true;
            this.FilterCheckbox_2.UseVisualStyleBackColor = true;
            // 
            // TagCheckbox_1
            // 
            this.TagCheckbox_1.AutoSize = true;
            this.TagCheckbox_1.Location = new System.Drawing.Point(6, 19);
            this.TagCheckbox_1.Name = "TagCheckbox_1";
            this.TagCheckbox_1.Size = new System.Drawing.Size(90, 17);
            this.TagCheckbox_1.TabIndex = 5;
            this.TagCheckbox_1.Text = "Large breasts";
            this.TagCheckbox_1.ThreeState = true;
            this.TagCheckbox_1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Custom filter. Separate with ;";
            // 
            // TextboxCustomFilter
            // 
            this.TextboxCustomFilter.Location = new System.Drawing.Point(6, 177);
            this.TextboxCustomFilter.Name = "TextboxCustomFilter";
            this.TextboxCustomFilter.Size = new System.Drawing.Size(274, 20);
            this.TextboxCustomFilter.TabIndex = 3;
            this.TextboxCustomFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextboxCustomFilter_KeyDown);
            // 
            // numericFilterPageCount
            // 
            this.numericFilterPageCount.Location = new System.Drawing.Point(190, 18);
            this.numericFilterPageCount.Name = "numericFilterPageCount";
            this.numericFilterPageCount.Size = new System.Drawing.Size(45, 20);
            this.numericFilterPageCount.TabIndex = 19;
            // 
            // CheckboxFilterByPages
            // 
            this.CheckboxFilterByPages.AutoSize = true;
            this.CheckboxFilterByPages.Location = new System.Drawing.Point(6, 19);
            this.CheckboxFilterByPages.Name = "CheckboxFilterByPages";
            this.CheckboxFilterByPages.Size = new System.Drawing.Size(274, 17);
            this.CheckboxFilterByPages.TabIndex = 18;
            this.CheckboxFilterByPages.Text = "Show only mangas with more than                   Pages";
            this.CheckboxFilterByPages.UseVisualStyleBackColor = true;
            // 
            // TagListbox
            // 
            this.TagListbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TagListbox.FormattingEnabled = true;
            this.TagListbox.Location = new System.Drawing.Point(302, 96);
            this.TagListbox.Name = "TagListbox";
            this.TagListbox.Size = new System.Drawing.Size(297, 195);
            this.TagListbox.TabIndex = 6;
            this.TagListbox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TagListbox_MouseUp);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(302, 297);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(35, 13);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = "label1";
            // 
            // lblTags
            // 
            this.lblTags.AutoSize = true;
            this.lblTags.Location = new System.Drawing.Point(302, 80);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(31, 13);
            this.lblTags.TabIndex = 4;
            this.lblTags.Text = "Tags";
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(302, 54);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(35, 13);
            this.lblLanguage.TabIndex = 3;
            this.lblLanguage.Text = "label1";
            this.lblLanguage.Visible = false;
            // 
            // lblPages
            // 
            this.lblPages.AutoSize = true;
            this.lblPages.Location = new System.Drawing.Point(302, 29);
            this.lblPages.Name = "lblPages";
            this.lblPages.Size = new System.Drawing.Size(35, 13);
            this.lblPages.TabIndex = 2;
            this.lblPages.Text = "label1";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(302, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(35, 13);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(9, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(287, 305);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // TabpageOptions
            // 
            this.TabpageOptions.Controls.Add(this.groupBox4);
            this.TabpageOptions.Controls.Add(this.groupBox2);
            this.TabpageOptions.Controls.Add(this.SaveOptionsButton);
            this.TabpageOptions.Controls.Add(this.groupBox1);
            this.TabpageOptions.Location = new System.Drawing.Point(4, 22);
            this.TabpageOptions.Name = "TabpageOptions";
            this.TabpageOptions.Padding = new System.Windows.Forms.Padding(3);
            this.TabpageOptions.Size = new System.Drawing.Size(766, 608);
            this.TabpageOptions.TabIndex = 2;
            this.TabpageOptions.Text = "Options";
            this.TabpageOptions.UseVisualStyleBackColor = true;
            this.TabpageOptions.Enter += new System.EventHandler(this.TabpageOptions_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.treeView1);
            this.groupBox4.Location = new System.Drawing.Point(414, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(346, 382);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Websites";
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.LabelEdit = true;
            this.treeView1.Location = new System.Drawing.Point(6, 19);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(340, 292);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.createSiteFolderCheckbox);
            this.groupBox2.Controls.Add(this.LabelExampleName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.NamingSchemeTextbox);
            this.groupBox2.Controls.Add(this.CreateSubfoldersCheckbox);
            this.groupBox2.Controls.Add(this.SelectFolderButton);
            this.groupBox2.Controls.Add(this.SelectedPathTextbox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 190);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Downloader";
            // 
            // createSiteFolderCheckbox
            // 
            this.createSiteFolderCheckbox.AutoSize = true;
            this.createSiteFolderCheckbox.Location = new System.Drawing.Point(9, 81);
            this.createSiteFolderCheckbox.Name = "createSiteFolderCheckbox";
            this.createSiteFolderCheckbox.Size = new System.Drawing.Size(167, 17);
            this.createSiteFolderCheckbox.TabIndex = 7;
            this.createSiteFolderCheckbox.Text = "Create folder for each website";
            this.createSiteFolderCheckbox.UseVisualStyleBackColor = true;
            // 
            // LabelExampleName
            // 
            this.LabelExampleName.AutoSize = true;
            this.LabelExampleName.Location = new System.Drawing.Point(219, 167);
            this.LabelExampleName.Name = "LabelExampleName";
            this.LabelExampleName.Size = new System.Drawing.Size(0, 13);
            this.LabelExampleName.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Example:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Chapter folder name";
            // 
            // NamingSchemeTextbox
            // 
            this.NamingSchemeTextbox.Location = new System.Drawing.Point(9, 164);
            this.NamingSchemeTextbox.Name = "NamingSchemeTextbox";
            this.NamingSchemeTextbox.Size = new System.Drawing.Size(148, 20);
            this.NamingSchemeTextbox.TabIndex = 9;
            // 
            // CreateSubfoldersCheckbox
            // 
            this.CreateSubfoldersCheckbox.AutoSize = true;
            this.CreateSubfoldersCheckbox.Location = new System.Drawing.Point(9, 43);
            this.CreateSubfoldersCheckbox.Name = "CreateSubfoldersCheckbox";
            this.CreateSubfoldersCheckbox.Size = new System.Drawing.Size(168, 17);
            this.CreateSubfoldersCheckbox.TabIndex = 8;
            this.CreateSubfoldersCheckbox.Text = "Create folders for each manga";
            this.CreateSubfoldersCheckbox.UseVisualStyleBackColor = true;
            // 
            // SelectFolderButton
            // 
            this.SelectFolderButton.Location = new System.Drawing.Point(298, 16);
            this.SelectFolderButton.Name = "SelectFolderButton";
            this.SelectFolderButton.Size = new System.Drawing.Size(86, 24);
            this.SelectFolderButton.TabIndex = 7;
            this.SelectFolderButton.Text = "Select Folder";
            this.SelectFolderButton.UseVisualStyleBackColor = true;
            this.SelectFolderButton.Click += new System.EventHandler(this.SelectFolderButton_Click);
            // 
            // SelectedPathTextbox
            // 
            this.SelectedPathTextbox.Location = new System.Drawing.Point(126, 17);
            this.SelectedPathTextbox.Name = "SelectedPathTextbox";
            this.SelectedPathTextbox.ReadOnly = true;
            this.SelectedPathTextbox.Size = new System.Drawing.Size(166, 20);
            this.SelectedPathTextbox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Default download path";
            // 
            // SaveOptionsButton
            // 
            this.SaveOptionsButton.Location = new System.Drawing.Point(6, 562);
            this.SaveOptionsButton.Name = "SaveOptionsButton";
            this.SaveOptionsButton.Size = new System.Drawing.Size(120, 40);
            this.SaveOptionsButton.TabIndex = 2;
            this.SaveOptionsButton.Text = "Save";
            this.SaveOptionsButton.UseVisualStyleBackColor = true;
            this.SaveOptionsButton.Click += new System.EventHandler(this.SaveOptionsButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textboxRememberedFilter);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericRetryTime);
            this.groupBox1.Controls.Add(this.SaveCoversCheckbox);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 190);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Remembered filter string";
            // 
            // textboxRememberedFilter
            // 
            this.textboxRememberedFilter.Location = new System.Drawing.Point(129, 76);
            this.textboxRememberedFilter.Name = "textboxRememberedFilter";
            this.textboxRememberedFilter.Size = new System.Drawing.Size(267, 20);
            this.textboxRememberedFilter.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Time between retrys: ";
            // 
            // numericRetryTime
            // 
            this.numericRetryTime.Location = new System.Drawing.Point(120, 42);
            this.numericRetryTime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericRetryTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericRetryTime.Name = "numericRetryTime";
            this.numericRetryTime.Size = new System.Drawing.Size(120, 20);
            this.numericRetryTime.TabIndex = 5;
            this.numericRetryTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SaveCoversCheckbox
            // 
            this.SaveCoversCheckbox.AutoSize = true;
            this.SaveCoversCheckbox.Location = new System.Drawing.Point(6, 19);
            this.SaveCoversCheckbox.Name = "SaveCoversCheckbox";
            this.SaveCoversCheckbox.Size = new System.Drawing.Size(120, 17);
            this.SaveCoversCheckbox.TabIndex = 4;
            this.SaveCoversCheckbox.Text = "Save covers to disk";
            this.SaveCoversCheckbox.UseVisualStyleBackColor = true;
            this.SaveCoversCheckbox.CheckedChanged += new System.EventHandler(this.SaveCoversCheckbox_CheckedChanged);
            // 
            // TabpageDownloads
            // 
            this.TabpageDownloads.Controls.Add(this.TabcontrolDownloads);
            this.TabpageDownloads.Location = new System.Drawing.Point(4, 22);
            this.TabpageDownloads.Name = "TabpageDownloads";
            this.TabpageDownloads.Size = new System.Drawing.Size(766, 608);
            this.TabpageDownloads.TabIndex = 3;
            this.TabpageDownloads.Text = "Downloads";
            this.TabpageDownloads.UseVisualStyleBackColor = true;
            // 
            // TabcontrolDownloads
            // 
            this.TabcontrolDownloads.Controls.Add(this.tabPage1);
            this.TabcontrolDownloads.Controls.Add(this.tabPage2);
            this.TabcontrolDownloads.Controls.Add(this.tabPage3);
            this.TabcontrolDownloads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabcontrolDownloads.Location = new System.Drawing.Point(0, 0);
            this.TabcontrolDownloads.Name = "TabcontrolDownloads";
            this.TabcontrolDownloads.SelectedIndex = 0;
            this.TabcontrolDownloads.Size = new System.Drawing.Size(766, 608);
            this.TabcontrolDownloads.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ListviewCurrentDownloads);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(758, 582);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Current downloads";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ListviewCurrentDownloads
            // 
            this.ListviewCurrentDownloads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn_1,
            this.StatusColumn_1,
            this.PercentageColumn_1,
            this.PagesColumn_1});
            this.ListviewCurrentDownloads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListviewCurrentDownloads.Location = new System.Drawing.Point(3, 3);
            this.ListviewCurrentDownloads.Name = "ListviewCurrentDownloads";
            this.ListviewCurrentDownloads.Size = new System.Drawing.Size(752, 576);
            this.ListviewCurrentDownloads.TabIndex = 0;
            this.ListviewCurrentDownloads.UseCompatibleStateImageBehavior = false;
            this.ListviewCurrentDownloads.View = System.Windows.Forms.View.Details;
            // 
            // NameColumn_1
            // 
            this.NameColumn_1.Text = "Name";
            // 
            // StatusColumn_1
            // 
            this.StatusColumn_1.Text = "Status";
            // 
            // PercentageColumn_1
            // 
            this.PercentageColumn_1.Text = "Percentage";
            // 
            // PagesColumn_1
            // 
            this.PagesColumn_1.Text = "Pages done";
            this.PagesColumn_1.Width = 80;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(758, 582);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Failed downloads";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ListviewCompletedDownloads);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(758, 582);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Completed downloads";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ListviewCompletedDownloads
            // 
            this.ListviewCompletedDownloads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn_3,
            this.StatusColumn_3,
            this.CompletedOnColumn_3,
            this.TimeColumn_3});
            this.ListviewCompletedDownloads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListviewCompletedDownloads.FullRowSelect = true;
            this.ListviewCompletedDownloads.Location = new System.Drawing.Point(3, 3);
            this.ListviewCompletedDownloads.Name = "ListviewCompletedDownloads";
            this.ListviewCompletedDownloads.Size = new System.Drawing.Size(752, 576);
            this.ListviewCompletedDownloads.TabIndex = 1;
            this.ListviewCompletedDownloads.UseCompatibleStateImageBehavior = false;
            this.ListviewCompletedDownloads.View = System.Windows.Forms.View.Details;
            this.ListviewCompletedDownloads.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListviewCompletedDownloads_MouseClick);
            // 
            // NameColumn_3
            // 
            this.NameColumn_3.Text = "Name";
            this.NameColumn_3.Width = 250;
            // 
            // StatusColumn_3
            // 
            this.StatusColumn_3.Text = "Status";
            this.StatusColumn_3.Width = 120;
            // 
            // CompletedOnColumn_3
            // 
            this.CompletedOnColumn_3.Text = "Completed on";
            this.CompletedOnColumn_3.Width = 130;
            // 
            // TimeColumn_3
            // 
            this.TimeColumn_3.Text = "Time taken";
            this.TimeColumn_3.Width = 80;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1118, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.mainToolStripMenuItem.Text = "Main";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // ContextmenuMangalist
            // 
            this.ContextmenuMangalist.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolstripItemGotoGallery,
            this.ToolstripItemDownload});
            this.ContextmenuMangalist.Name = "cmMangalist";
            this.ContextmenuMangalist.Size = new System.Drawing.Size(153, 70);
            // 
            // ToolstripItemGotoGallery
            // 
            this.ToolstripItemGotoGallery.Name = "ToolstripItemGotoGallery";
            this.ToolstripItemGotoGallery.Size = new System.Drawing.Size(152, 22);
            this.ToolstripItemGotoGallery.Text = "Go to Gallery";
            this.ToolstripItemGotoGallery.Click += new System.EventHandler(this.ToolstripItemGotoGallery_Click);
            // 
            // ToolstripItemDownload
            // 
            this.ToolstripItemDownload.Name = "ToolstripItemDownload";
            this.ToolstripItemDownload.Size = new System.Drawing.Size(152, 22);
            this.ToolstripItemDownload.Text = "Download";
            this.ToolstripItemDownload.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // ContextmenuTags
            // 
            this.ContextmenuTags.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TagToolstripFilterByThis,
            this.showMangasWithoutThisTagToolStripMenuItem});
            this.ContextmenuTags.Name = "ContextmenuTags";
            this.ContextmenuTags.Size = new System.Drawing.Size(235, 48);
            // 
            // TagToolstripFilterByThis
            // 
            this.TagToolstripFilterByThis.Name = "TagToolstripFilterByThis";
            this.TagToolstripFilterByThis.Size = new System.Drawing.Size(234, 22);
            this.TagToolstripFilterByThis.Text = "Show mangas with this tag";
            this.TagToolstripFilterByThis.Click += new System.EventHandler(this.TagToolstripFilterByThis_Click);
            // 
            // showMangasWithoutThisTagToolStripMenuItem
            // 
            this.showMangasWithoutThisTagToolStripMenuItem.Name = "showMangasWithoutThisTagToolStripMenuItem";
            this.showMangasWithoutThisTagToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.showMangasWithoutThisTagToolStripMenuItem.Text = "Show mangas without this tag";
            this.showMangasWithoutThisTagToolStripMenuItem.Click += new System.EventHandler(this.showMangasWithoutThisTagToolStripMenuItem_Click);
            // 
            // StatusStrip_Main
            // 
            this.StatusStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolstripProgress,
            this.ToolstripLabel});
            this.StatusStrip_Main.Location = new System.Drawing.Point(0, 664);
            this.StatusStrip_Main.Name = "StatusStrip_Main";
            this.StatusStrip_Main.Size = new System.Drawing.Size(1118, 22);
            this.StatusStrip_Main.TabIndex = 8;
            this.StatusStrip_Main.Text = "statusStrip1";
            // 
            // ToolstripProgress
            // 
            this.ToolstripProgress.Name = "ToolstripProgress";
            this.ToolstripProgress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ToolstripProgress.Size = new System.Drawing.Size(100, 16);
            this.ToolstripProgress.Step = 1;
            this.ToolstripProgress.Visible = false;
            // 
            // ToolstripLabel
            // 
            this.ToolstripLabel.Name = "ToolstripLabel";
            this.ToolstripLabel.Size = new System.Drawing.Size(0, 17);
            this.ToolstripLabel.Visible = false;
            // 
            // ContextmenuCompletedDownloads
            // 
            this.ContextmenuCompletedDownloads.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemGoTo,
            this.MenyItemDelete});
            this.ContextmenuCompletedDownloads.Name = "ContextmenuCompletedDownloads";
            this.ContextmenuCompletedDownloads.Size = new System.Drawing.Size(191, 48);
            // 
            // MenuItemGoTo
            // 
            this.MenuItemGoTo.Name = "MenuItemGoTo";
            this.MenuItemGoTo.Size = new System.Drawing.Size(190, 22);
            this.MenuItemGoTo.Text = "Go to downloadfolder";
            // 
            // MenyItemDelete
            // 
            this.MenyItemDelete.Name = "MenyItemDelete";
            this.MenyItemDelete.Size = new System.Drawing.Size(190, 22);
            this.MenyItemDelete.Text = "Delete";
            // 
            // WebsiteDropdown
            // 
            this.WebsiteDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WebsiteDropdown.FormattingEnabled = true;
            this.WebsiteDropdown.Location = new System.Drawing.Point(12, 27);
            this.WebsiteDropdown.Name = "WebsiteDropdown";
            this.WebsiteDropdown.Size = new System.Drawing.Size(106, 21);
            this.WebsiteDropdown.TabIndex = 8;
            this.WebsiteDropdown.SelectedIndexChanged += new System.EventHandler(this.WebsiteDropdown_SelectedIndexChanged);
            // 
            // ListviewMangas
            // 
            this.ListviewMangas.AllColumns.Add(this.titleColumn);
            this.ListviewMangas.AllColumns.Add(this.pageColumn);
            this.ListviewMangas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.titleColumn,
            this.pageColumn});
            this.ListviewMangas.Location = new System.Drawing.Point(12, 54);
            this.ListviewMangas.Name = "ListviewMangas";
            this.ListviewMangas.ShowGroups = false;
            this.ListviewMangas.Size = new System.Drawing.Size(314, 607);
            this.ListviewMangas.TabIndex = 17;
            this.ListviewMangas.UseCompatibleStateImageBehavior = false;
            this.ListviewMangas.View = System.Windows.Forms.View.Details;
            this.ListviewMangas.VirtualMode = true;
            this.ListviewMangas.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.ListviewMangas_CellRightClick);
            this.ListviewMangas.SelectedIndexChanged += new System.EventHandler(this.ListviewMangas_SelectedIndexChanged);
            // 
            // titleColumn
            // 
            this.titleColumn.AspectName = "Title";
            this.titleColumn.Text = "Title";
            this.titleColumn.Width = 240;
            // 
            // pageColumn
            // 
            this.pageColumn.AspectName = "Pages";
            this.pageColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.pageColumn.Text = "Pages";
            this.pageColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.pageColumn.Width = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 686);
            this.Controls.Add(this.ListviewMangas);
            this.Controls.Add(this.WebsiteDropdown);
            this.Controls.Add(this.StatusStrip_Main);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.tabcontrolMain);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabcontrolMain.ResumeLayout(false);
            this.TabpageInfo.ResumeLayout(false);
            this.TabpageInfo.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBoxTags.ResumeLayout(false);
            this.groupBoxTags.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFilterPageCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.TabpageOptions.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRetryTime)).EndInit();
            this.TabpageDownloads.ResumeLayout(false);
            this.TabcontrolDownloads.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ContextmenuMangalist.ResumeLayout(false);
            this.ContextmenuTags.ResumeLayout(false);
            this.StatusStrip_Main.ResumeLayout(false);
            this.StatusStrip_Main.PerformLayout();
            this.ContextmenuCompletedDownloads.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListviewMangas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        



        #endregion

        private Button DownloadButton;
        private TabControl tabcontrolMain;
        private TabPage TabpageInfo;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem mainToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private PictureBox pictureBox1;
        private Label lblInfo;
        private Label lblTags;
        private Label lblLanguage;
        private Label lblPages;
        private Label lblTitle;
        private ContextMenuStrip ContextmenuMangalist;
        private ToolStripMenuItem ToolstripItemGotoGallery;
        private TabPage TabpageOptions;
        private Button SaveOptionsButton;
        private ListBox TagListbox;
        private ContextMenuStrip ContextmenuTags;
        private ToolStripMenuItem TagToolstripFilterByThis;
        private StatusStrip StatusStrip_Main;
        internal ToolStripProgressBar ToolstripProgress;
        internal ToolStripStatusLabel ToolstripLabel;
        private GroupBox groupBox1;
        private CheckBox SaveCoversCheckbox;
        private GroupBox groupBox2;
        private Label label1;
        private Button SelectFolderButton;
        private TextBox SelectedPathTextbox;
        private CheckBox CreateSubfoldersCheckbox;
        private Label label2;
        private TextBox NamingSchemeTextbox;
        private Label LabelExampleName;
        private Label label3;
        private ToolStripMenuItem ToolstripItemDownload;
        private TabPage TabpageDownloads;
        private TabControl TabcontrolDownloads;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private ColumnHeader NameColumn_1;
        private ColumnHeader StatusColumn_1;
        private ColumnHeader PercentageColumn_1;
        internal ListView ListviewCurrentDownloads;
        internal ListView ListviewCompletedDownloads;
        private ColumnHeader NameColumn_3;
        private ColumnHeader StatusColumn_3;
        private ColumnHeader CompletedOnColumn_3;
        private ColumnHeader PagesColumn_1;
        private Label label4;
        private NumericUpDown numericRetryTime;
        private ContextMenuStrip ContextmenuCompletedDownloads;
        private ToolStripMenuItem MenuItemGoTo;
        private ToolStripMenuItem MenyItemDelete;
        private GroupBox groupBox3;
        private Button ApplyFilterButton;
        private CheckBox FilterCheckbox_downloaded;
        private GroupBox groupBoxTags;
        private CheckBox FilterCheckbox_12;
        private CheckBox FilterCheckbox_11;
        private CheckBox FilterCheckbox_10;
        private CheckBox FilterCheckbox_9;
        private CheckBox FilterCheckbox_8;
        private CheckBox FilterCheckbox_7;
        private CheckBox FilterCheckbox_6;
        private CheckBox FilterCheckbox_5;
        private CheckBox FilterCheckbox_4;
        private CheckBox FilterCheckbox_3;
        private CheckBox FilterCheckbox_2;
        private CheckBox TagCheckbox_1;
        private Label label5;
        private TextBox TextboxCustomFilter;
        private NumericUpDown numericFilterPageCount;
        private CheckBox CheckboxFilterByPages;
        private Button ClearFilterButton;
        private CheckBox createSiteFolderCheckbox;
        private GroupBox groupBox4;
        private TreeView treeView1;
        private ComboBox WebsiteDropdown;
        private ColumnHeader TimeColumn_3;
        private ToolStripMenuItem showMangasWithoutThisTagToolStripMenuItem;
        private FastObjectListView ListviewMangas;
        private OLVColumn titleColumn;
        private OLVColumn pageColumn;
        private Label label6;
        private TextBox textboxRememberedFilter;
        private Label labelFilteredOut;
      
    
    }
}

