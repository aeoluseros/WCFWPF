using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using MEPLibrary;         //namespace

namespace MEPHost {
    class Program {
        static void Main(string[] args)
        {
            Uri httpBaseAddress = new Uri("http://localhost:6789/");
            ServiceHost sh = new ServiceHost(typeof (MEP), new Uri[] {httpBaseAddress});
            
            //ServiceEndpoint se = sh.AddServiceEndpoint(typeof (IMEP), new BasicHttpBinding(), httpBaseAddress);
            ServiceEndpoint se = sh.AddServiceEndpoint(typeof(IMEP), new WSDualHttpBinding(), httpBaseAddress);

            ServiceMetadataBehavior smb = sh.Description.Behaviors.Find<ServiceMetadataBehavior>();
            if(smb == null)
                smb = new ServiceMetadataBehavior();
            sh.Description.Behaviors.Add(smb);

            ServiceEndpoint httpSeMex = sh.AddServiceEndpoint(typeof (IMetadataExchange),
                MetadataExchangeBindings.CreateMexHttpBinding(), "http://localhost:6789/mex");

            sh.Open();

            Console.WriteLine("Started...");
            foreach (var item in sh.Description.Endpoints)
            {
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
