using RLD.BLL;
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
using System.Windows.Shapes;

namespace RLD.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for BookDialogWindow.xaml
    /// </summary>
    public partial class BookDialogWindow : Window
    {
        byte[] image { get; set; }
        public BookDialogWindow()
        {
            InitializeComponent();
        }

        private void Book_Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationContext())
            {
                var existingBook = db.Books.FirstOrDefault(item => item.Name == bookNameInput.Text);

                if (existingBook == null)
                {
                    if (bookNameInput.Text == "")
                    {
                        MessageBox.Show("Enter book name!");
                    }
                    else if (bookGenreInput.Text == "")
                    {
                        MessageBox.Show("Enter genre of book!");
                    }
                    else if (authorNameInput.Text == "")
                    {
                        MessageBox.Show("Enter author of book!");
                    }
                    else if (bookYearInput.Text == "")
                    {
                        MessageBox.Show("Enter book release date!");
                    }
                    else
                    {
                        Book book = new Book();
                        book.Name = bookNameInput.Text;
                        book.Author = authorNameInput.Text;
                        book.YearOfRelease = new DateTime(1719, 4, 25);
                        book.Genre = bookGenreInput.Text;
                        book.Picture = image;
                        book.bookURL = bookUrlInput.Text;
                        db.Books.Add(book);
                        db.SaveChanges();
                        this.DialogResult = true;
                    }
                }
                else
                {
                    MessageBox.Show("Book with this name already exists");
                }
            }
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Image";
            dialog.DefaultExt = ".png";
            dialog.Filter = "Image (.png)|*.png";

            bool? result = dialog.ShowDialog();
            var file = dialog.OpenFile();

            using (var db = new ApplicationContext())
            {
                byte[] fileData = null;

                using (var binaryReader = new BinaryReader(file))
                {
                    fileData = binaryReader.ReadBytes((int)file.Length);
                }

                if (fileData != null)
                {
                    image = fileData;
                }
            }
        }
    }
}
