using System;
using System.Windows.Forms;
using AtosCartorio.Data;
using AtosCartorio.Views;

namespace AtosCartorio
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Try to ensure the database exists on startup
            try
            {
                using (var context = new CartorioContext())
                {
                    // This will ensure the database is created if it doesn't exist
                    if (!context.Database.CanConnect())
                    {
                        context.Database.EnsureCreated();
                        MessageBox.Show("Banco de dados criado com sucesso!", 
                            "Inicialização", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inicializar o banco de dados: {ex.Message}", 
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Application.Run(new MainForm());
        }
    }
}