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

namespace RLD.Pages
{
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();

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
