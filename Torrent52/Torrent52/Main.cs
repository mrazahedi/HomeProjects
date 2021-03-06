﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UTorrentAPI;
using System.IO;
using System.Diagnostics;

namespace Torrent52
{
    class Main
    {
        private readonly int CLEANUP_FREQ_MS = 5000;
        private readonly string DOWNLOAD_LOG_FILE_NAME = "DownloadLog.txt";
        private readonly string ERROR_LOG_FILE_NAME = "ErrorLog.txt";
        private readonly string NEW_DOWNLOADED_FILE_TAG = "---NEW-- ";
        private readonly List<int> OPEN_TORRENT_TIMES = new List<int>() { 3, 6, 9, 15, 18, 19, 20, 21, 22 };

        private readonly string MOVIE_DIR_NAME = "Movies";
        private readonly string TV_SERIES_DIR_NAME = "TV-Series";

        private System.Threading.Thread _cleanupThread;
        private System.Threading.Thread _torrentShutDownThread;
        TorrentAPI _torrentApi = null;
        private bool _running = false;

        private string _uTorrentTempDirPath;
        private string _baseDirPath;
        private string _downloadDirPath;
        private string _movieDirPath;
        private string _tvShowDirPath;
        private float _matchPercentage;
        private int _autoCloseFrequency;

        private string _torrentFilePath = "";
        private System.IO.StreamWriter _downloadLogFileStreamWriter = null;
        private System.IO.StreamWriter _errorLogFileStreamWriter = null;

        private Mutex _mutextObj = null;

        //--------------------------------------------------------------------
        public Main(string uTorrentTempDirPath, string baseDirPath, string downloadDirName, float matchPerc, int autoCloseFrequency, string torrentFilePath)
        {
            _mutextObj = new Mutex();

            _uTorrentTempDirPath = uTorrentTempDirPath;
            _baseDirPath = baseDirPath;
            _downloadDirPath = _baseDirPath + Path.DirectorySeparatorChar + downloadDirName;
            _movieDirPath = _baseDirPath + Path.DirectorySeparatorChar + MOVIE_DIR_NAME;
            _tvShowDirPath = _baseDirPath + Path.DirectorySeparatorChar + TV_SERIES_DIR_NAME;
            _matchPercentage = matchPerc;
            _autoCloseFrequency = autoCloseFrequency * 60 * 1000;
            _torrentFilePath = torrentFilePath;
        }

        ~Main()
        {
            if(_downloadLogFileStreamWriter != null)
                _downloadLogFileStreamWriter.Close();

            if (_errorLogFileStreamWriter != null)
                _errorLogFileStreamWriter.Close();
        }

        //--------------------------------------------------------------------
        public void Start(string webUIUserName, string webUIPassword, string port)
        {
            if (_torrentApi == null)
                _torrentApi = new TorrentAPI(webUIUserName, webUIPassword, port);

            if (_cleanupThread == null)
                _cleanupThread = new Thread(new System.Threading.ThreadStart(CheckAndOrganize));

            if (!_cleanupThread.IsAlive)
            {
                _running = true;
                _cleanupThread.Start();
            }

            if (_torrentShutDownThread == null)
                _torrentShutDownThread = new Thread(new System.Threading.ThreadStart(KillUTorrentThread));

            if (!_torrentShutDownThread.IsAlive)
                _torrentShutDownThread.Start();
        }

        //--------------------------------------------------------------------
        public void Stop()
        {
            _running = false;
        }

        //--------------------------------------------------------------------
        private void KillUTorrentThread()
        {
            while (_running)
            {
                Thread.Sleep(_autoCloseFrequency);
                KillUTorrentIfAllDone();
            }
        }

        //--------------------------------------------------------------------
        private void KillUTorrentIfAllDone(bool forceKill = false)
        {
            _mutextObj.WaitOne();
            try
            {
                if (!forceKill && ShouldTorrentRun())
                {
                    if (Process.GetProcessesByName("utorrent").Count() == 0)
                        System.Diagnostics.Process.Start(_torrentFilePath);
                }
                else
                {
                    TorrentCollection torrentCollection = _torrentApi.GetTorrentJobs();
                    if (torrentCollection == null || torrentCollection.Count == 0)
                    {
                        foreach (Process proc in Process.GetProcessesByName("utorrent"))
                        {
                            proc.Kill();   
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write("was not able to shutdown torrent - " + e.ToString());
                LogData("KillUTorrentIfAllDone - Error: " + e.ToString(), ERROR_LOG_FILE_NAME, ref _errorLogFileStreamWriter);
            }
            _mutextObj.ReleaseMutex();
        }

        //--------------------------------------------------------------------
        private bool ShouldTorrentRun()
        {
            int currentHour = DateTime.Now.TimeOfDay.Hours;
            return OPEN_TORRENT_TIMES.Contains(currentHour);
        }

        //--------------------------------------------------------------------
        private bool IsUTorrentRunning()
        {
            if (Process.GetProcessesByName("utorrent").Length == 0)
                return false;

            TorrentCollection torrentCollection = _torrentApi.GetTorrentJobs();
            return (torrentCollection != null && torrentCollection.Count > 0);
        }

        //--------------------------------------------------------------------
        private void CheckAndOrganize()
        {
            while (_running)
            {
                Thread.Sleep(CLEANUP_FREQ_MS);

                List<Torrent> inProgressTorrents = new List<Torrent>();

                DeleteCompletedTorrentJobs(ref inProgressTorrents);

                if (inProgressTorrents.Count == 0)
                    MoveFilesFromTempToFinalDownloadDir();

                MoveCompletedFiles(inProgressTorrents);
                //UpdateFileNameStatus();
            }
        }

        //--------------------------------------------------------------------
        //Sometimes we end up killing completed torrent jobs before uTorrent copy the file to the final destination
        //If there is no torrent job running, scan the temp directory and move files to the final directory
        private void MoveFilesFromTempToFinalDownloadDir()
        {
            _mutextObj.WaitOne();
            try
            {
                if (!System.IO.Directory.Exists(_uTorrentTempDirPath))
                    return;

                string[] directories = System.IO.Directory.GetDirectories(_uTorrentTempDirPath, "*", SearchOption.TopDirectoryOnly);
                foreach (string srcPath in directories)
                {
                    string destPath = _downloadDirPath + Path.DirectorySeparatorChar + GetDirectoryName(srcPath);
                    if (System.IO.Directory.Exists(destPath))
                        destPath = GetNewNameForDirectory(destPath);

                    System.IO.Directory.Move(@srcPath, @destPath);
                }

                List<string> files = GetMovieFiles(_uTorrentTempDirPath, SearchOption.TopDirectoryOnly);

                foreach (string srcPath in files)
                {
                    string destPath = _downloadDirPath + Path.DirectorySeparatorChar + Path.GetFileName(srcPath);
                    if (!System.IO.File.Exists(destPath))
                        System.IO.File.Move(@srcPath, @destPath);
                }
            }
            catch (Exception e)
            {
                Console.Write("was not able to move files from temp to final directory - " + e.ToString());
                LogData("MoveFilesFromTempToFinalDownloadDir - Error: " + e.ToString(), ERROR_LOG_FILE_NAME, ref _errorLogFileStreamWriter);
            }
            _mutextObj.ReleaseMutex();
        }

        //--------------------------------------------------------------------
        private void DeleteCompletedTorrentJobs(ref List<Torrent> inProgressTorrents)
        {
            try
            {
                if (!IsUTorrentRunning())
                    return;

                List<Torrent> completedTorrentJobs = new List<Torrent>();
                List<Torrent> torrentsWithError = new List<Torrent>();
                TorrentCollection torrentCollection = _torrentApi.GetTorrentJobs();

                if (torrentCollection == null || torrentCollection.Count == 0)
                    return;

                foreach (Torrent torrent in torrentCollection)
                {
                    if (torrent == null)
                        continue;

                    if (torrent.Status == TorrentStatus.Error)
                    {
                        torrentsWithError.Add(torrent);
                    }
                    else if (/*torrent.Status == TorrentStatus.FinishedOrStopped && */torrent.ProgressInMils >= 1000)
                    {
                        LogData("Downloaded " + torrent.Name, DOWNLOAD_LOG_FILE_NAME, ref _downloadLogFileStreamWriter);
                        completedTorrentJobs.Add(torrent);
                    }
                    else
                    {
                        inProgressTorrents.Add(torrent);
                    }
                }

                foreach (Torrent torrent in completedTorrentJobs)
                {
                    LogData("Removing torrent from uTorrent: " + torrent.Name, DOWNLOAD_LOG_FILE_NAME, ref _downloadLogFileStreamWriter);
                    torrentCollection.Remove(torrent);
                }

                foreach (Torrent torrent in torrentsWithError)
                {
                    LogData("Removing torrent because of error - Name: " + torrent.Name + " --- Error: " + torrent.StatusMessage, DOWNLOAD_LOG_FILE_NAME, ref _downloadLogFileStreamWriter);
                    torrentCollection.Remove(torrent);
                }
            }
            catch (Exception e)
            {
                if(e.ToString().ToLower().Contains("there was no end point"))

                Console.Write("was not able to delete completed torrent jobs - " + e.ToString());
                LogData("DeleteCompletedTorrentJobs - Error: " + e.ToString(), ERROR_LOG_FILE_NAME, ref _errorLogFileStreamWriter);
            }
        }

        //--------------------------------------------------------------------
        private void UpdateFileNameStatus()
        {
            DateTime twoDaysAgo = DateTime.Now.AddDays(-3);

            List<string> filePaths = GetMovieFiles(_movieDirPath, SearchOption.AllDirectories);
            string[] directories = System.IO.Directory.GetDirectories(_baseDirPath, "*", SearchOption.AllDirectories);
            foreach (string dir in directories)
            {
                if (dir.ToLower().Contains(_downloadDirPath.ToLower()))
                    continue;

                DirectoryInfo dirInfo = new DirectoryInfo(dir);
                DateTime created = dirInfo.CreationTime;
                if (dirInfo.CreationTime > twoDaysAgo && !GetDirectoryName(dir).StartsWith(NEW_DOWNLOADED_FILE_TAG))
                {
                    System.IO.Directory.Move(dir, dir.Replace(GetDirectoryName(dir), NEW_DOWNLOADED_FILE_TAG + GetDirectoryName(dir)));
                }
                else if (dirInfo.CreationTime <= twoDaysAgo && GetDirectoryName(dir).StartsWith(NEW_DOWNLOADED_FILE_TAG))
                {
                    System.IO.Directory.Move(dir, dir.Replace(NEW_DOWNLOADED_FILE_TAG, ""));
                }
            }
        }

        //--------------------------------------------------------------------
        private void MoveCompletedFiles(List<Torrent> inProgressTorrents)
        {
            try
            {
                List<string> filesToBeMoved = new List<string>();
                List<string> filePaths = GetMovieFiles(_downloadDirPath, SearchOption.AllDirectories);

                foreach (string filePath in filePaths)
                {
                    if (FindMatchingTorrent(inProgressTorrents, filePath) == null)
                    {
                        filesToBeMoved.Add(filePath);
                    }
                }

                foreach (string filePath in filesToBeMoved)
                    MoveFileToDirAndCleanup(filePath);
            }
            catch (Exception e)
            {
                Console.Write("was not able to move completed files - " + e.ToString());
                LogData("MoveCompletedFiles - Error: " + e.ToString(), ERROR_LOG_FILE_NAME, ref _errorLogFileStreamWriter);

                //There is a chance a uTorrent process is hanging on to the files. Kill it if there is no active torrent
                KillUTorrentIfAllDone(true);
            }
        }

        //--------------------------------------------------------------------
        private List<string> GetMovieFiles(string baseDirPath, SearchOption searchOption)
        {
            List<string> movies = new List<string>();

            string[] filePaths = System.IO.Directory.GetFiles(baseDirPath, "*.*", searchOption);
            foreach (string file in filePaths)
            {
                string extension = Path.GetExtension(file).ToLower();
                if (extension.Equals(".avi") || extension.Equals(".mp4") || extension.Equals(".mkv") || extension.Equals(".mpeg4"))
                    movies.Add(file);
            }

            return movies;
        }

        //--------------------------------------------------------------------
        private Torrent FindMatchingTorrent(List<Torrent> torrentList, string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            foreach (Torrent torrent in torrentList)
            {
                foreach (UTorrentAPI.File torrentFile in torrent.Files)
                {
                    if (torrentFile.Path.Contains(fileName))
                        return torrent;
                }
            }

            return null;
        }

        //--------------------------------------------------------------------
        private void MoveFileToDirAndCleanup(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
                return;

            string destDirPath = FindParentDir(Path.GetFileNameWithoutExtension(filePath));
            if (string.IsNullOrEmpty(destDirPath))
            {
                Console.Write("Was not able to move " + destDirPath);
                return;
            }

            _mutextObj.WaitOne();
            string fileDirPath = Path.GetDirectoryName(filePath);
            if (fileDirPath.Equals(_downloadDirPath))
            {
                //It is one file located in Download folder. Put the file in a folder with the same name

                fileDirPath = fileDirPath + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(filePath);
                System.IO.Directory.CreateDirectory(fileDirPath);

                string newFilePath = fileDirPath + Path.DirectorySeparatorChar + Path.GetFileName(filePath);
                LogData("Downloaded One File With no Folder - Created a DIR and moved the file to " + newFilePath, DOWNLOAD_LOG_FILE_NAME, ref _downloadLogFileStreamWriter);
                System.IO.File.Move(@filePath, @newFilePath);
            }

            string destPath = @destDirPath + Path.DirectorySeparatorChar + GetDirectoryName(fileDirPath);
            if (System.IO.Directory.Exists(destPath))
                destPath = GetNewNameForDirectory(destPath);

            LogData("Moving directory " + filePath + "  to  " + destPath, DOWNLOAD_LOG_FILE_NAME, ref _downloadLogFileStreamWriter);
            System.IO.Directory.Move(@fileDirPath, destPath);
            _mutextObj.ReleaseMutex();
        }

        //--------------------------------------------------------------------
        private string GetNewNameForDirectory(string dirPath)
        {
            int postfix = 0;
            while (true)
            {
                if (System.IO.Directory.Exists(dirPath + "_copy" + postfix.ToString("00")))
                    postfix++;
                else
                    return dirPath + "_copy" + postfix.ToString("00");
            }
        }

        //--------------------------------------------------------------------
        private string FindParentDir(string fileName)
        {
            string[] directories = System.IO.Directory.GetDirectories(_tvShowDirPath, "*", SearchOption.TopDirectoryOnly);

            string foundMatchDir = _movieDirPath;
            float foundMatchPerc = 0f;

            foreach (string dir in directories)
            {
                float matchPerc = GetMatchPercentage(fileName, GetDirectoryName(dir));
                if (matchPerc >= _matchPercentage && matchPerc >= foundMatchPerc)
                    foundMatchDir = dir;
            }

            return foundMatchDir;
        }

        //--------------------------------------------------------------------
        private float GetMatchPercentage(string fileName, string matchFileName)
        {
            string sanitizedFileName = SanitizeFileName(fileName);
            string[] matchFileNameWords = matchFileName.ToLower().Split(' ');

            int totalMatchFound = 0;
            foreach (string word in matchFileNameWords)
            {
                if (sanitizedFileName.Contains(word))
                    totalMatchFound++;
            }

            return totalMatchFound / matchFileNameWords.Length;
        }

        //--------------------------------------------------------------------
        private void LogData(string message, string logFileName, ref System.IO.StreamWriter logFileStreamWriter)
        {
            if(logFileStreamWriter == null)
                logFileStreamWriter = new System.IO.StreamWriter(_baseDirPath + Path.DirectorySeparatorChar + logFileName, true);

            logFileStreamWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - " + message);
            logFileStreamWriter.Flush();
        }

        //--------------------------------------------------------------------
        private string SanitizeFileName(string fileName)
        {
            fileName = fileName.Replace('[', ' ');
            fileName = fileName.Replace(']', ' ');
            fileName = fileName.Replace('(', ' ');
            fileName = fileName.Replace(')', ' ');
            fileName = fileName.Replace('.', ' ');
            fileName = fileName.Replace('-', ' ');
            fileName = fileName.Replace('_', ' ');
            fileName = fileName.Replace('/', ' ');
            fileName = fileName.Replace('\\', ' ');
            fileName = fileName.Replace('{', ' ');
            fileName = fileName.Replace('}', ' ');

            return fileName.ToLower();
        }

        //--------------------------------------------------------------------
        private string GetDirectoryName(string dirPath)
        {
            return dirPath.Substring(dirPath.LastIndexOf(Path.DirectorySeparatorChar) + 1);
        }
    }
}
