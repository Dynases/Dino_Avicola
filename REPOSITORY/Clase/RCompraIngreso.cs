using REPOSITORY.Base;
using REPOSITORY.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY.com.CompraIngreso.View;

namespace REPOSITORY.Clase
{
    public class RCompraIngreso : BaseConexion, ICompraIngreso
    {
        #region Consulta
        public List<VCompraIngreso> Listar()
        {
            try
            {
                using (var db = GetEsquema())
                {
                    var listResult = (from a in db.CompraIng
                                      join c in db.Proveed on 
                                       new
                                       {
                                           idProve = a.IdProvee                                          
                                       }
                                       equals
                                       new
                                       {
                                           idProve = c.Id                                          
                                       }
                                      select new VCompraIngreso
                                      {
                                          Id = a.Id,
                                          Proveedor = c.Descrip,
                                          FechaEnt = a.FechaEnt,
                                          FechaRec = a.Fecha,
                                          Entregado = a.Entregado,
                                          Total = a.Total,
                                          Fecha = a.Fecha,
                                          Hora = a.Hora,
                                          Usuario = a.Usuario,
                                      }).ToList();
                    return listResult;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<VCompraIngresoLista> ListarXId(int id)
        {
            try
            {
                using (var db = GetEsquema())
                {
                    var listResult = (from a in db.CompraIng
                                      join c in db.Proveed on
                                      new
                                      {
                                          idProve = a.IdProvee
                                      }
                                      equals
                                      new
                                      {
                                          idProve = c.Id
                                      }
                                      join b in db.Proveed_01 on
                                         new
                                         {
                                             idProve = c.Id
                                         }
                                         equals
                                         new
                                         {
                                             idProve = b.IdProveed
                                         }
                                      where a.Id.Equals(id)
                                      select new VCompraIngresoLista
                                      {
                                          Id = a.Id,
                                          IdSucur = a.IdSucur,
                                          IdProvee = a.IdProvee,                                         
                                          CantidadSemanas = a.EdadSemana,
                                          Proveedor = c.Descrip,
                                          NumNota = a.NumNota,
                                          FechaEnt = a.FechaEnt,
                                          FechaRec = a.FechaRec,
                                          Placa = a.Placa,
                                          Tipo = a.Tipo,
                                          Observacion = a.Obser,
                                          Entregado = a.Entregado,
                                          Recibido = a.Recibido,
                                          Total = a.Total,
                                          TotalRecibido= a.TotalRecibido,
                                          TotalVendido =a.TotalVendido
                                      }).ToList();
                    return listResult;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}
