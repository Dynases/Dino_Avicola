using ENTITY.com.Seleccion_01.View;
using REPOSITORY.Clase;
using REPOSITORY.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Class
{
    public class LSeleccion_01
    {
        protected ISeleccion_01 iSeleccion_01;
        public LSeleccion_01()
        {
            iSeleccion_01 = new RSeleccion_01();
        }
        public List<VSeleccion_01_Lista> Listar()
        {
            try
            {
                return iSeleccion_01.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
