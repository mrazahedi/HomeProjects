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
            if (args.Length != 4)
            {
                Console.WriteLine("Need to pass 4 arguments: \n" +
                                    "Download root directory path - Ex: C:\\Downloads \n" +
                                    "Torrent download directory name in download root directory path - Ex: Misc \n" +
                                    "File directory match accuracy - Ex: 0.8" +
                                    "Auto close frequency in min - Ex: 5");
                errorFound = true;
            }

            float accuracy = 0.8f;
            try
            {
                accuracy = System.Convert.ToSingle(args[2]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Was not able to parse the third parameter - " + ex.ToString());
                errorFound = true;
            }

            int autoCloseFrequency = 5;
            try
            {
                autoCloseFrequency = System.Convert.ToInt32(args[3]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Was not able to parse the fourth parameter - " + ex.ToString());
                errorFound = true;
            }

            Main main = null;
            if (errorFound)
            {
                Console.WriteLine("Default arguments will be used - C:\\Downloads Misc 0.8 5");
                main = new Main("C:\\Downloads", "Misc", 0.8f, 5);
            }
            else
            {
                main = new Main(args[0], args[1], accuracy, autoCloseFrequency);
            }

            //Main main = new Main("C:\\Downloads", "Misc", 0.8f);
            main.Start();
        }
    }
}
