using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace BinanceBot
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();

            this.commonServiceInstaller.Description = ConfigurationManager.AppSettings["ServiceDescription"];
            this.commonServiceInstaller.DisplayName = ConfigurationManager.AppSettings["ServiceName"];
            this.commonServiceInstaller.ServiceName = ConfigurationManager.AppSettings["ServiceName"];
        }

        private void serviceProcessInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }

        private void BinanceBot_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}
