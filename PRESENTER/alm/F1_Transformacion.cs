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
    public partial class F1_Transformacion : MODEL.ModeloF1
    {
        public F1_Transformacion()
        {
            InitializeComponent();
        }

        private void F1_Transformacion_Load(object sender, EventArgs e)
        {
            this.Name = "TRANSFORMACION";
        }
    }
}