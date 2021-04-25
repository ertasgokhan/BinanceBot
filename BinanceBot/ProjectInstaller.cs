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

            var config = ConfigurationManager.OpenExeConfiguration(this.GetType().Assembly.Location);

            if (config.AppSettings.Settings["ServiceName"] != null)
            {
                this.commonServiceInstaller.ServiceName = config.AppSettings.Settings["ServiceName"].Value;
            }
            if (config.AppSettings.Settings["DisplayName"] != null)
            {
                this.commonServiceInstaller.DisplayName = config.AppSettings.Settings["DisplayName"].Value;
            }
            if (config.AppSettings.Settings["Description"] != null)
            {
                this.commonServiceInstaller.Description = config.AppSettings.Settings["Description"].Value;
            }
        }

        private void serviceProcessInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }

        private void BinanceBot_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}
