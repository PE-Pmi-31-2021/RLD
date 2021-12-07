using System;

namespace RLD.BLL
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime YearOfRelease { get; set; }
        public string Genre { get; set; }
        public byte[] Picture { get; set; }
        public string BookURL { get; set; }
    }
}
