using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AIBStore.Domain.Abstract;
using AIBStore.Domain.Entities;

namespace WebApplication2.Controllers
{
    public class EmailController : ApiController
    {
        private IEmail oEmail;

        public EmailController(IEmail emailProcessor)
        {
            oEmail = emailProcessor;
        }

        [ResponseType(typeof(int))]
        public IEnumerable<int> Get()
        {
            int e = 8;
            //            Email e = new Email("to", "from", "subject", "body");

            yield return (e);

        }

        [ResponseType(typeof(int))]
        public IHttpActionResult Get(int id)
        {

            //            Email e = new Email("to", "from", "subject", "body");

            return Ok(id);
            //return Ok(new Email("to", "from", "subject", "body"));
        }

        [ResponseType(typeof(Email))]
        public IHttpActionResult Post(Email email)
        {
            oEmail.Send(email);
            return Ok(email);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, int email)
        {
            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
