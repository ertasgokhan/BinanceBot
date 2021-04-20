using Binance.Generate.OTT;
using Binance.OTT.Trade;
using System.ServiceProcess;

namespace BinanceBot
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
        }


        //        static async System.Threading.Tasks.Task Main()
        //        {
        //#if (!DEBUG)
        //            ServiceBase[] ServicesToRun;
        //            ServicesToRun = new ServiceBase[]
        //            {
        //                new Service1()
        //            };
        //            ServiceBase.Run(ServicesToRun);
        //#else
        //            Service1 myServ = new Service1();
        //            //myServ.Process();


        //            GenerateOTTLine.GenerateOTT();

        //            await BinanceTrade.TradeAsync();

        //            // here Process is my Service function
        //            // that will run when my service onstart is call
        //            // you need to call your own method or function name here instead of Process();
        //#endif
        //        }
    }
}
