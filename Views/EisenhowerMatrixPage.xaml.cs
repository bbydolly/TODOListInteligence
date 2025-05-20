using TODOListInteligence.Models;

namespace TODOListInteligence.Views;

public partial class EisenhowerMatrixPage : ContentPage
{
    public EisenhowerMatrixPage()
    {
        InitializeComponent();
        BindingContext = UserConfig.Instance;
        System.Diagnostics.Debug.WriteLine($"A: {UserConfig.Instance.UrgentAndImportantTasks.Count}");
        System.Diagnostics.Debug.WriteLine($"B: {UserConfig.Instance.ImportantButNotUrgentTasks.Count}");
        System.Diagnostics.Debug.WriteLine($"C: {UserConfig.Instance.UrgentButNotImportantTasks.Count}");
        System.Diagnostics.Debug.WriteLine($"D: {UserConfig.Instance.NeitherUrgentNorImportantTasks.Count}");
    }

    private async void OnQuadrantTapped(object sender, TappedEventArgs e)
    {

    }
    private async void OnTaskSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is UserTask selectedTask)
        {
            // Aquí puedes abrir una página de edición o mostrar un popup
            // Ejemplo: await Navigation.PushAsync(new TaskEditPage(selectedTask));
            // O mostrar un DisplayAlert para editar/borrar
            ((CollectionView)sender).SelectedItem = null; // Deselecciona para permitir volver a pulsar
        }
    }

    private void OnDeleteButtonClicked(object sender, EventArgs e)
    {

    }

}