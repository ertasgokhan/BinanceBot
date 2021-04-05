using Binance.Generate.OTT;
using System;
using System.IO;
using System.Timers;

namespace BinanceBot
{
    public class InnerOperation
    {
        public const string sourceDirectory = @"C:\BinanceBot\";
        Timer timer = new Timer();
        public void Start()
        {
            WriteToFile("Service Başladı " + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 50000;
            timer.Enabled = true;
        }

        public void Stop()
        {
            WriteToFile("Service Tamamlandı " + DateTime.Now);
        }

        public void WriteToFile(string Message)
        {
            if (!Directory.Exists(sourceDirectory))
            {
                Directory.CreateDirectory(sourceDirectory);
            }

            string filepath = sourceDirectory + "\\Log.txt";

            if (!File.Exists(filepath))
            {
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            GenerateOTTLine.GenerateOTT();
        }
    }
}
