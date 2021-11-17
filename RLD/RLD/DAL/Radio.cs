using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RLD.BLL
{
    public enum RadioGenre
    {
        News
    }

    public class Radio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SteamURL { get; set; }
        public RadioGenre Genre { get; set; }
        public byte[] Logotype { get; set; }
        public bool IsFavorite { get; set; }
    }
}
