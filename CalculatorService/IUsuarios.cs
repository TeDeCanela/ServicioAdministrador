using System;
using System.Runtime.Serialization;
using System.ServiceModel;


namespace ServicioAdministrador
{
    [ServiceContract(CallbackContract = typeof(IUsersManagerCallback))]
    interface IUsuarios
    {
        [OperationContract(IsOneWay = true)]
        void AddUser(User user);

        [OperationContract(IsOneWay = true)]
        void SendMessage(string message);
    }

    [ServiceContract]
    interface IUsersManagerCallback
    {
        // Método asíncrono para recibir mensajes (no espera respuesta).
        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(string message);

        [OperationContract]
        void UsersResponse(string response);
    }
}


    [DataContract]
    public class User
    {
        [DataMember]
        public String Name { get; set; }
        [DataMember]    
        public String LastName { get; set; }   
    }

