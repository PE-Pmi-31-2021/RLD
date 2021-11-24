using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using RLD.BLL;
using RLD.Presentation;
using RLD.Presentation.Windows;
using System.IO;


namespace RLD.Pages
{
    public partial class RadiosPage : Page
    {
        bool isPlaying = false;
        BitmapImage playIcon = new BitmapImage();
        BitmapImage pauseIcon = new BitmapImage();
        BitmapImage defaultImage = new BitmapImage();

        public RadiosPage()
        {
            InitializeComponent();

            using (var db = new ApplicationContext())
            {
                var query = from b in db.Radios
                            select b;

                foreach (var item in query)
                {
                    listbox1.Items.Add(item.Name);
                }
            }

            
            playIcon.BeginInit();
            playIcon.UriSource = new Uri(@"../../Icons/PlayIcon.png", UriKind.Relative);
            playIcon.EndInit();

            
            pauseIcon.BeginInit();
            pauseIcon.UriSource = new Uri(@"../../Icons/PauseIcon.png", UriKind.Relative);
            pauseIcon.EndInit();

            defaultImage.BeginInit();
            defaultImage.UriSource = new Uri(@"../../Icons/DefaultRadioIcon.png", UriKind.Relative);
            defaultImage.EndInit();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Settings settingsPage = new Settings();
            this.Content = new Frame() { Content = settingsPage };
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Cards cardsPage = new Cards();
            this.Content = new Frame() { Content = cardsPage };
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            BooksPage booksPage = new BooksPage();
            this.Content = new Frame() { Content = booksPage };
        }

        public byte[] StreamToBytes(Stream image)
        {
            byte[] fileData = null;

            using (var binaryReader = new BinaryReader(image))
            {
                fileData = binaryReader.ReadBytes((int)image.Length);
            }

            return fileData;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listbox1.SelectedItem != null)
            {
                using (var db = new ApplicationContext())
                {
                    var currentRadio = db.Radios.FirstOrDefault(item => item.Name == listbox1.SelectedItem.ToString());

                    if (currentRadio.Logotype != null)
                    {
                        BitmapImage currentRadioImage = new BitmapImage();
                        currentRadioImage.BeginInit();
                        currentRadioImage.StreamSource = new MemoryStream(currentRadio.Logotype);
                        currentRadioImage.EndInit();
                        radioLogotype.Source = currentRadioImage;
                    }
                    else
                    {
                        radioLogotype.Source = defaultImage;
                    }

                    try
                    {
                        radioPlayer.Source = new System.Uri(currentRadio.StreamURL);
                    }
                    catch
                    {
                        MessageBox.Show("Invalid radio url");
                    }
                }
            }
            else
            {
                radioLogotype.Source = defaultImage;
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (listbox1.SelectedItem != null)
            {
                RadioConfirmDelete window = new RadioConfirmDelete();
                window.ShowDialog();

                bool? result = window.DialogResult;

                if (result.HasValue && result == true)
                {
                    using (var db = new ApplicationContext())
                    {
                        db.Radios.Remove(db.Radios.FirstOrDefault(item => item.Name == listbox1.SelectedItem.ToString()));
                        db.SaveChanges();
                    }
                    listbox1.Items.RemoveAt(listbox1.Items.IndexOf(listbox1.SelectedItem));
                }
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            RadioDialogWindow window = new RadioDialogWindow();
            window.ShowDialog();

            listbox1.Items.Clear();
            using (var db = new ApplicationContext())
            {
                var query = from b in db.Radios
                            select b;

                foreach (var item in query)
                {
                    listbox1.Items.Add(item.Name);
                }
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {

                radioPlayer.Stop();
                isPlaying = false;
                playingIcon.Source = playIcon;
            }
            else
            {
                radioPlayer.Play();
                isPlaying = true;
                playingIcon.Source = pauseIcon;
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            radioPlayer.Volume -= 0.05;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            radioPlayer.Volume += 0.05;
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            if (listbox1.SelectedItem != null)
            {
                Radio radio;
                using (var db = new ApplicationContext())
                {
                    radio = db.Radios.FirstOrDefault(item => item.Name == listbox1.SelectedItem.ToString());
                }

                RadioEditDialog window = new RadioEditDialog(radio.Name, radio.StreamURL);
                window.ShowDialog();

                listbox1.Items.Clear();
                using (var db = new ApplicationContext())
                {
                    var query = from b in db.Radios
                                select b;

                    foreach (var item in query)
                    {
                        listbox1.Items.Add(item.Name);
                    }
                }
            }
        }
    }
}
