using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Proyecto_FINAL
{

    public partial class InicioSesion : Form
    {
        bool inicioAdmin = false;
        public static class Admins
        {
            public static string[,] Admin = new string[2, 2];//2 administradores y 2 dimensión usu                                          
            //usuario y contraseña
            public static string[] usuario = { "adrian", "cesar" };
            public static string[] contraseña = { "tingolingo123", "happylife132" };
            
        }
        
        public static class InfoSocios
        {
            public static int contadorSocios = 0; // Lleva la cuenta de los socios registrados


            public static string[,,] Socios = new string[3, 10000, 10]; // 3 categorias , 10000 regristos , 9 Datos 


            public static string[] Planes =
            {
               "Normal", "Yellow" , "Black"
            };
            public static string[] generos =
            {
                "Hombre","Mujer","Otro"
            };
            public static List<string> ListaSocios = new List<string>(); // Lista en texto plano
        }
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void btnVerificación_Click(object sender, EventArgs e)
        {
            string contacto = txtContacto.Text; // Aquí se espera el nombre de usuario o contacto
            string codigoAcceso = TxtContraseña.Text; // Aquí se espera la contraseña o código de acceso

            // Verificar que los campos no estén vacíos
            if (string.IsNullOrEmpty(contacto) || string.IsNullOrEmpty(codigoAcceso))
            {
                MessageBox.Show("Completa todos los campos que se solicitan", "Error");
                return;
            }

            // Verificar si es un administrador
            for (int indexAdmin = 0; indexAdmin < Admins.Admin.GetLength(0); indexAdmin++)
            {
                if (Admins.Admin[indexAdmin, 0] == contacto && Admins.Admin[indexAdmin, 1] == codigoAcceso)
                {
                    inicioAdmin = true; // Es un administrador
                    break;
                }
            }

            if (inicioAdmin)
            {
                CambiarHaciaAdmin(); // Cambiar a la página de administrador
                return; // Salir del método para evitar verificar si es un socio
            }

            // Si no es un administrador, verificar si es un socio
            bool socioEncontrado = false;
            for (int plan = 0; plan < InfoSocios.Socios.GetLength(0); plan++) // Recorre las categorías (planes)
            {
                for (int i = 0; i < InfoSocios.contadorSocios; i++) // Recorre los registros
                {
                    // Comparar el contacto y el código de acceso
                    if (InfoSocios.Socios[plan, i, 3] == contacto && // Contacto
                        InfoSocios.Socios[plan, i, 4] == codigoAcceso) // Código de acceso
                    {
                        socioEncontrado = true;
                        string nombre = InfoSocios.Socios[plan, i, 1]; // Obtener el nombre del usuario
                        MessageBox.Show($"Bienvenido, {nombre}", "Inicio de sesión exitoso");
                        CambiarPaginaUsuario(); // Cambiar a la página de usuario
                        return; // Salir del método
                    }
                }
            }

            // Si no se encontró al usuario
            if (!socioEncontrado)
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error");
            }
        }
        private void CambiarPaginaUsuario()
        {
            Form3 form3 = new Form3(Admins.Admin, InfoSocios.Planes, InfoSocios.contadorSocios, InfoSocios.Socios, InfoSocios.ListaSocios, InfoSocios.generos);
            form3.Show();
            this.Hide();
        }
        private void CambiarHaciaAdmin()
        {
            //añadir todo esto cuando creemos otro.
            RegistrarUsuarios form1 = new RegistrarUsuarios(Admins.Admin,InfoSocios.Planes,InfoSocios.contadorSocios, InfoSocios.Socios, InfoSocios.ListaSocios, InfoSocios.generos);
            form1.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        

        private void InicioSesion_Load_1(object sender, EventArgs e)
        {
            // Llenar la matriz Admin con los datos de los arreglos usuario y contraseña
            for (int i = 0; i < Admins.usuario.Length; i++)
            {
                Admins.Admin[i, 0] = Admins.usuario[i]; // Asignar el usuario
                Admins.Admin[i, 1] = Admins.contraseña[i]; // Asignar la contraseña
            }
        }
    }
}

