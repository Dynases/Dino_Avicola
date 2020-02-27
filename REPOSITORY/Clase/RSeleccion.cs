using REPOSITORY.Base;
using REPOSITORY.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY.com.Seleccion.View;
using DATA.EntityDataModel.DiAvi;

namespace REPOSITORY.Clase
{

    public class RSeleccion : BaseConexion, ISeleccion
    {
        #region tRANSACCIONES
        public bool Guardar(VSeleccionLista vSeleccion, ref int id)
        {
            try
            {
                using (var db = GetEsquema())
                {
                    var idAux = id;
                    Seleccion seleccion;
                    if (id > 0)
                    {
                        seleccion = db.CompraIng.Where(a => a.Id == idAux).FirstOrDefault();
                        if (seleccion == null)
                            throw new Exception("No existe la compra con id " + idAux);
                    }
                    else
                    {
                        seleccion = new CompraIng();
                        db.CompraIng.Add(seleccion);
                    }

                    seleccion.IdSucur = vSeleccion.IdSucur;
                    seleccion.IdProvee = vSeleccion.IdProvee;
                    seleccion.Estado = vSeleccion.estado;
                    seleccion.NumNota = vSeleccion.NumNota;
                    seleccion.FechaEnt = vSeleccion.FechaEnt;
                    seleccion.FechaRec = vSeleccion.FechaRec;
                    seleccion.Placa = vSeleccion.Placa;
                    seleccion.EdadSemana = vSeleccion.CantidadSemanas;
                    seleccion.Tipo = vSeleccion.Tipo;
                    seleccion.Obser = vSeleccion.Observacion;
                    seleccion.Entregado = vSeleccion.Entregado;
                    seleccion.Recibido = vSeleccion.Recibido;
                    seleccion.TotalVendido = vSeleccion.TotalVendido;
                    seleccion.TotalRecibido = vSeleccion.TotalRecibido;
                    seleccion.Total = vSeleccion.Total;
                    seleccion.Fecha = vSeleccion.Fecha;
                    seleccion.Hora = vSeleccion.Hora;
                    seleccion.Usuario = vSeleccion.Usuario;
                    db.SaveChanges();
                    id = seleccion.Id;
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        #endregion
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
