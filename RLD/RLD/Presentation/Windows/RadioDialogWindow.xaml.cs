using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using log4net;
using RLD.BLL;

namespace RLD.Presentation
{
    /// <summary>
    /// Interaction logic for RadioDialogWindow.xaml
    /// </summary>
    public partial class RadioDialogWindow : Window
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private byte[] Image { get; set; }

        public RadioDialogWindow()
        {
            InitializeComponent();

            log4net.Config.XmlConfigurator.Configure();

            Log.Info("Opened RadioDialog window.");

            using (var db = new ApplicationContext())
            {
                if (db.Settings.Where(item => item.Name == "Theme").FirstOrDefault().Value == "Dark")
                {
                    var darkColor = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    var lightColor = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                    Background = darkColor;
                    Foreground = lightColor;

                    radioNameInput.Background = darkColor;
                    radioNameInput.Foreground = lightColor;
                    radioUrlInput.Background = darkColor;
                    radioUrlInput.Foreground = lightColor;

                    browseButton.Background = darkColor;
                    browseButton.Foreground = lightColor;
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

                    radioNameInput.Background = lightColor;
                    radioNameInput.Foreground = darkColor;
                    radioUrlInput.Background = lightColor;
                    radioUrlInput.Foreground = darkColor;

                    browseButton.Background = lightColor;
                    browseButton.Foreground = darkColor;
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
            using (var db = new ApplicationContext())
            {
                var existingRadio = db.Radios.FirstOrDefault(item => item.Name == radioNameInput.Text);

                if (existingRadio == null)
                {
                    if (radioNameInput.Text == string.Empty)
                    {
                        Log.Warn("Radio name is not entered.");
                        MessageBox.Show("Enter radio name");
                    }
                    else if (radioUrlInput.Text == string.Empty)
                    {
                        Log.Warn("Radio URL is not entered.");
                        MessageBox.Show("Enter radio URL");
                    }
                    else
                    {
                        Radio radio = new();
                        radio.Name = radioNameInput.Text;
                        radio.StreamURL = radioUrlInput.Text;
                        radio.Logotype = Image;
                        db.Radios.Add(radio);
                        db.SaveChanges();
                        DialogResult = true;
                    }
                }
                else
                {
                    Log.Warn($"Radio {existingRadio.Name} already exists.");
                    MessageBox.Show("Radio with this name already exists");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                FileName = "Image",
                DefaultExt = ".png",
                Filter = "Image (.png)|*.png"
            };

            bool? result = dialog.ShowDialog();

            Stream file;
            try
            {
                file = dialog.OpenFile();
                using (var db = new ApplicationContext())
                {
                    byte[] fileData = null;

                    using (var binaryReader = new BinaryReader(file))
                    {
                        fileData = binaryReader.ReadBytes((int)file.Length);
                    }

                    if (fileData != null)
                    {
                        Image = fileData;
                    }
                }

                Log.Info("Radio icon was added.");
            }
            catch (Exception)
            {
                Log.Error("Unknown error happened.");
                return;
            }
        }
    }
}
