using System;
using System.ServiceModel;

namespace Host
{
    class HostMain
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(ServicioAdministrador.ImplementacionDeServicio)))
            {
                host.Open();
                Console.WriteLine("Server is running");
                Console.ReadLine();
                Console.ReadLine();
                Console.ReadLine();
            }
        }

    }
}
