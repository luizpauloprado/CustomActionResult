using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LuizPauloPradoBlog.WebApi.ActionResults;

namespace LuizPauloPradoBlog.WebApi.Controllers
{
    public class SampleController : ApiController
    {
        List<string> _sampleData;

        public SampleController()
        {
            _sampleData = new List<string>() { "a", "b", "c" };
        }

        [HttpPost]
        public IHttpActionResult Post()
        {
            if (_sampleData == null)
                return NotFound();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return new SampleResult();
        }

        [HttpGet]
        public IHttpActionResult Get(string name)
        {
            try
            {
                var item = _sampleData.Single(x => x == name);

                return Ok(item);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Request, ex);
            }
        }
    }
}
