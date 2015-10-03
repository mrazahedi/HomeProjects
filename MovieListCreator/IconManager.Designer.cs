namespace DIconManager
{
	partial class IconManager
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
            this.label1 = new System.Windows.Forms.Label();
            this.sourceDir_txt = new System.Windows.Forms.TextBox();
            this.destDir_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Make the Movie List";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Movie Directory:";
            // 
            // sourceDir_txt
            // 
            this.sourceDir_txt.Location = new System.Drawing.Point(115, 24);
            this.sourceDir_txt.Name = "sourceDir_txt";
            this.sourceDir_txt.Size = new System.Drawing.Size(166, 20);
            this.sourceDir_txt.TabIndex = 2;
            this.sourceDir_txt.Text = "E:\\Movies";
            // 
            // destDir_txt
            // 
            this.destDir_txt.Location = new System.Drawing.Point(115, 71);
            this.destDir_txt.Name = "destDir_txt";
            this.destDir_txt.Size = new System.Drawing.Size(166, 20);
            this.destDir_txt.TabIndex = 4;
            this.destDir_txt.Text = "E:\\Movies\\movieList.txt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output Directory:";
            // 
            // IconManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 207);
            this.Controls.Add(this.destDir_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sourceDir_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "IconManager";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sourceDir_txt;
        private System.Windows.Forms.TextBox destDir_txt;
        private System.Windows.Forms.Label label2;
	}
}

