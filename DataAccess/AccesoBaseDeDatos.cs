using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Spatial;


namespace ServicioAdministrador
{
    public class AccesoBaseDeDatos
    {
        public void AddUpdateDeleteEntityInConnectedScenario(String usuario, String apellido)
        {
            Console.WriteLine("*** AddUpdateDeleteEntityInConnectedScenario Starts ***");

            using (var contexto = new EntidadesGloom())
            {
                //Log DB commands to console
                contexto.Database.Log = Console.WriteLine;
                //comentario inecesario, camabios incessraio 2
                //Add a new student and address
                //var nuevoUsuario = contexto.Usuarios.Add(new Usuarios { Id = 02, Usaername = usuario, LastName = apellido });
                contexto.SaveChanges(); // Executes Insert command
            }

            Console.WriteLine("*** AddUpdateDeleteEntityInConnectedScenario Ends ***");
        }
    }
}
