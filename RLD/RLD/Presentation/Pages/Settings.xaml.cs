using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RLD.Pages
{
    public partial class Settings : Page
    {
        private readonly BitmapImage booksIcon = new BitmapImage();
        private readonly BitmapImage cardsIcon = new BitmapImage();
        private readonly BitmapImage radiosIcon = new BitmapImage();
        private readonly BitmapImage RLDIcon = new BitmapImage();
        private readonly BitmapImage settingsIcon = new BitmapImage();

        public Settings()
        {
            InitializeComponent();

            using (var db2 = new ApplicationContext())
            {
                if (db2.Settings.Where(item => item.Name == "Theme").FirstOrDefault().Value == "Dark")
                {
                    var darkColor = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    var lightColor = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                    Background = darkColor;
                    Foreground = lightColor;

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

                    themeLabel.Foreground = lightColor;
                    startupPageLabel.Foreground = lightColor;
                    linksLabel.Foreground = lightColor;

                    radioButtonDark.Foreground = lightColor;
                    radioButtonLight.Foreground = lightColor;
                    radioButtonBooks.Foreground = lightColor;
                    radioButtonRadios.Foreground = lightColor;
                    radioButtonCards.Foreground = lightColor;

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
                else if (db2.Settings.Where(item => item.Name == "Theme").FirstOrDefault().Value == "Light")
                {
                    var lightColor = new SolidColorBrush(Color.FromRgb(235, 235, 235));
                    var darkColor = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                    Background = lightColor;
                    Foreground = darkColor;

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

                    themeLabel.Foreground = darkColor;
                    startupPageLabel.Foreground = darkColor;
                    linksLabel.Foreground = darkColor;

                    radioButtonDark.Foreground = darkColor;
                    radioButtonLight.Foreground = darkColor;
                    radioButtonBooks.Foreground = darkColor;
                    radioButtonRadios.Foreground = darkColor;
                    radioButtonCards.Foreground = darkColor;

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

                var theme = db.Settings.FirstOrDefault(item => item.Name == "Theme");
                if (theme != null)
                {
                    if (theme.Value == "Dark")
                    {
                        radioButtonDark.IsChecked = true;
                    }
                    else if (theme.Value == "Light")
                    {
                        radioButtonLight.IsChecked = true;
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

        private void RadioButtonBooks_Checked(object sender, RoutedEventArgs e)
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

        private void RadioButtonRadios_Checked(object sender, RoutedEventArgs e)
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

        private void RadioButtonCards_Checked(object sender, RoutedEventArgs e)
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

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var theme = db.Settings.FirstOrDefault(item => item.Name == "Theme");
                if (theme != null)
                {
                    theme.Value = "Dark";
                    db.SaveChanges();
                }
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var theme = db.Settings.FirstOrDefault(item => item.Name == "Theme");
                if (theme != null)
                {
                    theme.Value = "Light";
                    db.SaveChanges();
                }
            }
        }
    }
}
