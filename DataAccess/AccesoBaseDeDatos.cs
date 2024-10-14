﻿using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Spatial;


namespace AccesoDatos
{
    public class AccesoBaseDeDatos
    {
        public static void AgregarJugadorABaseDeDatos(Jugador jugador)
        {
            using(var contexto = new EntidadesGloom())
            {
                contexto.Jugador.Add(jugador);
                contexto.SaveChanges();
            }
        }        
    }
}
