﻿using OdSyncService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace TestConsole
{
    class Program
    {
        static ServiceHost host = null;
        static void Main(string[] args)
        {
            Console.WriteLine("Press 'q' to end or any key to reapeat");
            do
            {
                OdSyncStatusWS os = new OdSyncStatusWS();


                var statuses = os.GetStatus();
                Console.WriteLine("======================================================");
                Console.WriteLine();
                
                    foreach (var status in statuses)
                        Console.WriteLine("{2} - Status = {0} Path = {1}", status.StatusString, status.LocalPath, status.ServiceType);
            } while (Console.ReadKey().KeyChar != 'q');

            try
            {
                host = new ServiceHost(typeof(OdSyncService.OdSyncStatusWS));

                Console.WriteLine("Opening service {0}...", host.Description.ServiceType);
                host.Open();
                Console.WriteLine("Service Opened");
                Console.WriteLine();
                Console.WriteLine("Endpoint(s)");
                Console.WriteLine("===========");
                foreach (var endP in host.Description.Endpoints)
                {
                    Console.WriteLine("{0} ({1})", endP.Address, endP.Binding);
                }
                Console.WriteLine();
                Console.Write("Press any key to close the Service...");
                Console.ReadKey();

                //OdSyncStatusWS sync = new OdSyncStatusWS();

                //var statuses = sync.GetStatus(true);
            }
            finally
            {
                if(host != null)
                    host.Close();
            }
        }
    }
}
