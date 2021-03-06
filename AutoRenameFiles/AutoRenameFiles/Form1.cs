﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Collections;
using System.Drawing.Imaging;

namespace AutoRenameFiles
{
    public partial class Form1 : Form
    {
        public static readonly List<string> IMAGE_EXTENSION_LIST = new List<string>()
        {
            ".jpg",
            ".jpeg",
            ".png",
            ".tif",
            ".gif"
        };

        public static readonly List<string> VIDEO_EXTENSION_LIST = new List<string>()
        {
            ".avi",
            ".mov",
            ".mp4",
        };

        public class FileCreationInfo
        {
            public string _path = null;
            public string _tempPath = null;
            public System.DateTime _creationDate = System.DateTime.Now;

            public FileCreationInfo(string filePath, bool retrieveTakenTime)
            {
                _path = filePath;
                _tempPath = filePath;
                if (retrieveTakenTime)
                {
                    _creationDate = GetDateTakenFromImage(_path);
                }
            }

            public DateTime GetDateTakenFromImage(string path)
            {
                System.DateTime time = System.DateTime.Now;

                //if (!IMAGE_EXTENSION_LIST.Contains(System.IO.Path.GetExtension(path).ToLower()))
                //  return time;
                if (!IsImage(System.IO.Path.GetExtension(path)))
                    return time;

                System.Drawing.Image myImage = Image.FromFile(path);
                try
                {
                    System.Drawing.Imaging.PropertyItem propItem = myImage.GetPropertyItem(36867);
                    time = System.DateTime.Parse(new System.Text.RegularExpressions.Regex(":").Replace(System.Text.Encoding.UTF8.GetString(propItem.Value), "-", 2));
                }
                catch
                {
                    System.Diagnostics.Debug.Write("\n" + "was not able to find creation date for " + path);
                }
                myImage.Dispose();
                return time;
            }

            public static bool IsImage(string extension)
            {
                switch (extension.ToLower())
                {
                    case (".jpg"):
                        return true;
                    case (".png"):
                        return true;
                    case (".bmp"):
                        return true;
                    case (".gif"):
                        return true;
                    case (".jpeg"):
                        return true;
                    case (".tiff"):
                        return true;
                }
                return false;
            }
        }

        public class CreationDateComparer : IComparer<FileCreationInfo>
        {
            private bool _ascending = true;
            public CreationDateComparer(bool asc)
            {
                _ascending = asc;
            }

            // Call CaseInsensitiveComparer.Compare with the parameters reversed.
            public int Compare(FileCreationInfo x, FileCreationInfo y)
            {
                if(_ascending)
                    return x._creationDate.CompareTo(y._creationDate);
                else
                    return y._creationDate.CompareTo(x._creationDate);
            }
        }

        //-----------------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
            DestResizeDir.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + Path.DirectorySeparatorChar + "ResizedImages";
        }

        //-----------------------------------------------------------------------------
        private void renameButtonRun_Click(object sender, EventArgs e)
        {
            RenameFiles(dirPath.Text, radioButtonUseSpace.Checked, nameVideoCheckbox.Checked);
        }

        //-----------------------------------------------------------------------------
        private void renameButtonBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = dirPath.Text;

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                dirPath.Text = folderBrowser.SelectedPath;
            }
        }

        //-----------------------------------------------------------------------------
        private List<FileCreationInfo> GetFileCreationInfoList(string[] filePaths, bool retrieveTakenTime)
        {
            List<FileCreationInfo> filePathInfoList = new List<FileCreationInfo>();
            foreach (string path in filePaths)
            {
                UpdateStatusBoard(Color.Black, "Retrieving data for " + path);
                filePathInfoList.Add(new FileCreationInfo(path, retrieveTakenTime));
            }
            if (NumberOnDateCheckbox.Checked)
            {
                UpdateStatusBoard(Color.Black, "Sorting files");
                CreationDateComparer comparer = new CreationDateComparer(AscRadioButton.Checked);
                filePathInfoList.Sort(comparer);
                //Array.Sort(filePaths, comparer);
            }

            return filePathInfoList;
        }

        //-----------------------------------------------------------------------------
        public void RenameFiles(string rootDirPath, bool useSpace, bool prefixVideos)
        {
            if (!Directory.Exists(rootDirPath))
            {
                outputLabel.ForeColor = Color.Red;
                outputLabel.Text = "Invalid directory path";
                return;
            }

            List<string> dirList = new List<string>();
            dirList.Add(rootDirPath);
            dirList.AddRange(Directory.GetDirectories(rootDirPath, "*", SearchOption.AllDirectories));

            outputLabel.ForeColor = Color.Black;
            progBar.BeginInvoke(new Action(() =>
            {
                progBar.Value = 0;
                progBar.Maximum = dirList.Count();
            }));

            List<FileCreationInfo> _fileInfoList;
            new Thread(new ThreadStart(() =>
            {
                UpdateStatusBoard(Color.Black, "Retrieving File Info");
                foreach (string directoryPath in dirList)
                {
                    UpdateStatusBoard(Color.Black, "Renaming files in " + directoryPath);

                    _fileInfoList = GetFileCreationInfoList(Directory.GetFiles(directoryPath), NumberOnDateCheckbox.Checked);                    
                    RenameFiles(_fileInfoList, Path.GetDirectoryName(directoryPath), useSpace, prefixVideos);

                    progBar.BeginInvoke(new Action(() =>
                    {
                        progBar.PerformStep();
                    }));
                }
                UpdateStatusBoard(Color.Green, "Completed");
            })).Start();
        }

        //-----------------------------------------------------------------------------
        public void UpdateStatusBoard(Color color, string message)
        {
            outputLabel.BeginInvoke(new Action(() =>
            {
                outputLabel.ForeColor = color;
                outputLabel.Text = message;
            }));
        }

        //-----------------------------------------------------------------------------
        public void RenameFiles(List<FileCreationInfo> filePathInfoList, string prefix, bool useSpace, bool prefixVideos)
        {
            int postfixDigit = 1;
            string nameDigitSpace = useSpace ? " " : "";
            string prefixVideoString = prefixVideos ? ("Video" + nameDigitSpace) : "";

            bool isImage = false;
            bool isVideo = false;

            //We need to run two passes. One to posfix with TEMP and one to clean it up. This is to avoid clashing names
            string tempPrefix = "TEMP";
            for (int i = 0; i < 2; ++i)
            {
                postfixDigit = 1;
                if (i == 1)
                {
                    tempPrefix = "";
                }
                foreach (FileCreationInfo filePathInfo in filePathInfoList)
                {
                    string filePath = filePathInfo._path;
                    isImage = false;
                    isVideo = false;

                    if (!ExtensionAllowed(Path.GetExtension(filePath), ref isImage, ref isVideo))
                        continue;

                    string prefixVidStr = "";
                    if (isVideo)
                    {
                        prefixVidStr = prefixVideoString;
                    }

                    string newPath = Path.GetDirectoryName(filePath) + Path.DirectorySeparatorChar +
                                    Directory.GetParent(filePath).Name + nameDigitSpace + prefixVidStr + postfixDigit.ToString("000") + tempPrefix + Path.GetExtension(filePath);

                    if (i == 0)
                    {
                        filePathInfo._tempPath = newPath;
                    }
                    else
                    {
                        filePath = filePathInfo._tempPath;
                    }

                    File.Move(filePath, newPath);
                    postfixDigit++;
                }
            }
        }

        //-----------------------------------------------------------------------------
        public bool ExtensionAllowed(string extension, ref bool isImage, ref bool isVideo)
        {
            if (checkbox_everything.Checked)
                return true;

            if (checkbox_image.Checked && IMAGE_EXTENSION_LIST.Contains(extension.ToLower()))
            {
                isImage = true;
                return true;
            }

            if (checkbox_video.Checked && VIDEO_EXTENSION_LIST.Contains(extension.ToLower()))
            {
                isVideo = true;
                return true;
            }

            return false;
        }

        //-----------------------------------------------------------------------------
        public void ResizeFiles(string rootDirPath, string destDirPath, string maxWidthT, string maxHeightT)
        {
            if (!Directory.Exists(rootDirPath))
            {
                resizeOutputLabel.ForeColor = Color.Red;
                resizeOutputLabel.Text = "Invalid source directory path";
                return;
            }

            int maxWidth = 0;
            int maxHeight = 0;
            try
            {
                maxWidth = System.Convert.ToInt16(maxWidthT);
                maxHeight = System.Convert.ToInt32(maxHeightT);
            }
            catch
            {
                resizeOutputLabel.ForeColor = Color.Red;
                resizeOutputLabel.Text = "Inavlid size specified for maxWidth or maxHeight";
                return;
            }

            if (maxWidth == 0 || maxHeight == 0)
            {
                resizeOutputLabel.ForeColor = Color.Red;
                resizeOutputLabel.Text = "Inavlid size specified for maxWidth or maxHeight";
                return;
            }

            resizeOutputLabel.ForeColor = Color.Black;

            List<string> allFilePaths = new List<string>(Directory.GetFiles(rootDirPath));
            string[] allDirectories = Directory.GetDirectories(rootDirPath, "*", SearchOption.AllDirectories);
            foreach (string directoryPath in allDirectories)
            {
                allFilePaths.AddRange(Directory.GetFiles(directoryPath));
            }

            resizeProgBar.Value = 0;
            resizeProgBar.Maximum = allFilePaths.Count();

            new Thread(new ThreadStart(() =>
            {
                foreach (string filePath in allFilePaths)
                {
                    resizeProgBar.BeginInvoke(new Action(() =>
                    {
                        resizeProgBar.PerformStep();
                    }));

                    if (!IMAGE_EXTENSION_LIST.Contains(Path.GetExtension(filePath).ToLower()))
                        continue;

                    Log(filePath);

                    resizeOutputLabel.BeginInvoke(new Action(() =>
                    {
                        resizeOutputLabel.Text = "Resizing " + filePath;
                    }));

                   
                    ResizeImage(maxWidth, maxHeight, filePath, rootDirPath, destDirPath);
                }

                resizeOutputLabel.BeginInvoke(new Action(() =>
                {
                    resizeOutputLabel.ForeColor = Color.Green;
                    resizeOutputLabel.Text = "Completed";
                }));

            })).Start();
        }

        //-----------------------------------------------------------------------------
        public void RemoveDuplicates(string rootDirPath)
        {
            if (!Directory.Exists(rootDirPath))
            {
                dupeLabel.ForeColor = Color.Red;
                dupeLabel.Text = "Invalid source directory path";
                return;
            }

            dupeLabel.ForeColor = Color.Black;

            List<string> allFilePaths = new List<string>(Directory.GetFiles(rootDirPath));
            string[] allDirectories = Directory.GetDirectories(rootDirPath, "*", SearchOption.AllDirectories);
            foreach (string directoryPath in allDirectories)
            {
                allFilePaths.AddRange(Directory.GetFiles(directoryPath));
            }

            allFilePaths.Sort();

            List<string> filesToBeDeleted = new List<string>();

            foreach (string filePath in allFilePaths)
            {
                string DupeFileName = System.IO.Path.GetFileNameWithoutExtension(filePath) + "_1";

                string DupeFilePath = System.IO.Path.GetDirectoryName(filePath) +
                                        System.IO.Path.DirectorySeparatorChar +
                                        DupeFileName +
                                        System.IO.Path.GetExtension(filePath);

                if (allFilePaths.Contains(DupeFilePath, StringComparer.OrdinalIgnoreCase))
                {
                    filesToBeDeleted.Add(DupeFilePath);
                }
            }

            resizeProgBar.Value = 0;
            resizeProgBar.Maximum = allFilePaths.Count();

            new Thread(new ThreadStart(() =>
            {
                foreach (string filePath in filesToBeDeleted)
                {
                    dupeLabel.BeginInvoke(new Action(() =>
                    {
                        dupeLabel.Text = "Resizing " + filePath;
                    }));

                    File.Delete(filePath);
                }

                dupeLabel.BeginInvoke(new Action(() =>
                {
                    dupeLabel.ForeColor = Color.Green;
                    dupeLabel.Text = "Completed. Total Files deleted: " + filesToBeDeleted.Count;
                }));

            })).Start();
        }

        //-----------------------------------------------------------------------------
        public void FlattenFiles(string flattenDirPath)
        {
            if (!Directory.Exists(flattenDirPath))
            {
                flattenFilesOutputLabel.ForeColor = Color.Red;
                flattenFilesOutputLabel.Text = "Invalid source directory path";
                return;
            }


            flattenFilesOutputLabel.ForeColor = Color.Black;

            List<string> allFilePaths = new List<string>(Directory.GetFiles(flattenDirPath));
            string[] allDirectories = Directory.GetDirectories(flattenDirPath, "*", SearchOption.AllDirectories);
            foreach (string directoryPath in allDirectories)
            {
                allFilePaths.AddRange(Directory.GetFiles(directoryPath));
            }

            resizeProgBar.Value = 0;
            resizeProgBar.Maximum = allFilePaths.Count();

            new Thread(new ThreadStart(() =>
            {
                foreach (string filePath in allFilePaths)
                {
                    string newPath = Path.Combine(flattenDirPath, Path.GetFileName(filePath));
                    System.IO.File.Move(filePath, newPath );
                    resizeProgBar.BeginInvoke(new Action(() =>
                    {
                        resizeProgBar.PerformStep();
                    }));
                }

                flattenFilesOutputLabel.BeginInvoke(new Action(() =>
                {
                    flattenFilesOutputLabel.ForeColor = Color.Green;
                    flattenFilesOutputLabel.Text = "Completed";
                }));

                if (deleteEmptyDirs.Checked)
                {
                    foreach (string directoryPath in allDirectories)
                    {
                        if (Directory.GetFiles(directoryPath).Count() == 0)
                        {
                            Directory.Delete(directoryPath);
                        }
                    }
                }

            })).Start();
        }

        //-----------------------------------------------------------------------------
        public void ResizeImage(int maxWidth, int maxHeight, string path, string rootDirPath, string DestDirPath)
        {
            var image = System.Drawing.Image.FromFile(path);
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);
            var newImage = new Bitmap(newWidth, newHeight);
            Graphics thumbGraph = Graphics.FromImage(newImage);

            thumbGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;

            thumbGraph.DrawImage(image, 0, 0, newWidth, newHeight);
            image.Dispose();

            string finalPath = Path.GetDirectoryName(path) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(path) + "_resized" + Path.GetExtension(path);
            finalPath = finalPath.Replace(rootDirPath, DestDirPath);

            string finalDirPath = Path.GetDirectoryName(finalPath);
            if (!Directory.Exists(finalDirPath))
                Directory.CreateDirectory(finalDirPath);

            newImage.Save(finalPath);
        }

        //-----------------------------------------------------------------------------
        public void Log(string message)
        {
            System.Diagnostics.Debug.Write("\n" + message);
        }

        //-----------------------------------------------------------------------------
        private void resizeButtonRun_Click(object sender, EventArgs e)
        {
            ResizeFiles(resizeDir.Text, DestResizeDir.Text, maxWidthText.Text, maxHeightText.Text);
        }

        //-----------------------------------------------------------------------------
        private void resizeButtonBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = resizeDir.Text;

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                resizeDir.Text = folderBrowser.SelectedPath;
            }
        }

        //-----------------------------------------------------------------------------
        private void resizeDestBrwsButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = DestResizeDir.Text;

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                DestResizeDir.Text = folderBrowser.SelectedPath;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FlattenFiles(flattenDir.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = resizeDir.Text;

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                flattenDir.Text = folderBrowser.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = resizeDir.Text;

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                dupeDir.Text = folderBrowser.SelectedPath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RemoveDuplicates(dupeDir.Text);
        }

        private void NumberOnDateCheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void AscRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void nameVideoCheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
