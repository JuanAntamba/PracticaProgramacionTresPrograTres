
namespace PracticaProgramacionTresPrograTres.Views
{
    public partial class ListaSuscripcionesPage : ContentPage
    {
        private SuscripcionViewModel viewModel = new();

        public ListaSuscripcionesPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.CargarSuscripciones();
        }
    }
}
