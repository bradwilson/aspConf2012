using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiTimeout.Handlers
{
    public class LoggingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Req >> [{0}] {1} {2}",
                              DateTime.Now.ToString("HH:mm:ss.fff"),
                              request.Method,
                              request.RequestUri.PathAndQuery);

            var response = await base.SendAsync(request, cancellationToken);

            Console.WriteLine("<< Rsp [{0}] {1} {2} - {3} {4}",
                              DateTime.Now.ToString("HH:mm:ss.fff"),
                              request.Method,
                              request.RequestUri.PathAndQuery,
                              (int)response.StatusCode,
                              response.StatusCode);

            return response;
        }
    }
}
