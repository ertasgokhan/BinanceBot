using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace BinanceBot
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    new GokhanService(),
            //    new BulutService(),
            //    new CommonService()
            //};

            var commonService = new CommonService();

            ServiceBase.Run(commonService);

            var gokhanService = new GokhanService();

            ServiceBase.Run(gokhanService);

            var bulutService = new BulutService();

            ServiceBase.Run(bulutService);
        }
    }
}
