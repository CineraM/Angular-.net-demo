using MCAPI.Data;
using MCAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MCAPI.Controllers
{
    public class PersonalController : ApiController
    {
        // GET api/<controller>
        public List<Personal> Get()
        {
            return PersonalData.SelectAll();
        }

        // GET api/<controller>/5
        public Personal Get(int id)
        {
            return PersonalData.Query(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Personal personal)
        {
            return PersonalData.Insert(personal);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Personal personal)
        {
            return PersonalData.Modify(personal);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return PersonalData.Delete(id);
        }
    }
}