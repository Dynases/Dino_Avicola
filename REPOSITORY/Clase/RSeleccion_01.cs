using REPOSITORY.Base;
using REPOSITORY.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY.com.Seleccion_01.View;

namespace REPOSITORY.Clase
{
    public class RSeleccion_01 : BaseConexion, ISeleccion_01
    {
        public List<VSeleccion_01_Lista> Listar()
        {
            try
            {
                using (var db = GetEsquema())
                {
                    var listResult = (from a in db.Seleccion_01
                                      join b in db.Producto on
                                      new { idProducto = a.IdProducto }
                                        equals new { idProducto = b.Id }                                     
                                      select new VSeleccion_01_Lista
                                      {
                                          Id = a.Id,
                                          IdSeleccion = a.IdSeleccion,
                                          Producto = b.Descrip,
                                          Cantidad = a.Cantidad,
                                          Precio = a.Precio,
                                          Total = a.Total
                                      }).ToList();
                    return listResult;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<VSeleccion_01_Lista> ListarXId(int id)
        {
            try
            {
                using (var db = GetEsquema())
                {
                    var listResult = (from a in db.Seleccion_01
                                      join b in db.Producto on
                                      new { idProducto = a.IdProducto }
                                        equals new { idProducto = b.Id }
                                      select new VSeleccion_01_Lista
                                      {
                                          Id = a.Id,
                                          IdSeleccion = a.IdSeleccion,
                                          Producto = b.Descrip,
                                          Cantidad = a.Cantidad,
                                          Precio = a.Precio,
                                          Total = a.Total
                                      }).ToList();
                    return listResult;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
