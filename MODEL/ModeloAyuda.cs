using Janus.Windows.GridEX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MODEL
{
    public partial class ModeloAyuda : Form
    {
        #region Varibles
        DataTable dtBuscador = new DataTable();
        public string nombreVista;
        public int posX,posY;
        public bool seleccionado;
        public int Columna = -1;
        //GridEX filaSelect = new GridEX();
        //List(Of Celda)
        #endregion
        public ModeloAyuda()
        {
            InitializeComponent();
        }
    }
}
