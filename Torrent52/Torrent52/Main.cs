using System;
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
        private readonly int CLEANUP_FREQ_MS = 15000;
        private readonly string LOG_FILE_NAME = "DownloadLog.txt";
        private readonly string NEW_DOWNLOADED_FILE_TAG = "---NEW-- ";

        private System.Threading.Thread _cleanupThread;
        private System.Threading.Thread _torrentShutDownThread;
        TorrentAPI _torrentApi = null;
        private bool _running = false;

        private string _baseDirPath;
        private string _downloadDirPath;
        private string _movieDirPath;
        private float _matchPercentage;
        private int _autoCloseFrequency;

        private System.IO.StreamWriter _logFileStreamWriter = null;

        //--------------------------------------------------------------------
        public Main(string baseDirPath, string downloadDirName, float matchPerc, int autoCloseFrequency)
        {
            _baseDirPath = baseDirPath;
            _downloadDirPath = _baseDirPath + Path.DirectorySeparatorChar + downloadDirName;
            _movieDirPath = _baseDirPath + Path.DirectorySeparatorChar + "Movies";
            _matchPercentage = matchPerc;
            _autoCloseFrequency = autoCloseFrequency * 60 * 1000;
        }

        ~Main()
        {
            if(_logFileStreamWriter != null)
                _logFileStreamWriter.Close();
        }

        //--------------------------------------------------------------------
        public void Start()
        {
            if (_torrentApi == null)
                _torrentApi = new TorrentAPI();

            if (_cleanupThread == null)
                _cleanupThread = new Thread(new System.Threading.ThreadStart(CheckAndOrganize));

            if (!_cleanupThread.IsAlive)
            {
                _running = true;
                _cleanupThread.Start();
            }

            if (_torrentShutDownThread == null)
                _torrentShutDownThread = new Thread(new System.Threading.ThreadStart(KillUTorrentIfAllDone));

            if (!_torrentShutDownThread.IsAlive)
                _torrentShutDownThread.Start();
        }

        //--------------------------------------------------------------------
        public void Stop()
        {
            _running = false;
        }

        //--------------------------------------------------------------------
        private void KillUTorrentIfAllDone()
        {
            while (_running)
            {
                Thread.Sleep(_autoCloseFrequency);
                try
                {
                    if (ShouldTorrentRun())
                    {
                        if (Process.GetProcessesByName("utorrent").Count() == 0)
                            System.Diagnostics.Process.Start(@"C:\Users\Ale\AppData\Roaming\uTorrent\uTorrent.exe");
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
                }
            }
        }

        //--------------------------------------------------------------------
        private bool ShouldTorrentRun()
        {
            int currentHour = DateTime.Now.TimeOfDay.Hours;
            return currentHour == 3 || currentHour == 9 || currentHour == 15;
        }

        //--------------------------------------------------------------------
        private void CheckAndOrganize()
        {
            while (_running)
            {
                Thread.Sleep(CLEANUP_FREQ_MS);

                try
                {
                    List<Torrent> inProgressTorrents = new List<Torrent>();
                    DeleteCompletedTorrentJobs(ref inProgressTorrents);
                    MoveCompletedFiles(inProgressTorrents);
                    UpdateFileNameStatus();
                }
                catch (Exception e)
                {
                    Console.Write("was not able to shutdown torrent - " + e.ToString());
                }
            }
        }

        //--------------------------------------------------------------------
        private void DeleteCompletedTorrentJobs(ref List<Torrent> inProgressTorrents)
        {
            List<Torrent> completedTorrentJobs = new List<Torrent>();
            List<Torrent> torrentsWithError = new List<Torrent>();
            TorrentCollection torrentCollection = _torrentApi.GetTorrentJobs();

            if (torrentCollection == null)
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
                    LogData("Downloaded " + torrent.Name);
                    completedTorrentJobs.Add(torrent);
                }
                else
                {
                    inProgressTorrents.Add(torrent);
                }
            }

            foreach (Torrent torrent in completedTorrentJobs)
            {
                LogData("Removing torrent from uTorrent: " + torrent.Name);
                torrentCollection.Remove(torrent);
            }

            foreach (Torrent torrent in torrentsWithError)
            {
                LogData("Removing torrent because of error - Name: " + torrent.Name + " --- Error: " + torrent.StatusMessage);
                torrentCollection.Remove(torrent);
            }
        }

        //--------------------------------------------------------------------
        private void UpdateFileNameStatus()
        {
            DateTime twoDaysAgo = DateTime.Now.AddDays(-3);

            List<string> filePaths = GetMovieFiles(_movieDirPath);
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
            List<string> filesToBeMoved = new List<string>();
            List<string> filePaths = GetMovieFiles(_downloadDirPath);

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

        //--------------------------------------------------------------------
        private List<string> GetMovieFiles(string baseDirPath)
        {
            List<string> movies = new List<string>();

            string[] filePaths = System.IO.Directory.GetFiles(_downloadDirPath, "*.*", SearchOption.AllDirectories);
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

            string fileDirPath = Path.GetDirectoryName(filePath);
            if (fileDirPath.Equals(_downloadDirPath))
            {
                string destPath = destDirPath + Path.DirectorySeparatorChar + Path.GetFileName(filePath);
                if (System.IO.File.Exists(destPath))
                    System.IO.File.Delete(destPath);

                //It is one file located in Download folder. move the file

                LogData("Moving file " + filePath + "  to  " + destPath);
                System.IO.File.Move(@filePath, @destPath);
            }
            else
            {
                string destPath = @destDirPath + Path.DirectorySeparatorChar + GetDirectoryName(fileDirPath);
                if (System.IO.Directory.Exists(destPath))
                    destPath = GetNewNameForDirectory(destPath);

                //The file is inside another folder. Move the whole folder over
                LogData("Moving directory " + filePath + "  to  " + destPath);
                System.IO.Directory.Move(@fileDirPath, destPath);
            }
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
            string[] directories = System.IO.Directory.GetDirectories(_baseDirPath, "*", SearchOption.AllDirectories);
            foreach (string dir in directories)
            {
                if (dir.ToLower().Contains(_downloadDirPath.ToLower()))
                    continue;

                if (dir.ToLower().Contains(_movieDirPath.ToLower()))
                    continue;

                if (FileNameMatch(fileName, GetDirectoryName(dir), _matchPercentage))
                    return dir;
            }

            return _movieDirPath;
        }

        //--------------------------------------------------------------------
        private bool FileNameMatch(string fileName, string matchFileName, float matchPerc)
        {
            string sanitizedFileName = SanitizeFileName(fileName);
            string[] matchFileNameWords = matchFileName.ToLower().Split(' ');

            int totalMatchFound = 0;
            foreach (string word in matchFileNameWords)
            {
                if (sanitizedFileName.Contains(word))
                    totalMatchFound++;
            }

            if (totalMatchFound / matchFileNameWords.Length >= matchPerc)
                return true;

            return false;
        }

        //--------------------------------------------------------------------
        private void LogData(string message)
        {
            if(_logFileStreamWriter == null)
                _logFileStreamWriter = new System.IO.StreamWriter(_baseDirPath + Path.DirectorySeparatorChar + LOG_FILE_NAME, true);

            _logFileStreamWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - " + message);
            _logFileStreamWriter.Flush();
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
