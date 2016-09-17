using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AppDemo.Core.DataTransferObjects;
using AppDemo.Core.Abstract.Services;
using AppDemo.Core.DataTransferObjects.Request;

namespace AppDemo.Api.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("v1/contact")]
    public class ContactRequestController : BaseController
    {
        IContactRequestService _ctcServ;

        public ContactRequestController(IContactRequestService ctcServ)
        {
            _ctcServ = ctcServ;
        }

        [HttpPost]
        [Route("request")]
        public async Task<IHttpActionResult> ContactRequest(ContactRequestData dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok(await _ctcServ.CreateAsync(dto));
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

            return BadRequest(ModelState);
        }
    }
}
