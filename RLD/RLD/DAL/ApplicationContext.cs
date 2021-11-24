﻿using System;
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
                        Name = "Країна ФМ",
                        StreamURL = "http://185.65.246.132:8000/kiev320s.mp3",
                        Genre = RadioGenre.News,
                        IsFavorite = false
                    },
                    new Radio
                    {
                        Id = 2,
                        Name = "Радіо Хіт FM",
                        StreamURL = "https://online.hitfm.ua/HitFM_HD",
                        Genre = RadioGenre.News,
                        IsFavorite = false
                    },
                    new Radio
                    {
                        Id = 3,
                        Name = "Радіо Хіт FM Сучасні хіти",
                        StreamURL = "https://online.hitfm.ua/HitFM_Top_HD",
                        Genre = RadioGenre.News,
                        IsFavorite = false
                    },
                    new Radio
                    {
                        Id = 4,
                        Name = "Радіо Хіт FM Українські хіти",
                        StreamURL = "https://online.hitfm.ua/HitFM_Ukr_HD",
                        Genre = RadioGenre.News,
                        IsFavorite = false
                    },
                    new Radio
                    {
                        Id = 5,
                        Name = "Радіо Хіт FM Найбільші хіти",
                        StreamURL = "https://online.hitfm.ua/HitFM_Top_HD",
                        Genre = RadioGenre.News,
                        IsFavorite = false
                    },
                    new Radio
                    {
                        Id = 6,
                        Name = "Радіо Максимум",
                        StreamURL = "https://streamvideo.luxnet.ua/maximum/smil:maximum.stream.smil/playlist.m3u8",
                        Genre = RadioGenre.News,
                        IsFavorite = false
                    },
                    new Radio
                    {
                        Id = 7,
                        Name = "UA:Радіо Промінь",
                        StreamURL = "http://radio.ukr.radio:8000/ur2-mp3",
                        Genre = RadioGenre.News,
                        IsFavorite = false
                    },
                    new Radio
                    {
                        Id = 8,
                        Name = "UA:Українське радіо Львів ",
                        StreamURL = "http://radio.ukr.radio:8000/ur1-lv-mp3",
                        Genre = RadioGenre.News,
                        IsFavorite = false
                    },
                    new Radio
                    {
                        Id = 9,
                        Name = "UA:Радіо Культура",
                        StreamURL = "http://radio.ukr.radio:8000/ur3-mp3",
                        Genre = RadioGenre.News,
                        IsFavorite = false
                    },
                    new Radio
                    {
                        Id = 10,
                        Name = "Дуже радіо",
                        StreamURL = "http://178.136.125.252:8000/duzhefm",
                        Genre = RadioGenre.News,
                        IsFavorite = false
                    },
                    new Radio
                    {
                        Id = 11,
                        Name = "Радіо Люкс FM",
                        StreamURL = "https://streamvideo.luxnet.ua/lux/smil:lux.stream.smil/playlist.m3u8",
                        Genre = RadioGenre.News,
                        IsFavorite = false
                    },

            });
            modelBuilder.Entity<Book>().HasData(
                new Book[]
                {
                    new Book
                    {
                        Id = 1,
                        Name = "Робінзон Крузо",
                        Author = "Данієль Дефо",
                        Genre = BookGenre.Adventure,
                        YearOfRelease = new DateTime(1719, 4, 25)
                    },
                    new Book
                    {
                        Id = 2,
                        Name = "Том Сойер",
                        Author = "Марк Твен",
                        Genre = BookGenre.Adventure,
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
