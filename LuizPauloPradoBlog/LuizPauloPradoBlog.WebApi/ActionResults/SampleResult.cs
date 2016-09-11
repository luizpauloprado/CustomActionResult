using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LuizPauloPradoBlog.WebApi.ActionResults
{
    public class SampleResult : IHttpActionResult
    {
        private string _message;

        public SampleResult()
        {
            _message = "OK " + DateTime.Now.ToShortDateString();
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_message)
            };

            return Task.FromResult(response);
        }
    }
}