using BibliotecaClases;
using DataAccess;

//using DataAccess;
using System;
using System.Data.Entity;
using System.Data.SqlClient;

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
            try
            {
                using (var contexto = new EntidadesGloom())
                {
                    var jugadorEntidad = ConvertirAJugador(jugador);
                    contexto.Jugadores.Add(jugadorEntidad);
                    contexto.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                throw ManejadorExcepciones.CrearSqlException(ex);
            }
        }
        public static void ActualizarJugadorABaseDeDatos(BibliotecaClases.Jugador jugador)
        {
            try
            {
                using (var contexto = new EntidadesGloom())
                {
                    var jugadorEntidad = ConvertirAJugador(jugador);
                    contexto.Jugadores.Attach(jugadorEntidad);
                    contexto.Entry(jugadorEntidad).State = EntityState.Modified;
                    contexto.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                throw ManejadorExcepciones.CrearSqlException(ex);
            }
        }
    }
}
