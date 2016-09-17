using AppDemo.Core.DataTransferObjects.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Core.Abstract.Services
{
    public interface IContactRequestService
    {
        Task<int> CreateAsync(ContactRequestData dto);
    }
}
