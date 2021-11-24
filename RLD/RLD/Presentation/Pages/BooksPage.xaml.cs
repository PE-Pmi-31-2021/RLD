using RLD.BLL;
using RLD.Presentation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for Books.xaml
    /// </summary>
    public partial class BooksPage : Page
    {
        public List<Book> booksList { get; set; }
        public WebBrowser browser { get; set; }

        public BooksPage()
        {
            InitializeComponent();

            browser = new WebBrowser();

            booksList = new List<Book> { };

            var db = new ApplicationContext(); ;
            db.Books.Load();
            booksList = db.Books.Local.ToList();
            BooksDate.ItemsSource = booksList;

        }

        private void txtNameToSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string txtOrig = txtNameToSearch.Text;
            string upper = txtOrig.ToUpper();
            string lower = txtOrig.ToLower();

            var booksFiltered = from book in booksList
                                let ename = book.Name
                                where ename.StartsWith(lower) || ename.StartsWith(upper) || ename.Contains(txtOrig)
                                select book;

            BooksDate.ItemsSource = booksFiltered;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Setting settingsPage = new Setting();
            this.Content = new Frame() { Content = settingsPage };
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RadiosPage radiosPage = new RadiosPage();
            this.Content = new Frame() { Content = radiosPage };
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Cards cardsPage = new Cards();
            this.Content = new Frame() { Content = cardsPage };
        }
        private void addBook(object sender, RoutedEventArgs e)
        {
            /*RadioDialogWindow window = new RadioDialogWindow();
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
            }*/
        }
        private void readBook(object sender, RoutedEventArgs e)
        {
            string link = "C:/Users/Dmytro/Downloads/WPFTestFile.pdf";
            browserHost.Navigate(new Uri(String.Format("file:///" + link)));


            /*RadioDialogWindow window = new RadioDialogWindow();
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
            }*/
        }
        private void deleteBook(object sender, RoutedEventArgs e)
        {
            //if (BooksDate.SelectedItem != null)
            //{
            //    RadioConfirmDelete window = new RadioConfirmDelete();
            //    window.ShowDialog();

            //    bool? result = window.DialogResult;

            //    if (result.HasValue && result == true)
            //    {
            //        using (var db = new ApplicationContext())
            //        {
            //            db.Books.Remove(db.Books.FirstOrDefault(item => item.Name == BooksDate.SelectedItem.ToString()));
            //            db.SaveChanges();
            //        }
            //        BooksDate.Items.RemoveAt(BooksDate.Items.IndexOf(BooksDate.SelectedItem));
            //    }
            //}
        }
    }
}
