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
    public class HijosController : ApiController
    {
        // GET api/<controller>
        public List<Hijo> Get()
        {
            return HijosData.SelectAll();
        }

        // GET api/<controller>/5
        public Hijo Get(int id)
        {
            return HijosData.Query(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Hijo hijo)
        {
            return HijosData.Insert(hijo);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Hijo hijo)
        {
            return HijosData.Modify(hijo);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return HijosData.Delete(id);
        }
    }
}