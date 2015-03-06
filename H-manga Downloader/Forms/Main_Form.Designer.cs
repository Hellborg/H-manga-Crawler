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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.lblDate = new System.Windows.Forms.Label();
            this.lblPages = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureboxCover = new System.Windows.Forms.PictureBox();
            this.TabpageOptions = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.createSiteFolderCheckbox = new System.Windows.Forms.CheckBox();
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
            this.ListviewMangas = new System.Windows.Forms.ListView();
            this.titleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pagesColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabcontrolMain.SuspendLayout();
            this.TabpageInfo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBoxTags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFilterPageCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxCover)).BeginInit();
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
            this.SuspendLayout();
            // 
            // DownloadButton
            // 
            resources.ApplyResources(this.DownloadButton, "DownloadButton");
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabcontrolMain
            // 
            resources.ApplyResources(this.tabcontrolMain, "tabcontrolMain");
            this.tabcontrolMain.Controls.Add(this.TabpageInfo);
            this.tabcontrolMain.Controls.Add(this.TabpageOptions);
            this.tabcontrolMain.Controls.Add(this.TabpageDownloads);
            this.tabcontrolMain.Name = "tabcontrolMain";
            this.tabcontrolMain.SelectedIndex = 0;
            // 
            // TabpageInfo
            // 
            this.TabpageInfo.Controls.Add(this.groupBox3);
            this.TabpageInfo.Controls.Add(this.TagListbox);
            this.TabpageInfo.Controls.Add(this.lblInfo);
            this.TabpageInfo.Controls.Add(this.lblTags);
            this.TabpageInfo.Controls.Add(this.lblDate);
            this.TabpageInfo.Controls.Add(this.lblPages);
            this.TabpageInfo.Controls.Add(this.lblTitle);
            this.TabpageInfo.Controls.Add(this.pictureboxCover);
            resources.ApplyResources(this.TabpageInfo, "TabpageInfo");
            this.TabpageInfo.Name = "TabpageInfo";
            this.TabpageInfo.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.ClearFilterButton);
            this.groupBox3.Controls.Add(this.ApplyFilterButton);
            this.groupBox3.Controls.Add(this.FilterCheckbox_downloaded);
            this.groupBox3.Controls.Add(this.groupBoxTags);
            this.groupBox3.Controls.Add(this.numericFilterPageCount);
            this.groupBox3.Controls.Add(this.CheckboxFilterByPages);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // ClearFilterButton
            // 
            resources.ApplyResources(this.ClearFilterButton, "ClearFilterButton");
            this.ClearFilterButton.Name = "ClearFilterButton";
            this.ClearFilterButton.UseVisualStyleBackColor = true;
            this.ClearFilterButton.Click += new System.EventHandler(this.ClearFilterButton_Click);
            // 
            // ApplyFilterButton
            // 
            resources.ApplyResources(this.ApplyFilterButton, "ApplyFilterButton");
            this.ApplyFilterButton.Name = "ApplyFilterButton";
            this.ApplyFilterButton.UseVisualStyleBackColor = true;
            this.ApplyFilterButton.Click += new System.EventHandler(this.ApplyFilterButton_Click);
            // 
            // FilterCheckbox_downloaded
            // 
            resources.ApplyResources(this.FilterCheckbox_downloaded, "FilterCheckbox_downloaded");
            this.FilterCheckbox_downloaded.Name = "FilterCheckbox_downloaded";
            this.FilterCheckbox_downloaded.UseVisualStyleBackColor = true;
            // 
            // groupBoxTags
            // 
            resources.ApplyResources(this.groupBoxTags, "groupBoxTags");
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
            this.groupBoxTags.Name = "groupBoxTags";
            this.groupBoxTags.TabStop = false;
            // 
            // labelFilteredOut
            // 
            resources.ApplyResources(this.labelFilteredOut, "labelFilteredOut");
            this.labelFilteredOut.Name = "labelFilteredOut";
            // 
            // FilterCheckbox_12
            // 
            resources.ApplyResources(this.FilterCheckbox_12, "FilterCheckbox_12");
            this.FilterCheckbox_12.Name = "FilterCheckbox_12";
            this.FilterCheckbox_12.ThreeState = true;
            this.FilterCheckbox_12.UseVisualStyleBackColor = true;
            // 
            // FilterCheckbox_11
            // 
            resources.ApplyResources(this.FilterCheckbox_11, "FilterCheckbox_11");
            this.FilterCheckbox_11.Name = "FilterCheckbox_11";
            this.FilterCheckbox_11.ThreeState = true;
            this.FilterCheckbox_11.UseVisualStyleBackColor = true;
            // 
            // FilterCheckbox_10
            // 
            resources.ApplyResources(this.FilterCheckbox_10, "FilterCheckbox_10");
            this.FilterCheckbox_10.Name = "FilterCheckbox_10";
            this.FilterCheckbox_10.ThreeState = true;
            this.FilterCheckbox_10.UseVisualStyleBackColor = true;
            // 
            // FilterCheckbox_9
            // 
            resources.ApplyResources(this.FilterCheckbox_9, "FilterCheckbox_9");
            this.FilterCheckbox_9.Name = "FilterCheckbox_9";
            this.FilterCheckbox_9.ThreeState = true;
            this.FilterCheckbox_9.UseVisualStyleBackColor = true;
            // 
            // FilterCheckbox_8
            // 
            resources.ApplyResources(this.FilterCheckbox_8, "FilterCheckbox_8");
            this.FilterCheckbox_8.Name = "FilterCheckbox_8";
            this.FilterCheckbox_8.ThreeState = true;
            this.FilterCheckbox_8.UseVisualStyleBackColor = true;
            // 
            // FilterCheckbox_7
            // 
            resources.ApplyResources(this.FilterCheckbox_7, "FilterCheckbox_7");
            this.FilterCheckbox_7.Name = "FilterCheckbox_7";
            this.FilterCheckbox_7.ThreeState = true;
            this.FilterCheckbox_7.UseVisualStyleBackColor = true;
            // 
            // FilterCheckbox_6
            // 
            resources.ApplyResources(this.FilterCheckbox_6, "FilterCheckbox_6");
            this.FilterCheckbox_6.Name = "FilterCheckbox_6";
            this.FilterCheckbox_6.ThreeState = true;
            this.FilterCheckbox_6.UseVisualStyleBackColor = true;
            // 
            // FilterCheckbox_5
            // 
            resources.ApplyResources(this.FilterCheckbox_5, "FilterCheckbox_5");
            this.FilterCheckbox_5.Name = "FilterCheckbox_5";
            this.FilterCheckbox_5.ThreeState = true;
            this.FilterCheckbox_5.UseVisualStyleBackColor = true;
            // 
            // FilterCheckbox_4
            // 
            resources.ApplyResources(this.FilterCheckbox_4, "FilterCheckbox_4");
            this.FilterCheckbox_4.Name = "FilterCheckbox_4";
            this.FilterCheckbox_4.ThreeState = true;
            this.FilterCheckbox_4.UseVisualStyleBackColor = true;
            // 
            // FilterCheckbox_3
            // 
            resources.ApplyResources(this.FilterCheckbox_3, "FilterCheckbox_3");
            this.FilterCheckbox_3.Name = "FilterCheckbox_3";
            this.FilterCheckbox_3.ThreeState = true;
            this.FilterCheckbox_3.UseVisualStyleBackColor = true;
            // 
            // FilterCheckbox_2
            // 
            resources.ApplyResources(this.FilterCheckbox_2, "FilterCheckbox_2");
            this.FilterCheckbox_2.Name = "FilterCheckbox_2";
            this.FilterCheckbox_2.ThreeState = true;
            this.FilterCheckbox_2.UseVisualStyleBackColor = true;
            // 
            // TagCheckbox_1
            // 
            resources.ApplyResources(this.TagCheckbox_1, "TagCheckbox_1");
            this.TagCheckbox_1.Name = "TagCheckbox_1";
            this.TagCheckbox_1.ThreeState = true;
            this.TagCheckbox_1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // TextboxCustomFilter
            // 
            resources.ApplyResources(this.TextboxCustomFilter, "TextboxCustomFilter");
            this.TextboxCustomFilter.Name = "TextboxCustomFilter";
            this.TextboxCustomFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextboxCustomFilter_KeyDown);
            // 
            // numericFilterPageCount
            // 
            resources.ApplyResources(this.numericFilterPageCount, "numericFilterPageCount");
            this.numericFilterPageCount.Name = "numericFilterPageCount";
            // 
            // CheckboxFilterByPages
            // 
            resources.ApplyResources(this.CheckboxFilterByPages, "CheckboxFilterByPages");
            this.CheckboxFilterByPages.Name = "CheckboxFilterByPages";
            this.CheckboxFilterByPages.UseVisualStyleBackColor = true;
            // 
            // TagListbox
            // 
            this.TagListbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TagListbox.FormattingEnabled = true;
            resources.ApplyResources(this.TagListbox, "TagListbox");
            this.TagListbox.Name = "TagListbox";
            this.TagListbox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TagListbox_MouseUp);
            // 
            // lblInfo
            // 
            resources.ApplyResources(this.lblInfo, "lblInfo");
            this.lblInfo.Name = "lblInfo";
            // 
            // lblTags
            // 
            resources.ApplyResources(this.lblTags, "lblTags");
            this.lblTags.Name = "lblTags";
            // 
            // lblDate
            // 
            resources.ApplyResources(this.lblDate, "lblDate");
            this.lblDate.Name = "lblDate";
            // 
            // lblPages
            // 
            resources.ApplyResources(this.lblPages, "lblPages");
            this.lblPages.Name = "lblPages";
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // pictureboxCover
            // 
            this.pictureboxCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pictureboxCover, "pictureboxCover");
            this.pictureboxCover.Name = "pictureboxCover";
            this.pictureboxCover.TabStop = false;
            // 
            // TabpageOptions
            // 
            this.TabpageOptions.Controls.Add(this.groupBox4);
            this.TabpageOptions.Controls.Add(this.groupBox2);
            this.TabpageOptions.Controls.Add(this.SaveOptionsButton);
            this.TabpageOptions.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.TabpageOptions, "TabpageOptions");
            this.TabpageOptions.Name = "TabpageOptions";
            this.TabpageOptions.UseVisualStyleBackColor = true;
            this.TabpageOptions.Enter += new System.EventHandler(this.TabpageOptions_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.treeView1);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.LabelEdit = true;
            resources.ApplyResources(this.treeView1, "treeView1");
            this.treeView1.Name = "treeView1";
            this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.createSiteFolderCheckbox);
            this.groupBox2.Controls.Add(this.CreateSubfoldersCheckbox);
            this.groupBox2.Controls.Add(this.SelectFolderButton);
            this.groupBox2.Controls.Add(this.SelectedPathTextbox);
            this.groupBox2.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // createSiteFolderCheckbox
            // 
            resources.ApplyResources(this.createSiteFolderCheckbox, "createSiteFolderCheckbox");
            this.createSiteFolderCheckbox.Name = "createSiteFolderCheckbox";
            this.createSiteFolderCheckbox.UseVisualStyleBackColor = true;
            this.createSiteFolderCheckbox.CheckedChanged += new System.EventHandler(this.createSiteFolderCheckbox_CheckedChanged);
            // 
            // CreateSubfoldersCheckbox
            // 
            resources.ApplyResources(this.CreateSubfoldersCheckbox, "CreateSubfoldersCheckbox");
            this.CreateSubfoldersCheckbox.Name = "CreateSubfoldersCheckbox";
            this.CreateSubfoldersCheckbox.UseVisualStyleBackColor = true;
            // 
            // SelectFolderButton
            // 
            resources.ApplyResources(this.SelectFolderButton, "SelectFolderButton");
            this.SelectFolderButton.Name = "SelectFolderButton";
            this.SelectFolderButton.UseVisualStyleBackColor = true;
            this.SelectFolderButton.Click += new System.EventHandler(this.SelectFolderButton_Click);
            // 
            // SelectedPathTextbox
            // 
            resources.ApplyResources(this.SelectedPathTextbox, "SelectedPathTextbox");
            this.SelectedPathTextbox.Name = "SelectedPathTextbox";
            this.SelectedPathTextbox.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // SaveOptionsButton
            // 
            resources.ApplyResources(this.SaveOptionsButton, "SaveOptionsButton");
            this.SaveOptionsButton.Name = "SaveOptionsButton";
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
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // textboxRememberedFilter
            // 
            resources.ApplyResources(this.textboxRememberedFilter, "textboxRememberedFilter");
            this.textboxRememberedFilter.Name = "textboxRememberedFilter";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // numericRetryTime
            // 
            resources.ApplyResources(this.numericRetryTime, "numericRetryTime");
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
            this.numericRetryTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SaveCoversCheckbox
            // 
            resources.ApplyResources(this.SaveCoversCheckbox, "SaveCoversCheckbox");
            this.SaveCoversCheckbox.Name = "SaveCoversCheckbox";
            this.SaveCoversCheckbox.UseVisualStyleBackColor = true;
            this.SaveCoversCheckbox.CheckedChanged += new System.EventHandler(this.SaveCoversCheckbox_CheckedChanged);
            // 
            // TabpageDownloads
            // 
            this.TabpageDownloads.Controls.Add(this.TabcontrolDownloads);
            resources.ApplyResources(this.TabpageDownloads, "TabpageDownloads");
            this.TabpageDownloads.Name = "TabpageDownloads";
            this.TabpageDownloads.UseVisualStyleBackColor = true;
            // 
            // TabcontrolDownloads
            // 
            this.TabcontrolDownloads.Controls.Add(this.tabPage1);
            this.TabcontrolDownloads.Controls.Add(this.tabPage2);
            this.TabcontrolDownloads.Controls.Add(this.tabPage3);
            resources.ApplyResources(this.TabcontrolDownloads, "TabcontrolDownloads");
            this.TabcontrolDownloads.Name = "TabcontrolDownloads";
            this.TabcontrolDownloads.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ListviewCurrentDownloads);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ListviewCurrentDownloads
            // 
            this.ListviewCurrentDownloads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn_1,
            this.StatusColumn_1,
            this.PercentageColumn_1,
            this.PagesColumn_1});
            resources.ApplyResources(this.ListviewCurrentDownloads, "ListviewCurrentDownloads");
            this.ListviewCurrentDownloads.Name = "ListviewCurrentDownloads";
            this.ListviewCurrentDownloads.UseCompatibleStateImageBehavior = false;
            this.ListviewCurrentDownloads.View = System.Windows.Forms.View.Details;
            // 
            // NameColumn_1
            // 
            resources.ApplyResources(this.NameColumn_1, "NameColumn_1");
            // 
            // StatusColumn_1
            // 
            resources.ApplyResources(this.StatusColumn_1, "StatusColumn_1");
            // 
            // PercentageColumn_1
            // 
            resources.ApplyResources(this.PercentageColumn_1, "PercentageColumn_1");
            // 
            // PagesColumn_1
            // 
            resources.ApplyResources(this.PagesColumn_1, "PagesColumn_1");
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ListviewCompletedDownloads);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ListviewCompletedDownloads
            // 
            this.ListviewCompletedDownloads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn_3,
            this.StatusColumn_3,
            this.CompletedOnColumn_3,
            this.TimeColumn_3});
            resources.ApplyResources(this.ListviewCompletedDownloads, "ListviewCompletedDownloads");
            this.ListviewCompletedDownloads.FullRowSelect = true;
            this.ListviewCompletedDownloads.Name = "ListviewCompletedDownloads";
            this.ListviewCompletedDownloads.UseCompatibleStateImageBehavior = false;
            this.ListviewCompletedDownloads.View = System.Windows.Forms.View.Details;
            this.ListviewCompletedDownloads.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListviewCompletedDownloads_MouseClick);
            // 
            // NameColumn_3
            // 
            resources.ApplyResources(this.NameColumn_3, "NameColumn_3");
            // 
            // StatusColumn_3
            // 
            resources.ApplyResources(this.StatusColumn_3, "StatusColumn_3");
            // 
            // CompletedOnColumn_3
            // 
            resources.ApplyResources(this.CompletedOnColumn_3, "CompletedOnColumn_3");
            // 
            // TimeColumn_3
            // 
            resources.ApplyResources(this.TimeColumn_3, "TimeColumn_3");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.aboutToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            resources.ApplyResources(this.mainToolStripMenuItem, "mainToolStripMenuItem");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            // 
            // ContextmenuMangalist
            // 
            this.ContextmenuMangalist.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolstripItemGotoGallery,
            this.ToolstripItemDownload});
            this.ContextmenuMangalist.Name = "cmMangalist";
            resources.ApplyResources(this.ContextmenuMangalist, "ContextmenuMangalist");
            // 
            // ToolstripItemGotoGallery
            // 
            this.ToolstripItemGotoGallery.Name = "ToolstripItemGotoGallery";
            resources.ApplyResources(this.ToolstripItemGotoGallery, "ToolstripItemGotoGallery");
            this.ToolstripItemGotoGallery.Click += new System.EventHandler(this.ToolstripItemGotoGallery_Click);
            // 
            // ToolstripItemDownload
            // 
            this.ToolstripItemDownload.Name = "ToolstripItemDownload";
            resources.ApplyResources(this.ToolstripItemDownload, "ToolstripItemDownload");
            this.ToolstripItemDownload.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // ContextmenuTags
            // 
            this.ContextmenuTags.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TagToolstripFilterByThis,
            this.showMangasWithoutThisTagToolStripMenuItem});
            this.ContextmenuTags.Name = "ContextmenuTags";
            resources.ApplyResources(this.ContextmenuTags, "ContextmenuTags");
            // 
            // TagToolstripFilterByThis
            // 
            this.TagToolstripFilterByThis.Name = "TagToolstripFilterByThis";
            resources.ApplyResources(this.TagToolstripFilterByThis, "TagToolstripFilterByThis");
            this.TagToolstripFilterByThis.Click += new System.EventHandler(this.TagToolstripFilterByThis_Click);
            // 
            // showMangasWithoutThisTagToolStripMenuItem
            // 
            this.showMangasWithoutThisTagToolStripMenuItem.Name = "showMangasWithoutThisTagToolStripMenuItem";
            resources.ApplyResources(this.showMangasWithoutThisTagToolStripMenuItem, "showMangasWithoutThisTagToolStripMenuItem");
            this.showMangasWithoutThisTagToolStripMenuItem.Click += new System.EventHandler(this.showMangasWithoutThisTagToolStripMenuItem_Click);
            // 
            // StatusStrip_Main
            // 
            this.StatusStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolstripProgress,
            this.ToolstripLabel});
            resources.ApplyResources(this.StatusStrip_Main, "StatusStrip_Main");
            this.StatusStrip_Main.Name = "StatusStrip_Main";
            // 
            // ToolstripProgress
            // 
            this.ToolstripProgress.Name = "ToolstripProgress";
            resources.ApplyResources(this.ToolstripProgress, "ToolstripProgress");
            this.ToolstripProgress.Step = 1;
            // 
            // ToolstripLabel
            // 
            this.ToolstripLabel.Name = "ToolstripLabel";
            resources.ApplyResources(this.ToolstripLabel, "ToolstripLabel");
            // 
            // ContextmenuCompletedDownloads
            // 
            this.ContextmenuCompletedDownloads.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemGoTo,
            this.MenyItemDelete});
            this.ContextmenuCompletedDownloads.Name = "ContextmenuCompletedDownloads";
            resources.ApplyResources(this.ContextmenuCompletedDownloads, "ContextmenuCompletedDownloads");
            // 
            // MenuItemGoTo
            // 
            this.MenuItemGoTo.Name = "MenuItemGoTo";
            resources.ApplyResources(this.MenuItemGoTo, "MenuItemGoTo");
            // 
            // MenyItemDelete
            // 
            this.MenyItemDelete.Name = "MenyItemDelete";
            resources.ApplyResources(this.MenyItemDelete, "MenyItemDelete");
            // 
            // WebsiteDropdown
            // 
            this.WebsiteDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WebsiteDropdown.FormattingEnabled = true;
            resources.ApplyResources(this.WebsiteDropdown, "WebsiteDropdown");
            this.WebsiteDropdown.Name = "WebsiteDropdown";
            this.WebsiteDropdown.SelectedIndexChanged += new System.EventHandler(this.WebsiteDropdown_SelectedIndexChanged);
            // 
            // ListviewMangas
            // 
            this.ListviewMangas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.titleColumn,
            this.pagesColumn,
            this.dateColumn});
            resources.ApplyResources(this.ListviewMangas, "ListviewMangas");
            this.ListviewMangas.Name = "ListviewMangas";
            this.ListviewMangas.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ListviewMangas.UseCompatibleStateImageBehavior = false;
            this.ListviewMangas.View = System.Windows.Forms.View.Details;
            this.ListviewMangas.VirtualMode = true;
            this.ListviewMangas.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListviewMangas_ColumnClick);
            this.ListviewMangas.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.listView1_RetrieveVirtualItem);
            this.ListviewMangas.SelectedIndexChanged += new System.EventHandler(this.ListviewMangas_SelectedIndexChanged_1);
            this.ListviewMangas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListviewMangas_MouseClick);
            this.ListviewMangas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListviewMangas_MouseDown);
            // 
            // titleColumn
            // 
            resources.ApplyResources(this.titleColumn, "titleColumn");
            // 
            // pagesColumn
            // 
            resources.ApplyResources(this.pagesColumn, "pagesColumn");
            // 
            // dateColumn
            // 
            resources.ApplyResources(this.dateColumn, "dateColumn");
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListviewMangas);
            this.Controls.Add(this.WebsiteDropdown);
            this.Controls.Add(this.StatusStrip_Main);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.tabcontrolMain);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxCover)).EndInit();
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
        private PictureBox pictureboxCover;
        private Label lblInfo;
        private Label lblTags;
        private Label lblDate;
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
        private Label label6;
        private TextBox textboxRememberedFilter;
        private Label labelFilteredOut;
        private ListView ListviewMangas;
        private ColumnHeader titleColumn;
        private ColumnHeader pagesColumn;
        private ColumnHeader dateColumn;
      
    
    }
}

