using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRESENTER.com
{
    public partial class F1_Compra : MODEL.ModeloF1
    {
        public F1_Compra()
        {
            InitializeComponent();
        }

        private void F1_Compra_Load(object sender, EventArgs e)
        {
            this.Name = "COMPRA";
        }
    }
}
