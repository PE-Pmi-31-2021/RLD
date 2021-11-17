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
using System.IO;


namespace RLD.Pages
{
    public partial class RadiosPage : Page
    {
        bool isPlaying = false;
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
            //Settings settingsPage = new Settings();
            //this.Content = settingsPage;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Cards cardsPage = new Cards();
            this.Content = new Frame() { Content = cardsPage };
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Books booksPage = new Books();
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
            using (var db = new ApplicationContext())
            {
                var currentRadio = from r in db.Radios
                                   where r.Name == listbox1.SelectedItem.ToString()
                                   select r;

                BitmapImage currentRadioImage = new BitmapImage();
                currentRadioImage.BeginInit();
                currentRadioImage.StreamSource = new MemoryStream(currentRadio.FirstOrDefault().Logotype);
                currentRadioImage.EndInit();

                radioLogotype.Source = currentRadioImage;
                radioPlayer.Source = new System.Uri(currentRadio.FirstOrDefault().SteamURL);
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

                        db.Radios.Remove(db.Radios.FirstOrDefault(item => item.Name == listbox1.SelectedItem));
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
            }
            else
            {
                radioPlayer.Play();
                isPlaying = true;
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationContext())
            {
                var radios = from r in db.Radios
                             select r;

                var nextRadio = radios.SkipWhile(x => x.Name != listbox1.SelectedItem.ToString()).Skip(1).FirstOrDefault();

                listbox1.SelectedItem = nextRadio.Name;
                //BitmapImage nextRadioImage = new BitmapImage();
                //nextRadioImage.BeginInit();
                //nextRadioImage.StreamSource = new MemoryStream(nextRadio.Logotype);
                //nextRadioImage.EndInit();

                //radioLogotype.Source = nextRadioImage;
                //radioPlayer.Source = new System.Uri(nextRadio.SteamURL);
            }
        }
    }
}
