//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_Jugador
    {
        public int IdJugador { get; set; }
        public string NombreJugador { get; set; }
        public int IdEquipo { get; set; }
        public int Goles { get; set; }
    
        public virtual TBL_Equipo TBL_Equipo { get; set; }
    }
}
