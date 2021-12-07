﻿using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using RLD.BLL;

namespace RLD.Presentation.Windows
{
    public partial class RadioEditDialog : Window
    {
        private byte[] Image { get; set; }
        private string PreviousName { get; set; }

        private bool imageChanged;

        public RadioEditDialog(string radioName, string radioUrl)
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

            PreviousName = radioName;
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
                    if (radioNameInput.Text == string.Empty)
                    {
                        MessageBox.Show("Enter radio name");
                    }
                    else if (radioUrlInput.Text == string.Empty)
                    {
                        MessageBox.Show("Enter radio url");
                    }
                    else
                    {
                        existingRadio.Name = radioNameInput.Text;
                        existingRadio.StreamURL = radioUrlInput.Text;
                        if (imageChanged)
                        {
                            existingRadio.Logotype = Image;
                        }

                        db.Update(existingRadio);
                        db.SaveChanges();
                        this.DialogResult = true;
                    }
                }
                else
                {
                    var previousRadio = db.Radios.FirstOrDefault(item => item.Name == PreviousName);
                    if (previousRadio != null)
                    {
                        Image = previousRadio.Logotype;
                    }

                    if (radioNameInput.Text == string.Empty)
                    {
                        MessageBox.Show("Enter radio name");
                    }
                    else if (radioUrlInput.Text == string.Empty)
                    {
                        MessageBox.Show("Enter radio url");
                    }
                    else
                    {
                        Radio radio = new Radio();
                        radio.Name = radioNameInput.Text;
                        radio.StreamURL = radioUrlInput.Text;
                        radio.Logotype = Image;
                        db.Radios.Add(radio);
                        db.Radios.Remove(db.Radios.FirstOrDefault(item => item.Name == PreviousName));
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
                        Image = fileData;
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
