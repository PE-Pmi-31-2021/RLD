using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLD.BLL
{
    public enum BookGenre
    {

    }

    public class Books
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime YearOfRelease { get; set; }
        public BookGenre Genre { get; set; }
        public byte[] File { get; set; }
        public string Cover { get; set; }
    }
}
