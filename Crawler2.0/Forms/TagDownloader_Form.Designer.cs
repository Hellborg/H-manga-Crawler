namespace Crawler2._0.Forms
{
    partial class TagDownloaderForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.TagDownloadProgressLabel = new System.Windows.Forms.Label();
            this.TagDownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(302, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TagDownloadProgressLabel
            // 
            this.TagDownloadProgressLabel.AutoSize = true;
            this.TagDownloadProgressLabel.Location = new System.Drawing.Point(9, 9);
            this.TagDownloadProgressLabel.Name = "TagDownloadProgressLabel";
            this.TagDownloadProgressLabel.Size = new System.Drawing.Size(35, 13);
            this.TagDownloadProgressLabel.TabIndex = 1;
            this.TagDownloadProgressLabel.Text = "label1";
            // 
            // TagDownloadProgressBar
            // 
            this.TagDownloadProgressBar.Location = new System.Drawing.Point(12, 25);
            this.TagDownloadProgressBar.Name = "TagDownloadProgressBar";
            this.TagDownloadProgressBar.Size = new System.Drawing.Size(413, 35);
            this.TagDownloadProgressBar.TabIndex = 2;
            // 
            // TagDownloader_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 104);
            this.Controls.Add(this.TagDownloadProgressBar);
            this.Controls.Add(this.TagDownloadProgressLabel);
            this.Controls.Add(this.button1);
            this.Name = "TagDownloaderForm";
            this.Text = "TagDownloader_Form";
            this.Load += new System.EventHandler(this.TagDownloader_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label TagDownloadProgressLabel;
        private System.Windows.Forms.ProgressBar TagDownloadProgressBar;
    }
}