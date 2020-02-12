using REPOSITORY.Base;
using REPOSITORY.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY.com.CompraIngreso_01;

namespace REPOSITORY.Clase
{
    public class RCompraIngreso_01 : BaseConexion, ICompraIngreso_01
    {
        public List<VCompraIngreso_01> ListarXId(int id)
        {

            try
            {
                using (var db = GetEsquema())
                {
                    var listResult = (from a in db.CompraIng_01
                                      join c in db.Producto on
                                       new
                                       {
                                           idProve = a.IdProduc
                                       }
                                       equals
                                       new
                                       {
                                           idProve = c.Id
                                       }
                                      where a.IdCompra.Equals(id)
                                      select new VCompraIngreso_01
                                      {
                                          Id = a.Id,
                                          IdProduc = a.IdProduc,
                                          Producto = c.Descrip,
                                          Caja = a.Caja,
                                          Grupo = a.Grupo,
                                          Maple = a.Maple,
                                          Cantidad = a.Cantidad,
                                          TotalCant = a.TotalCant,
                                          PrecioCost = a.PrecioCost,
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

        public List<VCompraIngreso_01> ListarXId2()
        {

            try
            {
                using (var db = GetEsquema())
                {
                    var listResult = (from c in db.Producto                                
                                      join b in db.Precio on
                                      new
                                      {
                                          idProduc = c.Id
                                      }
                                      equals
                                      new
                                      {
                                          idProduc = b.IdProduc
                                      }
                                      where b.IdPrecioCat.Equals(1)
                                      select new VCompraIngreso_01
                                      {
                                          Id = 0,
                                          IdProduc = c.Id,
                                          Producto = c.Descrip,
                                          Caja = 0,
                                          Grupo = 0,
                                          Maple = 0,
                                          Cantidad = 0,
                                          TotalCant = 0,
                                          PrecioCost = b.Prrecio,
                                          Total = 0
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
