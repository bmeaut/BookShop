using BookShop.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Dal.EntityConfiguration;

internal class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).HasMaxLength(50);
        builder.Property(e => e.Order).HasMaxLength(50);

        builder.HasOne(e => e.ParentCategory)
               .WithMany(e => e.ChildCategories)
               .HasForeignKey(e => e.ParentCategoryId)
               .OnDelete(DeleteBehavior.NoAction);
    }

    public static void SeedData(EntityTypeBuilder<Category> builder)
    { 
        builder.HasData( 
            new Category { Id =  1, Name = "Ezoterika",              ParentCategoryId = null,    Order = "00"    },
            new Category { Id =  2, Name = "Feng shui",              ParentCategoryId = 1,       Order = "00.01" },
            new Category { Id =  3, Name = "Horoszkóp, asztrológia", ParentCategoryId = 1,       Order = "00.02" },
            new Category { Id =  4, Name = "Parapszichológia",       ParentCategoryId = 1,       Order = "00.03" },
            new Category { Id =  5, Name = "Irodalom",               ParentCategoryId = null,    Order = "01"    },
            new Category { Id =  6, Name = "Életrajz",               ParentCategoryId = 5,       Order = "01.01" },
            new Category { Id =  7, Name = "Dráma, színmű",          ParentCategoryId = 5,       Order = "01.02" },
            new Category { Id =  8, Name = "Vers, eposz",            ParentCategoryId = 5,       Order = "01.03" },
            new Category { Id =  9, Name = "Tankönyvek",             ParentCategoryId = null,    Order = "02"    },
            new Category { Id = 10, Name = "Matematika",             ParentCategoryId = 9,       Order = "02.01" },
            new Category { Id = 11, Name = "Kémia",                  ParentCategoryId = 9,       Order = "02.02" },
            new Category { Id = 12, Name = "Közgazdaságtudomány",    ParentCategoryId = 9,       Order = "02.03" },
            new Category { Id = 13, Name = "Biológia",               ParentCategoryId = 9,       Order = "02.04" },
            new Category { Id = 14, Name = "Regény",                 ParentCategoryId = null,    Order = "03"    },
            new Category { Id = 15, Name = "Családregény",           ParentCategoryId = 14,      Order = "03.01" },
            new Category { Id = 16, Name = "Fantasy",                ParentCategoryId = 14,      Order = "03.02" },
            new Category { Id = 17, Name = "Erotikus",               ParentCategoryId = 14,      Order = "03.03" },
            new Category { Id = 18, Name = "Krimi",                  ParentCategoryId = 14,      Order = "03.04" },
            new Category { Id = 19, Name = "Sci-fi",                 ParentCategoryId = 14,      Order = "03.05" },
            new Category { Id = 20, Name = "Thriller",               ParentCategoryId = 14,      Order = "03.06" },
            new Category { Id = 21, Name = "Történelmi",             ParentCategoryId = 14,      Order = "03.07" }
        );
    }
}