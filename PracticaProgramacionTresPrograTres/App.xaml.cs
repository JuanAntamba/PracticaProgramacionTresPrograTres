using PracticaProgramacionTresPrograTres.Data; // Asegúrate de tener este using

namespace PracticaProgramacionTresPrograTres
{
    public partial class App : Application
    {
        public static AppDatabase Database { get; private set; }

        public App()
        {
            InitializeComponent();

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "suscripciones.db3");
            Database = new AppDatabase(dbPath);
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}
