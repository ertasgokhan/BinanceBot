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
    public partial class Service1 : ServiceBase
    {
        InnerOperation obj = new InnerOperation();

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            obj.Start();
        }

        protected override void OnStop()
        {
            obj.Stop();
        }
    }
}
