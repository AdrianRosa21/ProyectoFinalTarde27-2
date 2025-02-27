using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_FINAL
{
    public partial class Form3 : Form
    {
        //
        
        private string[,] admin;
        private string[] planes;
        private int contadorSocios;
        private string[,,] socios;
        private List<string> listaSocios;
        private string[] generos;
        //

        public Form3(string[,] admin, string[] planes, int contadorSocios, string[,,] socios, List<string> listaSocios, string[] generos)
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.admin = admin;
            this.planes = planes;
            this.contadorSocios = contadorSocios;
            this.socios = socios;
            this.listaSocios = listaSocios;
            this.generos = generos;
        }


    }
}
