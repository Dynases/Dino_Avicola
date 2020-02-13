using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTILITY.Global
{
    public class GLCelda
    {
        public static string campo;
        public static string titulo;
        public static int tamano;
        public static bool visible;
        public static string formato = string.Empty;
        public static void Celda(string Campo, bool Visible, string Titulo, int Tamano, string Formato)
        {
            campo = Campo;
            visible = Visible;
            titulo = Titulo;
            tamano = Tamano;
            formato = Formato;
        }
    }
}
