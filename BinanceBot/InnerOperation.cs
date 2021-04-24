using Binance.Generate.OTT;
using Binance.OTT.Trade;
using Binance.UtilitiesLib;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Telegram.Bot;
using Timer = System.Timers.Timer;

namespace BinanceBot
{
    public class InnerOperation
    {
        public string sourceDirectory;
        public string accountName;
        Timer timer = new Timer();
        private static EnvironmentVariables environmentVariables = new EnvironmentVariables();
        private static TelegramBotClient botClient;

        public async Task StartAsync(string account)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
            sourceDirectory = @"C:\TradeBot\" + account;
            accountName = account;
            readEnvironmentVariables();
            SendMessageFromTelegramBot("Servis çalışmaya başladı");
            WriteToFile("Service Başladı " + DateTime.Now);
            // Create Timer
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTimeAsync);
            timer.Interval = 3600000;
            timer.Enabled = true;
            // Generate OTT && Trade
            await GenerateOTTLine.GenerateOTT(account);
            await BinanceTrade.TradeAsync(account);
        }

        public void Stop()
        {
            WriteToFile("Servis Sonlandırıldı " + DateTime.Now);
            SendMessageFromTelegramBot("Servis Sonlandırıldı");
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

        private static async void SendMessageFromTelegramBot(string message)
        {
            await botClient.SendTextMessageAsync(environmentVariables.w, message);
        }

        private void readEnvironmentVariables()
        {
            string filepath = sourceDirectory + "environment_variables.txt";

            using (StreamReader rd = File.OpenText(filepath))
            {
                while (!rd.EndOfStream)
                {
                    string str = rd.ReadLine();
                    environmentVariables.z = StringCipher.Decrypt(str.Split(';')[2]);
                    environmentVariables.w = StringCipher.Decrypt(str.Split(';')[3]);
                }
            }

            botClient = new TelegramBotClient(environmentVariables.z);
        }

        private async void OnElapsedTimeAsync(object source, ElapsedEventArgs e)
        {
            await GenerateOTTLine.GenerateOTT(accountName);

            await BinanceTrade.TradeAsync(accountName);
        }
    }
}
