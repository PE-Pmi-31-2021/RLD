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
        BitmapImage RLDIcon = new BitmapImage();
        BitmapImage radiosIcon = new BitmapImage();
        BitmapImage booksIcon = new BitmapImage();
        BitmapImage cardsIcon = new BitmapImage();
        BitmapImage settingsIcon = new BitmapImage();
        BitmapImage addIcon = new BitmapImage();
        BitmapImage editIcon = new BitmapImage();
        BitmapImage removeIcon = new BitmapImage();
        BitmapImage playIcon = new BitmapImage();
        BitmapImage pauseIcon = new BitmapImage();
        BitmapImage volumeMinusIcon = new BitmapImage();
        BitmapImage volumePlusIcon = new BitmapImage();
        BitmapImage defaultRadioIcon = new BitmapImage();

        bool isRadioPlaying = false;

        public RadiosPage()
        {
            InitializeComponent();

            using (var db = new ApplicationContext())
            {
                var radios = from r in db.Radios
                             select r;

                foreach (var radio in radios)
                {
                    radiosListBox.Items.Add(radio.Name);
                }

                if (db.Settings.Where(item => item.Name == "Theme").FirstOrDefault().Value == "Dark")
                {
                    var darkColor = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    var lightColor = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                    RLDLabel.Foreground = lightColor;
                    radiosLabel.Foreground = lightColor;
                    booksLabel.Foreground = lightColor;
                    cardsLabel.Foreground = lightColor;
                    settingsLabel.Foreground = lightColor;

                    RLDButton.Background = darkColor;
                    radiosButton.Background = darkColor;
                    booksButton.Background = darkColor;
                    cardsButton.Background = darkColor;
                    settingsButton.Background = darkColor;
                    addButton.Background = darkColor;
                    editButton.Background = darkColor;
                    removeButton.Background = darkColor;
                    playButton.Background = darkColor;
                    volumeMinusButton.Background = darkColor;
                    volumePlusButton.Background = darkColor;

                    RLDIcon.BeginInit();
                    RLDIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.RLD);
                    RLDIcon.EndInit();
                    RLDIconXAML.Source = RLDIcon;

                    radiosIcon.BeginInit();
                    radiosIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Radios);
                    radiosIcon.EndInit();
                    radiosIconXAML.Source = radiosIcon;

                    booksIcon.BeginInit();
                    booksIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Books);
                    booksIcon.EndInit();
                    booksIconXAML.Source = booksIcon;

                    cardsIcon.BeginInit();
                    cardsIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Cards);
                    cardsIcon.EndInit();
                    cardsIconXAML.Source = cardsIcon;

                    settingsIcon.BeginInit();
                    settingsIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Settings);
                    settingsIcon.EndInit();
                    settingsIconXAML.Source = settingsIcon;

                    addIcon.BeginInit();
                    addIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Add);
                    addIcon.EndInit();
                    addIconXAML.Source = addIcon;

                    editIcon.BeginInit();
                    editIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Edit);
                    editIcon.EndInit();
                    editIconXAML.Source = editIcon;

                    removeIcon.BeginInit();
                    removeIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Remove);
                    removeIcon.EndInit();
                    removeIconXAML.Source = removeIcon;

                    playIcon.BeginInit();
                    playIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Play);
                    playIcon.EndInit();
                    playIconXAML.Source = playIcon;

                    pauseIcon.BeginInit();
                    pauseIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Pause);
                    pauseIcon.EndInit();

                    volumeMinusIcon.BeginInit();
                    volumeMinusIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.VolumeMinus);
                    volumeMinusIcon.EndInit();
                    volumeMinusIconXAML.Source = volumeMinusIcon;

                    volumePlusIcon.BeginInit();
                    volumePlusIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.VolumePlus);
                    volumePlusIcon.EndInit();
                    volumePlusIconXAML.Source = volumePlusIcon;
                }

                else if (db.Settings.Where(item => item.Name == "Theme").FirstOrDefault().Value == "Light")
                {
                    var lightColor = new SolidColorBrush(Color.FromRgb(235, 235, 235));
                    var darkColor = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                    RLDLabel.Foreground = darkColor;
                    radiosLabel.Foreground = darkColor;
                    booksLabel.Foreground = darkColor;
                    cardsLabel.Foreground = darkColor;
                    settingsLabel.Foreground = darkColor;

                    RLDButton.Background = lightColor;
                    radiosButton.Background = lightColor;
                    booksButton.Background = lightColor;
                    cardsButton.Background = lightColor;
                    settingsButton.Background = lightColor;
                    addButton.Background = lightColor;
                    editButton.Background = lightColor;
                    removeButton.Background = lightColor;
                    playButton.Background = lightColor;
                    volumeMinusButton.Background = lightColor;
                    volumePlusButton.Background = lightColor;

                    RLDIcon.BeginInit();
                    RLDIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.RLD);
                    RLDIcon.EndInit();
                    RLDIconXAML.Source = RLDIcon;

                    radiosIcon.BeginInit();
                    radiosIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Radios);
                    radiosIcon.EndInit();
                    radiosIconXAML.Source = radiosIcon;

                    booksIcon.BeginInit();
                    booksIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Books);
                    booksIcon.EndInit();
                    booksIconXAML.Source = booksIcon;

                    cardsIcon.BeginInit();
                    cardsIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Cards);
                    cardsIcon.EndInit();
                    cardsIconXAML.Source = cardsIcon;

                    settingsIcon.BeginInit();
                    settingsIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Settings);
                    settingsIcon.EndInit();
                    settingsIconXAML.Source = settingsIcon;

                    addIcon.BeginInit();
                    addIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Add);
                    addIcon.EndInit();
                    addIconXAML.Source = addIcon;

                    editIcon.BeginInit();
                    editIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Edit);
                    editIcon.EndInit();
                    editIconXAML.Source = editIcon;

                    removeIcon.BeginInit();
                    removeIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Remove);
                    removeIcon.EndInit();
                    removeIconXAML.Source = removeIcon;

                    playIcon.BeginInit();
                    playIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Play);
                    playIcon.EndInit();
                    playIconXAML.Source = playIcon;

                    pauseIcon.BeginInit();
                    pauseIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Pause);
                    pauseIcon.EndInit();

                    volumeMinusIcon.BeginInit();
                    volumeMinusIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.VolumeMinus);
                    volumeMinusIcon.EndInit();
                    volumeMinusIconXAML.Source = volumeMinusIcon;

                    volumePlusIcon.BeginInit();
                    volumePlusIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.VolumePlus);
                    volumePlusIcon.EndInit();
                    volumePlusIconXAML.Source = volumePlusIcon;
                }

                defaultRadioIcon.BeginInit();
                defaultRadioIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.DefaultRadio);
                defaultRadioIcon.EndInit();
                defaultRadioIconXAML.Source = defaultRadioIcon;
            }
        }

        private void booksButton_Click(object sender, RoutedEventArgs e)
        {
            if (isRadioPlaying)
            {
                radioPlayer.Stop();
                isRadioPlaying = false;
                playIconXAML.Source = playIcon;
            }

            BooksPage booksPage = new BooksPage();
            Content = new Frame() { Content = booksPage };
        }

        private void cardsButton_Click(object sender, RoutedEventArgs e)
        {
            if (isRadioPlaying)
            {
                radioPlayer.Stop();
                isRadioPlaying = false;
                playIconXAML.Source = playIcon;
            }

            Cards cardsPage = new Cards();
            Content = new Frame() { Content = cardsPage };
        }

        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            if (isRadioPlaying)
            {
                radioPlayer.Stop();
                isRadioPlaying = false;
                playIconXAML.Source = playIcon;
            }

            Settings settingsPage = new Settings();
            Content = new Frame() { Content = settingsPage };
        }

        private void radiosListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (radiosListBox.SelectedItem != null)
            {
                using (var db = new ApplicationContext())
                {
                    var currentRadio = db.Radios.FirstOrDefault(radio => radio.Name == radiosListBox.SelectedItem.ToString());

                    if (currentRadio.Logotype != null)
                    {
                        BitmapImage currentRadioIcon = new BitmapImage();
                        currentRadioIcon.BeginInit();
                        currentRadioIcon.StreamSource = new MemoryStream(currentRadio.Logotype);
                        currentRadioIcon.EndInit();
                        defaultRadioIconXAML.Source = currentRadioIcon;
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
                        MessageBox.Show("Error: invalid radio URL.");
                    }
                }
            }
            else
            {
                defaultRadioIconXAML.Source = defaultRadioIcon;
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            RadioDialogWindow window = new RadioDialogWindow();
            window.ShowDialog();

            radiosListBox.Items.Clear();

            using (var db = new ApplicationContext())
            {
                var radios = from r in db.Radios
                             select r;

                foreach (var radio in radios)
                {
                    radiosListBox.Items.Add(radio.Name);
                }
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (radiosListBox.SelectedItem != null)
            {
                Radio radioForEdit;
                using (var db = new ApplicationContext())
                {
                    radioForEdit = db.Radios.FirstOrDefault(radio => radio.Name == radiosListBox.SelectedItem.ToString());
                }

                RadioEditDialog window = new RadioEditDialog(radioForEdit.Name, radioForEdit.StreamURL);
                window.ShowDialog();

                radiosListBox.Items.Clear();
                using (var db = new ApplicationContext())
                {
                    var radios = from r in db.Radios
                                 select r;

                    foreach (var radio in radios)
                    {
                        radiosListBox.Items.Add(radio.Name);
                    }
                }
            }
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if (radiosListBox.SelectedItem != null)
            {
                RadioConfirmDelete window = new RadioConfirmDelete();
                window.ShowDialog();

                bool? result = window.DialogResult;

                if (result.HasValue && result == true)
                {
                    using (var db = new ApplicationContext())
                    {
                        db.Radios.Remove(db.Radios.FirstOrDefault(radio => radio.Name == radiosListBox.SelectedItem.ToString()));
                        db.SaveChanges();
                    }
                    radiosListBox.Items.RemoveAt(radiosListBox.Items.IndexOf(radiosListBox.SelectedItem));
                }
            }
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            if (isRadioPlaying)
            {
                radioPlayer.Stop();
                isRadioPlaying = false;
                playIconXAML.Source = playIcon;
            }
            else
            {
                radioPlayer.Play();
                isRadioPlaying = true;
                playIconXAML.Source = pauseIcon;
            }
        }

        private void volumeMinusButton_Click(object sender, RoutedEventArgs e)
        {
            radioPlayer.Volume -= 0.05;
        }

        private void volumePlusButton_Click(object sender, RoutedEventArgs e)
        {
            radioPlayer.Volume += 0.05;
        }
    }
}
