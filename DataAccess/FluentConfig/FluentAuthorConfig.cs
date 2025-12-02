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
    public class FluentAuthorConfig : IEntityTypeConfiguration<Fluent_Author>
    {
        public void Configure(EntityTypeBuilder<Fluent_Author> modelBuilder)
        {
            //primary key
            modelBuilder.HasKey(o => o.Author_Id);
            // required and maxleght
            modelBuilder.Property(o => o.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Property(o => o.LastName).IsRequired();
            //not mapped 
            modelBuilder.Ignore(o => o.FullName);

        }
    }
}
