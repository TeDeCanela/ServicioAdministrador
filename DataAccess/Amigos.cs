//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Amigos
    {
        public string NombreUsuario { get; set; }
        public string JugadorAmigo { get; set; }
        public string Estado { get; set; }
    
        public virtual Amigos amigos { get; set; }
    }
}
