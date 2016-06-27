using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AppDemo.Core.DataTransferObject;
using AppDemo.Core.BusinessLayer;

namespace AppDemo.Api.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("v1/contact")]
    public class ContactRequestController : BaseController
    {
        
        [HttpPost]
        [Route("request")]
        public async Task<IHttpActionResult> ContactRequest(ContactRequestDataTransferObject dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ContactRequestBusinessLogic bl = new ContactRequestBusinessLogic(this.Db);
                    return Ok(await bl.Create(dto));
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
