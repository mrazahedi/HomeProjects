using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Torrent52
{
    class Program
    {
        static void Main(string[] args)
        {
            bool errorFound = false;
            if (args.Length != 9)
            {
                Console.WriteLine("Need to pass the following arguments: \n" +
                                    "uTorrent temp download directory path - Ex: C:\\TorrentDownloads \n" +
                                    "Download root directory path - Ex: C:\\Downloads \n" +
                                    "Torrent download directory name in download root directory path - Ex: Misc \n" +
                                    "File directory match accuracy - Ex: 0.8  \n" +
                                    "Auto close frequency in min - Ex: 5  \n" +
                                    "Torrent software path - Ex: C:\\Users\\Ali\\AppData\\Roaming\\uTorrent\\uTorrent.exe  \n" +
                                    "Torrent webUI username \n" +
                                    "Torrent webUI password \n" +
                                    "port");
                errorFound = true;
            }

            float accuracy = 0.8f;
            try
            {
                accuracy = System.Convert.ToSingle(args[3]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Was not able to parse the third parameter - " + ex.ToString());
                errorFound = true;
            }

            int autoCloseFrequency = 5;
            try
            {
                autoCloseFrequency = System.Convert.ToInt32(args[4]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Was not able to parse the fourth parameter - " + ex.ToString());
                errorFound = true;
            }

            if (!errorFound && string.IsNullOrEmpty(args[5]))
            {
                Console.WriteLine("Was not able to parse the fifth parameter that specifies the torrent file path ");
                errorFound = true;
            }

            Main main = null;
            if (errorFound)
            {
                Console.WriteLine("Default arguments will be used - C:\\Downloads Misc 0.8 5");
                main = new Main("C:\\TorrentDownloads", "C:\\Downloads", "Misc", 0.8f, 5, @"C:\Users\Ali\AppData\Roaming\uTorrent\uTorrent.exe");
            }
            else
            {
                main = new Main(args[0], args[1], args[2], accuracy, autoCloseFrequency, args[5]);
            }

            if(!errorFound)
                main.Start(args[6], args[7], args[8]);
        }
    }
}
