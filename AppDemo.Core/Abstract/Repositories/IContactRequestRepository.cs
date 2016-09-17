using AppDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Core.Abstract.Repositories
{
    public interface IContactRequestRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns>returns ContactRequest id</returns>
        Task<int> CreateAsync(ContactRequest req);
    }
}
