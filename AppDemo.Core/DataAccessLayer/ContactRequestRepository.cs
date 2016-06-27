using AppDemo.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Core.DataAccessLayer
{
    internal class ContactRequestRepository
    {
        private AppDemoDbContext db = null;
        internal ContactRequestRepository(AppDemoDbContext db)
        {
            this.db = db;
        }

        internal async Task<int> Create(ContactRequest req)
        {
            db.ContactRequests.Add(req);
            await db.SaveChangesAsync();

            return req.Id;
        }
    }
}
