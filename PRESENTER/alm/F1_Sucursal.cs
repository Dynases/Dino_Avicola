using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRESENTER.alm
{
    public partial class F1_Sucursal : MODEL.ModeloF1
    {
        public F1_Sucursal()
        {
            InitializeComponent();
        }

        #region Variables de Entorno



        #endregion

        #region Metodos



        #endregion


        #region Eventos

        private void F1_Sucursal_Load(object sender, EventArgs e)
        {
            LblTitulo.Text = "SUCURSALES";
        }

        #endregion
    }
}
