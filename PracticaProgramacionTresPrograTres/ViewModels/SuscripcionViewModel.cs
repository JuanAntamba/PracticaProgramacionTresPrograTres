// ViewModels/SuscripcionViewModel.cs
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using PracticaProgramacionTresPrograTres.Models;
using PracticaProgramacionTresPrograTres;
using PracticaProgramacionTresPrograTres.Services;

public class SuscripcionViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Suscripcion> Suscripciones { get; } = new();

    public string Servicio { get; set; }
    public string CorreoAsociado { get; set; }
    public decimal CostoMensual { get; set; }
    public bool RenovacionAutomatica { get; set; }

    public ICommand GuardarCommand { get; }

    public SuscripcionViewModel()
    {
        GuardarCommand = new Command(async () => await GuardarSuscripcion());
    }

    private async Task GuardarSuscripcion()
    {
        if (((int)CostoMensual) % 2 == 0)
        {
            await Shell.Current.DisplayAlert("Error", "El costo mensual debe ser un número impar.", "OK");
            return;
        }

        var nueva = new Suscripcion
        {
            Servicio = Servicio,
            CorreoAsociado = CorreoAsociado,
            CostoMensual = CostoMensual,
            RenovacionAutomatica = RenovacionAutomatica,
            FechaRegistro = DateTime.Now
        };

        await App.Database.InsertSuscripcionAsync(nueva);
        await LogService.AppendLog(nueva.Servicio);
        Suscripciones.Add(nueva);
    }

    public async Task CargarSuscripciones()
    {
        Suscripciones.Clear();
        var lista = await App.Database.GetSuscripcionesAsync();
        foreach (var s in lista)
            Suscripciones.Add(s);
    }

    public event PropertyChangedEventHandler PropertyChanged;
}
