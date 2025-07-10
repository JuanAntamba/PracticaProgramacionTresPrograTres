namespace PracticaProgramacionTresPrograTres.Views;

public partial class CrearSuscripcionPage : ContentPage
{
    public CrearSuscripcionPage()
    {
        InitializeComponent();
        BindingContext = new SuscripcionViewModel();
    }
}
