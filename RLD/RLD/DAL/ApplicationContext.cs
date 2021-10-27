using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RLD.BLL;

namespace RLD
{
    class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Radio> Radios { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Links> Links { get; set; }
        public DbSet<Cards> Cards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RLD;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Radio>().HasData(
                new Radio[]
                {
                    new Radio
                    {
                        Id = 1,
                        Name = "Хіт ФМ",
                        SteamURL = "http://www.radiomelodia.com.ua/RadioMelodia.m3u",
                        Genre = RadioGenre.News,
                        IsFavorite = true
                    },
                    new Radio
                    {
                        Id = 2,
                        Name = "Мелодія ФМ",
                        SteamURL = "http://www.radiomelodia.com.ua/RadioMelodia.m3u",
                        Genre = RadioGenre.News,
                        IsFavorite = false
                    }
            });
            modelBuilder.Entity<Books>().HasData(
                new Books[]
                {
                    new Books
                    {
                        Id = 1,
                        Name = "Робінзон Крузо",
                        Author = "Данієль Дефо",
                        Genre = BookGenre.Adventure,
                        YearOfRelease = new DateTime(1719, 4, 25)
                    },
                    new Books
                    {
                        Id = 2,
                        Name = "Том Сойер",
                        Author = "Марк Твен",
                        Genre = BookGenre.Adventure,
                        YearOfRelease = new DateTime(1876, 6, 10)
                    }
            });
            modelBuilder.Entity<Cards>().HasData(
                new Cards[]
                {
                    new Cards
                    {
                        Id = 1,
                        Name = "Card1",
                        Description = "Health card",
                        Category = CardCategory.Health,
                        IsInDraft = true
                    },
                    new Cards
                    {
                        Id = 2,
                        Name = "Card2",
                        Description = "Motivational card",
                        Category = CardCategory.Motivation,
                        IsInDraft = true
                    }
            });
            modelBuilder.Entity<Settings>().HasData(
                new Settings[]
                {
                    new Settings
                    {
                        Id = 1,
                        Name = "Theme",
                        Value = "Dark"
                    },
            });
            modelBuilder.Entity<Links>().HasData(
                new Links[]
                {
                    new Links
                    {
                        Id = 1,
                        Name = "Link",
                        Url = "google.com"
                    },
            });
        }
    }
}
