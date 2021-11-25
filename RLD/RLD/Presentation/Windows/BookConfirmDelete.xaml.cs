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
using System.Windows.Shapes;

namespace RLD.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for BookConfirmDelete.xaml
    /// </summary>
    public partial class BookConfirmDelete : Window
    {
        public BookConfirmDelete()
        {
            InitializeComponent();
        }

        private void Book_Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
