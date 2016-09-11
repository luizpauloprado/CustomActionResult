using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LuizPauloPradoBlog.WebApi.ActionResults
{
    public class ErrorResult : IHttpActionResult
    {
        private HttpRequestMessage _request;
        private Dictionary<string, string> _customizedException;

        public ErrorResult(HttpRequestMessage request, Exception ex)
        {
            _request = request;
            _customizedException = CreateCustomizedException(ex);
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(_customizedException)),
                StatusCode = HttpStatusCode.InternalServerError
            };

            return Task.FromResult(response);
        }

        private Dictionary<string, string> CreateCustomizedException(Exception ex)
        {
            var message = ex.Message;
            var innerMessage = ex.InnerException == null ? "" : ex.InnerException.Message;

            var customizedException = new Dictionary<string, string>();
            customizedException.Add("Message", message);
            customizedException.Add("InnerMessage", innerMessage);

            return customizedException;
        }
    }
}