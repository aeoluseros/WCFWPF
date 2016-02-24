using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary;

namespace TransactionHost {
    class Program {
        static void Main(string[] args) {
            Uri tcpBaseAddress = new Uri("net.tcp://localhost:6789/");
            ServiceHost sh = new ServiceHost(typeof(TransactionService), new Uri[] { tcpBaseAddress });

            var netTcpBinding = new NetTcpBinding();
            netTcpBinding.TransactionFlow = true;

            ServiceEndpoint se = sh.AddServiceEndpoint(typeof(ITransactionService), netTcpBinding, tcpBaseAddress);

            ServiceMetadataBehavior smb = sh.Description.Behaviors.Find<ServiceMetadataBehavior>();
            if (smb == null)
                smb = new ServiceMetadataBehavior();
            sh.Description.Behaviors.Add(smb);

            ServiceEndpoint httpSeMex = sh.AddServiceEndpoint(typeof(IMetadataExchange),
                MetadataExchangeBindings.CreateMexTcpBinding(), "net.tcp://localhost:6789/mex");

            sh.Open();

            Console.WriteLine("Started...");
            foreach (var item in sh.Description.Endpoints) {
                Console.WriteLine("Address: " + item.Address.ToString());
                Console.WriteLine("Binding: " + item.Binding.Name.ToString());
                Console.WriteLine("Contract: " + item.Contract.Name.ToString());
                Console.WriteLine("------------------");
            }

            Console.ReadLine();

            sh.Close();
            Console.WriteLine("Closed...");
        }
    }
}
