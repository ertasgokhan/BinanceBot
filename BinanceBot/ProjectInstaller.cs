using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;

namespace BinanceBot
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void serviceProcessInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }

        private void BinanceBot_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}
