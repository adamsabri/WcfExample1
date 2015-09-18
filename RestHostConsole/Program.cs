using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using WcfService;

namespace RestHostConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServiceHost();

            //ServiceHost();
        }

        private static void ServiceHost()
        {
            //Create two different URIs to serve as the base address
            // One for http requests and another for net.tcp
            var httpUrl = new Uri("http://localhost:8733/WcfService/RestService");
            //var netTcpUrl = new Uri("net.tcp://localhost:8080/RestService");

            //Create ServiceHost to host the service in the console application
            var host = new ServiceHost(typeof(RestService), httpUrl);

            //Enable metadata exchange - you need this so others can create proxies
            //to consume your WCF service
            //var serviceMetaBehavior = new ServiceMetadataBehavior { HttpGetEnabled = true };
            //host.Description.Behaviors.Add(serviceMetaBehavior);

            //Start the Service
            host.Open();

            foreach (ServiceEndpoint se in host.Description.Endpoints)
                Console.WriteLine("Service is host with endpoint " + se.Address);
            Console.WriteLine("Host is running... Press <Enter> key to stop");
            Console.ReadKey();
        }

        private static void WebServiceHost()
        {

            //var httpUrl = new Uri("http://localhost:8090/MyService/EmployeeService");
            var httpUrl = new Uri("http://localhost:8090/RestService");
            var host = new WebServiceHost(typeof(RestService), httpUrl);
            host.Open();

            foreach (ServiceEndpoint se in host.Description.Endpoints)
                Console.WriteLine("Service is host with endpoint " + se.Address);
            //Console.WriteLine("ASP.Net : " + ServiceHostingEnvironment.AspNetCompatibilityEnabled);
            Console.WriteLine("Host is running... Press < Enter > key to stop");
            Console.ReadLine();
        }
    }
}
