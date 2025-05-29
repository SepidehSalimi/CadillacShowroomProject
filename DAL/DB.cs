using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DB:DbContext
    {
        public DB() : base() { }
        public DB(DbContextOptions<DB> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=blogging.db");
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-7JHHOIU\\WEB;Initial Catalog=rr;Integrated Security=True;User ID = t1; Password =1");
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CarsShope;Integrated Security=True; Encrypt=False;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Cars> car { get; set; }
        public DbSet<Messages> message { get; set; }
        public DbSet<CarRequest> carReq { get; set; }
        

    }
}
