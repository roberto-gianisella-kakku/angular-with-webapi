using AppDemo.Core.Abstract.Repositories;
using AppDemo.Core.Data;
using AppDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Core.Concrete.Repositories
{
    public class ContactRequestRepository : IContactRequestRepository
    {
        private AppDemoDbContext db = null;
        public ContactRequestRepository(AppDemoDbContext db)
        {
            this.db = db;
        }

        public async Task<int> CreateAsync(ContactRequest req)
        {
            db.ContactRequests.Add(req);
            await db.SaveChangesAsync();

            return req.Id;
        }
    }
}
