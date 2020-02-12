using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.com.CompraIngreso.View
{
    public class VCompraIngresoLista
    {
        public int Id { get; set; }
        public int IdSucur { get; set; }
        public int IdProvee { get; set; }
        public string Proveedor { get; set; }
        public string NumNota { get; set; }
        public System.DateTime FechaEnt { get; set; }
        public System.DateTime FechaRec { get; set; }
        public string Placa { get; set; }
        public int Tipo { get; set; }
        public string Observacion { get; set; }
        public string Entregado { get; set; }
        public int Recibido { get; set; }
        public decimal Total { get; set; }

        public string CantidadSemanas { get; set; }

    }
}
