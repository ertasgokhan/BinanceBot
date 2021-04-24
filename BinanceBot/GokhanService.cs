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
    public partial class GokhanService : ServiceBase
    {
        InnerOperation obj = new InnerOperation();

        public GokhanService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            obj.StartAsync(@"GOKHAN\\");
        }

        protected override void OnStop()
        {
            obj.Stop();
        }
    }
}
