using ENTITY.com.Seleccion.View;
using REPOSITORY.Clase;
using REPOSITORY.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Class
{
    public class LSeleccion
    {
        protected ISeleccion iSeleccion;
        public LSeleccion()
        {
            iSeleccion = new RSeleccion();
        }
        #region Consulta
        public List<VSeleccionLista> Listar()
        {
            try
            {
                return iSeleccion.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
