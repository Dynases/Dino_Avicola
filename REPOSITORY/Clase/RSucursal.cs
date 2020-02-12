﻿using ENTITY.inv.Sucursal.View;
using REPOSITORY.Base;
using REPOSITORY.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.Clase
{
    public class RSucursal : BaseConexion, ISucursal
    {
        public List<VSucursalCombo> Listar()
        {
            try
            {
                using (var db = GetEsquema())
                {
                    var listResult = (from a in db.Sucursal
                                      select new VSucursalCombo
                                      {
                                          IdLibreria = a.Id,
                                          Descripcion = a.Descrip
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
