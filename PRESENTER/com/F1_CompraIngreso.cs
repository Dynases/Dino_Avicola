using DevComponents.DotNetBar;
using ENTITY.com.CompraIngreso_01;
using ENTITY.Libreria.View;
using Janus.Windows.GridEX;
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
using UTILITY.Enum.EnEstaticos;
using UTILITY.Global;

namespace PRESENTER.com
{
    public partial class F1_CompraIngreso : MODEL.ModeloF1
    {
        public F1_CompraIngreso()
        {
            InitializeComponent();
            MP_Iniciar();
            superTabControl1.SelectedTabIndex = 0;
        }
        #region Variables
        string _NombreFormulario = "COMPRA INGRESO";
        bool _Limpiar = false;
        int _idOriginal = 0;
        int _idProveedor = 0;
        int _MPos = 0;
        #endregion
        #region Eventos
        private void btn_Tipo_Click(object sender, EventArgs e)
        {
            try
            {
                int idLibreria = 0;
                var lLibreria = new ServiceDesktop.ServiceDesktopClient().LibreriaListarCombo(Convert.ToInt32(ENEstaticosGrupo.COMPRA_INGRESO),
                                                                                         Convert.ToInt32(ENEstaticosOrden.COMPRA_INGRESO_TIPO));
                if (lLibreria.Count() > 0)
                {
                    idLibreria = lLibreria.Select(x => x.IdLibreria).Max();
                }
                VLibreriaLista libreria = new VLibreriaLista()
                {
                    IdGrupo = Convert.ToInt32(ENEstaticosGrupo.COMPRA_INGRESO),
                    IdOrden = Convert.ToInt32(ENEstaticosOrden.COMPRA_INGRESO_TIPO),
                    IdLibrer = idLibreria + 1,
                    Descrip = Cb_Tipo.Text == "" ? "" : Cb_Tipo.Text,
                    Fecha = DateTime.Now.Date,
                    Hora = DateTime.Now.ToString("hh:mm"),
                    Usuario = UTGlobal.Usuario,
                };
                if (new ServiceDesktop.ServiceDesktopClient().LibreriaGuardar(libreria))
                {
                    UTGlobal.MG_ArmarCombo(Cb_Tipo,
                                  new ServiceDesktop.ServiceDesktopClient().LibreriaListarCombo(Convert.ToInt32(ENEstaticosGrupo.COMPRA_INGRESO),
                                                                                                Convert.ToInt32(ENEstaticosOrden.COMPRA_INGRESO_TIPO)).ToList());
                    Cb_Tipo.SelectedIndex = ((List<VLibreria>)Cb_Tipo.DataSource).Count() - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GLMensaje.Error);
            }
        }

        private void btn_Recibido_Click(object sender, EventArgs e)
        {
            try
            {
                int idLibreria = 0;
                var lLibreria = new ServiceDesktop.ServiceDesktopClient().LibreriaListarCombo(Convert.ToInt32(ENEstaticosGrupo.COMPRA_INGRESO),
                                                                                         Convert.ToInt32(ENEstaticosOrden.COMPRA_INGRESO_RECIBIDO));
                if (lLibreria.Count() > 0)
                {
                    idLibreria = lLibreria.Select(x => x.IdLibreria).Max();
                }
                VLibreriaLista libreria = new VLibreriaLista()
                {
                    IdGrupo = Convert.ToInt32(ENEstaticosGrupo.COMPRA_INGRESO),
                    IdOrden = Convert.ToInt32(ENEstaticosOrden.COMPRA_INGRESO_RECIBIDO),
                    IdLibrer = idLibreria + 1,
                    Descrip = Cb_Recibido.Text == "" ? "" : Cb_Recibido.Text,
                    Fecha = DateTime.Now.Date,
                    Hora = DateTime.Now.ToString("hh:mm"),
                    Usuario = UTGlobal.Usuario,
                };
                if (new ServiceDesktop.ServiceDesktopClient().LibreriaGuardar(libreria))
                {
                    UTGlobal.MG_ArmarCombo(Cb_Recibido,
                                  new ServiceDesktop.ServiceDesktopClient().LibreriaListarCombo(Convert.ToInt32(ENEstaticosGrupo.COMPRA_INGRESO),
                                                                                                Convert.ToInt32(ENEstaticosOrden.COMPRA_INGRESO_RECIBIDO)).ToList());
                    Cb_Recibido.SelectedIndex = ((List<VLibreria>)Cb_Recibido.DataSource).Count() - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GLMensaje.Error);
            }
        }
        private void Cb_Tipo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Cb_Tipo.Enabled == true)
                {
                    MP_CargarDetalle(Convert.ToInt32(Cb_Tipo.Value), 2);
                }
            }
            catch (Exception ex)
            {
                MP_MostrarMensajeError(ex.Message);
            }
        }

        private void Cb_Recibido_ValueChanged(object sender, EventArgs e)
        {
            MP_SeleccionarButtonCombo(Cb_Recibido, btn_Recibido);
        }
        private void Dgv_GBuscador_SelectionChanged(object sender, EventArgs e)
        {
            if (Dgv_GBuscador.Row >= 0 && Dgv_GBuscador.RowCount >= 0)
            {
                MP_MostrarRegistro(Dgv_GBuscador.Row);
            }
        }
        private void Dgv_Detalle_EditingCell(object sender, EditingCellEventArgs e)
        {
            if (Tb_Cod.ReadOnly == false)
            {
                if (e.Column.Index == Dgv_Detalle.RootTable.Columns[3].Index ||
                    e.Column.Index == Dgv_Detalle.RootTable.Columns[4].Index ||
                    e.Column.Index == Dgv_Detalle.RootTable.Columns[5].Index ||
                    e.Column.Index == Dgv_Detalle.RootTable.Columns[6].Index ||
                    e.Column.Index == Dgv_Detalle.RootTable.Columns[8].Index)
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
      
        private void Dgv_Detalle_CellEdited(object sender, ColumnActionEventArgs e)
        {
            Double caja, grupo, maple, cantidad, subTotal, precio, total;
            caja = Convert.ToDouble(Dgv_Detalle.CurrentRow.Cells[3].Value) * 360;
            grupo = Convert.ToDouble(Dgv_Detalle.CurrentRow.Cells[4].Value) * 300;
            maple = Convert.ToDouble(Dgv_Detalle.CurrentRow.Cells[5].Value) * 30;
            cantidad = Convert.ToDouble(Dgv_Detalle.CurrentRow.Cells[6].Value);
            subTotal = caja + grupo + maple + cantidad;
            Dgv_Detalle.CurrentRow.Cells[7].Value = subTotal;
            precio = Convert.ToDouble(Dgv_Detalle.CurrentRow.Cells[8].Value);
            total = subTotal * precio;
            Dgv_Detalle.CurrentRow.Cells[9].Value = total;
            MP_ObtenerCalculo();

        }
        private void Dgv_Detalle_CellValueChanged(object sender, ColumnActionEventArgs e)
        {
        }
        #endregion

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, GLMensaje.Error);
            }
        }
        private void MP_CargarEncabezado()
        {
            try
            {
                var result = new ServiceDesktop.ServiceDesktopClient().CmmpraIngresoListar();
                if (result.Count() > 0)
                {
                    Dgv_GBuscador.DataSource = result;
                    Dgv_GBuscador.RetrieveStructure();
                    Dgv_GBuscador.AlternatingColors = true;

                    Dgv_GBuscador.RootTable.Columns[0].Key = "id";
                    Dgv_GBuscador.RootTable.Columns[0].Visible = false;

                    Dgv_GBuscador.RootTable.Columns[1].Key = "Proveedor";
                    Dgv_GBuscador.RootTable.Columns[1].Caption = "Proveedor";
                    Dgv_GBuscador.RootTable.Columns[1].Width = 300;
                    Dgv_GBuscador.RootTable.Columns[1].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                    Dgv_GBuscador.RootTable.Columns[1].CellStyle.FontSize = 8;
                    Dgv_GBuscador.RootTable.Columns[1].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
                    Dgv_GBuscador.RootTable.Columns[1].Visible = true;

                    Dgv_GBuscador.RootTable.Columns[2].Key = "FechaEnt";
                    Dgv_GBuscador.RootTable.Columns[2].Caption = "Fecha Entrega";
                    Dgv_GBuscador.RootTable.Columns[2].Width = 220;
                    Dgv_GBuscador.RootTable.Columns[2].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                    Dgv_GBuscador.RootTable.Columns[2].CellStyle.FontSize = 8;
                    Dgv_GBuscador.RootTable.Columns[2].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                    Dgv_GBuscador.RootTable.Columns[2].Visible = true;

                    Dgv_GBuscador.RootTable.Columns[3].Key = "FechaRec";
                    Dgv_GBuscador.RootTable.Columns[3].Caption = "Fecha Recepcion";
                    Dgv_GBuscador.RootTable.Columns[3].Width = 200;
                    Dgv_GBuscador.RootTable.Columns[3].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                    Dgv_GBuscador.RootTable.Columns[3].CellStyle.FontSize = 8;
                    Dgv_GBuscador.RootTable.Columns[3].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                    Dgv_GBuscador.RootTable.Columns[3].Visible = true;

                    Dgv_GBuscador.RootTable.Columns[4].Key = "Entregado";
                    Dgv_GBuscador.RootTable.Columns[4].Caption = "Entregado";
                    Dgv_GBuscador.RootTable.Columns[4].Width = 200;
                    Dgv_GBuscador.RootTable.Columns[4].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                    Dgv_GBuscador.RootTable.Columns[4].CellStyle.FontSize = 8;
                    Dgv_GBuscador.RootTable.Columns[4].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
                    Dgv_GBuscador.RootTable.Columns[4].Visible = true;                   

                    Dgv_GBuscador.RootTable.Columns[5].Key = "Total";
                    Dgv_GBuscador.RootTable.Columns[5].Caption = "Total";
                    Dgv_GBuscador.RootTable.Columns[5].FormatString = "0.00";
                    Dgv_GBuscador.RootTable.Columns[5].Width = 200;
                    Dgv_GBuscador.RootTable.Columns[5].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                    Dgv_GBuscador.RootTable.Columns[5].CellStyle.FontSize = 8;
                    Dgv_GBuscador.RootTable.Columns[5].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
                    Dgv_GBuscador.RootTable.Columns[5].Visible = true;

                    Dgv_GBuscador.RootTable.Columns[6].Key = "Fecha";
                    Dgv_GBuscador.RootTable.Columns[6].Visible = false;

                    Dgv_GBuscador.RootTable.Columns[7].Key = "Hora";
                    Dgv_GBuscador.RootTable.Columns[7].Visible = false;

                    Dgv_GBuscador.RootTable.Columns[8].Key = "Usuario";
                    Dgv_GBuscador.RootTable.Columns[8].Visible = false;

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
                MessageBox.Show(ex.StackTrace, GLMensaje.Error);
            }
        }
        private void MP_CargarDetalle(int id, int tipo)
        {
            try
            {
                List<VCompraIngreso_01> lresult = new List<VCompraIngreso_01>();
                if (tipo == 1)
                {
                    //Consulta segun un Id de Ingreso
                    lresult = new ServiceDesktop.ServiceDesktopClient().CmmpraIngreso_01ListarXId(id).ToList();
                }
                else
                {
                   //Consulta segun un Categoria 
                    lresult = new ServiceDesktop.ServiceDesktopClient().CmmpraIngreso_01ListarXId2(id).ToList();
                }

                MP_ArmarDetalle(lresult);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, GLMensaje.Error);
            }

        }        
        private void MP_ArmarDetalle(List<VCompraIngreso_01> lresult)
        {
            if (lresult.Count() > 0)
            {
                DataTable result = ListaATabla(lresult);
                Dgv_Detalle.DataSource = result;
                Dgv_Detalle.RetrieveStructure();
                Dgv_Detalle.AlternatingColors = true;

                Dgv_Detalle.RootTable.Columns[0].Key = "id";
                Dgv_Detalle.RootTable.Columns[0].Visible = false;

                Dgv_Detalle.RootTable.Columns[1].Key = "IdProduc";
                Dgv_Detalle.RootTable.Columns[1].Visible = false;

                Dgv_Detalle.RootTable.Columns[2].Key = "Producto";
                Dgv_Detalle.RootTable.Columns[2].Caption = "PRODUCTO";
                Dgv_Detalle.RootTable.Columns[2].Width = 105;
                Dgv_Detalle.RootTable.Columns[2].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                Dgv_Detalle.RootTable.Columns[2].CellStyle.FontSize = 9;
                Dgv_Detalle.RootTable.Columns[2].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
                Dgv_Detalle.RootTable.Columns[2].Visible = true;

                Dgv_Detalle.RootTable.Columns[3].Key = "Caja";
                Dgv_Detalle.RootTable.Columns[3].Caption = "CAJA";
                Dgv_Detalle.RootTable.Columns[3].FormatString = "0";
                Dgv_Detalle.RootTable.Columns[3].Width = 90;
                Dgv_Detalle.RootTable.Columns[3].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                Dgv_Detalle.RootTable.Columns[3].CellStyle.FontSize = 9;
                Dgv_Detalle.RootTable.Columns[3].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
                Dgv_Detalle.RootTable.Columns[3].Visible = true;

                Dgv_Detalle.RootTable.Columns[4].Key = "Grupo";
                Dgv_Detalle.RootTable.Columns[4].Caption = "GRUPO";
                Dgv_Detalle.RootTable.Columns[4].FormatString = "0";
                Dgv_Detalle.RootTable.Columns[4].Width = 90;
                Dgv_Detalle.RootTable.Columns[4].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                Dgv_Detalle.RootTable.Columns[4].CellStyle.FontSize = 9;
                Dgv_Detalle.RootTable.Columns[4].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
                Dgv_Detalle.RootTable.Columns[4].Visible = true;

                Dgv_Detalle.RootTable.Columns[5].Key = "Maple";
                Dgv_Detalle.RootTable.Columns[5].Caption = "MAPLE";
                Dgv_Detalle.RootTable.Columns[5].FormatString = "0";
                Dgv_Detalle.RootTable.Columns[5].Width = 90;
                Dgv_Detalle.RootTable.Columns[5].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                Dgv_Detalle.RootTable.Columns[5].CellStyle.FontSize = 9;
                Dgv_Detalle.RootTable.Columns[5].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
                Dgv_Detalle.RootTable.Columns[5].Visible = true;

                Dgv_Detalle.RootTable.Columns[6].Key = "Cantidad";
                Dgv_Detalle.RootTable.Columns[6].Caption = "UNIDADES";
                Dgv_Detalle.RootTable.Columns[6].FormatString = "0";
                Dgv_Detalle.RootTable.Columns[6].Width = 90;
                Dgv_Detalle.RootTable.Columns[6].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                Dgv_Detalle.RootTable.Columns[6].CellStyle.FontSize = 9;
                Dgv_Detalle.RootTable.Columns[6].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
                Dgv_Detalle.RootTable.Columns[6].Visible = true;

                Dgv_Detalle.RootTable.Columns[7].Key = "TotalCant";
                Dgv_Detalle.RootTable.Columns[7].Caption = "TOTAL U.";
                Dgv_Detalle.RootTable.Columns[7].FormatString = "0";
                Dgv_Detalle.RootTable.Columns[7].Width = 110;
                Dgv_Detalle.RootTable.Columns[7].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                Dgv_Detalle.RootTable.Columns[7].CellStyle.FontSize = 9;
                Dgv_Detalle.RootTable.Columns[7].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
                Dgv_Detalle.RootTable.Columns[7].Visible = true;

                Dgv_Detalle.RootTable.Columns[8].Key = "PrecioCost";
                Dgv_Detalle.RootTable.Columns[8].Caption = "PRECIO";
                Dgv_Detalle.RootTable.Columns[8].FormatString = "0.00";
                Dgv_Detalle.RootTable.Columns[8].Width = 90;
                Dgv_Detalle.RootTable.Columns[8].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                Dgv_Detalle.RootTable.Columns[8].CellStyle.FontSize = 9;
                Dgv_Detalle.RootTable.Columns[8].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
                Dgv_Detalle.RootTable.Columns[8].Visible = true;

                Dgv_Detalle.RootTable.Columns[9].Key = "Total";
                Dgv_Detalle.RootTable.Columns[9].Caption = "TOTAL BS";
                Dgv_Detalle.RootTable.Columns[9].FormatString = "0.00";
                Dgv_Detalle.RootTable.Columns[9].Width = 110;
                Dgv_Detalle.RootTable.Columns[9].HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                Dgv_Detalle.RootTable.Columns[9].CellStyle.FontSize = 9;
                Dgv_Detalle.RootTable.Columns[9].CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
                Dgv_Detalle.RootTable.Columns[9].Visible = true;

                //Habilitar filtradores              
                //Dgv_Buscardor.FilterRowButtonStyle = FilterRowButtonStyle.ConditionOperatorDropDown;
                Dgv_Detalle.GroupByBoxVisible = false;
                Dgv_Detalle.VisualStyle = VisualStyle.Office2007;
            }
        }

        private void MP_InicioArmarCombo()
        {
            //Carga las librerias al combobox desde una lista
            UTGlobal.MG_ArmarCombo(Cb_Tipo,
                                   new ServiceDesktop.ServiceDesktopClient().LibreriaListarCombo(Convert.ToInt32(ENEstaticosGrupo.PRODUCTO),
                                                                                                 Convert.ToInt32(ENEstaticosOrden.PRODUCTO_GRUPO2)).ToList());
            UTGlobal.MG_ArmarCombo(Cb_Recibido,
                                   new ServiceDesktop.ServiceDesktopClient().LibreriaListarCombo(Convert.ToInt32(ENEstaticosGrupo.COMPRA_INGRESO),
                                                                                                 Convert.ToInt32(ENEstaticosOrden.COMPRA_INGRESO_RECIBIDO)).ToList());

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
        public static DataTable ListaATabla(List<VCompraIngreso_01> lista)
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
            Tb_Cod.ReadOnly = false;
            Tb_NUmGranja.ReadOnly = false;
            Tb_Placa.ReadOnly = false;
            Cb_Tipo.Enabled = true;
            tb_Proveedor.ReadOnly = false;
            Tb_Observacion.ReadOnly = false;
            Tb_Edad.ReadOnly = false;
            Tb_Entregado.ReadOnly = false;           
            Tb_FechaEnt.Value = DateTime.Now;
            Tb_FechaRec.Value = DateTime.Now;
            Cb_Recibido.Enabled = true;  
            Dgv_Detalle.Enabled = true;            
            btn_Recibido.Enabled = true;
        }
        private void MP_InHabilitar()
        {
            Tb_Cod.ReadOnly = true;
            Tb_NUmGranja.ReadOnly = true;
            Tb_Placa.ReadOnly = true;
            Cb_Tipo.Enabled = false;
            tb_Proveedor.ReadOnly = true;           
            Tb_Observacion.ReadOnly = true;
            Tb_Observacion.ReadOnly = true;
            Tb_Entregado.ReadOnly = true;
            Tb_Edad.ReadOnly = true;
            _Limpiar = false;           
            Cb_Recibido.Enabled = false;          
            Dgv_Detalle.Enabled = false;           
            btn_Recibido.Enabled = false;
        }
        private void MP_Limpiar()
        {
            try
            {
                Tb_Cod.Clear();
                Tb_NUmGranja.Clear();
                Tb_Placa.Clear();
                Tb_Observacion.Clear();
                Tb_Observacion.Clear();
                Tb_Entregado.Clear();
                Tb_FechaEnt.Value = DateTime.Now;
                Tb_FechaRec.Value = DateTime.Now;
                if (_Limpiar == false)
                {
                    UTGlobal.MG_SeleccionarCombo(Cb_Tipo);
                    UTGlobal.MG_SeleccionarCombo(Cb_Recibido);
                }
                MP_CargarDetalle(Convert.ToInt32(Cb_Tipo.Value), 2);
                Tb_TotalVendido.Value = 0;             
                Tb_TotalEnviado.Value = 0;                
                Tb_TotalMaples.Value = 0;
                Tb_TotalFisico.Value = 0;
                Tb_TPrecio.Value = 0;
                Tb_TSaldoTo.Value = 0;
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
            Dgv_GBuscador.Row = _Pos;
            _idOriginal = (int)Dgv_GBuscador.GetValue("id");
            if (_idOriginal != 0)            {
                var tabla = new ServiceDesktop.ServiceDesktopClient().CmmpraIngresoListarXId(_idOriginal).ToArray();
                var registro = tabla.First();
                if (tabla.Length > 0)
                {
                    Tb_Cod.Text = tabla.Where(x => !string.IsNullOrEmpty(x.Id.ToString())).Count() > 0 ? tabla.Select(x => x.Id).First().ToString() : "";
                    Tb_NUmGranja.Text = tabla.Where(x => !string.IsNullOrEmpty(x.NumNota)).Count() > 0 ? tabla.Select(x => x.NumNota).First().ToString() : "";
                    Tb_FechaEnt.Value = tabla.Select(x => x.FechaEnt).First();
                    Tb_FechaRec.Value = tabla.Select(x => x.FechaRec).First();
                    Tb_Placa.Text = tabla.Where(x => !string.IsNullOrEmpty(x.Placa)).Count() > 0 ? tabla.Select(x => x.Placa).First().ToString() : "";
                    tb_Proveedor.Text = tabla.Where(x => !string.IsNullOrEmpty(x.Proveedor)).Count() > 0 ? tabla.Select(x => x.Proveedor).First().ToString() : "";
                    _idProveedor = tabla.Select(x => x.IdProvee).First();
                    Tb_Observacion.Text = tabla.Where(x => !string.IsNullOrEmpty(x.Observacion)).Count() > 0 ? tabla.Select(x => x.Observacion).First().ToString() : "";                  
                    Cb_Tipo.Value = tabla.Select(x => x.Tipo).First();
                    Cb_Recibido.Value = tabla.Select(x => x.Recibido).First();
                    Tb_Edad.Text = tabla.Select(x => x.CantidadSemanas).First().ToString();
                    Tb_Entregado.Text = tabla.Where(x => !string.IsNullOrEmpty(x.Entregado)).Count() > 0 ? tabla.Select(x => x.Entregado).First().ToString() : "";
                    Tb_TotalEnviado.Value =  Convert.ToDouble(registro.TotalRecibido);
                    Tb_TotalVendido.Value = Convert.ToDouble(registro.TotalVendido);
                    Tb_TotalFisico.Value = Convert.ToDouble(registro.Total);
                    MP_CargarDetalle(Convert.ToInt32(Tb_Cod.Text), 1);
                    MP_ObtenerCalculo();
                }
                LblPaginacion.Text = Convert.ToString(_Pos + 1) + "/" + Dgv_GBuscador.RowCount.ToString();
            }
        }
        private void MP_ObtenerCalculo()
        {
            //Tb_TotalEnviado.Value = Convert.ToDouble(Dgv_Detalle.GetTotal(Dgv_Detalle.RootTable.Columns[3], AggregateFunction.Sum));
            //Tb_TGrupo.Value = Convert.ToDouble(Dgv_Detalle.GetTotal(Dgv_Detalle.RootTable.Columns[4], AggregateFunction.Sum));
            //Tb_TMaples.Value = Convert.ToDouble(Dgv_Detalle.GetTotal(Dgv_Detalle.RootTable.Columns[5], AggregateFunction.Sum));
            //Tb_TCantidad.Value = Convert.ToDouble(Dgv_Detalle.GetTotal(Dgv_Detalle.RootTable.Columns[6], AggregateFunction.Sum));
            //Tb_TotalFisico.Value = (Tb_TotalEnviado.Value * 360) + (Tb_TGrupo.Value * 300) + (Tb_TMaples.Value * 30) + Tb_TCantidad.Value;
            //Tb_TPrecio.Value = Convert.ToDouble(Dgv_Detalle.GetTotal(Dgv_Detalle.RootTable.Columns[8], AggregateFunction.Sum)) / 10;
            //Tb_TSaldoTo.Value = Tb_TTotal.Value * Tb_TPrecio.Value;
            //Tb_TotalVendido.Value = Tb_TotalEnviado.Value * 12;
            //Tb_MGrupos.Value = Tb_TGrupo.Value * 10;
            //Tb_MMaples.Value = Tb_TMaples.Value;
            //Tb_MCantidad.Value = Convert.ToInt32((Tb_TCantidad.Value / 300) * 11);
            //Tb_MTotal.Value = Tb_TSaldoTo.Value + Tb_MGrupos.Value + Tb_MMaples.Value + Tb_MCantidad.Value;
            Tb_TotalFisico.Value = Convert.ToDouble(Dgv_Detalle.GetTotal(Dgv_Detalle.RootTable.Columns[7], AggregateFunction.Sum));
            Tb_TPrecio.Value = Convert.ToDouble(Dgv_Detalle.GetTotal(Dgv_Detalle.RootTable.Columns[8], AggregateFunction.Sum)) / Dgv_Detalle.RowCount;
            Tb_TSaldoTo.Value = Tb_TotalFisico.Value * Tb_TPrecio.Value;
            Tb_TotalMaples.Value = Tb_TotalFisico.Value / 30;
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

        #region Metodo heredados

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






        #endregion

        private void tb_Proveedor_KeyDown(object sender, KeyEventArgs e)
        {

            if (Tb_FechaEnt.IsInputReadOnly == false)
            {
              
                    var lista = new ServiceDesktop.ServiceDesktopClient().ListarEncabezado();                   
                    List<GLCelda> listEstCeldas = new List<GLCelda>();
                    listEstCeldas.Add(new GLCelda (){campo = "Id", visible = true, titulo = "ID",tamano = 80});
                    listEstCeldas.Add(new GLCelda() { campo = "Descripcion", visible = true, titulo = "DESCRIPCION", tamano = 200 });
                    listEstCeldas.Add(new GLCelda() { campo = "Contacto", visible = true, titulo = "CONTACTO", tamano = 150 });
                    listEstCeldas.Add(new GLCelda() { campo = "Ciudad", visible = false, titulo = "IDCIUDAD", tamano = 80 });
                    listEstCeldas.Add(new GLCelda() { campo = "NombreCiudad", visible = true, titulo = "CIUDAD", tamano = 120 });
                    listEstCeldas.Add(new GLCelda() { campo = "Telefono", visible = true, titulo = "TELEFONO", tamano = 100 });
                    GLEfecto efecto = new GLEfecto();
                    efecto.Tipo = 3;                 
                    //listEstCeldas.Add(New Modelo.Celda("ydrazonsocial", true, "RAZÓN SOCIAL", 180));
                    //listEstCeldas.Add(New Modelo.Celda("yddesc", True, "NOMBRE", 280));
                    //listEstCeldas.Add(New Modelo.Celda("yddctnum", True, "N. Documento".ToUpper, 150));
                    //listEstCeldas.Add(New Modelo.Celda("yddirec", True, "DIRECCIÓN", 220));
                    //listEstCeldas.Add(New Modelo.Celda("ydtelf1", True, "Teléfono".ToUpper, 200));
                    //listEstCeldas.Add(New Modelo.Celda("ydfnac", True, "F.Nacimiento".ToUpper, 150, "MM/dd,YYYY"));
                    //listEstCeldas.Add(New Modelo.Celda("ydnumivend,", False, "ID", 50));
                    //listEstCeldas.Add(New Modelo.Celda("vendedor,", False, "ID", 50));
                    //listEstCeldas.Add(New Modelo.Celda("yddias", False, "CRED", 50));                
            }
        }
    }
}
