using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AIBStore.Domain.Abstract;
using AIBStore.Domain.Entities;
using AIBStore.WebAPI.Helpers;

namespace AIBStore.WebAPI.Controllers
{
    public class EmailController : ApiController
    {
        private IEmailProcessor emailProcessor;

        public EmailController(IEmailProcessor emailProcessor)
        {
            this.emailProcessor = emailProcessor;
        }

        [ResponseType(typeof(Email))]
        public IEnumerable<Email> Get()
        {
            Email e = new Email();

            e.To = "to@customer.ie";
            e.From = "from@aib.ie";
            e.Subject = "subject";
            e.Body = "body";
            yield return (e);
        }

        [ResponseType(typeof(Email))]
        public IHttpActionResult Get(string name)
        {
            if (name.ToUpper() == "ERROR") CustomError.RaiseError(ErrorLevel.Error, "This is an error message");

            Email e = new Email();
            e.To = string.Concat (name, "@customer.ie");
            e.From = "from@aib.ie";
            e.Subject = "subject";
            e.Body = "body";
            return Ok(e);
        }

        [ResponseType(typeof(Email))]
        public IHttpActionResult Post(Email email)
        {
            emailProcessor.Send(email);
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
