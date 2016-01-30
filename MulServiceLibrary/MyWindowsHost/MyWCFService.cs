using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using MulServiceLibrary;
using System.ServiceModel;

namespace MyWindowsHost {
    public partial class MyWCFService : ServiceBase {
        public MyWCFService() {
            InitializeComponent();
        }

        ServiceHost sh = null;

        protected override void OnStart(string[] args)
        {
            sh = new ServiceHost(typeof (MultiService), new Uri("net.tcp://localhost:9001/MyWindowsService"));
            sh.Open();
        }

        protected override void OnStop() {
            if (sh != null)
            {
                sh.Close();
            }
            sh = null;
        }
    }
}
