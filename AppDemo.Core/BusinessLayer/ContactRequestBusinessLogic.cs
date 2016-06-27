using AppDemo.Core;
using AppDemo.Core.DataAccessLayer;
using AppDemo.Core.DataTransferObject;
using AppDemo.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Core.BusinessLayer
{
    public class ContactRequestBusinessLogic
    {
        private AppDemoDbContext db = null;
        public ContactRequestBusinessLogic(AppDemoDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(ContactRequestDataTransferObject dto)
        {
            ContactRequestRepository rep = new ContactRequestRepository(db);
            var contactReq = Factory.MakeContactRequest(dto);

            return await rep.Create(contactReq);
        }
    }
}
