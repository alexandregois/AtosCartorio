using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;

namespace AtosCartorio.Data
{
    public static class MigrationHelper
    {
        public static void UpdateDatabase()
        {
            try
            {
                using (var context = new CartorioContext())
                {
                    context.Database.Migrate();
                    
                    MessageBox.Show("Banco de dados atualizado com sucesso!", 
                        "Migration Completo", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar o banco de dados: {ex.Message}\n\n{ex.InnerException?.Message}", 
                    "Erro de Migration", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }
        
        public static void RecreateDatabase()
        {
            try
            {
                using (var context = new CartorioContext())
                {
                    bool deleted = context.Database.EnsureDeleted();
                    
                    bool created = context.Database.EnsureCreated();
                    
                    if (deleted && created)
                    {
                        MessageBox.Show("Banco de dados recriado com sucesso!", 
                            "Recriação Concluída", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
                    }
                    else if (created)
                    {
                        MessageBox.Show("Banco de dados criado com sucesso!", 
                            "Criação Concluída", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível recriar completamente o banco de dados.", 
                            "Aviso", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao recriar o banco de dados: {ex.Message}\n\n{ex.InnerException?.Message}", 
                    "Erro de Recriação", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }
    }
}
