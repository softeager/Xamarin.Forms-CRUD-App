using CRUDApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CRUDApp
{
   
        public class DatabaseContext : DbContext
        {
            public DbSet<StudentModel> Students { get; set; }
            public DatabaseContext()
            {
                this.Database.EnsureCreated();
            }
            // overrides the OnConfigure Method 
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student.db");
                optionsBuilder.UseSqlite($"Filename={dbPath}");
            }
        }
}
