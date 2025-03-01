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
        public static string[,] NombresEjerciciosVisibles = new string[5, 7];//5 dias y 7 ejercicios
        public static string[] TodosLosEjercicios =
        {
            // Pecho
            "Press banca", "Press banca inclinado", "Press banca declinado", "Aperturas con mancuernas",
            "Peck deck", "Fondos en paralelas", "Press con barra",

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

        public static string[] GruposMusculares = { "Pecho", "Espalda", "Piernas", "Hombros", "Bíceps", "Tríceps", "Abdomen", "Cardio" };


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
            

            // Tamaño predeterminado
            this.Size = new Size(1940, 1058);
            cmbRutina.Items.AddRange(Rutinas); // Agregar rutinas al ComboBox
            RecomendarRutina(IMC); // Recomendamos la rutina predeterminada
            LlenarNombresEjerciciosVisibles();
            MostrarEjercicios(cmbRutina.SelectedItem?.ToString() ?? "");
        }
        private void LlenarNombresEjerciciosVisibles()
        {
            Random random = new Random();
            for (int dia = 0; dia < 5; dia++)
            {
                string grupoMuscular = GruposMusculares[dia % GruposMusculares.Length];
                List<string> ejerciciosDelGrupo = TodosLosEjercicios.Where(e => e.Contains(grupoMuscular)).ToList();
                for (int ejercicio = 0; ejercicio < 7; ejercicio++)
                {
                    if (ejerciciosDelGrupo.Count > 0)
                    {
                        int index = random.Next(ejerciciosDelGrupo.Count);
                        NombresEjerciciosVisibles[dia, ejercicio] = ejerciciosDelGrupo[index];
                        ejerciciosDelGrupo.RemoveAt(index);
                    }
                }
            }
        }


        private void LlenarRutina(string rutina)
        {
            Random random = new Random();
            int diasEntrenamiento = 0;
            switch (rutina)
            {
                case "Arnold Split":
                    diasEntrenamiento = 5;
                    break;
                case "Upper Lower":
                    diasEntrenamiento = 4;
                    break;
                case "Push Pull Legs":
                    diasEntrenamiento = 5;
                    break;
                case "Heavy Duty":
                    diasEntrenamiento = 4;
                    break;
                case "Full Body":
                    diasEntrenamiento = 3;
                    break;

            }
            for (int dia = 0; dia < diasEntrenamiento; dia++)
            {
                List<string> ejercicios = TodosLosEjercicios.OrderBy(e => random.Next()).Take(7).ToList();
                for (int ejercicio = 0; ejercicio < 7; ejercicio++)
                {
                    NombresEjerciciosVisibles[dia, ejercicio] = ejercicios[ejercicio];
                }
            }

            // Si hay menos de 5 días, limpiar los días adicionales
            for (int dia = diasEntrenamiento; dia < 5; dia++)
            {
                for (int ejercicio = 0; ejercicio < 7; ejercicio++)
                {
                    NombresEjerciciosVisibles[dia, ejercicio] = "";
                }
            }


        }

        private void RecomendarRutina(double imc)
        {
            if (imc < 18.5)
                cmbRutina.SelectedItem = Rutinas[2];
            else if (imc >= 18.5 && imc <= 24.9)
                cmbRutina.SelectedItem = Rutinas[0];
            else if (imc >= 25 && imc <= 29.9)
                cmbRutina.SelectedItem = Rutinas[1];
            else
                cmbRutina.SelectedItem = Rutinas[4];
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cmbRutina.SelectedIndexChanged += (s, ev) =>
            {
                string rutinaSeleccionada = cmbRutina.SelectedItem.ToString();
                MessageBox.Show("Cambio de rutina: " + rutinaSeleccionada); // Depuración
                LlenarRutina(rutinaSeleccionada);
                MostrarEjercicios(rutinaSeleccionada);
            };
            MessageBox.Show($"{IMC}", "mensaje!");
        }

        private void MostrarEjercicios(string rutina)
        {
            List<Label> labels = new List<Label> { lblDia1, lblDia2, lblDia3, lblDia4, lblDia5 };
            int dias = 5;

            foreach (var lbl in labels)
            {
                lbl.Text = "";
                lbl.Visible = false;
            }

            for (int dia = 0; dia < dias; dia++)
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
        }

        private void btnElegir_Click(object sender, EventArgs e)
        {
            if (cmbRutina.SelectedItem != null)
            {
                string rutinaSeleccionada = cmbRutina.SelectedItem.ToString();
                MessageBox.Show("Rutina seleccionada: " + rutinaSeleccionada);
                LlenarRutina(rutinaSeleccionada);
                MostrarEjercicios(rutinaSeleccionada);
            }
        }

        private void cmbRutina_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void groupBox3_Enter(object sender, EventArgs e) { }

        private void pictureBox26_Click(object sender, EventArgs e) { }


    }
}

