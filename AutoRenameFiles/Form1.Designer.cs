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
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dirPath = new System.Windows.Forms.TextBox();
            this.outputLabel = new System.Windows.Forms.Label();
            this.progBar = new System.Windows.Forms.ProgressBar();
            this.radioButtonUseSpace = new System.Windows.Forms.RadioButton();
            this.radioButtonNoSpace = new System.Windows.Forms.RadioButton();
            this.checkbox_image = new System.Windows.Forms.CheckBox();
            this.checkbox_video = new System.Windows.Forms.CheckBox();
            this.checkbox_everything = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonRun
            // 
            this.buttonRun.BackColor = System.Drawing.Color.LightGreen;
            this.buttonRun.Location = new System.Drawing.Point(259, 43);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 0;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = false;
            this.buttonRun.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(259, 12);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 1;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.button2_Click);
            // 
            // dirPath
            // 
            this.dirPath.Location = new System.Drawing.Point(12, 12);
            this.dirPath.Name = "dirPath";
            this.dirPath.Size = new System.Drawing.Size(241, 20);
            this.dirPath.TabIndex = 2;
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(12, 204);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(138, 13);
            this.outputLabel.TabIndex = 3;
            this.outputLabel.Text = "Please choose the directory";
            // 
            // progBar
            // 
            this.progBar.Location = new System.Drawing.Point(12, 178);
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(356, 23);
            this.progBar.Step = 1;
            this.progBar.TabIndex = 4;
            // 
            // radioButtonUseSpace
            // 
            this.radioButtonUseSpace.AutoSize = true;
            this.radioButtonUseSpace.Location = new System.Drawing.Point(12, 72);
            this.radioButtonUseSpace.Name = "radioButtonUseSpace";
            this.radioButtonUseSpace.Size = new System.Drawing.Size(145, 17);
            this.radioButtonUseSpace.TabIndex = 5;
            this.radioButtonUseSpace.Text = "Use Space - Ex: pic 4.jpg";
            this.radioButtonUseSpace.UseVisualStyleBackColor = true;
            // 
            // radioButtonNoSpace
            // 
            this.radioButtonNoSpace.AutoSize = true;
            this.radioButtonNoSpace.Checked = true;
            this.radioButtonNoSpace.Location = new System.Drawing.Point(12, 49);
            this.radioButtonNoSpace.Name = "radioButtonNoSpace";
            this.radioButtonNoSpace.Size = new System.Drawing.Size(137, 17);
            this.radioButtonNoSpace.TabIndex = 6;
            this.radioButtonNoSpace.TabStop = true;
            this.radioButtonNoSpace.Text = "No Space - Ex: pic4.jpg";
            this.radioButtonNoSpace.UseVisualStyleBackColor = true;
            // 
            // checkbox_image
            // 
            this.checkbox_image.AutoSize = true;
            this.checkbox_image.Checked = true;
            this.checkbox_image.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_image.Location = new System.Drawing.Point(259, 80);
            this.checkbox_image.Name = "checkbox_image";
            this.checkbox_image.Size = new System.Drawing.Size(120, 17);
            this.checkbox_image.TabIndex = 7;
            this.checkbox_image.Text = "Image ( jpg, png ... )";
            this.checkbox_image.UseVisualStyleBackColor = true;
            // 
            // checkbox_video
            // 
            this.checkbox_video.AutoSize = true;
            this.checkbox_video.Location = new System.Drawing.Point(259, 103);
            this.checkbox_video.Name = "checkbox_video";
            this.checkbox_video.Size = new System.Drawing.Size(120, 17);
            this.checkbox_video.TabIndex = 8;
            this.checkbox_video.Text = "Video ( avi, mp4 ... )";
            this.checkbox_video.UseVisualStyleBackColor = true;
            // 
            // checkbox_everything
            // 
            this.checkbox_everything.AutoSize = true;
            this.checkbox_everything.Location = new System.Drawing.Point(259, 126);
            this.checkbox_everything.Name = "checkbox_everything";
            this.checkbox_everything.Size = new System.Drawing.Size(76, 17);
            this.checkbox_everything.TabIndex = 9;
            this.checkbox_everything.Text = "Everything";
            this.checkbox_everything.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 260);
            this.Controls.Add(this.checkbox_everything);
            this.Controls.Add(this.checkbox_video);
            this.Controls.Add(this.checkbox_image);
            this.Controls.Add(this.radioButtonNoSpace);
            this.Controls.Add(this.radioButtonUseSpace);
            this.Controls.Add(this.progBar);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.dirPath);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.buttonRun);
            this.Name = "Form1";
            this.Text = "AutoRename";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox dirPath;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.ProgressBar progBar;
        private System.Windows.Forms.RadioButton radioButtonUseSpace;
        private System.Windows.Forms.RadioButton radioButtonNoSpace;
        private System.Windows.Forms.CheckBox checkbox_image;
        private System.Windows.Forms.CheckBox checkbox_video;
        private System.Windows.Forms.CheckBox checkbox_everything;
    }
}

