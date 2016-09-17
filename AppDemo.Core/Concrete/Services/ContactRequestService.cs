using AppDemo.Core;
using AppDemo.Core.Abstract.Repositories;
using AppDemo.Core.Abstract.Services;
using AppDemo.Core.DataTransferObjects.Request;
using AppDemo.Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Core.Concrete.Services
{
    public class ContactRequestService : IContactRequestService
    {
        IContactRequestRepository _ctcrepo;
        ModelFactory _modelFactory = new ModelFactory();

        public ContactRequestService(IContactRequestRepository ctcrepo)
        {
            this._ctcrepo = ctcrepo;
        }

        public async Task<int> CreateAsync(ContactRequestData dto)
        {
            var contactReq = _modelFactory.Create(dto);

            return await _ctcrepo.CreateAsync(contactReq);
        }
    }
}
