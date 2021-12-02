using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RLD.BLL;

namespace RLD.Presentation
{
    /// <summary>
    /// Interaction logic for RadioDialogWindow.xaml
    /// </summary>
    public partial class RadioDialogWindow : Window
    {
        byte[] image { get; set; }

        public RadioDialogWindow()
        {
            InitializeComponent();

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
            }
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationContext())
            {
                var existingRadio = db.Radios.FirstOrDefault(item => item.Name == radioNameInput.Text);
                
                if (existingRadio == null)
                {
                    if (radioNameInput.Text == "")
                    {
                        MessageBox.Show("Enter radio name");
                    }
                    else if (radioUrlInput.Text == "")
                    {
                        MessageBox.Show("Enter radio url");
                    }
                    else
                    {
                        Radio radio = new Radio();
                        radio.Name = radioNameInput.Text;
                        radio.StreamURL = radioUrlInput.Text;
                        radio.Logotype = image;
                        db.Radios.Add(radio);
                        db.SaveChanges();
                        this.DialogResult = true;
                    }
                }
                else
                {
                    MessageBox.Show("Radio with this name already exists");
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Image";
            dialog.DefaultExt = ".png";
            dialog.Filter = "Image (.png)|*.png";

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
                        image = fileData;
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
