using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Windows;
using System.IO;
using IWshRuntimeLibrary;



namespace DIconManager
{
	public partial class IconManager : Form
	{		
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public extern static IntPtr GetDesktopWindow();

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public extern static bool UpdateWindow(IntPtr wnd);

		ArrayList DesktopIcons; //Contains all desktop icons

		/// <summary>
		/// Constructor
		/// </summary>
		public IconManager()
		{
			InitializeComponent();
			Initialize();
		}

		/// <summary>
		/// Initializer
		/// </summary>
		public void Initialize()
		{
			DesktopIcons = new ArrayList();
		}

        private void button1_Click(object sender, EventArgs e)
        {

            TextWriter textWriter = new StreamWriter(destDir_txt.Text);
            
            DirectoryInfo myDIR = new DirectoryInfo(sourceDir_txt.Text);
            DirectoryInfo[] CategoryFolder = myDIR.GetDirectories();
            
            foreach (DirectoryInfo currentCategory in CategoryFolder)
            {
                textWriter.WriteLine("--------------------------------------------------------------");
                textWriter.WriteLine(currentCategory.Name);
                textWriter.WriteLine("--------------------------------------------------------------");
                DirectoryInfo[] movieFolder = currentCategory.GetDirectories();
                foreach (DirectoryInfo currentMovie in movieFolder)
                {
                    textWriter.WriteLine(currentMovie.Name);
                }
                textWriter.WriteLine("\n");
                textWriter.WriteLine("\n");
            }

            // close the stream
            textWriter.Close();
        }
	}
}