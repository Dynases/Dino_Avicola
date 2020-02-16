using REPOSITORY.Base;
using REPOSITORY.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY.com.Seleccion.View;

namespace REPOSITORY.Clase
{

    public class RSeleccion : BaseConexion, ISeleccion
    {
        public List<VSeleccionLista> Listar()
        {
            try
            {
                using (var db = GetEsquema())
                {
                    var listResult = (from a in db.Seleccion
                                      join b in db.CompraIng on
                                      new { idCompraIng = a.IdCompraIng }
                                        equals new { idCompraIng = b.Id }
                                      join c in db.Proveed on
                                      new { idProve = b.IdProvee }
                                            equals new { idProve = c.Id }
                                      select new VSeleccionLista
                                      {
                                          Id = a.Id,
                                          IdCompraIng = a.IdCompraIng,
                                          Granja = b.NumNota,
                                          FechaEntrega = b.FechaEnt,
                                          FechaRecepcion = b.FechaRec,
                                          Proveedor = c.Descrip,
                                          Placa = b.Placa,
                                          Tipo = b.Tipo,
                                          Edad = b.EdadSemana,
                                          Fecha = a.Fecha,
                                          Hora = a.Hora,
                                          Usuario = a.Usuario
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
