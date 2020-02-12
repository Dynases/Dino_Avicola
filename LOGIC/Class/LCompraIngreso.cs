using ENTITY.com.CompraIngreso.View;
using REPOSITORY.Clase;
using REPOSITORY.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Class
{
   public class LCompraIngreso
    {
        protected ICompraIngreso iCompraIngreso;
        public LCompraIngreso()
        {
            iCompraIngreso = new RCompraIngreso();
        }
        #region Consulta

        public List<VCompraIngresoLista> ListarXId(int id)
        {
            try
            {
                return iCompraIngreso.ListarXId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<VCompraIngreso> Listar()
        {
            try
            {
                return iCompraIngreso.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
