using BibliotecaClases;
//using DataAccess;
using System;

namespace AccesoDatos
{
    public class AccesoBaseDeDatos
    {
        public static Jugador ConvertirAJugador(BibliotecaClases.Jugador jugador)
        {
            return new Jugador
            {
                nombreUsuario = jugador.nombreUsuario,
                nombre = jugador.nombre,
                apellidos = jugador.apellidos,
                correo = jugador.correo,
                tipo = jugador.tipo,
            };
        }
        public static void AgregarJugadorABaseDeDatos(BibliotecaClases.Jugador jugador)
        {
            using(var contexto = new EntidadesGloom())
            {
                var jugadorEntidad = ConvertirAJugador(jugador);
                contexto.Jugadores.Add(jugadorEntidad);
                contexto.SaveChanges();


            }
        }        
    }
}
