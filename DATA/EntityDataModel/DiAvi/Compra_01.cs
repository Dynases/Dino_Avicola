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
    
    public partial class Compra_01
    {
        public int Id { get; set; }
        public int IdCompra { get; set; }
        public int IdProduc { get; set; }
        public int Estado { get; set; }
        public decimal Cantidad { get; set; }
        public int UniMin { get; set; }
        public decimal PrecioCost { get; set; }
        public string Lote { get; set; }
        public System.DateTime FechaVen { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Utilidad { get; set; }
        public decimal PrecioVen { get; set; }
        public string Observ { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Usuario { get; set; }
    
        public virtual Compra Compra { get; set; }
        public virtual Producto Producto { get; set; }
    }
}