using AppDemo.Core.DataTransferObjects.Request;
using AppDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Core.Factories
{
    public class ModelFactory
    {
        public ContactRequest Create(ContactRequestData dto)
        {
            return new ContactRequest
            {
                Comment = dto.Comment,
                Email = dto.Email,
                Name = dto.Name
            };
        }
    }
}
