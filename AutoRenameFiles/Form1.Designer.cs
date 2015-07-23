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
            this.checkbox_everything = new System.Windows.Forms.CheckBox();
            this.checkbox_video = new System.Windows.Forms.CheckBox();
            this.checkbox_image = new System.Windows.Forms.CheckBox();
            this.radioButtonNoSpace = new System.Windows.Forms.RadioButton();
            this.radioButtonUseSpace = new System.Windows.Forms.RadioButton();
            this.progBar = new System.Windows.Forms.ProgressBar();
            this.outputLabel = new System.Windows.Forms.Label();
            this.dirPath = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonRun = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DestResizeDir = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.maxHeightText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.maxWidthText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.resizeProgBar = new System.Windows.Forms.ProgressBar();
            this.resizeOutputLabel = new System.Windows.Forms.Label();
            this.resizeDir = new System.Windows.Forms.TextBox();
            this.resizeButtonBrowse = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.AutoRename.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // AutoRename
            // 
            this.AutoRename.AccessibleDescription = "";
            this.AutoRename.AccessibleName = "";
            this.AutoRename.Controls.Add(this.tabPage1);
            this.AutoRename.Controls.Add(this.tabPage2);
            this.AutoRename.Location = new System.Drawing.Point(0, 1);
            this.AutoRename.Name = "AutoRename";
            this.AutoRename.SelectedIndex = 0;
            this.AutoRename.Size = new System.Drawing.Size(420, 270);
            this.AutoRename.TabIndex = 10;
            this.AutoRename.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkbox_everything);
            this.tabPage1.Controls.Add(this.checkbox_video);
            this.tabPage1.Controls.Add(this.checkbox_image);
            this.tabPage1.Controls.Add(this.radioButtonNoSpace);
            this.tabPage1.Controls.Add(this.radioButtonUseSpace);
            this.tabPage1.Controls.Add(this.progBar);
            this.tabPage1.Controls.Add(this.outputLabel);
            this.tabPage1.Controls.Add(this.dirPath);
            this.tabPage1.Controls.Add(this.buttonBrowse);
            this.tabPage1.Controls.Add(this.buttonRun);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(412, 244);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Rename";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkbox_everything
            // 
            this.checkbox_everything.AutoSize = true;
            this.checkbox_everything.Location = new System.Drawing.Point(277, 138);
            this.checkbox_everything.Name = "checkbox_everything";
            this.checkbox_everything.Size = new System.Drawing.Size(76, 17);
            this.checkbox_everything.TabIndex = 19;
            this.checkbox_everything.Text = "Everything";
            this.checkbox_everything.UseVisualStyleBackColor = true;
            // 
            // checkbox_video
            // 
            this.checkbox_video.AutoSize = true;
            this.checkbox_video.Location = new System.Drawing.Point(277, 115);
            this.checkbox_video.Name = "checkbox_video";
            this.checkbox_video.Size = new System.Drawing.Size(120, 17);
            this.checkbox_video.TabIndex = 18;
            this.checkbox_video.Text = "Video ( avi, mp4 ... )";
            this.checkbox_video.UseVisualStyleBackColor = true;
            // 
            // checkbox_image
            // 
            this.checkbox_image.AutoSize = true;
            this.checkbox_image.Checked = true;
            this.checkbox_image.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_image.Location = new System.Drawing.Point(277, 92);
            this.checkbox_image.Name = "checkbox_image";
            this.checkbox_image.Size = new System.Drawing.Size(120, 17);
            this.checkbox_image.TabIndex = 17;
            this.checkbox_image.Text = "Image ( jpg, png ... )";
            this.checkbox_image.UseVisualStyleBackColor = true;
            // 
            // radioButtonNoSpace
            // 
            this.radioButtonNoSpace.AutoSize = true;
            this.radioButtonNoSpace.Location = new System.Drawing.Point(30, 84);
            this.radioButtonNoSpace.Name = "radioButtonNoSpace";
            this.radioButtonNoSpace.Size = new System.Drawing.Size(137, 17);
            this.radioButtonNoSpace.TabIndex = 16;
            this.radioButtonNoSpace.Text = "No Space - Ex: pic4.jpg";
            this.radioButtonNoSpace.UseVisualStyleBackColor = true;
            // 
            // radioButtonUseSpace
            // 
            this.radioButtonUseSpace.AutoSize = true;
            this.radioButtonUseSpace.Checked = true;
            this.radioButtonUseSpace.Location = new System.Drawing.Point(30, 61);
            this.radioButtonUseSpace.Name = "radioButtonUseSpace";
            this.radioButtonUseSpace.Size = new System.Drawing.Size(145, 17);
            this.radioButtonUseSpace.TabIndex = 15;
            this.radioButtonUseSpace.TabStop = true;
            this.radioButtonUseSpace.Text = "Use Space - Ex: pic 4.jpg";
            this.radioButtonUseSpace.UseVisualStyleBackColor = true;
            // 
            // progBar
            // 
            this.progBar.Location = new System.Drawing.Point(30, 190);
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(356, 23);
            this.progBar.Step = 1;
            this.progBar.TabIndex = 14;
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(30, 216);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(138, 13);
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
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(277, 24);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 11;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.BackColor = System.Drawing.Color.LightGreen;
            this.buttonRun.Location = new System.Drawing.Point(277, 55);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 10;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.DestResizeDir);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.maxHeightText);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.maxWidthText);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.resizeProgBar);
            this.tabPage2.Controls.Add(this.resizeOutputLabel);
            this.tabPage2.Controls.Add(this.resizeDir);
            this.tabPage2.Controls.Add(this.resizeButtonBrowse);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(412, 244);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(275, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
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
            this.resizeOutputLabel.AutoSize = true;
            this.resizeOutputLabel.Location = new System.Drawing.Point(28, 212);
            this.resizeOutputLabel.Name = "resizeOutputLabel";
            this.resizeOutputLabel.Size = new System.Drawing.Size(138, 13);
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
            this.resizeButtonBrowse.Location = new System.Drawing.Point(275, 30);
            this.resizeButtonBrowse.Name = "resizeButtonBrowse";
            this.resizeButtonBrowse.Size = new System.Drawing.Size(75, 23);
            this.resizeButtonBrowse.TabIndex = 16;
            this.resizeButtonBrowse.Text = "Browse";
            this.resizeButtonBrowse.UseVisualStyleBackColor = true;
            this.resizeButtonBrowse.Click += new System.EventHandler(this.resizeButtonBrowse_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightGreen;
            this.button2.Location = new System.Drawing.Point(275, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Run";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 269);
            this.Controls.Add(this.AutoRename);
            this.Name = "Form1";
            this.Text = "AutoRename";
            this.AutoRename.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabControl AutoRename;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox checkbox_everything;
        private System.Windows.Forms.CheckBox checkbox_video;
        private System.Windows.Forms.CheckBox checkbox_image;
        private System.Windows.Forms.RadioButton radioButtonNoSpace;
        private System.Windows.Forms.RadioButton radioButtonUseSpace;
        private System.Windows.Forms.ProgressBar progBar;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.TextBox dirPath;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ProgressBar resizeProgBar;
        private System.Windows.Forms.Label resizeOutputLabel;
        private System.Windows.Forms.TextBox resizeDir;
        private System.Windows.Forms.Button resizeButtonBrowse;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox maxHeightText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox maxWidthText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DestResizeDir;
        private System.Windows.Forms.Button button1;
    }
}

