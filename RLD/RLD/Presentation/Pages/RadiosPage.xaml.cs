using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using log4net;
using RLD.BLL;
using RLD.Presentation;
using RLD.Presentation.Windows;

namespace RLD.Pages
{
    public partial class RadiosPage : Page
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly BitmapImage RLDIcon = new();
        private readonly BitmapImage radiosIcon = new();
        private readonly BitmapImage booksIcon = new();
        private readonly BitmapImage cardsIcon = new();
        private readonly BitmapImage settingsIcon = new();
        private readonly BitmapImage addIcon = new();
        private readonly BitmapImage editIcon = new();
        private readonly BitmapImage removeIcon = new();
        private readonly BitmapImage playIcon = new();
        private readonly BitmapImage pauseIcon = new();
        private readonly BitmapImage volumeMinusIcon = new();
        private readonly BitmapImage volumePlusIcon = new();
        private readonly BitmapImage defaultRadioIcon = new();

        private bool isRadioPlaying;

        public RadiosPage()
        {
            InitializeComponent();

            log4net.Config.XmlConfigurator.Configure();

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

                    Background = darkColor;

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

                    radiosListBox.Background = darkColor;
                    radiosListBox.Foreground = lightColor;

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

                    defaultRadioIcon.BeginInit();
                    defaultRadioIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.DefaultRadio);
                    defaultRadioIcon.EndInit();
                    defaultRadioIconXAML.Source = defaultRadioIcon;
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

                    radiosListBox.Background = lightColor;
                    radiosListBox.Foreground = darkColor;

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

                    defaultRadioIcon.BeginInit();
                    defaultRadioIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.DefaultRadio);
                    defaultRadioIcon.EndInit();
                    defaultRadioIconXAML.Source = defaultRadioIcon;
                }
            }
        }

        private void BooksButton_Click(object sender, RoutedEventArgs e)
        {
            if (isRadioPlaying)
            {
                radioPlayer.Stop();
                isRadioPlaying = false;
                playIconXAML.Source = playIcon;
            }

            BooksPage booksPage = new();
            Content = new Frame() { Content = booksPage };

            log.Info("Opened Books page.");
        }

        private void CardsButton_Click(object sender, RoutedEventArgs e)
        {
            if (isRadioPlaying)
            {
                radioPlayer.Stop();
                isRadioPlaying = false;
                playIconXAML.Source = playIcon;
            }

            Cards cardsPage = new();
            Content = new Frame() { Content = cardsPage };

            log.Info("Opened Cards page.");

        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            if (isRadioPlaying)
            {
                radioPlayer.Stop();
                isRadioPlaying = false;
                playIconXAML.Source = playIcon;
            }

            Settings settingsPage = new();
            Content = new Frame() { Content = settingsPage };

            log.Info("Opened Settings page.");
        }

        private void RadiosListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (radiosListBox.SelectedItem != null)
            {
                using (var db = new ApplicationContext())
                {
                    var currentRadio = db.Radios.FirstOrDefault(radio => radio.Name == radiosListBox.SelectedItem.ToString());

                    if (currentRadio.Logotype != null)
                    {
                        BitmapImage currentRadioIcon = new();
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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            RadioDialogWindow window = new();
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

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (radiosListBox.SelectedItem != null)
            {
                Radio radioForEdit;
                using (var db = new ApplicationContext())
                {
                    radioForEdit = db.Radios.FirstOrDefault(radio => radio.Name == radiosListBox.SelectedItem.ToString());
                }

                RadioEditDialog window = new(radioForEdit.Name, radioForEdit.StreamURL);
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

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (radiosListBox.SelectedItem != null)
            {
                RadioConfirmDelete window = new();
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

        private void PlayButton_Click(object sender, RoutedEventArgs e)
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

        private void VolumeMinusButton_Click(object sender, RoutedEventArgs e)
        {
            radioPlayer.Volume -= 0.05;
        }

        private void VolumePlusButton_Click(object sender, RoutedEventArgs e)
        {
            radioPlayer.Volume += 0.05;
        }
    }
}
