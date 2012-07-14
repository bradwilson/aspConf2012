using System;
using System.Web.Http;
using System.Web.Http.SelfHost;
using WebApiTimeout.Handlers;

namespace WebApiTimeout
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8181");

            config.MessageHandlers.Add(new LoggingHandler());

            config.Routes.MapHttpRoute(
                "default",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
            );

            var server = new HttpSelfHostServer(config);
            server.OpenAsync().Wait();

            Console.WriteLine("Listening at {0}", config.BaseAddress);
            Console.WriteLine();
            Console.ReadKey(true);

            server.CloseAsync().Wait();
        }
    }
}
