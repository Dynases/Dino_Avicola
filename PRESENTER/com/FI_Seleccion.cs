﻿using System;
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
    public partial class FI_Seleccion : MODEL.ModeloF1
    {
        public FI_Seleccion()
        {
            InitializeComponent();
        }

        private void FI_Seleccion_Load(object sender, EventArgs e)
        {
            this.Name = "SELECCION";
        }
    }
}
