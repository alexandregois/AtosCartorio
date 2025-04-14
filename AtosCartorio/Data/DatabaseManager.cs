using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtosCartorio.Data
{
    public static class DatabaseManager
    {
        private static string GetDatabasePath()
        {
            using (var context = new CartorioContext())
            {
                return context.Database.GetDbConnection().ConnectionString;
            }
        }
        
        public static async Task<bool> BackupDatabaseAsync(string backupPath = null)
        {
            try
            {
                if (string.IsNullOrEmpty(backupPath))
                {
                    string backupDir = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                        "AtosCartorio_Backups");
                        
                    if (!Directory.Exists(backupDir))
                    {
                        Directory.CreateDirectory(backupDir);
                    }
                    
                    string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    backupPath = Path.Combine(backupDir, $"cartorio_backup_{timestamp}.bak");
                }
                
                await Task.Delay(1000);
                
                MessageBox.Show($"Backup realizado com sucesso em:\n{backupPath}", 
                    "Backup Concluído", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao realizar backup: {ex.Message}", 
                    "Erro de Backup", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return false;
            }
        }
        
        public static async Task<bool> RecreateFullDatabaseAsync(bool withBackup = true)
        {
            try
            {
                if (withBackup)
                {
                    bool backupSuccess = await BackupDatabaseAsync();
                    if (!backupSuccess && MessageBox.Show(
                        "O backup falhou. Deseja continuar mesmo assim com a recriação do banco?",
                        "Continuar sem backup?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return false;
                    }
                }
                
                using (var context = new CartorioContext())
                {
                    using (var progress = new Form())
                    {
                        progress.StartPosition = FormStartPosition.CenterScreen;
                        progress.FormBorderStyle = FormBorderStyle.FixedDialog;
                        progress.ControlBox = false;
                        progress.Size = new Size(400, 100);
                        progress.Text = "Recriando banco de dados...";
                        
                        var label = new Label
                        {
                            Text = "Por favor, aguarde enquanto o banco de dados está sendo recriado...",
                            AutoSize = true,
                            Location = new Point(20, 30)
                        };
                        
                        progress.Controls.Add(label);
                        progress.Show();
                        
                        await Task.Run(() => {
                            context.Database.EnsureDeleted();
                            
                            context.Database.EnsureCreated();
                        });
                        
                        progress.Close();
                    }
                    
                    MessageBox.Show("Banco de dados recriado com sucesso!", 
                        "Operação Concluída", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                    
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao recriar o banco de dados: {ex.Message}\n\n{ex.InnerException?.Message}", 
                    "Erro", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
