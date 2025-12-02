using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.FluentConfig
{
    public class FluentBookDetailConfig : IEntityTypeConfiguration<Fluent_BookDetail>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookDetail> modelBuilder)
        {
            modelBuilder.ToTable("fluent_BookDetail");

            modelBuilder.Property(u => u.NumberOfChapters).HasColumnName("NoOfChapter");

            //required property using fluent API
            modelBuilder.Property(u => u.NumberOfChapters).IsRequired();
            //set primary key using fluent API
            modelBuilder.HasKey(u => u.BookDetail_Id);
            //one to one mapping using fluent API
            modelBuilder.HasOne(o => o.Book).WithOne(b => b.BookDetail)
                .HasForeignKey<Fluent_BookDetail>(u => u.IDBook);

        }
    }
}
