using DataAccess;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;

namespace ServicioAdministrador
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CalculatorService" in both code and config file together.
    [ServiceBehavior(ConcurrencyMode= ConcurrencyMode.Reentrant)]
    public partial class ImplementacionDeServicio : IServicioAdministrador
    {
        public void Sum(int a, int b)
        {
            int result = a + b;
            OperationContext.Current.GetCallbackChannel<ICalculatorServiceCallback>().Response(result);


        }
    }

    public partial class ImplementacionDeServicio : IUsuarios
    {
        private static List<IUsersManagerCallback> clients = new List<IUsersManagerCallback>();
        public void AddUser(User user)
        {
            AccesoBaseDeDatos daox = new AccesoBaseDeDatos();
            Console.WriteLine("add user");
            String message = "User added " + user.Name + " " + user.LastName;
            daox.AddUpdateDeleteEntityInConnectedScenario(user.Name, user.LastName);
            OperationContext.Current.GetCallbackChannel<IUsersManagerCallback>().UsersResponse(message);
            var callback = OperationContext.Current.GetCallbackChannel<IUsersManagerCallback>();

            if (!clients.Contains(callback))
            {
                clients.Add(callback);
                NotifyClients($"{user.Name} se ha unido al chat.");
            }

        }
        public void SendMessage(string message)
        {
            foreach (var client in clients)
            {
                client.ReceiveMessage(message);
            }
        }
        private void NotifyClients(string message)
        {
            foreach (var client in clients)
            {
                client.ReceiveMessage(message);  // Notificar a todos los clientes
            }
        }
    }
}
