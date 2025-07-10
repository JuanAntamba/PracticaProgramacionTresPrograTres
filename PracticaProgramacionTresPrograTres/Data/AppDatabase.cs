// Data/AppDatabase.cs
using SQLite;
using PracticaProgramacionTresPrograTres.Models;

namespace PracticaProgramacionTresPrograTres.Data
{
    public class AppDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public AppDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Suscripcion>().Wait();
        }

        public Task<int> InsertSuscripcionAsync(Suscripcion s) =>
            _database.InsertAsync(s);

        public Task<List<Suscripcion>> GetSuscripcionesAsync() =>
            _database.Table<Suscripcion>().ToListAsync();
    }
}
