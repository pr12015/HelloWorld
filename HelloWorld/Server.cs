﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Contracts;

namespace HelloWorld
{
    public class Server
    {
        private ServiceHost serviceHost;
        private int port;

        public Server(int portNumber)
        {
            port = portNumber;
            Start();
        }

        public int Port { get { return port; } set { port = value; } }

        public void Start()
        {            
            serviceHost = new ServiceHost(typeof(Container));
            NetTcpBinding binding = new NetTcpBinding();
            serviceHost.AddServiceEndpoint(typeof(IContainer), binding, new Uri(string.Format("net.tcp://localhost:{0}/Container", port)));

            serviceHost.Open();
            Console.WriteLine("Server (PORT: {0}) ready and waiting for requests...", port);
        }

        public void Stop()
        {
            serviceHost.Close();
            Console.WriteLine("Server has been closed.");
        }
    }
}
