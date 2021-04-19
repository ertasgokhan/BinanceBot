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
        private static EnvironmentVariables environmentVariables = new EnvironmentVariables();
        private static TelegramBotClient botClient = new TelegramBotClient(environmentVariables.TelegramToken);

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
            botClient.SendTextMessageAsync("-1001152564061", message);
        }

        private static void readEnvironmentVariables()
        {
            string filepath = sourceDirectory + "environment_variables.txt";

            using (StreamReader rd = File.OpenText(filepath))
            {
                while (!rd.EndOfStream)
                {
                    string str = rd.ReadLine();
                    environmentVariables.TelegramToken = str.Split(';')[2];
                    environmentVariables.ChatId = str.Split(';')[3];
                }
            }
        }

        private async static void OnElapsedTimeAsync(object source, ElapsedEventArgs e)
        {
            readEnvironmentVariables();

            GenerateOTTLine.GenerateOTT();

            await BinanceTrade.TradeAsync();
        }
    }
}
