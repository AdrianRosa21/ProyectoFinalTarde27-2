namespace Proyecto_FINAL
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += (sender, e) =>
            {
                MessageBox.Show($"ERROR DE APLICACION: {e.Exception.Message}");
            };
            Application.Run(new InicioSesion());
        }
    }
}