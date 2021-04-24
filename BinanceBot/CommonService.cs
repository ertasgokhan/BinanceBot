using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace BinanceBot
{
    public partial class CommonService : ServiceBase
    {
        InnerOperation obj = new InnerOperation();

        public CommonService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            obj.StartAsync(@"COMMON\\");
        }

        protected override void OnStop()
        {
            obj.Stop();
        }
    }
}
