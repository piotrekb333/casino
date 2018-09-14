using DAL.Entities;
using DAL.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class CasinoDbContext : DbContext, ICasinoDbContext
    {
        public CasinoDbContext() : base(Const.CONNECTION_STRING)
        {
        }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
