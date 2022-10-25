namespace HeroNextTranslator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTranslateSourcePath = new System.Windows.Forms.Label();
            this.btnSearchTranslateSource = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSearchFolderPath = new System.Windows.Forms.Label();
            this.btnSelectSearchFolder = new System.Windows.Forms.Button();
            this.btnStartSearch = new System.Windows.Forms.Button();
            this.lbOccurances = new System.Windows.Forms.ListBox();
            this.pgbProgress = new System.Windows.Forms.ProgressBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTranslationName = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtTranslationValue = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblHeroRepoFolder = new System.Windows.Forms.Label();
            this.btnSearchHeroRepoFolder = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblTotalTranslations = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSelectedFilePath = new System.Windows.Forms.Label();
            this.btnViewFile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTranslateSourcePath);
            this.groupBox1.Controls.Add(this.btnSearchTranslateSource);
            this.groupBox1.Location = new System.Drawing.Point(13, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Translate source";
            // 
            // lblTranslateSourcePath
            // 
            this.lblTranslateSourcePath.AutoSize = true;
            this.lblTranslateSourcePath.Location = new System.Drawing.Point(86, 19);
            this.lblTranslateSourcePath.MaximumSize = new System.Drawing.Size(300, 0);
            this.lblTranslateSourcePath.Name = "lblTranslateSourcePath";
            this.lblTranslateSourcePath.Size = new System.Drawing.Size(31, 15);
            this.lblTranslateSourcePath.TabIndex = 1;
            this.lblTranslateSourcePath.Text = "Path";
            // 
            // btnSearchTranslateSource
            // 
            this.btnSearchTranslateSource.Location = new System.Drawing.Point(6, 15);
            this.btnSearchTranslateSource.Name = "btnSearchTranslateSource";
            this.btnSearchTranslateSource.Size = new System.Drawing.Size(75, 23);
            this.btnSearchTranslateSource.TabIndex = 0;
            this.btnSearchTranslateSource.Text = "...";
            this.btnSearchTranslateSource.UseVisualStyleBackColor = true;
            this.btnSearchTranslateSource.Click += new System.EventHandler(this.btnSearchTranslateSource_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblSearchFolderPath);
            this.groupBox2.Controls.Add(this.btnSelectSearchFolder);
            this.groupBox2.Location = new System.Drawing.Point(13, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(624, 75);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search folder";
            // 
            // lblSearchFolderPath
            // 
            this.lblSearchFolderPath.AutoSize = true;
            this.lblSearchFolderPath.Location = new System.Drawing.Point(86, 19);
            this.lblSearchFolderPath.Name = "lblSearchFolderPath";
            this.lblSearchFolderPath.Size = new System.Drawing.Size(31, 15);
            this.lblSearchFolderPath.TabIndex = 1;
            this.lblSearchFolderPath.Text = "Path";
            // 
            // btnSelectSearchFolder
            // 
            this.btnSelectSearchFolder.Location = new System.Drawing.Point(5, 15);
            this.btnSelectSearchFolder.Name = "btnSelectSearchFolder";
            this.btnSelectSearchFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSelectSearchFolder.TabIndex = 0;
            this.btnSelectSearchFolder.Text = "...";
            this.btnSelectSearchFolder.UseVisualStyleBackColor = true;
            this.btnSelectSearchFolder.Click += new System.EventHandler(this.btnSelectSearchFolder_Click);
            // 
            // btnStartSearch
            // 
            this.btnStartSearch.Location = new System.Drawing.Point(11, 234);
            this.btnStartSearch.Name = "btnStartSearch";
            this.btnStartSearch.Size = new System.Drawing.Size(82, 41);
            this.btnStartSearch.TabIndex = 2;
            this.btnStartSearch.Text = "Search";
            this.btnStartSearch.UseVisualStyleBackColor = true;
            this.btnStartSearch.Click += new System.EventHandler(this.btnStartSearch_ClickAsync);
            // 
            // lbOccurances
            // 
            this.lbOccurances.FormattingEnabled = true;
            this.lbOccurances.ItemHeight = 15;
            this.lbOccurances.Location = new System.Drawing.Point(12, 310);
            this.lbOccurances.Name = "lbOccurances";
            this.lbOccurances.Size = new System.Drawing.Size(419, 319);
            this.lbOccurances.TabIndex = 3;
            this.lbOccurances.SelectedValueChanged += new System.EventHandler(this.lbOccurances_SelectedValueChanged);
            // 
            // pgbProgress
            // 
            this.pgbProgress.Location = new System.Drawing.Point(12, 281);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(625, 23);
            this.pgbProgress.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtTranslationName);
            this.groupBox3.Location = new System.Drawing.Point(443, 310);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(195, 57);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Name";
            // 
            // txtTranslationName
            // 
            this.txtTranslationName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTranslationName.Location = new System.Drawing.Point(6, 22);
            this.txtTranslationName.Name = "txtTranslationName";
            this.txtTranslationName.Size = new System.Drawing.Size(183, 23);
            this.txtTranslationName.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtTranslationValue);
            this.groupBox4.Location = new System.Drawing.Point(443, 373);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(195, 57);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Value";
            // 
            // txtTranslationValue
            // 
            this.txtTranslationValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTranslationValue.Location = new System.Drawing.Point(6, 22);
            this.txtTranslationValue.Name = "txtTranslationValue";
            this.txtTranslationValue.Size = new System.Drawing.Size(183, 23);
            this.txtTranslationValue.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(443, 445);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(195, 44);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_ClickAsync);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.lblHeroRepoFolder);
            this.groupBox5.Controls.Add(this.btnSearchHeroRepoFolder);
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(625, 53);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Hero repository folder";
            // 
            // lblHeroRepoFolder
            // 
            this.lblHeroRepoFolder.AutoSize = true;
            this.lblHeroRepoFolder.Location = new System.Drawing.Point(87, 26);
            this.lblHeroRepoFolder.MinimumSize = new System.Drawing.Size(100, 0);
            this.lblHeroRepoFolder.Name = "lblHeroRepoFolder";
            this.lblHeroRepoFolder.Size = new System.Drawing.Size(100, 15);
            this.lblHeroRepoFolder.TabIndex = 1;
            this.lblHeroRepoFolder.Text = "Path";
            // 
            // btnSearchHeroRepoFolder
            // 
            this.btnSearchHeroRepoFolder.Location = new System.Drawing.Point(6, 22);
            this.btnSearchHeroRepoFolder.Name = "btnSearchHeroRepoFolder";
            this.btnSearchHeroRepoFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSearchHeroRepoFolder.TabIndex = 0;
            this.btnSearchHeroRepoFolder.Text = "...";
            this.btnSearchHeroRepoFolder.UseVisualStyleBackColor = true;
            this.btnSearchHeroRepoFolder.Click += new System.EventHandler(this.btnSearchHeroRepoFolder_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblTotalTranslations);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Location = new System.Drawing.Point(466, 71);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(171, 76);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Occurances";
            // 
            // lblTotalTranslations
            // 
            this.lblTotalTranslations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalTranslations.AutoSize = true;
            this.lblTotalTranslations.Location = new System.Drawing.Point(78, 23);
            this.lblTotalTranslations.MaximumSize = new System.Drawing.Size(300, 0);
            this.lblTotalTranslations.Name = "lblTotalTranslations";
            this.lblTotalTranslations.Size = new System.Drawing.Size(13, 15);
            this.lblTotalTranslations.TabIndex = 3;
            this.lblTotalTranslations.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 49);
            this.label1.MaximumSize = new System.Drawing.Size(300, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Translations loaded";
            // 
            // lblSelectedFilePath
            // 
            this.lblSelectedFilePath.AutoSize = true;
            this.lblSelectedFilePath.Location = new System.Drawing.Point(69, 632);
            this.lblSelectedFilePath.MaximumSize = new System.Drawing.Size(500, 0);
            this.lblSelectedFilePath.Name = "lblSelectedFilePath";
            this.lblSelectedFilePath.Size = new System.Drawing.Size(31, 15);
            this.lblSelectedFilePath.TabIndex = 10;
            this.lblSelectedFilePath.Text = "Path";
            // 
            // btnViewFile
            // 
            this.btnViewFile.Image = global::HeroNextTranslator.Properties.Resources.search;
            this.btnViewFile.Location = new System.Drawing.Point(11, 631);
            this.btnViewFile.Name = "btnViewFile";
            this.btnViewFile.Size = new System.Drawing.Size(52, 36);
            this.btnViewFile.TabIndex = 12;
            this.btnViewFile.UseVisualStyleBackColor = true;
            this.btnViewFile.Click += new System.EventHandler(this.btnViewFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 671);
            this.Controls.Add(this.btnViewFile);
            this.Controls.Add(this.lblSelectedFilePath);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pgbProgress);
            this.Controls.Add(this.lbOccurances);
            this.Controls.Add(this.btnStartSearch);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hero Next Translator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Label lblTranslateSourcePath;
        private Button btnSearchTranslateSource;
        private GroupBox groupBox2;
        private Label lblSearchFolderPath;
        private Button btnSelectSearchFolder;
        private Button btnStartSearch;
        private ListBox lbOccurances;
        private ProgressBar pgbProgress;
        private GroupBox groupBox3;
        private TextBox txtTranslationName;
        private GroupBox groupBox4;
        private TextBox txtTranslationValue;
        private Button btnSave;
        private GroupBox groupBox5;
        private Label lblHeroRepoFolder;
        private Button btnSearchHeroRepoFolder;
        private GroupBox groupBox6;
        private Label lblTotalTranslations;
        private Label label1;
        private Label lblSelectedFilePath;
        private Button btnViewFile;
    }
}