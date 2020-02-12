using ENTITY.com.CompraIngreso.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.Interface
{
   public interface ICompraIngreso
    {
        List<VCompraIngreso> Listar();
        List<VCompraIngresoLista> ListarXId(int id);
    }
}
