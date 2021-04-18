using Binance.Generate.OTT;
using Binance.OTT.Trade;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Timers;
using Telegram.Bot;

namespace BinanceBot
{
    public class InnerOperation
    {
        public const string sourceDirectory = @"C:\BinanceBot\";
        Timer timer = new Timer();
        private static TelegramBotClient botClient = new TelegramBotClient("1724957087:AAH0ByKhfMJIGPP8JI51oJMqCh9HbwwmRrU");

        public void Start()
        {
            WriteToFile("Service Başladı " + DateTime.Now);
            SendMessageFromTelegramBot("Servis çalışmaya başladı");
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTimeAsync);
            timer.Interval = 3600000;
            timer.Enabled = true;
        }

        public void Stop()
        {
            WriteToFile("Service Tamamlandı " + DateTime.Now);
            SendMessageFromTelegramBot("Servis sonlandırıldı");
        }

        private void WriteToFile(string Message)
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

        private static void SendMessageFromTelegramBot(string message)
        {
            botClient.SendTextMessageAsync("-535329225", message);
        }

        private void ReSync()
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "NET";
            p.StartInfo.Arguments = "TIME \\\\SERVERNAME /SET /YES";
            p.Start();
            p.WaitForExit();
        }

        private async static void OnElapsedTimeAsync(object source, ElapsedEventArgs e)
        {
            GenerateOTTLine.GenerateOTT();

            await BinanceTrade.TradeAsync();
        }
    }
}
