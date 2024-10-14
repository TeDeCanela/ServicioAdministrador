using BibliotecaClases;
using AccesoDatos;
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

    public partial class ImplementacionDeServicio : IJugador
    {
        
        public void AgregarJugador(Jugador jugador)
        {
            try
            {
                var nuevoJugador = new Jugador 
                {
                    nombreUsuario = jugador.nombreUsuario,
                    nombre = jugador.nombre,
                    apellidos = jugador.apellidos,
                    correo = jugador.correo,
                    contraseña = jugador.contraseña,
                    tipo = jugador.tipo,
                };

                AccesoBaseDeDatos.AgregarJugadorABaseDeDatos(nuevoJugador);

            }catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar el registro");
            }

        }

        

        void IJugador.AgregarJugador(BibliotecaClases.Jugador jugador)
        {
            throw new NotImplementedException();
        }

       
    }
}
