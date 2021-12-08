using System.Linq;
using System.Windows;
using System.Windows.Media;
using log4net;

namespace RLD.Presentation
{
    public partial class RadioConfirmDelete : Window
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public RadioConfirmDelete()
        {
            InitializeComponent();

            log4net.Config.XmlConfigurator.Configure();

            Log.Info("Opened RadioConfirmDelete window.");

            using (var db = new ApplicationContext())
            {
                if (db.Settings.Where(item => item.Name == "Theme").FirstOrDefault().Value == "Dark")
                {
                    var darkColor = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    var lightColor = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                    Background = darkColor;
                    Foreground = lightColor;

                    sureTextBlock.Foreground = lightColor;

                    OKButton.Background = darkColor;
                    OKButton.Foreground = lightColor;
                    cancelButton.Background = darkColor;
                    cancelButton.Foreground = lightColor;
                }
                else if (db.Settings.Where(item => item.Name == "Theme").FirstOrDefault().Value == "Light")
                {
                    var lightColor = new SolidColorBrush(Color.FromRgb(235, 235, 235));
                    var darkColor = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                    Background = lightColor;
                    Foreground = darkColor;

                    sureTextBlock.Foreground = darkColor;

                    OKButton.Background = lightColor;
                    OKButton.Foreground = darkColor;
                    cancelButton.Background = lightColor;
                    cancelButton.Foreground = darkColor;
                }

                Log.Info($"{db.Settings.Where(item => item.Name == "Theme").FirstOrDefault().Value} theme enabled.");
            }
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            Log.Info("Results accepted.");
            DialogResult = true; 
        }
    }
}