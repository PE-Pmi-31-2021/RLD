using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RLD.Pages
{
    /// <summary>
    /// Interaction logic for Cards.xaml.
    /// </summary>
    public partial class Cards : Page
    {
        private readonly BitmapImage booksIcon = new BitmapImage();
        private readonly BitmapImage cardsIcon = new BitmapImage();
        private readonly BitmapImage radiosIcon = new BitmapImage();
        private readonly BitmapImage RLDIcon = new BitmapImage();
        private readonly BitmapImage settingsIcon = new BitmapImage();

        public Cards()
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

                    creationPanel.Background = darkColor;

                    categoryTextBlock.Background = darkColor;
                    categoryTextBlock.Foreground = lightColor;
                    titleTextBlock.Background = darkColor;
                    titleTextBlock.Foreground = lightColor;
                    descriptionTextBlock.Background = darkColor;
                    descriptionTextBlock.Foreground = lightColor;

                    textTextBox.Background = darkColor;
                    textTextBox.Foreground = lightColor;

                    addBackgroundButton.Background = darkColor;
                    addBackgroundButton.Foreground = lightColor;
                    resetButton.Background = darkColor;
                    resetButton.Foreground = lightColor;
                    saveButton.Background = darkColor;
                    saveButton.Foreground = lightColor;
                    addButton.Background = darkColor;
                    addButton.Foreground = lightColor;

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
                    var lightColor = new SolidColorBrush(Color.FromRgb(235, 235, 235));
                    var darkColor = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                    Background = lightColor;

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

                    creationPanel.Background = lightColor;

                    categoryTextBlock.Background = lightColor;
                    categoryTextBlock.Foreground = darkColor;
                    titleTextBlock.Background = lightColor;
                    titleTextBlock.Foreground = darkColor;
                    descriptionTextBlock.Background = lightColor;
                    descriptionTextBlock.Foreground = darkColor;

                    textTextBox.Background = lightColor;
                    textTextBox.Foreground = darkColor;

                    addBackgroundButton.Background = lightColor;
                    addBackgroundButton.Foreground = darkColor;
                    resetButton.Background = lightColor;
                    resetButton.Foreground = darkColor;
                    saveButton.Background = lightColor;
                    saveButton.Foreground = darkColor;
                    addButton.Background = lightColor;
                    addButton.Foreground = darkColor;

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
