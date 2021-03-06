﻿using Janus.Windows.GridEX;
using Janus.Windows.GridEX.EditControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using UTILITY.Enum.EnEstaticos;
using UTILITY.Global;
using ENTITY.com.Seleccion.View;
using ENTITY.com.CompraIngreso_01;
using ENTITY.com.Seleccion_01.View;
using PRESENTER.frm;

namespace PRESENTER.com
{
    public partial class FI_Seleccion : MODEL.ModeloF1
    {
        #region Variables
        string _NombreFormulario = "SELECCION";
        bool _Limpiar = false;
        int _idOriginal = 0;  
        int _MPos = 0;
        #endregion
        public FI_Seleccion()
        {
            InitializeComponent();
        }

        private void FI_Seleccion_Load(object sender, EventArgs e)
        {
            this.Name = _NombreFormulario;
            MP_Iniciar();
        }
        #region Metodos privados
        private void MP_Iniciar()
        {
            try
            {
                LblTitulo.Text = _NombreFormulario;
                MP_InicioArmarCombo();
                btnMax.Visible = false;
                MP_CargarEncabezado();
                MP_InHabilitar();
                Tb_MERMA.Value = 0;
            }
            catch (Exception ex)
            {
                MP_MostrarMensajeError(ex.Message);
            }
        }
        private void MP_CargarEncabezado()
        {
            try
            {
                var ListaCompleta = new ServiceDesktop.ServiceDesktopClient().Seleccion_Lista().ToList();
                var lista = (from a in ListaCompleta                     
                            select new { a.Id,a.IdCompraIng, a.Granja, a.Proveedor, a.FechaEntrega, a.FechaRecepcion,a.Fecha,a.Hora,a.Usuario}).ToList();
                if (lista.Count() > 0)
                {
                    Dgv_GBuscador.DataSource = lista;
                    Dgv_GBuscador.RetrieveStructure();
                    Dgv_GBuscador.AlternatingColors = true;

                    Dgv_GBuscador.RootTable.Columns["id"].Caption = "Nota Seleccion";
                    Dgv_GBuscador.RootTable.Columns["id"].Width = 140;
                    Dgv_GBuscador.RootTable.Columns["id"].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                    Dgv_GBuscador.RootTable.Columns["id"].CellStyle.FontSize = 8;
                    Dgv_GBuscador.RootTable.Columns["id"].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
                    Dgv_GBuscador.RootTable.Columns["id"].Visible = true;

                    Dgv_GBuscador.RootTable.Columns["IdCompraIng"].Caption = "Nota Recepcion";
                    Dgv_GBuscador.RootTable.Columns["IdCompraIng"].Width = 140;
                    Dgv_GBuscador.RootTable.Columns["IdCompraIng"].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                    Dgv_GBuscador.RootTable.Columns["IdCompraIng"].CellStyle.FontSize = 8;
                    Dgv_GBuscador.RootTable.Columns["IdCompraIng"].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
                    Dgv_GBuscador.RootTable.Columns["IdCompraIng"].Visible = true;

                    Dgv_GBuscador.RootTable.Columns["Granja"].Caption = "Nota Granja";
                    Dgv_GBuscador.RootTable.Columns["Granja"].Width = 140;
                    Dgv_GBuscador.RootTable.Columns["Granja"].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                    Dgv_GBuscador.RootTable.Columns["Granja"].CellStyle.FontSize = 8;
                    Dgv_GBuscador.RootTable.Columns["Granja"].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                    Dgv_GBuscador.RootTable.Columns["Granja"].Visible = true;

                    Dgv_GBuscador.RootTable.Columns["Proveedor"].Caption = "Proveedor";
                    Dgv_GBuscador.RootTable.Columns["Proveedor"].Width = 250;
                    Dgv_GBuscador.RootTable.Columns["Proveedor"].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                    Dgv_GBuscador.RootTable.Columns["Proveedor"].CellStyle.FontSize = 8;
                    Dgv_GBuscador.RootTable.Columns["Proveedor"].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                    Dgv_GBuscador.RootTable.Columns["Proveedor"].Visible = true;

                    
                    Dgv_GBuscador.RootTable.Columns["FechaEntrega"].Caption = "Fecha Entrega";
                    Dgv_GBuscador.RootTable.Columns["FechaEntrega"].Width = 200;
                    Dgv_GBuscador.RootTable.Columns["FechaEntrega"].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                    Dgv_GBuscador.RootTable.Columns["FechaEntrega"].CellStyle.FontSize = 8;
                    Dgv_GBuscador.RootTable.Columns["FechaEntrega"].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                    Dgv_GBuscador.RootTable.Columns["FechaEntrega"].Visible = true;

                    Dgv_GBuscador.RootTable.Columns["FechaRecepcion"].Caption = "FechaRecepcion";
                    Dgv_GBuscador.RootTable.Columns["FechaRecepcion"].Width = 200;
                    Dgv_GBuscador.RootTable.Columns["FechaRecepcion"].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                    Dgv_GBuscador.RootTable.Columns["FechaRecepcion"].CellStyle.FontSize = 8;
                    Dgv_GBuscador.RootTable.Columns["FechaRecepcion"].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
                    Dgv_GBuscador.RootTable.Columns["FechaRecepcion"].Visible = true;                  

                    Dgv_GBuscador.RootTable.Columns["Fecha"].Visible = false;                    
                    Dgv_GBuscador.RootTable.Columns["Hora"].Visible = false;                    
                    Dgv_GBuscador.RootTable.Columns["Usuario"].Visible = false;

                    //Habilitar filtradores
                    Dgv_GBuscador.DefaultFilterRowComparison = FilterConditionOperator.Contains;
                    Dgv_GBuscador.FilterMode = FilterMode.Automatic;
                    Dgv_GBuscador.FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges;
                    //Dgv_Buscardor.FilterRowButtonStyle = FilterRowButtonStyle.ConditionOperatorDropDown;
                    Dgv_GBuscador.GroupByBoxVisible = false;
                    Dgv_GBuscador.VisualStyle = VisualStyle.Office2007;
                }
            }
            catch (Exception ex)
            {
                MP_MostrarMensajeError(ex.Message);
            }
        }
        private void MP_CargarDetalle(int id)
        {
            try
            {              
                //Consulta segun un Id de Ingreso
                var lresult = new ServiceDesktop.ServiceDesktopClient().CmmpraIngreso_01ListarXId(id).ToList();
                var lista = (from a in lresult                            
                             select new { a.Id, a.Producto,a.TotalCant,a.PrecioCost,a.Total}).ToList();
                if (lista.Count() > 0)
                {                   
                    Dgv_Detalle.DataSource = lista;
                    Dgv_Detalle.RetrieveStructure();
                    Dgv_Detalle.AlternatingColors = true;

                    Dgv_Detalle.RootTable.Columns["id"].Visible = false;              
                                        
                    Dgv_Detalle.RootTable.Columns["Producto"].Caption = "PRODUCTO";
                    Dgv_Detalle.RootTable.Columns["Producto"].Width = 130;
                    Dgv_Detalle.RootTable.Columns["Producto"].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                    Dgv_Detalle.RootTable.Columns["Producto"].CellStyle.FontSize = 9;
                    Dgv_Detalle.RootTable.Columns["Producto"].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
                    Dgv_Detalle.RootTable.Columns["Producto"].Visible = true;

                    Dgv_Detalle.RootTable.Columns["TotalCant"].Caption = "CANT.";
                    Dgv_Detalle.RootTable.Columns["TotalCant"].FormatString = "0";
                    Dgv_Detalle.RootTable.Columns["TotalCant"].Width = 70;
                    Dgv_Detalle.RootTable.Columns["TotalCant"].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                    Dgv_Detalle.RootTable.Columns["TotalCant"].CellStyle.FontSize = 9;
                    Dgv_Detalle.RootTable.Columns["TotalCant"].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
                    Dgv_Detalle.RootTable.Columns["TotalCant"].Visible = true;

                    Dgv_Detalle.RootTable.Columns["PrecioCost"].Caption = "PRECIO";
                    Dgv_Detalle.RootTable.Columns["PrecioCost"].FormatString = "0.00";
                    Dgv_Detalle.RootTable.Columns["PrecioCost"].Width = 70;
                    Dgv_Detalle.RootTable.Columns["PrecioCost"].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                    Dgv_Detalle.RootTable.Columns["PrecioCost"].CellStyle.FontSize = 9;
                    Dgv_Detalle.RootTable.Columns["PrecioCost"].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
                    Dgv_Detalle.RootTable.Columns["PrecioCost"].Visible = true;

                    Dgv_Detalle.RootTable.Columns["Total"].Caption = "TOTAL";
                    Dgv_Detalle.RootTable.Columns["Total"].FormatString = "0.00";
                    Dgv_Detalle.RootTable.Columns["Total"].Width = 90;
                    Dgv_Detalle.RootTable.Columns["Total"].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                    Dgv_Detalle.RootTable.Columns["Total"].CellStyle.FontSize = 9;
                    Dgv_Detalle.RootTable.Columns["Total"].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
                    Dgv_Detalle.RootTable.Columns["Total"].Visible = true;                        
           
                    //Dgv_Buscardor.FilterRowButtonStyle = FilterRowButtonStyle.ConditionOperatorDropDown;
                    Dgv_Detalle.GroupByBoxVisible = false;
                    Dgv_Detalle.VisualStyle = VisualStyle.Office2007;
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, GLMensaje.Error);
            }
        }
        private void MP_CargarDetalle2(int id)
        {
            try
            {
                List<VSeleccion_01_Lista> lresult = new ServiceDesktop.ServiceDesktopClient().Seleccion_01_Lista().Where(a => a.IdSeleccion == id).ToList();
                ArmarDetalle(lresult);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, GLMensaje.Error);
            }
        }

        private void ArmarDetalle(List<VSeleccion_01_Lista> lresult)
        {
            if (lresult.Count() > 0)
            {
                Dgv_Seleccion.DataSource = lresult;
                Dgv_Seleccion.RetrieveStructure();
                Dgv_Seleccion.AlternatingColors = true;

                Dgv_Seleccion.RootTable.Columns["id"].Visible = false;
                Dgv_Seleccion.RootTable.Columns["IdSeleccion"].Visible = false;
                Dgv_Seleccion.RootTable.Columns["IdProducto"].Visible = false;
                Dgv_Seleccion.RootTable.Columns["Estado"].Visible = false;

                Dgv_Seleccion.RootTable.Columns["Producto"].Caption = "PRODUCTO";
                Dgv_Seleccion.RootTable.Columns["Producto"].Width = 150;
                Dgv_Seleccion.RootTable.Columns["Producto"].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                Dgv_Seleccion.RootTable.Columns["Producto"].CellStyle.FontSize = 9;
                Dgv_Seleccion.RootTable.Columns["Producto"].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
                Dgv_Seleccion.RootTable.Columns["Producto"].Visible = true;

                Dgv_Seleccion.RootTable.Columns["Cantidad"].Key = "Cantidad";
                Dgv_Seleccion.RootTable.Columns["Cantidad"].Caption = "CANT.";
                Dgv_Seleccion.RootTable.Columns["Cantidad"].FormatString = "0";
                Dgv_Seleccion.RootTable.Columns["Cantidad"].Width = 75;
                Dgv_Seleccion.RootTable.Columns["Cantidad"].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                Dgv_Seleccion.RootTable.Columns["Cantidad"].CellStyle.FontSize = 9;
                Dgv_Seleccion.RootTable.Columns["Cantidad"].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
                Dgv_Seleccion.RootTable.Columns["Cantidad"].Visible = true;

                Dgv_Seleccion.RootTable.Columns["Precio"].Caption = "PRECIO";
                Dgv_Seleccion.RootTable.Columns["Precio"].FormatString = "0.00";
                Dgv_Seleccion.RootTable.Columns["Precio"].Width = 75;
                Dgv_Seleccion.RootTable.Columns["Precio"].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                Dgv_Seleccion.RootTable.Columns["Precio"].CellStyle.FontSize = 9;
                Dgv_Seleccion.RootTable.Columns["Precio"].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
                Dgv_Seleccion.RootTable.Columns["Precio"].Visible = true;

                Dgv_Seleccion.RootTable.Columns["Total"].Caption = "TOTAL";
                Dgv_Seleccion.RootTable.Columns["Total"].FormatString = "0.00";
                Dgv_Seleccion.RootTable.Columns["Total"].Width = 90;
                Dgv_Seleccion.RootTable.Columns["Total"].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                Dgv_Seleccion.RootTable.Columns["Total"].CellStyle.FontSize = 9;
                Dgv_Seleccion.RootTable.Columns["Total"].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
                Dgv_Seleccion.RootTable.Columns["Total"].Visible = true;

                //Dgv_Buscardor.FilterRowButtonStyle = FilterRowButtonStyle.ConditionOperatorDropDown;
                Dgv_Seleccion.GroupByBoxVisible = false;
                Dgv_Seleccion.VisualStyle = VisualStyle.Office2007;
            }
        }

        private void MP_CargarDetalle_Nuevo(int IdCompraIngreso_01)
        {
            try
            {               
                //Consulta segun un Categoria 
                var lresult = new ServiceDesktop.ServiceDesktopClient().Seleccion_01_ListarXId_Vacio(IdCompraIngreso_01).Where(a => !a.Producto.Contains("SIN SELECCION")).ToList();
                ArmarDetalle(lresult);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, GLMensaje.Error);
            }
        }       
        private void MP_InicioArmarCombo()
        {
            //Carga las librerias al combobox desde una lista
            UTGlobal.MG_ArmarCombo(Cb_Tipo,
                                   new ServiceDesktop.ServiceDesktopClient().LibreriaListarCombo(Convert.ToInt32(ENEstaticosGrupo.PRODUCTO),
                                                                                                 Convert.ToInt32(ENEstaticosOrden.PRODUCTO_GRUPO2)).ToList());
        }
        private void MP_SeleccionarButtonCombo(MultiColumnCombo combo, ButtonX btn)
        {
            try
            {
                if (combo.SelectedIndex < 0 && combo.Text != string.Empty)
                {
                    btn.Visible = true;
                }
                else
                {
                    btn.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, GLMensaje.Error);
            }
        }
        public static DataTable ListaATabla(List<VSeleccionLista> lista)
        {
            DataTable tabla = new DataTable();
            //Crear la Estructura de la Tabla a partir de la Lista de Objetos
            PropertyInfo[] propiedades = lista[0].GetType().GetProperties();
            for (int i = 0; i < propiedades.Length; i++)
            {
                tabla.Columns.Add(propiedades[i].Name, propiedades[i].PropertyType);
            }
            //Llenar la Tabla desde la Lista de Objetos
            DataRow fila = null;
            for (int i = 0; i < lista.Count; i++)
            {
                propiedades = lista[i].GetType().GetProperties();
                fila = tabla.NewRow();
                for (int j = 0; j < propiedades.Length; j++)
                {
                    fila[j] = propiedades[j].GetValue(lista[i], null);
                }
                tabla.Rows.Add(fila);
            }
            return (tabla);
        }
        private void MP_Habilitar()
        {
            Tb_IdCompraIngreso.ReadOnly = false;
            Tb_NUmGranja.ReadOnly = false;
            Tb_Placa.ReadOnly = false;
            Cb_Tipo.Enabled = true;
            tb_Proveedor.ReadOnly = false;           
            Tb_Edad.ReadOnly = false;           
            Tb_FechaEnt.Value = DateTime.Now;
            Tb_FechaRec.Value = DateTime.Now;        
            Dgv_Detalle.Enabled = true;
            Dgv_Seleccion.Enabled = true;

        }
        private void MP_InHabilitar()
        {
            Tb_IdCompraIngreso.ReadOnly = true;
            Tb_NUmGranja.ReadOnly = true;
            Tb_Placa.ReadOnly = true;
            Cb_Tipo.Enabled = false;
            Tb_Edad.ReadOnly = true;
            tb_Proveedor.ReadOnly = true;          
            _Limpiar = false;          
            Dgv_Detalle.Enabled = false;
            Dgv_Seleccion.Enabled = false;

        }
        private void MP_Limpiar()
        {
            try
            {
                Tb_IdCompraIngreso.Clear();
                Tb_NUmGranja.Clear();
                Tb_Placa.Clear();
               
                Tb_FechaEnt.Value = DateTime.Now;
                Tb_FechaRec.Value = DateTime.Now;
                if (_Limpiar == false)
                {
                    UTGlobal.MG_SeleccionarCombo(Cb_Tipo);                    
                }
                //((List<VCompraIngreso_01>)Dgv_Detalle.DataSource).Clear();
                Dgv_Detalle.DataSource = null;
                Dgv_Seleccion.DataSource = null;
                Tb_Recep_TCantidad.Value = 0;
                Tb_Recep_TPrecio.Value = 0;
                Tb_Recep_Total.Value = 0;
                Tb_TCantidad.Value = 0;
                Tb_TPrecio.Value = 0;
                Tb_Total.Value = 0;
                // ((DataTable)Dgv_Detalle.DataSource).Clear();
                //  Dgv_Detalle.DataSource = null;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace, GLMensaje.Error);
            }

        }
        private void MP_MostrarRegistro(int _Pos)
        {
            try
            { 
                Dgv_GBuscador.Row = _Pos;
                _idOriginal = (int)Dgv_GBuscador.GetValue("id");
                if (_idOriginal != 0)
                {
                    var ListaCompleta = new ServiceDesktop.ServiceDesktopClient().Seleccion_Lista();
                    var lista = (from a in ListaCompleta
                                 where a.Id.Equals(_idOriginal)
                                 select new { a.Id, a.IdCompraIng, a.Granja, a.FechaEntrega, a.FechaRecepcion, a.Placa, a.Proveedor, a.Tipo, a.Edad }).ToList();

                    foreach (var seleccion in lista)
                    {
                        Tb_Id.Text = seleccion.Id.ToString();
                        Tb_NUmGranja.Text = seleccion.Granja.ToString();
                        Tb_IdCompraIngreso.Text = seleccion.IdCompraIng.ToString();
                        Tb_FechaEnt.Value = seleccion.FechaEntrega;
                        Tb_FechaRec.Value = seleccion.FechaRecepcion;
                        Tb_Placa.Text = seleccion.Placa == "" ? "" : seleccion.Placa;
                        tb_Proveedor.Text = seleccion.Proveedor.ToString();
                        Cb_Tipo.Value = (int)seleccion.Tipo;
                        Tb_Edad.Text = seleccion.Edad.ToString();
                    }
                    MP_CargarDetalle(Convert.ToInt32(Tb_IdCompraIngreso.Text));
                    MP_CargarDetalle2(Convert.ToInt32(Tb_Id.Text));
                    MP_ObtenerCalculo();
                    LblPaginacion.Text = Convert.ToString(_Pos + 1) + "/" + Dgv_GBuscador.RowCount.ToString();
                }
            }
            catch (Exception ex)
            {
                MP_MostrarMensajeError(ex.Message);
            }            
        }
        private void MP_ObtenerCalculo()
        {
            try
            {
                decimal Precio = 0;
                if (Tb_IdCompraIngreso.Text != "")
                {
                    var lresult = new ServiceDesktop.ServiceDesktopClient().CmmpraIngreso_01ListarXId(Convert.ToInt32(Tb_IdCompraIngreso.Text)).ToList();
                    Precio = lresult.Select(c => c.PrecioCost).Sum() / lresult.Where(c => c.PrecioCost > 0).Select(d => d.PrecioCost).Count();
                }              
                Tb_Recep_TCantidad.Value = Convert.ToDouble(Dgv_Detalle.GetTotal(Dgv_Detalle.RootTable.Columns["TotalCant"], AggregateFunction.Sum));
                Tb_Recep_TPrecio.Value = Convert.ToDouble(Precio);
                Tb_Recep_Total.Value = Tb_Recep_TCantidad.Value * Tb_Recep_TPrecio.Value;
                Tb_TCantidad.Value = Convert.ToDouble(Dgv_Seleccion.GetTotal(Dgv_Seleccion.RootTable.Columns["Cantidad"], AggregateFunction.Sum));
                Tb_TPrecio.Value = Convert.ToDouble(Precio);
                //Tb_Selecc_TPrecio.Value = Convert.ToDouble(Dgv_Seleccion.GetTotal(Dgv_Seleccion.RootTable.Columns["Precio"], AggregateFunction.Sum)) / Dgv_Seleccion.RowCount;
                Tb_Total.Value = Tb_TCantidad.Value * Tb_TPrecio.Value;
            }
            catch (Exception ex)
            {
                MP_MostrarMensajeError(ex.Message);
            }                    
        }
        private void MP_Filtrar(int tipo)
        {
            MP_CargarEncabezado();
            if (Dgv_GBuscador.RowCount > 0)
            {
                _MPos = 0;
                MP_MostrarRegistro(tipo == 1 ? _MPos : Dgv_GBuscador.RowCount - 1);
            }
            else
            {
                MP_Limpiar();
                LblPaginacion.Text = "0/0";
            }
        }
        void MP_MostrarMensajeError(string mensaje)
        {
            ToastNotification.Show(this, mensaje.ToUpper(), PRESENTER.Properties.Resources.WARNING, (int)GLMensajeTamano.Mediano, eToastGlowColor.Green, eToastPosition.TopCenter);
        }

        #endregion
        #region Eventos     

        private void Dgv_GBuscador_SelectionChanged_1(object sender, EventArgs e)
        {
            if (Dgv_GBuscador.Row >= 0 && Dgv_GBuscador.RowCount >= 0)
            {
                MP_MostrarRegistro(Dgv_GBuscador.Row);
            }
        }

        private void Dgv_Detalle_EditingCell_1(object sender, EditingCellEventArgs e)
        {           
            e.Cancel = false;            
        }

        private void Dgv_Seleccion_EditingCell(object sender, EditingCellEventArgs e)
        {
            if (Tb_Id.ReadOnly == false)
            {
                if (e.Column.Index == Dgv_Seleccion.RootTable.Columns["Cantidad"].Index)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void Dgv_Seleccion_CellEdited(object sender, ColumnActionEventArgs e)
        {
            try
            {
                Double cantidad, precio, total;
                cantidad = Convert.ToDouble(Dgv_Seleccion.CurrentRow.Cells["Cantidad"].Value);
                precio = Convert.ToDouble(Dgv_Seleccion.CurrentRow.Cells["Precio"].Value);
                total = cantidad * precio;
                Dgv_Seleccion.CurrentRow.Cells["Total"].Value = total;
                MP_ObtenerCalculo();
            }
            catch (Exception ex)
            {

                MP_MostrarMensajeError(ex.Message);
            }
           
        }  

        private void Tb_IdCompraIngreso_KeyDown(object sender, KeyEventArgs e)
        {
            if (Tb_FechaEnt.IsInputReadOnly == false)
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
                {
                    var lista = new ServiceDesktop.ServiceDesktopClient().CompraIngreso_ListarEncabezado();
                    List<GLCelda> listEstCeldas = new List<GLCelda>();
                    listEstCeldas.Add(new GLCelda() { campo = "Id", visible = true, titulo = "ID", tamano = 80 });
                    listEstCeldas.Add(new GLCelda() { campo = "NumNota", visible = true, titulo = "NOTA DE GRANJA", tamano = 80 });
                    listEstCeldas.Add(new GLCelda() { campo = "FechaEnt", visible = true, titulo = "FECHA ENTRADA", tamano = 80 });
                    listEstCeldas.Add(new GLCelda() { campo = "FechaRec", visible = true, titulo = "FECHA RECEPCION", tamano = 80 });
                    listEstCeldas.Add(new GLCelda() { campo = "Placa", visible = true, titulo = "PLACA", tamano = 120 });
                    listEstCeldas.Add(new GLCelda() { campo = "IdProvee", visible = false, titulo = "IdProvee", tamano = 100 });
                    listEstCeldas.Add(new GLCelda() { campo = "Proveedor", visible = true, titulo = "PROVEEDOR", tamano = 150 });
                    listEstCeldas.Add(new GLCelda() { campo = "Tipo", visible = false, titulo = "Tipo", tamano = 100 });
                    listEstCeldas.Add(new GLCelda() { campo = "EdadSemana", visible = false, titulo = "EDAD SEMANA", tamano = 100 });
                    listEstCeldas.Add(new GLCelda() { campo = "IdSucur", visible = false, titulo = "IdSucur", tamano = 100 });
                    Efecto efecto = new Efecto();
                    efecto.Tipo = 3;
                    efecto.Tabla = lista;
                    efecto.SelectCol = 2;
                    efecto.listaCelda = listEstCeldas;
                    efecto.Alto = 50;
                    efecto.Ancho = 350;
                    efecto.Context = "SELECCIONE UN INGRESO";
                    efecto.ShowDialog();
                    bool bandera = false;
                    bandera = efecto.Band;
                    if (bandera)
                    {
                        Janus.Windows.GridEX.GridEXRow Row = efecto.Row;
                        Tb_IdCompraIngreso.Text = Row.Cells["Id"].Value.ToString();
                        Tb_NUmGranja.Text = Row.Cells["NumNota"].Value.ToString();
                        Tb_FechaEnt.Value = Convert.ToDateTime(Row.Cells["FechaEnt"].Value);
                        Tb_FechaRec.Value = Convert.ToDateTime(Row.Cells["FechaRec"].Value);
                        Cb_Tipo.Value = Row.Cells["Tipo"].Value;
                        tb_Proveedor.Text = Row.Cells["Proveedor"].Value.ToString();
                        Tb_Placa.Text = Row.Cells["Placa"].Value.ToString();
                        Tb_Edad.Text = Row.Cells["EdadSemana"].Value.ToString();
                        Cb_Almacen.Value = Row.Cells["IdSucur"].Value;
                        MP_CargarDetalle(Convert.ToInt32(Tb_IdCompraIngreso.Text));
                        MP_CargarDetalle_Nuevo(Convert.ToInt32(Tb_IdCompraIngreso.Text));
                    }
                }
            }
        }
        #endregion
        #region Metodo heredados
        public override bool MH_NuevoRegistro()
        {
            bool resultado = false;
            string mensaje = "";

            VSeleccion vSeleccion = new VSeleccion()
            {
                IdSucur = Convert.ToInt32(Cb_Almacen.Value),
                IdCompraIng = Convert.ToInt32(Tb_IdCompraIngreso.Text),
                Estado = 1,
                Cantidad = Convert.ToDecimal(Tb_TCantidad.Value),
                Precio = Convert.ToDecimal(Tb_TPrecio.Value),
                Total = Convert.ToDecimal(Tb_Total.Value),
                Fecha = DateTime.Now.Date,
                Hora = DateTime.Now.ToString("hh:mm"),
                Usuario = UTGlobal.Usuario,
                Merma = Convert.ToDecimal(Tb_MERMA.Value)
            };
            int id = Tb_Id.Text == string.Empty ? 0 : Convert.ToInt32(Tb_Id.Text);
            int idAux = id;
            var detalle = ((List<VSeleccion_01>)Dgv_Seleccion.DataSource).ToArray<VSeleccion_01>();

            resultado = new ServiceDesktop.ServiceDesktopClient().Seleccion_Guardar(vSeleccion, detalle, ref id, TxtNombreUsu.Text);
            if (resultado)
            {
                if (idAux == 0)//Registar
                {
                    Tb_NUmGranja.Focus();
                    MP_CargarEncabezado();
                    MP_Limpiar();
                    _Limpiar = true;
                    mensaje = GLMensaje.Nuevo_Exito(_NombreFormulario, id.ToString());
                }
                else//Modificar
                {
                    MP_Filtrar(1);
                    MP_InHabilitar();//El formulario
                    _Limpiar = true;
                    mensaje = GLMensaje.Modificar_Exito(_NombreFormulario, id.ToString());
                    MH_Habilitar();//El menu                   
                }
            }
            //Resultado
            if (resultado)
            {
                ToastNotification.Show(this, mensaje, PRESENTER.Properties.Resources.GRABACION_EXITOSA, (int)GLMensajeTamano.Chico, eToastGlowColor.Green, eToastPosition.TopCenter);
            }
            else
            {
                mensaje = GLMensaje.Registro_Error(_NombreFormulario);
                ToastNotification.Show(this, mensaje, PRESENTER.Properties.Resources.CANCEL, (int)GLMensajeTamano.Chico, eToastGlowColor.Green, eToastPosition.TopCenter);
            }
            return resultado;
        }
        public override void MH_Nuevo()
        {
            MP_Habilitar();
            MP_Limpiar();

        }
        public override void MH_Modificar()
        {
            MP_Habilitar();

        }
        public override void MH_Salir()
        {
            MP_InHabilitar();
            MP_Filtrar(1);
        }
        public override bool MH_Validar()
        {
            bool _Error = false;
            try
            {               
                if (Tb_NUmGranja.Text == "")
                {
                    Tb_NUmGranja.BackColor = Color.Red;
                    _Error = true;
                }
                else
                    Tb_NUmGranja.BackColor = Color.White;

                if (tb_Proveedor.Text == "")
                {
                    tb_Proveedor.BackColor = Color.Red;
                    _Error = true;
                }
                else
                    tb_Proveedor.BackColor = Color.White;
                if (Cb_Tipo.SelectedIndex == -1)
                {
                    Cb_Tipo.BackColor = Color.Red;
                    _Error = true;
                }
                else
                    Cb_Tipo.BackColor = Color.White;
                return _Error;
            }
            catch (Exception ex)
            {
                MP_MostrarMensajeError(ex.Message);
                return _Error;
            }          
        }
        #endregion

       
    }
}
