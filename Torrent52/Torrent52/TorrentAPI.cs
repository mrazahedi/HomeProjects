using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UTorrentAPI;
using System.Diagnostics;


namespace Torrent52
{
    class TorrentAPI
    {
        UTorrentClient _client = null;
        public TorrentAPI()
        {
            Connect();
        }

        public TorrentCollection GetTorrentJobs()
        {
            if (!TorrentIsRunning())
            {
                _client = null;
            }
            else if (_client == null)
            {
                Connect();
            }

            if (_client != null)
                return _client.Torrents;
            else
                return null;
        }

        public bool TorrentIsRunning()
        {
            Process[] runningProc = Process.GetProcessesByName("uTorrent");
            return (runningProc.Length != 0);
        }

        private void Connect()
        {
            if (TorrentIsRunning())
                _client = new UTorrentClient(new System.Uri("http://localhost:54307/gui/"), "azahedi", "Torrent52@mYH0use");
        }
    }
}
