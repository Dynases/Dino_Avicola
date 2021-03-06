//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DATA.EntityDataModel.DiAvi
{
    using System;
    using System.Collections.Generic;
    
    public partial class CompraIng
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompraIng()
        {
            this.CompraIng_01 = new HashSet<CompraIng_01>();
            this.Seleccion = new HashSet<Seleccion>();
        }
    
        public int Id { get; set; }
        public int IdSucur { get; set; }
        public int IdProvee { get; set; }
        public int Estado { get; set; }
        public string NumNota { get; set; }
        public System.DateTime FechaEnt { get; set; }
        public System.DateTime FechaRec { get; set; }
        public string Placa { get; set; }
        public string EdadSemana { get; set; }
        public int Tipo { get; set; }
        public string Obser { get; set; }
        public string Entregado { get; set; }
        public string Recibido { get; set; }
        public decimal TotalRecibido { get; set; }
        public decimal TotalVendido { get; set; }
        public decimal Total { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Usuario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompraIng_01> CompraIng_01 { get; set; }
        public virtual Proveed Proveed { get; set; }
        public virtual Sucursal Sucursal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Seleccion> Seleccion { get; set; }
    }
}
