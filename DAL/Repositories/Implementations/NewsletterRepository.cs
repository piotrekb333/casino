using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementations
{
    public class NewsletterRepository : Repository<Newsletter>,INewsletterRepository
    {
        private readonly CasinoDbContext _context;
        public NewsletterRepository()
        {
            this._context = new CasinoDbContext();
            this._context.Configuration.AutoDetectChangesEnabled = false;
            this._context.Configuration.LazyLoadingEnabled = false;
        }
        public bool EmailExistsInNewsletter(string email)
        {
            return _context.Newsletters.Any(m => m.Email.ToLower() == email.ToLower());
        }
    }
}
