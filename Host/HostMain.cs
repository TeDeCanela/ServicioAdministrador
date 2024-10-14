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
                Console.WriteLine("Server is running noooow inglish pinshi cambio qu no jala ahora ya estoy hasta la madre xddddd" +
                    "");

                Console.ReadLine();
            }
        }

    }
}
