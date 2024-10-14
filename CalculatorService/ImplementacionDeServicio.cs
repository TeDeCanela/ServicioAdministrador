using BibliotecaClases;
using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Data.SqlClient;


namespace ServicioAdministrador
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CalculatorService" in both code and config file together.
    //[ServiceBehavior(ConcurrencyMode= ConcurrencyMode.Reentrant)]


    public partial class ImplementacionDeServicio : IJugador
    {

        public void AgregarJugador(BibliotecaClases.Jugador jugador)
        {
            try
            {
                var nuevoJugador = new BibliotecaClases.Jugador
                {
                    nombreUsuario = jugador.nombreUsuario,
                    nombre = jugador.nombre,
                    apellidos = jugador.apellidos,
                    correo = jugador.correo,
                    contraseña = jugador.contraseña,
                    tipo = jugador.tipo,
                };

                AccesoBaseDeDatos.AgregarJugadorABaseDeDatos(nuevoJugador);
                String mensaje = "Jugador agregado " + jugador.nombreUsuario;
                OperationContext.Current.GetCallbackChannel<IJugadorCallback>().RespuestaJugador(mensaje);


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar el registro");
            }

        }

        public void ActualizarJugador(BibliotecaClases.Jugador jugador)
        {
            try
            {
                var nuevoJugador = new BibliotecaClases.Jugador
                {
                    nombreUsuario = jugador.nombreUsuario,
                    nombre = jugador.nombre,
                    apellidos = jugador.apellidos,
                    correo = jugador.correo,
                    contraseña = jugador.contraseña,
                    tipo = jugador.tipo,
                };

                AccesoBaseDeDatos.ActualizarJugadorABaseDeDatos(nuevoJugador);
                String mensaje = "Jugador actualizado " + jugador.nombreUsuario;
                OperationContext.Current.GetCallbackChannel<IJugadorCallback>().RespuestaJugador(mensaje);


            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al ejecutar el registro");
            }
        }

            void IJugador.AgregarJugador(BibliotecaClases.Jugador jugador)
        {
            throw new NotImplementedException();
        }
        void IJugador.ActualizarJugador(BibliotecaClases.Jugador jugador)
        {
            throw new NotImplementedException();
    }




}
}
