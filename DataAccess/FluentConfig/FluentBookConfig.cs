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
    public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
        {
            //one to many mapping using fluent API
            modelBuilder.HasOne(o => o.Publisher).WithMany(b => b.Books).HasForeignKey(u => u.Publisher_Id);

            //max length using fluent API
            modelBuilder.Property(o => o.ISBN).HasMaxLength(50).IsRequired();
            //set primary key using fluent API
            modelBuilder.HasKey(o => o.IDBook);

            modelBuilder.Ignore(o => o.PriceRange);

        }
    }
}
