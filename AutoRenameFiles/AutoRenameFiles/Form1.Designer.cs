namespace AutoRenameFiles
{
    partial class Form1
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.AutoRename = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.nameVideoCheckbox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.radioButtonNoSpace = new System.Windows.Forms.RadioButton();
            this.radioButtonUseSpace = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkbox_everything = new System.Windows.Forms.CheckBox();
            this.checkbox_video = new System.Windows.Forms.CheckBox();
            this.checkbox_image = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DescRadioButton = new System.Windows.Forms.RadioButton();
            this.AscRadioButton = new System.Windows.Forms.RadioButton();
            this.NumberOnDateCheckbox = new System.Windows.Forms.CheckBox();
            this.progBar = new System.Windows.Forms.ProgressBar();
            this.outputLabel = new System.Windows.Forms.Label();
            this.dirPath = new System.Windows.Forms.TextBox();
            this.renameButtonBrowse = new System.Windows.Forms.Button();
            this.renameButtonRun = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DestResizeDir = new System.Windows.Forms.TextBox();
            this.resizeDestBrwsButton = new System.Windows.Forms.Button();
            this.maxHeightText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.maxWidthText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.resizeProgBar = new System.Windows.Forms.ProgressBar();
            this.resizeOutputLabel = new System.Windows.Forms.Label();
            this.resizeDir = new System.Windows.Forms.TextBox();
            this.resizeButtonBrowse = new System.Windows.Forms.Button();
            this.resizeButtonRun = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.deleteEmptyDirs = new System.Windows.Forms.CheckBox();
            this.flattenFilesOutputLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flattenDir = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dupeLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dupeDir = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.AutoRename.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // AutoRename
            // 
            this.AutoRename.AccessibleDescription = "";
            this.AutoRename.AccessibleName = "";
            this.AutoRename.Controls.Add(this.tabPage1);
            this.AutoRename.Controls.Add(this.tabPage2);
            this.AutoRename.Controls.Add(this.tabPage3);
            this.AutoRename.Controls.Add(this.tabPage4);
            this.AutoRename.Location = new System.Drawing.Point(3, 1);
            this.AutoRename.Name = "AutoRename";
            this.AutoRename.SelectedIndex = 0;
            this.AutoRename.Size = new System.Drawing.Size(451, 382);
            this.AutoRename.TabIndex = 10;
            this.AutoRename.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.progBar);
            this.tabPage1.Controls.Add(this.outputLabel);
            this.tabPage1.Controls.Add(this.dirPath);
            this.tabPage1.Controls.Add(this.renameButtonBrowse);
            this.tabPage1.Controls.Add(this.renameButtonRun);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(443, 356);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Rename";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.nameVideoCheckbox);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.radioButtonNoSpace);
            this.panel3.Controls.Add(this.radioButtonUseSpace);
            this.panel3.Location = new System.Drawing.Point(30, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(209, 97);
            this.panel3.TabIndex = 26;
            // 
            // nameVideoCheckbox
            // 
            this.nameVideoCheckbox.AutoSize = true;
            this.nameVideoCheckbox.Location = new System.Drawing.Point(11, 70);
            this.nameVideoCheckbox.Name = "nameVideoCheckbox";
            this.nameVideoCheckbox.Size = new System.Drawing.Size(191, 17);
            this.nameVideoCheckbox.TabIndex = 23;
            this.nameVideoCheckbox.Text = "Add \'Video\' - Ex: party Video 1.mp4";
            this.nameVideoCheckbox.UseVisualStyleBackColor = true;
            this.nameVideoCheckbox.CheckedChanged += new System.EventHandler(this.nameVideoCheckbox_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Options";
            // 
            // radioButtonNoSpace
            // 
            this.radioButtonNoSpace.AutoSize = true;
            this.radioButtonNoSpace.Location = new System.Drawing.Point(11, 45);
            this.radioButtonNoSpace.Name = "radioButtonNoSpace";
            this.radioButtonNoSpace.Size = new System.Drawing.Size(137, 17);
            this.radioButtonNoSpace.TabIndex = 18;
            this.radioButtonNoSpace.Text = "No Space - Ex: pic4.jpg";
            this.radioButtonNoSpace.UseVisualStyleBackColor = true;
            // 
            // radioButtonUseSpace
            // 
            this.radioButtonUseSpace.AutoSize = true;
            this.radioButtonUseSpace.Checked = true;
            this.radioButtonUseSpace.Location = new System.Drawing.Point(11, 22);
            this.radioButtonUseSpace.Name = "radioButtonUseSpace";
            this.radioButtonUseSpace.Size = new System.Drawing.Size(145, 17);
            this.radioButtonUseSpace.TabIndex = 17;
            this.radioButtonUseSpace.TabStop = true;
            this.radioButtonUseSpace.Text = "Use Space - Ex: pic 4.jpg";
            this.radioButtonUseSpace.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkbox_everything);
            this.panel2.Controls.Add(this.checkbox_video);
            this.panel2.Controls.Add(this.checkbox_image);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(245, 125);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(141, 100);
            this.panel2.TabIndex = 24;
            this.panel2.Tag = "";
            // 
            // checkbox_everything
            // 
            this.checkbox_everything.AutoSize = true;
            this.checkbox_everything.Location = new System.Drawing.Point(19, 73);
            this.checkbox_everything.Name = "checkbox_everything";
            this.checkbox_everything.Size = new System.Drawing.Size(76, 17);
            this.checkbox_everything.TabIndex = 22;
            this.checkbox_everything.Text = "Everything";
            this.checkbox_everything.UseVisualStyleBackColor = true;
            // 
            // checkbox_video
            // 
            this.checkbox_video.AutoSize = true;
            this.checkbox_video.Checked = true;
            this.checkbox_video.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_video.Location = new System.Drawing.Point(19, 50);
            this.checkbox_video.Name = "checkbox_video";
            this.checkbox_video.Size = new System.Drawing.Size(120, 17);
            this.checkbox_video.TabIndex = 21;
            this.checkbox_video.Text = "Video ( avi, mp4 ... )";
            this.checkbox_video.UseVisualStyleBackColor = true;
            // 
            // checkbox_image
            // 
            this.checkbox_image.AutoSize = true;
            this.checkbox_image.Checked = true;
            this.checkbox_image.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_image.Location = new System.Drawing.Point(19, 27);
            this.checkbox_image.Name = "checkbox_image";
            this.checkbox_image.Size = new System.Drawing.Size(120, 17);
            this.checkbox_image.TabIndex = 20;
            this.checkbox_image.Text = "Image ( jpg, png ... )";
            this.checkbox_image.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Rename Files";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.Controls.Add(this.DescRadioButton);
            this.panel1.Controls.Add(this.AscRadioButton);
            this.panel1.Controls.Add(this.NumberOnDateCheckbox);
            this.panel1.Location = new System.Drawing.Point(30, 166);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(142, 59);
            this.panel1.TabIndex = 23;
            // 
            // DescRadioButton
            // 
            this.DescRadioButton.AutoSize = true;
            this.DescRadioButton.Location = new System.Drawing.Point(52, 26);
            this.DescRadioButton.Name = "DescRadioButton";
            this.DescRadioButton.Size = new System.Drawing.Size(50, 17);
            this.DescRadioButton.TabIndex = 25;
            this.DescRadioButton.Text = "Desc";
            this.DescRadioButton.UseVisualStyleBackColor = true;
            // 
            // AscRadioButton
            // 
            this.AscRadioButton.AutoSize = true;
            this.AscRadioButton.Checked = true;
            this.AscRadioButton.Location = new System.Drawing.Point(3, 26);
            this.AscRadioButton.Name = "AscRadioButton";
            this.AscRadioButton.Size = new System.Drawing.Size(43, 17);
            this.AscRadioButton.TabIndex = 24;
            this.AscRadioButton.TabStop = true;
            this.AscRadioButton.Text = "Asc";
            this.AscRadioButton.UseVisualStyleBackColor = true;
            // 
            // NumberOnDateCheckbox
            // 
            this.NumberOnDateCheckbox.AutoSize = true;
            this.NumberOnDateCheckbox.Location = new System.Drawing.Point(3, 3);
            this.NumberOnDateCheckbox.Name = "NumberOnDateCheckbox";
            this.NumberOnDateCheckbox.Size = new System.Drawing.Size(136, 17);
            this.NumberOnDateCheckbox.TabIndex = 23;
            this.NumberOnDateCheckbox.Text = "Number based on Date";
            this.NumberOnDateCheckbox.UseVisualStyleBackColor = true;
            // 
            // progBar
            // 
            this.progBar.Location = new System.Drawing.Point(30, 248);
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(356, 23);
            this.progBar.Step = 1;
            this.progBar.TabIndex = 14;
            // 
            // outputLabel
            // 
            this.outputLabel.Location = new System.Drawing.Point(30, 274);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(356, 79);
            this.outputLabel.TabIndex = 13;
            this.outputLabel.Text = "Please choose the directory";
            // 
            // dirPath
            // 
            this.dirPath.Location = new System.Drawing.Point(30, 24);
            this.dirPath.Name = "dirPath";
            this.dirPath.Size = new System.Drawing.Size(241, 20);
            this.dirPath.TabIndex = 12;
            // 
            // renameButtonBrowse
            // 
            this.renameButtonBrowse.Location = new System.Drawing.Point(311, 21);
            this.renameButtonBrowse.Name = "renameButtonBrowse";
            this.renameButtonBrowse.Size = new System.Drawing.Size(75, 23);
            this.renameButtonBrowse.TabIndex = 11;
            this.renameButtonBrowse.Text = "Browse";
            this.renameButtonBrowse.UseVisualStyleBackColor = true;
            this.renameButtonBrowse.Click += new System.EventHandler(this.renameButtonBrowse_Click);
            // 
            // renameButtonRun
            // 
            this.renameButtonRun.BackColor = System.Drawing.Color.LightGreen;
            this.renameButtonRun.Location = new System.Drawing.Point(311, 55);
            this.renameButtonRun.Name = "renameButtonRun";
            this.renameButtonRun.Size = new System.Drawing.Size(75, 23);
            this.renameButtonRun.TabIndex = 10;
            this.renameButtonRun.Text = "Run";
            this.renameButtonRun.UseVisualStyleBackColor = false;
            this.renameButtonRun.Click += new System.EventHandler(this.renameButtonRun_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.DestResizeDir);
            this.tabPage2.Controls.Add(this.resizeDestBrwsButton);
            this.tabPage2.Controls.Add(this.maxHeightText);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.maxWidthText);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.resizeProgBar);
            this.tabPage2.Controls.Add(this.resizeOutputLabel);
            this.tabPage2.Controls.Add(this.resizeDir);
            this.tabPage2.Controls.Add(this.resizeButtonBrowse);
            this.tabPage2.Controls.Add(this.resizeButtonRun);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(442, 360);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Resize";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Dest Path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Source Path";
            // 
            // DestResizeDir
            // 
            this.DestResizeDir.Location = new System.Drawing.Point(28, 145);
            this.DestResizeDir.Name = "DestResizeDir";
            this.DestResizeDir.Size = new System.Drawing.Size(241, 20);
            this.DestResizeDir.TabIndex = 25;
            // 
            // resizeDestBrwsButton
            // 
            this.resizeDestBrwsButton.Location = new System.Drawing.Point(275, 145);
            this.resizeDestBrwsButton.Name = "resizeDestBrwsButton";
            this.resizeDestBrwsButton.Size = new System.Drawing.Size(75, 23);
            this.resizeDestBrwsButton.TabIndex = 24;
            this.resizeDestBrwsButton.Text = "Browse";
            this.resizeDestBrwsButton.UseVisualStyleBackColor = true;
            this.resizeDestBrwsButton.Click += new System.EventHandler(this.resizeDestBrwsButton_Click);
            // 
            // maxHeightText
            // 
            this.maxHeightText.Location = new System.Drawing.Point(224, 89);
            this.maxHeightText.Name = "maxHeightText";
            this.maxHeightText.Size = new System.Drawing.Size(43, 20);
            this.maxHeightText.TabIndex = 23;
            this.maxHeightText.Text = "600";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Max Height";
            // 
            // maxWidthText
            // 
            this.maxWidthText.Location = new System.Drawing.Point(92, 89);
            this.maxWidthText.Name = "maxWidthText";
            this.maxWidthText.Size = new System.Drawing.Size(43, 20);
            this.maxWidthText.TabIndex = 21;
            this.maxWidthText.Text = "800";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Max Width";
            // 
            // resizeProgBar
            // 
            this.resizeProgBar.Location = new System.Drawing.Point(28, 186);
            this.resizeProgBar.Name = "resizeProgBar";
            this.resizeProgBar.Size = new System.Drawing.Size(356, 23);
            this.resizeProgBar.Step = 1;
            this.resizeProgBar.TabIndex = 19;
            // 
            // resizeOutputLabel
            // 
            this.resizeOutputLabel.Location = new System.Drawing.Point(28, 212);
            this.resizeOutputLabel.Name = "resizeOutputLabel";
            this.resizeOutputLabel.Size = new System.Drawing.Size(356, 73);
            this.resizeOutputLabel.TabIndex = 18;
            this.resizeOutputLabel.Text = "Please choose the directory";
            // 
            // resizeDir
            // 
            this.resizeDir.Location = new System.Drawing.Point(28, 30);
            this.resizeDir.Name = "resizeDir";
            this.resizeDir.Size = new System.Drawing.Size(241, 20);
            this.resizeDir.TabIndex = 17;
            // 
            // resizeButtonBrowse
            // 
            this.resizeButtonBrowse.Location = new System.Drawing.Point(324, 28);
            this.resizeButtonBrowse.Name = "resizeButtonBrowse";
            this.resizeButtonBrowse.Size = new System.Drawing.Size(75, 23);
            this.resizeButtonBrowse.TabIndex = 16;
            this.resizeButtonBrowse.Text = "Browse";
            this.resizeButtonBrowse.UseVisualStyleBackColor = true;
            this.resizeButtonBrowse.Click += new System.EventHandler(this.resizeButtonBrowse_Click);
            // 
            // resizeButtonRun
            // 
            this.resizeButtonRun.BackColor = System.Drawing.Color.LightGreen;
            this.resizeButtonRun.Location = new System.Drawing.Point(324, 69);
            this.resizeButtonRun.Name = "resizeButtonRun";
            this.resizeButtonRun.Size = new System.Drawing.Size(75, 23);
            this.resizeButtonRun.TabIndex = 15;
            this.resizeButtonRun.Text = "Run";
            this.resizeButtonRun.UseVisualStyleBackColor = false;
            this.resizeButtonRun.Click += new System.EventHandler(this.resizeButtonRun_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.deleteEmptyDirs);
            this.tabPage3.Controls.Add(this.flattenFilesOutputLabel);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.flattenDir);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(442, 360);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Flatten";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // deleteEmptyDirs
            // 
            this.deleteEmptyDirs.AutoSize = true;
            this.deleteEmptyDirs.Location = new System.Drawing.Point(249, 133);
            this.deleteEmptyDirs.Name = "deleteEmptyDirs";
            this.deleteEmptyDirs.Size = new System.Drawing.Size(142, 17);
            this.deleteEmptyDirs.TabIndex = 20;
            this.deleteEmptyDirs.Text = "Delete Empty Directories";
            this.deleteEmptyDirs.UseVisualStyleBackColor = true;
            // 
            // flattenFilesOutputLabel
            // 
            this.flattenFilesOutputLabel.Location = new System.Drawing.Point(32, 107);
            this.flattenFilesOutputLabel.Name = "flattenFilesOutputLabel";
            this.flattenFilesOutputLabel.Size = new System.Drawing.Size(211, 191);
            this.flattenFilesOutputLabel.TabIndex = 19;
            this.flattenFilesOutputLabel.Text = "Please choose the directory";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "This will put all files in the selected folder";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // flattenDir
            // 
            this.flattenDir.Location = new System.Drawing.Point(35, 51);
            this.flattenDir.Name = "flattenDir";
            this.flattenDir.Size = new System.Drawing.Size(241, 20);
            this.flattenDir.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(316, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightGreen;
            this.button2.Location = new System.Drawing.Point(316, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Run";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dupeLabel);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.dupeDir);
            this.tabPage4.Controls.Add(this.button3);
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(442, 360);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Duplicates";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dupeLabel
            // 
            this.dupeLabel.Location = new System.Drawing.Point(28, 98);
            this.dupeLabel.Name = "dupeLabel";
            this.dupeLabel.Size = new System.Drawing.Size(265, 230);
            this.dupeLabel.TabIndex = 21;
            this.dupeLabel.Text = "Please choose the directory";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "This will remove duplicate files";
            // 
            // dupeDir
            // 
            this.dupeDir.Location = new System.Drawing.Point(31, 56);
            this.dupeDir.Name = "dupeDir";
            this.dupeDir.Size = new System.Drawing.Size(241, 20);
            this.dupeDir.TabIndex = 19;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(312, 53);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "Browse";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightGreen;
            this.button4.Location = new System.Drawing.Point(312, 93);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "Run";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 387);
            this.Controls.Add(this.AutoRename);
            this.Name = "Form1";
            this.Text = "AutoRename";
            this.AutoRename.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabControl AutoRename;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ProgressBar progBar;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.TextBox dirPath;
        private System.Windows.Forms.Button renameButtonBrowse;
        private System.Windows.Forms.Button renameButtonRun;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ProgressBar resizeProgBar;
        private System.Windows.Forms.Label resizeOutputLabel;
        private System.Windows.Forms.TextBox resizeDir;
        private System.Windows.Forms.Button resizeButtonBrowse;
        private System.Windows.Forms.Button resizeButtonRun;
        private System.Windows.Forms.TextBox maxHeightText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox maxWidthText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DestResizeDir;
        private System.Windows.Forms.Button resizeDestBrwsButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox flattenDir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label flattenFilesOutputLabel;
        private System.Windows.Forms.CheckBox deleteEmptyDirs;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label dupeLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox dupeDir;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton DescRadioButton;
        private System.Windows.Forms.RadioButton AscRadioButton;
        private System.Windows.Forms.CheckBox NumberOnDateCheckbox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox nameVideoCheckbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButtonNoSpace;
        private System.Windows.Forms.RadioButton radioButtonUseSpace;
        private System.Windows.Forms.CheckBox checkbox_everything;
        private System.Windows.Forms.CheckBox checkbox_video;
        private System.Windows.Forms.CheckBox checkbox_image;
    }
}

