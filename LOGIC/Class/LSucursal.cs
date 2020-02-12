using ENTITY.inv.Sucursal.View;
using REPOSITORY.Clase;
using REPOSITORY.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Class
{
   public class LSucursal
    {
        protected ISucursal iSucursal;
        public LSucursal()
        {
            iSucursal = new RSucursal();
        }
        #region Consulta
        public List<VSucursalCombo> Listar()
        {
            try
            {
                return iSucursal.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}
