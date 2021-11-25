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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RLD.Pages
{
    public partial class Settings : Page
    {
        BitmapImage booksIcon = new BitmapImage();
        BitmapImage cardsIcon = new BitmapImage();
        BitmapImage radiosIcon = new BitmapImage();
        BitmapImage RLDIcon = new BitmapImage();
        BitmapImage settingsIcon = new BitmapImage();

        public Settings()
        {
            InitializeComponent();

            using (var db2 = new ApplicationContext())
            {
                if (db2.Settings.Where(item => item.Name == "Theme").FirstOrDefault().Value == "Dark")
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

                    RLDButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    radiosButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    booksButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    cardsButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    settingsButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));

                    booksIcon.BeginInit();
                    booksIcon.StreamSource = new MemoryStream(Icons.IconsResources.BooksIconDark);
                    booksIcon.EndInit();
                    booksIconXAML.Source = booksIcon;

                    cardsIcon.BeginInit();
                    cardsIcon.StreamSource = new MemoryStream(Icons.IconsResources.CardsIconDark);
                    cardsIcon.EndInit();
                    cardsIconXAML.Source = cardsIcon;

                    radiosIcon.BeginInit();
                    radiosIcon.StreamSource = new MemoryStream(Icons.IconsResources.RadiosIconDark);
                    radiosIcon.EndInit();
                    radiosIconXAML.Source = radiosIcon;

                    RLDIcon.BeginInit();
                    RLDIcon.StreamSource = new MemoryStream(Icons.IconsResources.RLDIconDark);
                    RLDIcon.EndInit();
                    RLDIconXAML.Source = RLDIcon;

                    settingsIcon.BeginInit();
                    settingsIcon.StreamSource = new MemoryStream(Icons.IconsResources.SettingsIconDark);
                    settingsIcon.EndInit();
                    settingsIconXAML.Source = settingsIcon;



                }

                else if (db2.Settings.Where(item => item.Name == "Theme").FirstOrDefault().Value == "Light")
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

                    booksIcon.BeginInit();
                    booksIcon.StreamSource = new MemoryStream(Icons.IconsResources.BooksIconLight);
                    booksIcon.EndInit();
                    booksIconXAML.Source = booksIcon;

                    cardsIcon.BeginInit();
                    cardsIcon.StreamSource = new MemoryStream(Icons.IconsResources.CardsIconLight);
                    cardsIcon.EndInit();
                    cardsIconXAML.Source = cardsIcon;

                    radiosIcon.BeginInit();
                    radiosIcon.StreamSource = new MemoryStream(Icons.IconsResources.RadiosIconLight);
                    radiosIcon.EndInit();
                    radiosIconXAML.Source = radiosIcon;

                    RLDIcon.BeginInit();
                    RLDIcon.StreamSource = new MemoryStream(Icons.IconsResources.RLDIconLight);
                    RLDIcon.EndInit();
                    RLDIconXAML.Source = RLDIcon;

                    settingsIcon.BeginInit();
                    settingsIcon.StreamSource = new MemoryStream(Icons.IconsResources.SettingsIconLight);
                    settingsIcon.EndInit();
                    settingsIconXAML.Source = settingsIcon;


                }
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                var startPage = db.Settings.FirstOrDefault(item => item.Name == "StartPage");
                if (startPage != null)
                {
                    if (startPage.Value == "Radios")
                    {
                        radioButtonRadios.IsChecked = true;
                    }
                    else if (startPage.Value == "Cards")
                    {
                        radioButtonCards.IsChecked = true;
                    }
                    else if (startPage.Value == "Books")
                    {
                        radioButtonBooks.IsChecked = true;
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RadiosPage radiosPage = new RadiosPage();
            this.Content = new Frame() { Content = radiosPage };
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Cards cardsPage = new Cards();
            this.Content = new Frame() { Content = cardsPage };
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BooksPage booksPage = new BooksPage();
            this.Content = new Frame() { Content = booksPage };
        }

        private void radioButtonBooks_Checked(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var startPage = db.Settings.FirstOrDefault(item => item.Name == "StartPage");
                if (startPage != null)
                {
                    startPage.Value = "Books";
                    db.SaveChanges();
                }
            }
        }

        private void radioButtonRadios_Checked(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var startPage = db.Settings.FirstOrDefault(item => item.Name == "StartPage");
                if (startPage != null)
                {
                    startPage.Value = "Radios";
                    db.SaveChanges();
                }
            }
        }

        private void radioButtonCards_Checked(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var startPage = db.Settings.FirstOrDefault(item => item.Name == "StartPage");
                if (startPage != null)
                {
                    startPage.Value = "Cards";
                    db.SaveChanges();
                }
            }
        }
    }
}
