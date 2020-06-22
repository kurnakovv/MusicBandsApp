namespace MusicianBandsApp.Migrations
{
    using MusicianBandsApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MusicianBandsApp.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MusicianBandsApp.Models.AppDbContext context)
        {
            Band b1 = new Band { BandId = 1, BandName = "ABBA", BandDateOfCreation = 1972, BandCountry = "Швеция", BandGenre = "Диско", BandImage = "ABBA_Logo.jpg" };
            Band b2 = new Band { BandId = 2, BandName = "The Beatles", BandDateOfCreation = 1960, BandCountry = "Великобритания", BandGenre = "Рок", BandImage = "beatles.png" };
            Band b3 = new Band { BandId = 3, BandName = "Nirvana", BandDateOfCreation = 1987, BandCountry = "США", BandGenre = "Гранж", BandImage = "nirvana.jpg" };
            Band b4 = new Band { BandId = 4, BandName = "Imagine Dragons", BandDateOfCreation = 2008, BandCountry = "США", BandGenre = "Альтернатива", BandImage = "Imagine_Dragons.jpg" };
            Band b5 = new Band { BandId = 5, BandName = "Green Day", BandDateOfCreation = 1986, BandCountry = "США", BandGenre = "Поп-панк", BandImage = "Green_Day.jpg" };

            context.Bands.Add(b1);
            context.Bands.Add(b2);
            context.Bands.Add(b3);
            context.Bands.Add(b4);
            context.Bands.Add(b5);

            Musician m1 = new Musician { MusicianId = 1, MusicianName = "Агнета Фельтског", MusicianDateOfBirth = 1950, MusicianRole = "Вокалист", BandId = 1, MusicianImage = "Агнета_Фельтског.jpg" };
            Musician m2 = new Musician { MusicianId = 2, MusicianName = "Бьорн Ульвеус", MusicianDateOfBirth = 1945, MusicianRole = "Вокалист", BandId = 1, MusicianImage = "Бьорн_Ульвеус.jpg" };
            Musician m3 = new Musician { MusicianId = 3, MusicianName = "Бенни Андерссон", MusicianDateOfBirth = 1943, MusicianRole = "Вокалист", BandId = 1, MusicianImage = "Бенни_Андерссон.jpg" };
            Musician m4 = new Musician { MusicianId = 4, MusicianName = "Анни-Фрид Лингстад", MusicianDateOfBirth = 1945, MusicianRole = "Вокалист", BandId = 1, MusicianImage = "Анни_Фрид_Лингстад.jpg" };

            Musician m5 = new Musician { MusicianId = 5, MusicianName = "Джон Леннон", MusicianDateOfBirth = 1940, MusicianRole = "Вокалист, гитарист", BandId = 2, MusicianImage = "Джон_Леннон.jpg" };
            Musician m6 = new Musician { MusicianId = 6, MusicianName = "Пол Маккартни", MusicianDateOfBirth = 1942, MusicianRole = "Вокалист, бас-гитарист", BandId = 2, MusicianImage = "Пол_Маккартни.jpg" };
            Musician m7 = new Musician { MusicianId = 7, MusicianName = "Джон Хариссон", MusicianDateOfBirth = 1943, MusicianRole = "Вокалист, гитарист", BandId = 2, MusicianImage = "Джон_Хариссон.jpg" };
            Musician m8 = new Musician { MusicianId = 8, MusicianName = "Ринго Старр", MusicianDateOfBirth = 1940, MusicianRole = "Вокалист, барабанщик", BandId = 2, MusicianImage = "Ринго_Старр.jpg" };

            Musician m9 = new Musician { MusicianId = 9, MusicianName = "Курт Кобейн", MusicianDateOfBirth = 1967, MusicianRole = "Солист, гитарист", BandId = 3, MusicianImage = "Курт_Кобейн.jpg" };
            Musician m10 = new Musician { MusicianId = 10, MusicianName = "Крист Новоселич", MusicianDateOfBirth = 1965, MusicianRole = "Бас-гитарист", BandId = 3, MusicianImage = "Крист_Новоселич.jpg" };
            Musician m11 = new Musician { MusicianId = 11, MusicianName = "Дейв Грол", MusicianDateOfBirth = 1969, MusicianRole = "Барабанщик", BandId = 3, MusicianImage = "Дейв_Грол.jpg" };

            Musician m12 = new Musician { MusicianId = 12, MusicianName = "Дэн Рэйнолдз", MusicianDateOfBirth = 1987, MusicianRole = "Солист", BandId = 4, MusicianImage = "Дэн_Рейнольдс.jpg" };
            Musician m13 = new Musician { MusicianId = 13, MusicianName = "Бен МакКи", MusicianDateOfBirth = 1935, MusicianRole = "Бас-гитарист, бэк-вокалист", BandId = 4, MusicianImage = "Бен_МакКи.jpg" };
            Musician m14 = new Musician { MusicianId = 14, MusicianName = "Уейн Сермон", MusicianDateOfBirth = 1984, MusicianRole = "Гитарист", BandId = 4, MusicianImage = "Уейн_Сермон.jpg" };
            Musician m15 = new Musician { MusicianId = 15, MusicianName = "Дэниел Платцман", MusicianDateOfBirth = 1968, MusicianRole = "Барабанщик", BandId = 4, MusicianImage = "Дэниел_Платцман.jpg" };

            Musician m16 = new Musician { MusicianId = 16, MusicianName = "Билли Джо Армстронг", MusicianDateOfBirth = 1972, MusicianRole = "Вокалист, гитарист", BandId = 5, MusicianImage = "Билли_Джо_Армстронг.jpg" };
            Musician m17 = new Musician { MusicianId = 17, MusicianName = "Майкл Дёрнт", MusicianDateOfBirth = 1972, MusicianRole = "Бас-гитарист, бэк-вокал", BandId = 5, MusicianImage = "Майкл_Дёрнт.jpg" };
            Musician m18 = new Musician { MusicianId = 18, MusicianName = "Тре Кул", MusicianDateOfBirth = 1972, MusicianRole = "Барабанщик", BandId = 5 };


            context.Musicians.Add(m1);
            context.Musicians.Add(m2);
            context.Musicians.Add(m3);
            context.Musicians.Add(m4);
            context.Musicians.Add(m5);
            context.Musicians.Add(m6);
            context.Musicians.Add(m7);
            context.Musicians.Add(m8);
            context.Musicians.Add(m9);
            context.Musicians.Add(m10);
            context.Musicians.Add(m11);
            context.Musicians.Add(m12);
            context.Musicians.Add(m13);
            context.Musicians.Add(m14);
            context.Musicians.Add(m15);
            context.Musicians.Add(m16);
            context.Musicians.Add(m17);
            context.Musicians.Add(m18);


            base.Seed(context);
        }
    }
}
