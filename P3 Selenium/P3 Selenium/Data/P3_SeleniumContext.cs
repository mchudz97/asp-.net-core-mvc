using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P3_Selenium.Models;

namespace P3_Selenium.Data
{
    public class P3_SeleniumContext : DbContext
    {
        public P3_SeleniumContext (DbContextOptions<P3_SeleniumContext> options)
            : base(options)
        {
        }

        public DbSet<P3_Selenium.Models.Announcement> Announcement { get; set; }

        public DbSet<P3_Selenium.Models.Brand> Brand { get; set; }

        public DbSet<P3_Selenium.Models.Car> Car { get; set; }

        public DbSet<P3_Selenium.Models.Owner> Owner { get; set; }
    }
}
