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
            this.gokhanServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            this.bulutServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // commonServiceInstaller
            // 
            this.commonServiceInstaller.Description = "Common Service Trade";
            this.commonServiceInstaller.DisplayName = "CommonService";
            this.commonServiceInstaller.ServiceName = "CommonService";
            // 
            // gokhanServiceInstaller
            // 
            this.gokhanServiceInstaller.Description = "Gokhan Service Trade";
            this.gokhanServiceInstaller.DisplayName = "GokhanService";
            this.gokhanServiceInstaller.ServiceName = "GokhanService";
            // 
            // serviceProcessInstaller1
            // 
            this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller1.Password = null;
            this.serviceProcessInstaller1.Username = null;
            // 
            // bulutServiceInstaller
            // 
            this.bulutServiceInstaller.Description = "Bulut Service Trade";
            this.bulutServiceInstaller.DisplayName = "BulutService";
            this.bulutServiceInstaller.ServiceName = "BulutService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.gokhanServiceInstaller,
            this.commonServiceInstaller,
            this.serviceProcessInstaller1,
            this.bulutServiceInstaller});

        }

        #endregion
        public System.ServiceProcess.ServiceInstaller bulutServiceInstaller;
        public System.ServiceProcess.ServiceInstaller commonServiceInstaller;
        public System.ServiceProcess.ServiceInstaller gokhanServiceInstaller;
        public System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;
    }
}