using System.Windows;
using log4net;

namespace RLD
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(App));

        protected override void OnStartup(StartupEventArgs e)
        {
            var splash = new SplashScreen("SplashScreen.jpg");
            splash.Show(true, true);
            log4net.Config.XmlConfigurator.Configure();
            Log.Info("App loaded.");
            base.OnStartup(e);
        }
    }
}
