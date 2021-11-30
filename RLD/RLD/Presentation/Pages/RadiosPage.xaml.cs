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

        BitmapImage addIcon = new BitmapImage();
        BitmapImage booksIcon = new BitmapImage();
        BitmapImage cardsIcon = new BitmapImage();
        BitmapImage editIcon = new BitmapImage();
        BitmapImage playIcon = new BitmapImage();
        BitmapImage pauseIcon = new BitmapImage();
        BitmapImage defaultRadioIcon = new BitmapImage();
        BitmapImage radiosIcon = new BitmapImage();
        BitmapImage removeIcon = new BitmapImage();
        BitmapImage RLDIcon = new BitmapImage();
        BitmapImage settingsIcon = new BitmapImage();
        BitmapImage volumeMinusIcon = new BitmapImage();
        BitmapImage volumePlusIcon = new BitmapImage();

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

                if (db.Settings.Where(item => item.Name == "Theme").FirstOrDefault().Value == "Dark")
                {
                  
                    RLDLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    radiosLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    booksLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    cardsLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    settingsLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                    RLDButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    radiosButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    booksButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    cardsButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    settingsButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));

                    addIcon.BeginInit();
                    addIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Add);
                    addIcon.EndInit();
                    addIconXAML.Source = addIcon;

                    booksIcon.BeginInit();
                    booksIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Books);
                    booksIcon.EndInit();
                    booksIconXAML.Source = booksIcon;

                    cardsIcon.BeginInit();
                    cardsIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Cards);
                    cardsIcon.EndInit();
                    cardsIconXAML.Source = cardsIcon;

                    editIcon.BeginInit();
                    editIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Edit);
                    editIcon.EndInit();
                    editIconXAML.Source = editIcon;

                    playIcon.BeginInit();
                    playIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Play);
                    playIcon.EndInit();
                    playIconXAML.Source = playIcon;

                    pauseIcon.BeginInit();
                    pauseIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Pause);
                    pauseIcon.EndInit();

                    defaultRadioIcon.BeginInit();
                    defaultRadioIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.DefaultRadio);
                    defaultRadioIcon.EndInit();
                    defaultRadioIconXAML.Source = defaultRadioIcon;

                    radiosIcon.BeginInit();
                    radiosIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Radios);
                    radiosIcon.EndInit();
                    radiosIconXAML.Source = radiosIcon;

                    removeIcon.BeginInit();
                    removeIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Remove);
                    removeIcon.EndInit();
                    removeIconXAML.Source = removeIcon;

                    RLDIcon.BeginInit();
                    RLDIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.RLD);
                    RLDIcon.EndInit();
                    RLDIconXAML.Source = RLDIcon;

                    settingsIcon.BeginInit();
                    settingsIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Settings);
                    settingsIcon.EndInit();
                    settingsIconXAML.Source = settingsIcon;

                    volumeMinusIcon.BeginInit();
                    volumeMinusIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.VolumeMinus);
                    volumeMinusIcon.EndInit();
                    volumeMinusIconXAML.Source = volumeMinusIcon;

                    volumePlusIcon.BeginInit();
                    volumePlusIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.VolumePlus);
                    volumePlusIcon.EndInit();
                    volumePlusIconXAML.Source = volumePlusIcon;

                    addButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    editButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    removeButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    playButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    volumeMinusButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    volumePlusButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                }

                else if (db.Settings.Where(item => item.Name == "Theme").FirstOrDefault().Value == "Light")
                {
                    RLDLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    radiosLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    booksLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    cardsLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    settingsLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                    RLDButton.Background = new SolidColorBrush(Color.FromRgb(235, 235, 235));
                    radiosButton.Background = new SolidColorBrush(Color.FromRgb(235, 235, 235));
                    booksButton.Background = new SolidColorBrush(Color.FromRgb(235, 235, 235));
                    cardsButton.Background = new SolidColorBrush(Color.FromRgb(235, 235, 235));
                    settingsButton.Background = new SolidColorBrush(Color.FromRgb(235, 235, 235));

                    addIcon.BeginInit();
                    addIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Add);
                    addIcon.EndInit();
                    addIconXAML.Source = addIcon;

                    booksIcon.BeginInit();
                    booksIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Books);
                    booksIcon.EndInit();
                    booksIconXAML.Source = booksIcon;

                    cardsIcon.BeginInit();
                    cardsIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Cards);
                    cardsIcon.EndInit();
                    cardsIconXAML.Source = cardsIcon;

                    editIcon.BeginInit();
                    editIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Edit);
                    editIcon.EndInit();
                    editIconXAML.Source = editIcon;

                    playIcon.BeginInit();
                    playIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Play);
                    playIcon.EndInit();
                    playIconXAML.Source = playIcon;

                    pauseIcon.BeginInit();
                    pauseIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Pause);
                    pauseIcon.EndInit();

                    defaultRadioIcon.BeginInit();
                    defaultRadioIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.DefaultRadio);
                    defaultRadioIcon.EndInit();
                    defaultRadioIconXAML.Source = defaultRadioIcon;

                    radiosIcon.BeginInit();
                    radiosIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Radios);
                    radiosIcon.EndInit();
                    radiosIconXAML.Source = radiosIcon;

                    removeIcon.BeginInit();
                    removeIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Remove);
                    removeIcon.EndInit();
                    removeIconXAML.Source = removeIcon;

                    RLDIcon.BeginInit();
                    RLDIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.RLD);
                    RLDIcon.EndInit();
                    RLDIconXAML.Source = RLDIcon;

                    settingsIcon.BeginInit();
                    settingsIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Settings);
                    settingsIcon.EndInit();
                    settingsIconXAML.Source = settingsIcon;

                    volumeMinusIcon.BeginInit();
                    volumeMinusIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.VolumeMinus);
                    volumeMinusIcon.EndInit();
                    volumeMinusIconXAML.Source = volumeMinusIcon;

                    volumePlusIcon.BeginInit();
                    volumePlusIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.VolumePlus);
                    volumePlusIcon.EndInit();
                    volumePlusIconXAML.Source = volumePlusIcon;

                    addButton.Background = new SolidColorBrush(Color.FromRgb(235, 235, 235));
                    editButton.Background = new SolidColorBrush(Color.FromRgb(235, 235, 235));
                    removeButton.Background = new SolidColorBrush(Color.FromRgb(235, 235, 235));
                    playButton.Background = new SolidColorBrush(Color.FromRgb(235, 235, 235));
                    volumeMinusButton.Background = new SolidColorBrush(Color.FromRgb(235, 235, 235));
                    volumePlusButton.Background = new SolidColorBrush(Color.FromRgb(235, 235, 235));
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
            if (isPlaying)
            {
                radioPlayer.Stop();
                isPlaying = false;
                playIconXAML.Source = playIcon;
            }
            Settings settingsPage = new Settings();
            this.Content = new Frame() { Content = settingsPage };
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                radioPlayer.Stop();
                isPlaying = false;
                playIconXAML.Source = playIcon;
            }
            Cards cardsPage = new Cards();
            this.Content = new Frame() { Content = cardsPage };
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                radioPlayer.Stop();
                isPlaying = false;
                playIconXAML.Source = playIcon;
            }
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
                        defaultRadioIconXAML.Source = currentRadioImage;
                    }
                    else
                    {
                        defaultRadioIconXAML.Source = defaultRadioIcon;
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
                defaultRadioIconXAML.Source = defaultRadioIcon;
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
                playIconXAML.Source = playIcon;
            }
            else
            {
                radioPlayer.Play();
                isPlaying = true;
                playIconXAML.Source = pauseIcon;
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
