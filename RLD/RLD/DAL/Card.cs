using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLD.BLL
{
    public enum CardCategory
    {
        Sport,
        Motivation,
        Health,
        Studying
    }

    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CardCategory Category { get; set; }
        public byte[] BackgroundImage { get; set; }
        public bool IsInDraft { get; set; }
    }
}
