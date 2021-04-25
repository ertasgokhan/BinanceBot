using System.Configuration;

namespace BinanceBot
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.commonServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            // 
            // commonServiceInstaller
            // 
            this.commonServiceInstaller.Description = ConfigurationManager.AppSettings["ServiceDescription"];
            this.commonServiceInstaller.DisplayName = ConfigurationManager.AppSettings["ServiceName"];
            this.commonServiceInstaller.ServiceName = ConfigurationManager.AppSettings["ServiceName"];
            // 
            // serviceProcessInstaller1
            // 
            this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller1.Password = null;
            this.serviceProcessInstaller1.Username = null;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.commonServiceInstaller,
            this.serviceProcessInstaller1});

        }

        #endregion
        private System.ServiceProcess.ServiceInstaller commonServiceInstaller;
        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;
    }
}