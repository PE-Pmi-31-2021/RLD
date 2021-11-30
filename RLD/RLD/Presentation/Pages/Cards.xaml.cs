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
    /// <summary>
    /// Interaction logic for Cards.xaml
    /// </summary>
    public partial class Cards : Page
    {
        BitmapImage booksIcon = new BitmapImage();
        BitmapImage cardsIcon = new BitmapImage();
        BitmapImage radiosIcon = new BitmapImage();
        BitmapImage RLDIcon = new BitmapImage();
        BitmapImage settingsIcon = new BitmapImage();

        public Cards()
        {
            InitializeComponent();

            using (var db = new ApplicationContext())
            {
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

                    RLDButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    radiosButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    booksButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    cardsButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    settingsButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));

                    booksIcon.BeginInit();
                    booksIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Books);
                    booksIcon.EndInit();
                    booksIconXAML.Source = booksIcon;

                    cardsIcon.BeginInit();
                    cardsIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Cards);
                    cardsIcon.EndInit();
                    cardsIconXAML.Source = cardsIcon;

                    radiosIcon.BeginInit();
                    radiosIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Radios);
                    radiosIcon.EndInit();
                    radiosIconXAML.Source = radiosIcon;

                    RLDIcon.BeginInit();
                    RLDIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.RLD);
                    RLDIcon.EndInit();
                    RLDIconXAML.Source = RLDIcon;

                    settingsIcon.BeginInit();
                    settingsIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Settings);
                    settingsIcon.EndInit();
                    settingsIconXAML.Source = settingsIcon;

                    

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

                    booksIcon.BeginInit();
                    booksIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Books);
                    booksIcon.EndInit();
                    booksIconXAML.Source = booksIcon;

                    cardsIcon.BeginInit();
                    cardsIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Cards);
                    cardsIcon.EndInit();
                    cardsIconXAML.Source = cardsIcon;

                    radiosIcon.BeginInit();
                    radiosIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Radios);
                    radiosIcon.EndInit();
                    radiosIconXAML.Source = radiosIcon;

                    RLDIcon.BeginInit();
                    RLDIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.RLD);
                    RLDIcon.EndInit();
                    RLDIconXAML.Source = RLDIcon;

                    settingsIcon.BeginInit();
                    settingsIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Settings);
                    settingsIcon.EndInit();
                    settingsIconXAML.Source = settingsIcon;


                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Settings settingsPage = new Settings();
            this.Content = new Frame() { Content = settingsPage };
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RadiosPage radiosPage = new RadiosPage();
            this.Content = new Frame() { Content = radiosPage };
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BooksPage booksPage = new BooksPage();
            this.Content = new Frame() { Content = booksPage };
        }
    }
}
