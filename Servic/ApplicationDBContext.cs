using Servic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Servic.Models.Type;

namespace App
{
    public class ApplicationDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-RRSQIN1\\SQLEXPRESS;Database=DatabaseForExam;Integrated Security=true;TrustServerCertificate=True;");
            
        }

        public DbSet<Comments> Comments { get; set; } = null!;
        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<Type> Type { get; set; } = null!;
        public DbSet<Application> Application { get; set; } = null!;
        

    }
}
