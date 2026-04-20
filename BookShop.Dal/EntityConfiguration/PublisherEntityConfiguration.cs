using BookShop.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Dal.EntityConfiguration;

internal class PublisherEntityConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).HasMaxLength(200);

        builder.HasMany(e => e.Books)
               .WithOne(e => e.Publisher)
               .HasForeignKey(e => e.PublisherId)
               .OnDelete(DeleteBehavior.NoAction);
    }

    public static void SeedData(EntityTypeBuilder<Publisher> builder)
    {
        builder.HasData(
            new Publisher { Id = 1, Name = "Bioenergetic Kiadó" },
            new Publisher { Id = 2, Name = "Terc Kiadó" },
            new Publisher { Id = 3, Name = "Csengőkert Könyvkiadó" },
            new Publisher { Id = 4, Name = "Hajja és Fiai Könyvkiadó" },
            new Publisher { Id = 5, Name = "Sziget Könyvkiadó" },
            new Publisher { Id = 6, Name = "Első Magyar Feng Shui Centrum" },
            new Publisher { Id = 7, Name = "Lunarimpex Kiadó" },
            new Publisher { Id = 8, Name = "Műszaki Könyvkiadó" },
            new Publisher { Id = 9, Name = "Kossuth Kiadó" },
            new Publisher { Id = 10, Name = "Animus Kiadó" },
            new Publisher { Id = 11, Name = "Partvonal Könyvkiadó" },
            new Publisher { Id = 12, Name = "Alexandra Kiadó" },
            new Publisher { Id = 13, Name = "Szaktudás Kiadó Ház" },
            new Publisher { Id = 14, Name = "Typotex Kiadó" },
            new Publisher { Id = 15, Name = "STB Könyvek Könyvkiadó" },
            new Publisher { Id = 16, Name = "Regulus Art Kft." },
            new Publisher { Id = 17, Name = "Officina '96 Kiadó" },
            new Publisher { Id = 18, Name = "Danvantara Kiadó" },
            new Publisher { Id = 19, Name = "Gabo Könyvkiadó, Gulliver Könyvkiadó" },
            new Publisher { Id = 20, Name = "Kairosz Kiadó" },
            new Publisher { Id = 21, Name = "Ankh Kiadó" },
            new Publisher { Id = 22, Name = "L'Harmattan Kiadó" },
            new Publisher { Id = 23, Name = "Akadémiai Kiadó" },
            new Publisher { Id = 24, Name = "Scolar Kiadó" },
            new Publisher { Id = 25, Name = "K.u.K.Kiadó" },
            new Publisher { Id = 26, Name = "Édesvíz Kiadó" },
            new Publisher { Id = 27, Name = "Cartaphilus Könyvkiadó" },
            new Publisher { Id = 28, Name = "Villon Books Kiadó" },
            new Publisher { Id = 29, Name = "Tarandus Kiadó" },
            new Publisher { Id = 30, Name = "Gabo Könyvkiadó" },
            new Publisher { Id = 31, Name = "HVG Kiadó" },
            new Publisher { Id = 32, Name = "Ursus Libris Kiadó" },
            new Publisher { Id = 33, Name = "Európa Könyvkiadó" },
            new Publisher { Id = 34, Name = "Kalligram Könyv - és Lapkiadó" },
            new Publisher { Id = 35, Name = "Szukits Könyvkiadó" },
            new Publisher { Id = 36, Name = "Osiris Kiadó" },
            new Publisher { Id = 37, Name = "Park Könyvkiadó" },
            new Publisher { Id = 38, Name = "Napkút Kiadó" },
            new Publisher { Id = 39, Name = "QLT Műfordító Bt." },
            new Publisher { Id = 40, Name = "Saxum Kiadó" },
            new Publisher { Id = 41, Name = "Magyar Napló Kiadó" },
            new Publisher { Id = 42, Name = "Helikon Kiadó" },
            new Publisher { Id = 43, Name = "Múlt és Jövő Kiadó" },
            new Publisher { Id = 44, Name = "Nemzeti Tankönyvkiadó" },
            new Publisher { Id = 45, Name = "Geographia Kiadó" },
            new Publisher { Id = 46, Name = "Littera Nova Kiadó" },
            new Publisher { Id = 47, Name = "Napvilág Kiadó" },
            new Publisher { Id = 48, Name = "Képzőművészeti Kiadó" },
            new Publisher { Id = 49, Name = "Gondolat Kiadó" },
            new Publisher { Id = 50, Name = "Gazdasági Versenyhivatal Versenykultúra Központ" },
            new Publisher { Id = 51, Name = "Mezőgazda Kiadó" },
            new Publisher { Id = 52, Name = "Pilis - Vet Kiadó" },
            new Publisher { Id = 53, Name = "Noran Kiadó" },
            new Publisher { Id = 54, Name = "Delta Vision Kiadó" },
            new Publisher { Id = 55, Name = "BBS - INFO Kft." },
            new Publisher { Id = 56, Name = "Dialóg Campus Kiadó" },
            new Publisher { Id = 57, Name = "Slovart Kiadó" },
            new Publisher { Id = 58, Name = "Magvető Könyvkiadó" },
            new Publisher { Id = 59, Name = "Ulpius - ház Könyvkiadó" },
            new Publisher { Id = 60, Name = "I.A.T.Kiadó" },
            new Publisher { Id = 61, Name = "Beholder Kiadó" },
            new Publisher { Id = 62, Name = "Art Nouveau Kiadó" },
            new Publisher { Id = 63, Name = "JLX Kiadó" },
            new Publisher { Id = 64, Name = "Illia & Co.Kiadó" },
            new Publisher { Id = 65, Name = "Kalandor Könyvkiadó" },
            new Publisher { Id = 66, Name = "Agave Könyvek" },
            new Publisher { Id = 67, Name = "Metropolis Media" },
            new Publisher { Id = 68, Name = "Kelly Kiadó" },
            new Publisher { Id = 69, Name = "Athenaeum 2000 Kiadó" },
            new Publisher { Id = 70, Name = "I.P.C.Könyvek" },
            new Publisher { Id = 71, Name = "PolgART Lap - és Könyvkiadó" },
            new Publisher { Id = 72, Name = "Geopen Könyvkiadó" },
            new Publisher { Id = 73, Name = "Tericum Kiadó" },
            new Publisher { Id = 74, Name = "Fumax" },
            new Publisher { Id = 75, Name = "Goodinvest Kft." },
            new Publisher { Id = 76, Name = "General Press Kiadó" }
        );
    }
}
