using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaProgramacionTresPrograTres.Services
{
    public static class LogService
    {
        public static string LogPath => Path.Combine(FileSystem.AppDataDirectory, "Logs_Antamba.txt");

        public static async Task AppendLog(string servicio)
        {
            string log = $"Se incluyó el registro [{servicio}] el {DateTime.Now:dd/MM/yyyy HH:mm}";
            await File.AppendAllTextAsync(LogPath, log + Environment.NewLine);
        }

        public static async Task<List<string>> LeerLogs()
        {
            if (!File.Exists(LogPath)) return new();
            return (await File.ReadAllLinesAsync(LogPath)).ToList();
        }
    }
}
