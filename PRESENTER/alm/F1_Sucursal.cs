using DevComponents.DotNetBar;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using UTILITY.Global;

namespace PRESENTER.alm
{
    public partial class F1_Sucursal : MODEL.ModeloF1
    {
        public F1_Sucursal()
        {
            InitializeComponent();
            this.MP_IniciarMapa();
            this.MP_InHabilitar();
        }

        //==================================
        #region Variables de entorno

        private GMapOverlay _overlay;
        private Double _latitud = 0;
        private Double _longitud = 0;
        private string _imagen = "Default.jpg";
        private bool _modificarImagen = false;

        #endregion

        //==================================
        #region Metodos

        private void MP_IniciarMapa()
        {
            _overlay = new GMapOverlay("points");
            Gmc_Sucursal.Overlays.Add(_overlay);
            MP_Map();
        }

        private void MP_Map()
        {
            Gmc_Sucursal.DragButton = MouseButtons.Left;
            Gmc_Sucursal.CanDragMap = true;
            Gmc_Sucursal.MapProvider = GMapProviders.GoogleMap;
            if (_latitud != 0 && _longitud != 0)
            {
                Gmc_Sucursal.Position = new PointLatLng(_latitud, _longitud);
            }
            else
            {
                _overlay.Markers.Clear();
                Gmc_Sucursal.Position = new PointLatLng(-17.3931784, -66.1738852);
            }
            Gmc_Sucursal.MinZoom = 0;
            Gmc_Sucursal.MaxZoom = 24;
            Gmc_Sucursal.Zoom = 15.5;
            Gmc_Sucursal.AutoScroll = true;
            GMapProvider.Language = LanguageType.Spanish;
        }

        private void MP_Reiniciar()
        {
            this.Tb_Descrip.Text = "";
            this.Tb_Direcc.Text = "";
            this.Tb_Telef.Text = "";            

            this.MP_InHabilitar();
        }

        private void MP_InHabilitar()
        {
            this.Tb_Descrip.ReadOnly = true;
            this.Tb_Direcc.ReadOnly = true;
            this.Tb_Telef.ReadOnly = true;
            this.BtAdicionar.Enabled = false;

            this.lblId.Visible = false;
        }

        private void MP_Habilitar()
        {
            this.Tb_Descrip.ReadOnly = false;
            this.Tb_Direcc.ReadOnly = false;
            this.Tb_Telef.ReadOnly = false;

            this.BtAdicionar.Enabled = true;
        }

        private bool MP_AccionResult()
        {
            return lblId.Text == string.Empty ? true : false;
        }

        private void MP_MostrarMensajeError(string mensaje)
        {
            ToastNotification.Show(this, mensaje.ToUpper(), PRESENTER.Properties.Resources.WARNING, (int)GLMensajeTamano.Mediano, eToastGlowColor.Green, eToastPosition.TopCenter);
        }

        private string MP_CopiarImagenRutaDefinida()
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "Ficheros JPG o JPEG o PNG|*.jpg;*.jpeg;*.png" +
                              "|Ficheros GIF|*.gif" +
                              "|Ficheros BMP|*.bmp" +
                              "|Ficheros PNG|*.png" +
                              "|Ficheros TIFF|*.tif";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    string ruta = file.FileName;
                    if (file.CheckFileExists)
                    {
                        Bitmap img = new Bitmap(new Bitmap(ruta));
                        Bitmap imgM = new Bitmap(new Bitmap(ruta));
                        MemoryStream Bin = new MemoryStream();
                        imgM.Save(Bin, System.Drawing.Imaging.ImageFormat.Jpeg);

                        if (MP_AccionResult())
                        {
                            int mayor;
                            mayor = 5;
                            _imagen = @"\Imagen_" + Convert.ToString(mayor + 1).Trim() + ".jpg";
                            Pc_Img.SizeMode = PictureBoxSizeMode.StretchImage;
                            Pc_Img.Image = Image.FromStream(Bin);

                            img.Save(UTGlobal.RutaTemporal + _imagen, System.Drawing.Imaging.ImageFormat.Jpeg);
                            img.Dispose();
                        }
                        else
                        {
                            _imagen = @"\Imagen_" + lblId.Text.Trim() + ".jpg";
                            Pc_Img.Image = Image.FromStream(Bin);
                            img.Save(UTGlobal.RutaTemporal + _imagen, System.Drawing.Imaging.ImageFormat.Jpeg);
                            img.Dispose();
                            _modificarImagen = true;
                        }
                    }
                    return _imagen;
                }
                return "default.jpg";
            }
            catch (Exception ex)
            {
                MP_MostrarMensajeError(ex.Message);
                return "";
            }
        }

        //===========
        #region Metodos Heredados

        public override void MH_Nuevo()
        {
            base.MH_Nuevo();
            this.MP_Habilitar();
        }

        public override void MH_Salir()
        {
            base.MH_Salir();
            this.MP_Reiniciar();
        }

        #endregion
        //===========


        #endregion

        //==================================
        #region Eventos

        private void F1_Sucursal_Load(object sender, EventArgs e)
        {
            LblTitulo.Text = "SUCURSALES";
        }

        private void BtAdicionar_Click(object sender, EventArgs e)
        {
            this.MP_CopiarImagenRutaDefinida();
            BtnGrabar.Focus();
        }

        #endregion

    }
}
