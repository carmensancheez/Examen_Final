//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Examen_Final_WEB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class visita
    {
        public int Id { get; set; }
        public string motivoVisita { get; set; }
        public System.DateTime fechaVisita { get; set; }
        public System.TimeSpan horaEntrada { get; set; }
        public System.TimeSpan horaSalida { get; set; }
        public string nombreCompleto { get; set; }
        public Nullable<int> contactoRecibio { get; set; }
    
        public virtual contacto contacto { get; set; }
    }
}
