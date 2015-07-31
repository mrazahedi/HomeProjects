﻿//-----------------------------------------------------------------------
// <copyright file="Torrent.cs" company="Mike Davis">
//     To the extent possible under law, Mike Davis has waived all copyright and related or neighboring rights to this work.  This work is published from: United States.  See copying.txt for details.  I would appreciate credit when incorporating this work into other works.  However, you are under no legal obligation to do so.
// </copyright>
//-----------------------------------------------------------------------

namespace UTorrentAPI
{
    using System;
    using UTorrentAPI.Protocol;

    /// <summary>
    /// Represents a torrent job in uTorrent
    /// </summary>
    public class Torrent : IJsonLoadable
    {
                private static readonly DateTime startOfEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

                /// <summary>
        /// Private storage for the <c>Label</c> field
        /// </summary>
        private string label = null;

        /// <summary>
        /// A reference to the wcf proxy used for updates to this collection
        /// </summary>
        private IUTorrentProxy proxy;

        /// <summary>
        /// Initializes a new instance of the Torrent class
        /// </summary>
        /// <param name="json">a json array returned from the web api representing a torrent</param>
        /// <param name="proxy">the procol client that this torrent should use for updates, etc</param>
        internal Torrent(JsonArray json, IUTorrentProxy proxy)
        {
            this.proxy = proxy;
            (this as IJsonLoadable).LoadFromJson(json);
        }

        /// <summary>
        /// Gets the infohash of the torrent
        /// </summary>
        public string Hash { get; private set; }

        /// <summary>
        /// Gets the current status of the torrent, which is a bitwise or of statuses
        /// </summary>
        public TorrentStatus Status { get; private set; }
        
        /// <summary>
        /// Gets the name of the torrent
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// Gets the size in bytes of the torrent
        /// </summary>
        public long SizeInBytes { get; private set; }
        
        /// <summary>
        /// Gets the progress of a torrent download in 1/1000ths
        /// </summary>
        public int ProgressInMils { get; private set; }
        
        /// <summary>
        /// Gets the number of bytes currently downloaded for this torrent
        /// </summary>
        public long DownloadedBytes { get; private set; }
        
        /// <summary>
        /// Gets the number of bytes currently uploaded for this torrent
        /// </summary>
        public long UploadedBytes { get; private set; }
        
        /// <summary>
        /// Gets the upload ratio in 1/1000ths
        /// </summary>
        public int RatioInMils { get; private set; }
        
        /// <summary>
        /// Gets the current upload rate of the torrent
        /// </summary>
        public int UploadBytesPerSec { get; private set; }
        
        /// <summary>
        /// Gets the current download rate of the torrent
        /// </summary>
        public int DownloadBytesPerSec { get; private set; }
        
        /// <summary>
        /// Gets an estimate for how long it will take to finish downloading the torrent
        /// </summary>
        public int EtaInSecs { get; private set; }

        /// <summary>
        /// Gets or sets the torrent's label
        /// </summary>
        public string Label
        {
            get
            {
                return this.label;
            }

            set
            {
                this.proxy.SetTorrentProperty(this.Hash, "label", value);
                this.label = value;
            }
        }
        
        /// <summary>
        /// Gets the number of peers connected
        /// </summary>
        public int PeersConnected { get; private set; }
        
        /// <summary>
        /// Gets the number of peers in the swarm
        /// </summary>
        public int PeersInSwarm { get; private set; }
        
        /// <summary>
        /// Gets the numbers of seeds connected
        /// </summary>
        public int SeedsConnected { get; private set; }
        
        /// <summary>
        /// Gets the number of seeds in the swarm
        /// </summary>
        public int SeedsInSwarm { get; private set; }
        
        /// <summary>
        /// Gets the availability of the torrent in 1/65535ths
        /// </summary>
        public int Availability { get; private set; }
        
        /// <summary>
        /// Gets the current index in the queue
        /// </summary>
        public int QueueOrder { get; private set; }

        /// <summary>
        /// Gets the number of bytes remaining to be downloaded
        /// </summary>
                public long RemainingBytes { get; private set; }

                /// <summary>
                /// Gets the DownloadUrl if torrent was added via add-url method
                /// </summary>
                public string DownloadUrl { get; private set; }

                /// <summary>
                /// Gets the rss feed url if torrent was download via feed system
                /// </summary>
                public string RssFeedUrl { get; private set; }

                /// <summary>
                /// Gets the status text Message Ex: "Seeding", "Downloading", "Finished" of the torrent
                /// </summary>
                public string StatusMessage { get; private set; }

                /// <summary>
                /// Gets the stream id of the torrent
                /// </summary>
                public string StreamID { get; private set; }

                /// <summary>
                /// Gets the datetime on which torrent was added on
                /// </summary>
                public DateTime DateAdded { get; private set; }

                /// <summary>
                /// Gets the datetime on which torrent completed its download
                /// </summary>
                public DateTime DateCompleted { get; private set; }

                /// <summary>
                /// Gets the update url of the torrent if it exists
                /// </summary>
                public string AppUpdateUrl { get; private set; }
                
        /// <summary>
        /// Gets the path where the torrent is being saved
        /// </summary>
        public string SavePath { get; private set; }

        /// <summary>
        /// Gets a collection of files included in the torrent
        /// </summary>
        public FileCollection Files
        {
            get
            {
                return this.proxy.ListFiles(this.Hash);
            }
        }

        /// <summary>
        /// Gets or sets all the trackers for this torrent
        /// </summary>
        public string[] Trackers
        {
            get
            {
                JsonObject json = this.proxy.GetTorrentProperties(this.Hash);
                return ((string)json["root"]["props"][0]["trackers"]).Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }
            
            set
            {
                this.proxy.SetTorrentProperty(this.Hash, "trackers", string.Join("\r\n\r\n", value));
            }
        }

        /// <summary>
        /// Sets all of the properties in the torrent
        /// based on the supplied json
        /// </summary>
        /// <param name="j">json object that represents a torrent</param>
        void IJsonLoadable.LoadFromJson(JsonBaseType j)
        {
            JsonArray json = j as JsonArray;

            this.Hash = json[0];
            this.Status = (TorrentStatus)(int)json[1];
            this.Name = json[2];
            this.SizeInBytes = json[3];
            this.ProgressInMils = json[4];
            this.DownloadedBytes = json[5];
            this.UploadedBytes = json[6];
            this.RatioInMils = json[7];
            this.UploadBytesPerSec = json[8];
            this.DownloadBytesPerSec = json[9];
            this.EtaInSecs = json[10];
            this.label = json[11];
            this.PeersConnected = json[12];
            this.PeersInSwarm = json[13];
            this.SeedsConnected = json[14];
            this.SeedsInSwarm = json[15];
            this.Availability = json[16];
            this.QueueOrder = json[17];
            this.RemainingBytes = json[18];
                        this.DownloadUrl = json[19];
                        this.RssFeedUrl = json[20];
                        this.StatusMessage = json[21];
                        this.StreamID = json[22];
                        this.DateAdded = startOfEpoch.AddSeconds((double)json[23]);
                        this.DateCompleted = startOfEpoch.AddSeconds((double)json[24]);
                        this.AppUpdateUrl = json[25];
            this.SavePath = json[26];
        }

        /// <summary>
        /// Starts the torrent for downloading or seeding
        /// </summary>
        /// <param name="force">Force downloading or seeding even if the queue is full</param>
        public void Start(bool force = false)
        {
            if (force)
            {
                this.proxy.ForceStartTorrent(this.Hash);
            }
            else
            {
                this.proxy.StartTorrent(this.Hash);
            }
        }

        /// <summary>
        /// Stops the torrent
        /// </summary>
        public void Stop()
        {
            this.proxy.StopTorrent(this.Hash);
        }

        /// <summary>
        /// Pauses the torrent
        /// </summary>
        public void Pause()
        {
            this.proxy.PauseTorrent(this.Hash);
        }

        /// <summary>
        /// Unpauses the torrent
        /// </summary>
        public void Unpause()
        {
            this.proxy.UnpauseTorrent(this.Hash);
        }

        /// <summary>
        /// Rechecks the torrent
        /// </summary>
        public void Recheck()
        {
            this.proxy.RecheckTorrent(this.Hash);
        }
    }
}
