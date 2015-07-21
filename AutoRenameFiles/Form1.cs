using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AutoRenameFiles
{
    public partial class Form1 : Form
    {
        public readonly List<string> IMAGE_EXTENSION_LIST = new List<string>()
        {
            ".jpg",
            ".jpeg",
            ".png",
            ".tif",
            ".gif"
        };

        public readonly List<string> VIDEO_EXTENSION_LIST = new List<string>()
        {
            ".avi",
            ".mov",
            ".mp4",
        };


        public Form1()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            RenameFiles(dirPath.Text, radioButtonUseSpace.Checked);
        }

        //-----------------------------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = dirPath.Text;

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                dirPath.Text = folderBrowser.SelectedPath;
            }
        }

        //-----------------------------------------------------------------------------
        public void RenameFiles(string rootDirPath, bool useSpace)
        {
            if (!Directory.Exists(rootDirPath))
            {
                outputLabel.Text = "Invalid directory path";
                return;
            }

            RenameFiles(Directory.GetFiles(rootDirPath), Path.GetDirectoryName(rootDirPath), "TEMP", useSpace);
            RenameFiles(Directory.GetFiles(rootDirPath), Path.GetDirectoryName(rootDirPath), "", useSpace);

            string[] allDirectories = Directory.GetDirectories(rootDirPath, "*", SearchOption.AllDirectories);
            progBar.Value = 0;
            progBar.Maximum = allDirectories.Count();
            foreach (string directoryPath in allDirectories)
            {
                outputLabel.Text = "Renaming files in " + directoryPath;
                RenameFiles(Directory.GetFiles(directoryPath), Path.GetDirectoryName(directoryPath), "TEMP", useSpace);
                RenameFiles(Directory.GetFiles(directoryPath), Path.GetDirectoryName(directoryPath), "", useSpace);
                progBar.PerformStep();
            }

            outputLabel.Text = "Completed";
        }

        //-----------------------------------------------------------------------------
        public void RenameFiles(string[] filePaths, string prefix, string specialPrefix, bool useSpace)
        {
            int postfixDigit = 1;
            string nameDigitSpace = useSpace ? " " : "";
            foreach (string filePath in filePaths)
            {
                if (!ExtensionAllowed(Path.GetExtension(filePath)))
                    continue;

                string newPath = Path.GetDirectoryName(filePath) + Path.DirectorySeparatorChar +
                                Directory.GetParent(filePath).Name + nameDigitSpace + postfixDigit.ToString("000") + specialPrefix + Path.GetExtension(filePath);
                File.Move(filePath, newPath);
                postfixDigit++;
            }
        }

        //-----------------------------------------------------------------------------
        public bool ExtensionAllowed(string extension)
        {
            if (checkbox_everything.Checked)
                return true;

            if (checkbox_image.Checked && IMAGE_EXTENSION_LIST.Contains(extension.ToLower()))
                return true;

            if (checkbox_video.Checked && VIDEO_EXTENSION_LIST.Contains(extension.ToLower()))
                return true;

            return false;
        }

        //-----------------------------------------------------------------------------
        public void Log(string message)
        {
            System.Diagnostics.Debug.Write("\n" + message);
        }
    }
}
