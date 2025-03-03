using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Proyecto_FINAL.InicioSesion;



namespace Proyecto_FINAL
{
    public partial class Form3 : Form
    {
        private string[,] admin;
        private string[] planes;
        private int contadorSocios;
        private string[,,] socios;
        private List<string> listaSocios;
        private string[] generos;
        private double IMC;

        string rutinaElegida;
        public string[] Rutinas = { "Arnold Split", "Upper Lower", "Push Pull Legs", "Heavy Duty", "Full Body" };
        public static string[,] NombresEjerciciosVisibles = new string[5, 7];
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
        public static string[,,] InfoEjercicios = new string[5, 7, 3]; // 5 días, 7 ejercicios, 3 datos (Tiempo, Repeticiones, Series)

        List<PictureBox[]> pictureBoxesPorDia;

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

            pictureBoxesPorDia = new List<PictureBox[]>
            {
                new PictureBox[] { picbox1Dia1, picbox2Dia1, picbox3Dia1, picbox4Dia1, picbox5Dia1, picbox6Dia1, picbox7Dia1 },
                new PictureBox[] { picbox1Dia2, picbox2Dia2, picbox3Dia2, picbox4Dia2, picbox5Dia2, picbox6Dia2, picbox7Dia2 },
                new PictureBox[] { picbox1Dia3, picbox2Dia3, picbox3Dia3, picbox4Dia3, picbox5Dia3, picbox6Dia3, picbox7Dia3 },
                new PictureBox[] { picbox1Dia4, picbox2Dia4, picbox3Dia4, picbox4Dia4, picbox5Dia4, picbox6Dia4, picbox7Dia4 },
                new PictureBox[] { picbox1Dia5, picbox2Dia5, picbox3Dia5, picbox4Dia5, picbox5Dia5, picbox6Dia5, picbox7Dia5 }
            };

            // Tamaño predeterminado
            this.Size = new Size(1940, 1058);
            cmbRutina.Items.AddRange(Rutinas); // Agregar rutinas al ComboBox
            RecomendarRutina(IMC); // Recomendamos la rutina predeterminada
            LlenarNombresEjerciciosVisibles();
            MostrarEjercicios(cmbRutina.SelectedItem?.ToString() ?? "");
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

        private void LlenarNombresEjerciciosVisibles()
        {
            Random random = new Random();
            for (int dia = 0; dia < 5; dia++)
            {
                string grupoMuscular = GruposMusculares[dia % GruposMusculares.Length];//El % es para que se divida el dia que sera de 5 a 0 entre 8 y se reparta en formas iguales
                List<string> ejerciciosDelGrupo = TodosLosEjercicios.Where(e => e.Contains(grupoMuscular)).ToList();//metodo que utiliza linq para hacer filtrado de datos  si el grupo es "Pecho", se seleccionarán solo los ejercicios con la palabra "Pecho" en su nombre.
                for (int ejercicio = 0; ejercicio < 7; ejercicio++)
                {
                    if (ejerciciosDelGrupo.Count > 0)
                    {
                        int index = random.Next(ejerciciosDelGrupo.Count);// saca el num de la fila al azar del que se ingresara
                        NombresEjerciciosVisibles[dia, ejercicio] = ejerciciosDelGrupo[index];
                        ejerciciosDelGrupo.RemoveAt(index);
                    }
                }
            }
        }
        //metodo para rellenar la matriz con los ejercicios que esten
        private void LlenarInfoEjercicios()
        {
            Random random = new Random();
            for (int dia = 0; dia < 5; dia++)
            {
                for (int ejercicio = 0; ejercicio < 7; ejercicio++)
                {
                    if (!string.IsNullOrEmpty(NombresEjerciciosVisibles[dia, ejercicio]))
                    {
                        InfoEjercicios[dia, ejercicio, 0] = random.Next(30, 90).ToString() + " seg"; // Tiempo
                        InfoEjercicios[dia, ejercicio, 1] = random.Next(8, 15).ToString() + " reps"; // Repeticiones
                        InfoEjercicios[dia, ejercicio, 2] = random.Next(3, 5).ToString() + " series"; // Series
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
                List<string> ejercicios = TodosLosEjercicios.OrderBy(e => random.Next()).Take(7).ToList();// Reordena aleatoriamente la lista de ejercicios.
                //Toma los primeros 7 ejercicios después del ordenamiento. asi se seleccionan 7 ejercicios aleatorios para el día actual.
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
        //metodo para mostrar los datos al datagridview

        private void MostrarDataGridView()
        {
            dataGridView1.Rows.Clear(); // Limpiar antes de llenar

            for (int dia = 0; dia < 5; dia++)
            {
                for (int ejercicio = 0; ejercicio < 7; ejercicio++)
                {
                    if (!string.IsNullOrEmpty(NombresEjerciciosVisibles[dia, ejercicio]))
                    {
                        string nombre = NombresEjerciciosVisibles[dia, ejercicio];
                        string tiempo = InfoEjercicios[dia, ejercicio, 0];
                        string repeticiones = InfoEjercicios[dia, ejercicio, 1];
                        string series = InfoEjercicios[dia, ejercicio, 2];

                        dataGridView1.Rows.Add($"Día {dia + 1}", nombre, tiempo, repeticiones, series);
                    }
                }
            }
        }
        private void ActualizarImagenesEjercicios()
        {
            string rutaImagenes = @"C:\Users\adrian.rosa\source\repos\ProyectoFinalTarde27-2\ProyectoFinalTarde27-2\Avance_27\Proyecto\IMG\";


            for (int dia = 0; dia < 5; dia++)
            {
                for (int ejercicio = 0; ejercicio < 7; ejercicio++)
                {
                    string nombreEjercicio = NombresEjerciciosVisibles[dia, ejercicio];

                    if (!string.IsNullOrEmpty(nombreEjercicio))
                    {
                        string nombreArchivo = nombreEjercicio.Replace(" ", "_").ToLower() + ".png";
                        string rutaCompleta = Path.Combine(rutaImagenes, nombreArchivo);

                        if (File.Exists(rutaCompleta))
                        {
                            pictureBoxesPorDia[dia][ejercicio].Image = Image.FromFile(rutaCompleta);
                        }
                        else
                        {

                            pictureBoxesPorDia[dia][ejercicio].Image = null;
                        }
                    }
                    else
                    {
                        pictureBoxesPorDia[dia][ejercicio].Image = null;
                    }
                }
            }

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

                int contadorEjercicios = 0; // Contador para saber cuántos ejercicios válidos hay en el día

                for (int i = 0; i < NombresEjerciciosVisibles.GetLength(1); i++)
                {
                    if (!string.IsNullOrEmpty(NombresEjerciciosVisibles[dia, i]))
                    {
                        contadorEjercicios++; // Aumenta el contador solo si hay un ejercicio válido
                    }
                }

                int ejerciciosAgregados = 0; // Cuenta cuántos ejercicios válidos se han agregado

                for (int i = 0; i < NombresEjerciciosVisibles.GetLength(1); i++)
                {
                    if (!string.IsNullOrEmpty(NombresEjerciciosVisibles[dia, i]))
                    {
                        ejerciciosAgregados++; // Se ha agregado un ejercicio más

                        if (ejerciciosAgregados < contadorEjercicios)
                        {
                            labels[dia].Text += NombresEjerciciosVisibles[dia, i] + ", ";
                        }
                        else
                        {
                            labels[dia].Text += NombresEjerciciosVisibles[dia, i];
                        }
                    }
                }
            }
            ActualizarImagenesEjercicios();

        }



        private void btnElegir_Click(object sender, EventArgs e)
        {
            if (cmbRutina.SelectedItem != null)
            {
                string rutinaSeleccionada = cmbRutina.SelectedItem.ToString();
                MessageBox.Show("Rutina seleccionada: " + rutinaSeleccionada);
                LlenarRutina(rutinaSeleccionada);
                MostrarEjercicios(rutinaSeleccionada);
                LlenarInfoEjercicios();
                MostrarDataGridView(); // Mostramos los datos
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cmbRutina.SelectedIndexChanged += (s, ev) =>
            {
                string rutinaSeleccionada = cmbRutina.SelectedItem.ToString();
                LlenarRutina(rutinaSeleccionada);
                MostrarEjercicios(rutinaSeleccionada);
            };
            //HASTA AQUI
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Día";
            dataGridView1.Columns[1].Name = "Ejercicio";
            dataGridView1.Columns[2].Name = "Tiempo de descanzo";
            dataGridView1.Columns[3].Name = "Repeticiones";
            dataGridView1.Columns[4].Name = "Series";

            //para agregar estilo al datagridview
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 9);
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            //esto para las imagenes
            for (int i = 1; i <= 7; i++) // Bucle para i con límite 7
            {
                for (int j = 1; j <= 5; j++) // Bucle para j con límite 5
                {
                    // Nombre del PictureBox dinámico
                    string nombrePicBox = $"picbox{i}dia{j}";

                    // Busca el control por su nombre
                    Control[] controles = this.Controls.Find(nombrePicBox, true);

                    if (controles.Length > 0 && controles[0] is PictureBox logo)
                    {
                        // Aplica el SizeMode si se encuentra el PictureBox
                        logo.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e) { }
        private void pictureBox26_Click(object sender, EventArgs e) { }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}