using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        
        protected override void OnConfiguring (DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=ATMECSBLRLT-262\\MSSQLSERVER1;Database=Interview;TrustServerCertificate=True;Trusted_Connection=True");
        }
    }
}
