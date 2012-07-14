using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;

namespace WebApiTimeout.Handlers
{
    public class TimeoutHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

            try
            {
                return await base.SendAsync(request, cts.Token);
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.ServiceUnavailable, ex);
            }
        }
    }
}
