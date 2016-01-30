using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MulServiceLibrary;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ConsoleApplication {
    class Program {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:6789/MyHttpEndpoint");  //I will use this in ServiceHost object.
            Uri tcpAddress = new Uri("net.tcp://localhost:6790");  //One more advantage for hosting service on Console App is that we can host tcp endpoint.

            //create service host object
            ServiceHost sh = new ServiceHost(typeof (MultiService), new Uri[] {baseAddress,tcpAddress});

            //adding an endpoint
            var se = sh.AddServiceEndpoint(typeof(IMultiService), new WSHttpBinding(), baseAddress);
            var setcp = sh.AddServiceEndpoint(typeof(IMultiService), new NetTcpBinding(), tcpAddress);
            
            //Enable Service MetaData Behavior for HTTP endpoint. (TCP doesn't need this)
            //var smb = new ServiceMetadataBehavior {HttpGetEnabled = true};
            //var smb = new ServiceMetadataBehavior {HttpGetEnabled = false};  //comment out and create in declarative way
            //sh.Description.Behaviors.Add(smb);


            //add a mex endpoint if the HttpGetEnabled = false.
            //use typeof(IMetadataExchange) is a fixed rule.
            ServiceEndpoint httpSeMex = sh.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "http://localhost:6789/MyHttpEndpoint/mex");

            //we can also add a mex endpoint for net.tcp
            ServiceEndpoint tcpSeMex = sh.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "net.tcp://localhost:6790/mex");
            
            //for above two endpoints, we have both service endpoints and mex endpoints.
            //once we have mex endpoint, we can use the mex endpoint to add service reference even we do not have
            //service endpoint


            //open service
            sh.Open();

            Console.WriteLine("Service Started...");

            foreach (var item in sh.Description.Endpoints)
            {
                Console.WriteLine("Address: " + item.Address.ToString());
                Console.WriteLine("Binding: " + item.Binding.Name.ToString());
                Console.WriteLine("Contract: " + item.Contract.Name.ToString());
                Console.WriteLine("-------------------------");
            }

            Console.ReadLine();

            //close Service
            sh.Close();
            Console.WriteLine("Service Closed...");
        }
    }
}
