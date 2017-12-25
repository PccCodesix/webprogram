using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model.Model;

namespace Model
{
   
   public class DbcontextUser: DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;database=TestDb;userid='root';pwd='p123456';SslMode=none");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //设置accout 唯一
           modelBuilder.Entity<User>().HasIndex(u => u.Aaccount).IsUnique();
        }
    }
}
