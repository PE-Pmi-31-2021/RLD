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

namespace RLD.Presentation.Windows
{
    public partial class RadioEditDialog : Window
    {
        byte[] image { get; set; }
        string previousName { get; set; }
        bool imageChanged = false;

        public RadioEditDialog(string radioName, string radioUrl)
        {
            InitializeComponent();
            previousName = radioName;
            radioNameInput.Text = radioName;
            radioUrlInput.Text = radioUrl;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationContext())
            {
                var existingRadio = db.Radios.FirstOrDefault(item => item.Name == radioNameInput.Text);
                
                if (existingRadio != null)
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
                        existingRadio.Name = radioNameInput.Text;
                        existingRadio.StreamURL = radioUrlInput.Text;
                        if (imageChanged)
                        {
                            existingRadio.Logotype = image;
                        }
                        db.Update(existingRadio);
                        db.SaveChanges();
                        this.DialogResult = true;
                    }
                }
                else
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
                        db.Radios.Remove(db.Radios.FirstOrDefault(item => item.Name == previousName));
                        db.SaveChanges();
                        this.DialogResult = true;
                    }
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            imageChanged = true;
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
