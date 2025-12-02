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
    public class FluentBookAuthorMapConfig : IEntityTypeConfiguration<Fluent_BookAuthorMap>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookAuthorMap> modelBuilder)
        {
            modelBuilder.HasKey(b => new { b.Author_Id, b.IDBook });

            modelBuilder.HasOne(u => u.Book).WithMany(p => p.BookAuthorMap).HasForeignKey(u => u.IDBook);
            modelBuilder.HasOne(u => u.Author).WithMany(p => p.BookAuthorMap).HasForeignKey(u => u.Author_Id);

        }
    }
}
