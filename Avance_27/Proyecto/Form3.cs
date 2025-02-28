using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Proyecto_FINAL.InicioSesion;

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
        private double IMC;
        //
        //
        //**Datos creados para la ventana**
        string rutinaElegida;
        public string[] Rutinas = { "Arnold Split", "Upper Lower", "Push Pull Legs", "Heavy Duty", "Full Body" };
        public static string[,] NombresEjerciciosVisibles = new string[5, 7];
        public static string[] TodosLosEjercicios =
        {
            // Pecho
            "Press banca", "Press banca inclinado", "Press banca declinado", "Aperturas con mancuernas",
            "Peck deck", "Fondos en paralelas", "Press con barra", "Flexiones",

            // Espalda
            "Dominadas", "Jalones al pecho", "Remo con barra", "Peso muerto",
            "Remo en polea baja", "Pullover", "Hiperextensiones", "Face Pull",

            // Piernas
            "Sentadillas", "Sentadillas búlgaras", "Prensa de piernas", "Peso muerto rumano",
            "Hip Thrust", "Zancadas", "Extensiones de pierna", "Curl femoral", "Elevación de talones", 

            // Hombros
            "Press militar", "Elevaciones laterales", "Elevaciones frontales", "Press Arnold",
            "Face Pull", "Encogimientos de hombros", "Pájaros",

            // Bíceps
            "Curl biceps", "Curl martillo", "Curl concentrado", "Curl con barra",
            "Curl con polea baja", "Predicador", "Curl 21", 

            // Tríceps
            "Extensiones triceps", "Fondos en paralelas", "Press francés", "Patada de tríceps",
            "Jalón de tríceps", "Extensiones con cuerda", "Press cerrado",

            // Abdomen
            "Abdominales", "Crunches", "Planchas", "Elevación de piernas",
            "Bicicletas", "Russian Twists", "Dragon Flag",

            // Cardio
            "Correr en cinta", "Elíptica", "Salto de cuerda", "Remo en máquina",
            "Burpees", "Mountain Climbers", "Escalador",

            // Extras
            "Hip Thrust con barra", "Farmer's Walk", "Plancha lateral", "Calentamiento de hombros",
            "Battle Ropes", "Escaleras", "Ab Rollout"
        };


        //
        //
        public Form3(string[,] admin, string[] planes, int contadorSocios, string[,,] socios, List<string> listaSocios, string[] generos, double IMC)
        {
            InitializeComponent();
            this.admin = admin;
            this.planes = planes;
            this.contadorSocios = contadorSocios;
            this.socios = socios;
            this.listaSocios = listaSocios;
            this.generos = generos;
            this.IMC = IMC;

            cmbRutina.Items.AddRange(Rutinas); // Agregar rutinas al ComboBox
            RecomendarRutina(IMC); // Recomendamos la rutina predeterminada
            LlenarNombresEjerciciosVisibles();
            MostrarEjercicios(cmbRutina.SelectedItem.ToString());
        }

        // Método para llenar automáticamente NombresEjerciciosVisibles
        private void LlenarNombresEjerciciosVisibles()
        {
            int index = 0;
            for (int dia = 0; dia < 5; dia++) // 5 días
            {
                for (int ejercicio = 0; ejercicio < 7; ejercicio++) // 7 ejercicios por día
                {
                    if (index < TodosLosEjercicios.Length)
                    {
                        NombresEjerciciosVisibles[dia, ejercicio] = TodosLosEjercicios[index];
                        index++;
                    }
                    else
                    {
                        NombresEjerciciosVisibles[dia, ejercicio] = "";
                    }
                }
            }
        }

        // Recomendar rutina basado en IMC
        private void RecomendarRutina(double imc)
        {
            if (imc < 18.5)
                cmbRutina.SelectedItem = Rutinas[2]; // Push Pull Legs
            else if (imc >= 18.5 && imc <= 24.9)
                cmbRutina.SelectedItem = Rutinas[0]; // Arnold Split
            else if (imc >= 25 && imc <= 29.9)
                cmbRutina.SelectedItem = Rutinas[1]; // Upper Lower
            else
                cmbRutina.SelectedItem = Rutinas[4]; // Full Body
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cmbRutina.SelectedIndexChanged += (s, ev) => MostrarEjercicios(cmbRutina.SelectedItem.ToString());
        }

        private void MostrarEjercicios(string rutina)
        {
            List<Label> labels = new List<Label> { lblDia1, lblDia2, lblDia3, lblDia4, lblDia5 };
            int dias = 5;

            for (int dia = 0; dia < 5; dia++)
            {
                if (dia < dias)
                {
                    labels[dia].Visible = true;
                    labels[dia].Text = $"Día {dia + 1}: ";
                    for (int i = 0; i < NombresEjerciciosVisibles.GetLength(1); i++)
                    {
                        if (!string.IsNullOrEmpty(NombresEjerciciosVisibles[dia, i]))
                        {
                            labels[dia].Text += NombresEjerciciosVisibles[dia, i] + (i < NombresEjerciciosVisibles.GetLength(1) - 1 ? ", " : "");
                        }
                    }
                }
                else
                {
                    labels[dia].Visible = false;
                    labels[dia].Text = null;
                }
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e) { }

        private void pictureBox26_Click(object sender, EventArgs e) { }

        private void btnElegir_Click(object sender, EventArgs e) {
            if (cmbRutina.SelectedItem != null)
            {
                MostrarEjercicios(cmbRutina.SelectedItem.ToString());
            }
        }
    }

}

