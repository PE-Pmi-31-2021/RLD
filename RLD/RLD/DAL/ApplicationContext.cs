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
        public DbSet<Book> Books { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Card> Cards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RLD;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Radio>().HasIndex(r => r.Name).IsUnique();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Radio>().HasData(
                new Radio[]
                {
                    new Radio
                    {
                        Id = 1,
                        Name = "Хіт ФМ",
                        StreamURL = "http://www.radiomelodia.com.ua/RadioMelodia.m3u",
                        Genre = RadioGenre.News,
                        IsFavorite = false
                    },
                    new Radio
                    {
                        Id = 2,
                        Name = "Мелодія ФМ",
                        StreamURL = "http://www.radiomelodia.com.ua/RadioMelodia.m3u",
                        Genre = RadioGenre.News,
                        IsFavorite = false
                    }
            });
            modelBuilder.Entity<Book>().HasData(
                new Book[]
                {
                    new Book
                    {
                        Id = 1,
                        Name = "Робінзон Крузо",
                        Author = "Данієль Дефо",
                        Genre = "Adventure",
                        YearOfRelease = new DateTime(1719, 4, 25)
                    },
                    new Book
                    {
                        Id = 2,
                        Name = "Том Сойер",
                        Author = "Марк Твен",
                        Genre = "Adventure",
                        YearOfRelease = new DateTime(1876, 6, 10)
                    }
            });
            modelBuilder.Entity<Card>().HasData(
                new Card[]
                {
                    new Card
                    {
                        Id = 1,
                        Name = "Card1",
                        Description = "Health card",
                        Category = CardCategory.Health,
                        IsInDraft = true
                    },
                    new Card
                    {
                        Id = 2,
                        Name = "Card2",
                        Description = "Motivational card",
                        Category = CardCategory.Motivation,
                        IsInDraft = true
                    }
            });
            modelBuilder.Entity<Setting>().HasData(
                new Setting[]
                {
                    new Setting
                    {
                        Id = 1,
                        Name = "Theme",
                        Value = "Dark"
                    },
                    new Setting
                    {
                        Id = 2,
                        Name = "StartPage",
                        Value = "Radios"
                    },
            });
            modelBuilder.Entity<Link>().HasData(
                new Link[]
                {
                    new Link
                    {
                        Id = 1,
                        Name = "Link",
                        Url = "google.com"
                    },
            });
        }
    }
}
