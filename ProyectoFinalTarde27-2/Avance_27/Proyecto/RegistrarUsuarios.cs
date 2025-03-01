using static Proyecto_FINAL.InicioSesion;

namespace Proyecto_FINAL
{
    public partial class RegistrarUsuarios : Form
    {

        string mensajeError;
        private string[,] admin;
        private string[] planes;
        private int contadorSocios;
        private string[,,] socios;
        private List<string> listaSocios;
        private string[] generos;

        public RegistrarUsuarios(string[,] admin, string[] planes, int contadorSocios, string[,,] socios, List<string> listaSocios, string[] generos)
        {
            InitializeComponent();
            // Asignar los datos recibidos a las variables de la clase
            this.admin = admin;
            this.planes = planes;
            this.contadorSocios = contadorSocios;
            this.socios = socios;
            this.listaSocios = listaSocios;
            this.generos = generos;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ELIZABETH PONGALE LOS PLACEHOLDERTEXT
            txtNombre.PlaceholderText = "Ingrese su nombre completo porfavor";
            //logica

            cmbPlan.Items.AddRange(InfoSocios.Planes);
            cmbPlan.SelectedIndex = 0; // Selecciona la primera opción
            cmbGeneros.Items.AddRange(InfoSocios.generos);
            cmbGeneros.SelectedIndex = 0;
            cmbPlan.DropDownStyle = ComboBoxStyle.DropDownList;//Esto hace que el Admin NO escriba o borre texto manualmente
        }

        private void btn_Regristarse_Click(object sender, EventArgs e)
        {
            if (InfoSocios.contadorSocios >= 10000)
            {
                MessageBox.Show("Ah llegado al maximo de usuarios posibles porfavor contactarse con su proovedor de servicios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int indice = InfoSocios.contadorSocios;
            //inicia desde 0
            string id = (indice + 1).ToString(); // ID único
            string nombre = txtNombre.Text;
            string edad = txtEdad.Text;
            string contacto = TxtNumero.Text;
            string codigoAcceso = GenerarCodigoAccesoUnico();
            string peso = txtPeso.Text;
            string altura = txtAltura.Text;
            string plan = cmbPlan.Text;
            int indexPlan = cmbPlan.SelectedIndex;
            string fechaRegistro = DateTime.Now.ToString("dd/MM/yyyy");
            string fechaVencimiento = DateTime.Now.AddYears(1).ToString("dd/MM/yyyy");
            string generos = cmbGeneros.Text;
            //aqui se crea el mensaje
            if (!ValidarDatos(out mensajeError))
            {
                MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // No continúa si hay errores
            }

            //matriz para iterar luego los datos que se recolectan
            string[] ingresarDatos = { id, nombre, edad, contacto, codigoAcceso, peso, altura, fechaRegistro, fechaVencimiento, generos };

            for (int i = 0; i < ingresarDatos.Length; i++)
            {
                InfoSocios.Socios[indexPlan, indice, i] = ingresarDatos[i];
            }



            string socioTexto = $"Su id es {id}, nombre: {nombre},edad: {edad},número de contacto: {contacto},codigo de acceso: {codigoAcceso},su peso: {peso},su altura: {altura},su fecha de registro: {fechaRegistro},tu plan: {plan},Cuando vence tu plan: {fechaVencimiento}, Genero: {generos}";
            InfoSocios.ListaSocios.Add(socioTexto);
            InfoSocios.contadorSocios++;



            MessageBox.Show($"{socioTexto}");

            CambiardePagina();
        }

        //Codigo de acceso
        public static string GenerarCodigoAccesoUnico()
        {
            string nuevoCodigo;
            do
            {
                nuevoCodigo = Guid.NewGuid().ToString().Substring(0, 8);
            } while (InfoSocios.ListaSocios.Exists(socio => socio.Contains("," + nuevoCodigo + ",")));

            return nuevoCodigo;
        }


        //metodo de verificacion
        private bool ValidarDatos(out string mensajeError)
        {
            mensajeError = "";

            // Verificar que ningún campo esté vacío
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtEdad.Text) ||
                string.IsNullOrWhiteSpace(TxtNumero.Text) ||
                string.IsNullOrWhiteSpace(txtPeso.Text) ||
                string.IsNullOrWhiteSpace(txtAltura.Text) ||
                string.IsNullOrWhiteSpace(cmbPlan.Text))
            {
                mensajeError = "Todos los campos son obligatorios.";
                return false;
            }

            // Verificar que contacto sea un número entero válido
            if (!int.TryParse(TxtNumero.Text, out _))//el _ es que no se ocupara
            {
                mensajeError = "El número de contacto debe ser un número entero.";
                return false;
            }

            // Verificar que peso y altura sean números decimales válidos
            if (!float.TryParse(txtPeso.Text, out _) || !float.TryParse(txtAltura.Text, out _))
            {
                mensajeError = "El peso y la altura deben ser valores numéricos.";
                return false;
            }

            return true; // Si todo está bien, retorna true
        }
        private void CambiardePagina()
        {
            InicioSesion registrarUsuarios = new InicioSesion();
            registrarUsuarios.Show();
            this.Close();
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
           
        }
    }
}
