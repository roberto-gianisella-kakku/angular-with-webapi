using AppDemo.Core.DataTransferObject;
using AppDemo.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Core.Utils
{
    internal static class Factory
    {
        public static ContactRequest MakeContactRequest(ContactRequestDataTransferObject dto)
        {
            return new ContactRequest {
                 Comment = dto.Comment,
                  Email = dto.Email,
                   Name = dto.Name
            };
        }
    }
}
