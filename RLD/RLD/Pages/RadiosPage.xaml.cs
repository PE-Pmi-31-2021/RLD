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

namespace RLD.Pages
{
    /// <summary>
    /// Interaction logic for RadiosPage.xaml
    /// </summary>
    public partial class RadiosPage : Page
    {
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
            Settings settingsPage = new Settings();
            this.Content = new Frame() { Content = settingsPage };
            //Settings settingsPage = new Settings();
            //this.Content = settingsPage;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Cards cardsPage = new Cards();
            this.Content = new Frame() { Content = cardsPage };
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Books booksPage = new Books();
            this.Content = new Frame() { Content = booksPage };
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
