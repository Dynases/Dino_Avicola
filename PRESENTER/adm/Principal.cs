using PRESENTER.com;
using PRESENTER.reg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRESENTER.adm
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Metro_Clientes_Click(object sender, EventArgs e)
        {
            F1_Clientes frm = new F1_Clientes();
            frm.Show();
        }

        private void Metro_Proveedor_Click(object sender, EventArgs e)
        {
            F1_Proveedor frm = new F1_Proveedor();
            frm.Show();
        }

        private void metroTileItem6_Click(object sender, EventArgs e)
        {
            F1_Productos frm = new F1_Productos();
            frm.Show();
        }

        private void Metro_Precio_Click(object sender, EventArgs e)
        {
            f1_Precio frm = new f1_Precio();
            frm.Show();
        }

        private void Metro_CompraIngreso_Click(object sender, EventArgs e)
        {
            F1_CompraIngreso frm = new F1_CompraIngreso();
            frm.Show();
        }
    }
}
