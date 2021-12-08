using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using log4net;
using RLD.BLL;
using RLD.Presentation.Windows;

namespace RLD.Pages
{
    /// <summary>
    /// Interaction logic for Books.xaml
    /// </summary>
    public partial class BooksPage : Page
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly BitmapImage RLDIcon = new();
        private readonly BitmapImage radiosIcon = new();
        private readonly BitmapImage booksIcon = new();
        private readonly BitmapImage cardsIcon = new();
        private readonly BitmapImage settingsIcon = new();
        private readonly BitmapImage searchIcon = new();
        private readonly BitmapImage defaultBooksIcon = new();

        public List<Book> BooksList { get; set; }
        public WebBrowser Browser { get; set; }

        public BooksPage()
        {
            InitializeComponent();

            log4net.Config.XmlConfigurator.Configure();

            using (var db2 = new ApplicationContext())
            {
                if (db2.Settings.Where(item => item.Name == "Theme").FirstOrDefault().Value == "Dark")
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

                    txtNameToSearch.Background = darkColor;
                    txtNameToSearch.Foreground = lightColor;

                    bookName.Foreground = lightColor;
                    bookGenre.Foreground = lightColor;
                    bookAuthor.Foreground = lightColor;
                    bookYear.Foreground = lightColor;

                    booksDate.Background = darkColor;
                    booksDate.Foreground = lightColor;

                    addButton.Background = darkColor;
                    addButton.Foreground = lightColor;
                    readButton.Background = darkColor;
                    readButton.Foreground = lightColor;
                    editButton.Background = darkColor;
                    editButton.Foreground = lightColor;
                    deleteButton.Background = darkColor;
                    deleteButton.Foreground = lightColor;

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

                    defaultBooksIcon.BeginInit();
                    defaultBooksIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.DefaultBook);
                    defaultBooksIcon.EndInit();
                    bookImage.Source = defaultBooksIcon;

                    searchIcon.BeginInit();
                    searchIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Search);
                    searchIcon.EndInit();
                    searchIconXAML.Source = searchIcon;
                }
                else if (db2.Settings.Where(item => item.Name == "Theme").FirstOrDefault().Value == "Light")
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

                    txtNameToSearch.Background = lightColor;
                    txtNameToSearch.Foreground = darkColor;

                    bookName.Foreground = darkColor;
                    bookGenre.Foreground = darkColor;
                    bookAuthor.Foreground = darkColor;
                    bookYear.Foreground = darkColor;

                    booksDate.Background = lightColor;
                    booksDate.Foreground = darkColor;

                    addButton.Background = lightColor;
                    addButton.Foreground = darkColor;
                    readButton.Background = lightColor;
                    readButton.Foreground = darkColor;
                    editButton.Background = lightColor;
                    editButton.Foreground = darkColor;
                    deleteButton.Background = lightColor;
                    deleteButton.Foreground = darkColor;

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

                    defaultBooksIcon.BeginInit();
                    defaultBooksIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.DefaultBook);
                    defaultBooksIcon.EndInit();
                    bookImage.Source = defaultBooksIcon;

                    searchIcon.BeginInit();
                    searchIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Search);
                    searchIcon.EndInit();
                    searchIconXAML.Source = searchIcon;
                }
            }

            Browser = new WebBrowser();

            BooksList = new List<Book> { };

            var db = new ApplicationContext();
            db.Books.Load();
            BooksList = db.Books.Local.ToList();
            booksDate.ItemsSource = BooksList;

            Log.Info("Opened Books page.");
        }

        private void TxtNameToSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string txtOrig = txtNameToSearch.Text;
            string upper = txtOrig.ToUpper();
            string lower = txtOrig.ToLower();

            var booksFiltered = from book in BooksList
                                let ename = book.Name
                                where ename.StartsWith(lower) || ename.StartsWith(upper) || ename.Contains(txtOrig)
                                select book;

            booksDate.ItemsSource = booksFiltered;

            Log.Info($"Searched books for {txtOrig}");
        }

        private void SettingsMenu(object sender, RoutedEventArgs e)
        {
            Settings settingsPage = new();
            this.Content = new Frame() { Content = settingsPage };
        }

        private void RadiosMenu(object sender, RoutedEventArgs e)
        {
            RadiosPage radiosPage = new();
            this.Content = new Frame() { Content = radiosPage };
        }

        private void CardsMenu(object sender, RoutedEventArgs e)
        {
            Cards cardsPage = new();
            this.Content = new Frame() { Content = cardsPage };
        }

        private void AddBook(object sender, RoutedEventArgs e)
        {
            var window = new BookDialogWindow();
            window.ShowDialog();

            using (var db = new ApplicationContext())
            {
                var query = from b in db.Books
                            select b;

                BooksList = query.ToList();
                booksDate.ItemsSource = query.ToList();
            }
        }

        private void ReadBook(object sender, RoutedEventArgs e)
        {
            var currentBook = (Book)booksDate.SelectedItem;
            try
            {
                browserHost.Navigate(new Uri(string.Format("file:///" + currentBook.BookURL.Replace("\"", string.Empty))));
                Log.Info($"Opened book {currentBook.Name}");
            }
            catch
            {
                MessageBox.Show("Invalid book url");
            }
        }

        private void DeleteBook(object sender, RoutedEventArgs e)
        {
            if (booksDate.SelectedItem != null)
            {
                var window = new BookConfirmDelete();
                window.ShowDialog();

                bool? result = window.DialogResult;

                if (result.HasValue && result == true)
                {
                    using (var db = new ApplicationContext())
                    {
                        var book = (Book)booksDate.SelectedItem;
                        db.Books.Remove(db.Books.FirstOrDefault(item => item.Name == book.Name));
                        db.SaveChanges();

                        Log.Info($"Deleted book {book.Name}");

                        var query = from b in db.Books
                                    select b;

                        BooksList = query.ToList();
                        booksDate.ItemsSource = query.ToList();
                    }
                }
            }
        }

        private void BooksDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (booksDate.SelectedItem != null)
            {
                using (var db = new ApplicationContext())
                {
                    var currentBook = (Book)booksDate.SelectedItem;

                    Log.Info($"Selected book {currentBook.Name}");

                    bookName.Text = currentBook.Name;
                    bookAuthor.Text = currentBook.Author;
                    bookGenre.Text = currentBook.Genre;
                    bookYear.Text = currentBook.YearOfRelease.Year.ToString();

                    if (currentBook.Picture != null)
                    {
                        var currentBookImage = new BitmapImage();
                        currentBookImage.BeginInit();
                        currentBookImage.StreamSource = new MemoryStream(currentBook.Picture);
                        currentBookImage.EndInit();
                        bookImage.Source = currentBookImage;
                    }
                    else
                    {
                        bookImage.Source = defaultBooksIcon;
                    }
                }
            }
            else
            {
                bookImage.Source = defaultBooksIcon;
            }
        }

        private void EditBook(object sender, RoutedEventArgs e)
        {
            if (booksDate.SelectedItem != null)
            {
                var selectedBook = (Book)booksDate.SelectedItem;
                Book book;
                using (var db = new ApplicationContext())
                {
                    book = db.Books.FirstOrDefault(item => item.Name == selectedBook.Name);
                }

                var window = new BookEditDialog(book.Name, book.Author, book.Genre, book.YearOfRelease);
                window.ShowDialog();

                using (var db = new ApplicationContext())
                {
                    var query = from b in db.Books
                                select b;

                    BooksList = query.ToList();
                    booksDate.ItemsSource = query.ToList();
                }
            }
        }
    }
}
