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
