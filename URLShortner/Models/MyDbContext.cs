using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace URLShortner.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("URLShortnerConnection")
        {

        }

        public DbSet<URLDetails> URLDetails { get; set; }

    }
}