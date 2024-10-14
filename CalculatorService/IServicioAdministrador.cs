﻿
using System.ServiceModel;


namespace ServicioAdministrador
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICalculatorService" in both code and config file together.
    [ServiceContract(CallbackContract =typeof(IServicioAdministradorCallback))]
    public interface IServicioAdministrador
    {
        [OperationContract(IsOneWay = true)]
        void Sum(int a, int b);
    }
    [ServiceContract]
    public interface IServicioAdministradorCallback
    {
        [OperationContract]
        void Response(int result);
    }

}
