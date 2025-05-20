using System.Collections.ObjectModel;
using System.Globalization;
using TODOListInteligence.Models;
using TODOListInteligence.Resources.Strings;

namespace TODOListInteligence.Views;

public partial class EisenhowerMatrixPage : ContentPage
{
    public EisenhowerMatrixPage()
    {
        var userLang = UserConfig.Instance.UserLanguage ?? "es";
        AppResources.Culture = new CultureInfo(userLang);
        InitializeComponent();
        BindingContext = UserConfig.Instance;
        System.Diagnostics.Debug.WriteLine($"A: {UserConfig.Instance.UrgentAndImportantTasks.Count}");
        System.Diagnostics.Debug.WriteLine($"B: {UserConfig.Instance.ImportantButNotUrgentTasks.Count}");
        System.Diagnostics.Debug.WriteLine($"C: {UserConfig.Instance.UrgentButNotImportantTasks.Count}");
        System.Diagnostics.Debug.WriteLine($"D: {UserConfig.Instance.NeitherUrgentNorImportantTasks.Count}");
    }

    private async void OnQuadrantTapped(object sender, TappedEventArgs e)
    {
        string quadrant = e.Parameter as string;

        ObservableCollection<UserTask> collection = null;
        string title = "";

        var vm = BindingContext as UserConfig; // Cambia TuViewModel por el nombre real de tu ViewModel

        switch (quadrant)
        {
            case "Q1":
                collection = vm?.UrgentAndImportantTasks;
                title = "Urgentes e Importantes";
                break;
            case "Q2":
                collection = vm?.ImportantButNotUrgentTasks;
                title = "Importantes pero No Urgentes";
                break;
            case "Q3":
                collection = vm?.UrgentButNotImportantTasks;
                title = "Urgentes pero No Importantes";
                break;
            case "Q4":
                collection = vm?.NeitherUrgentNorImportantTasks;
                title = "Ni Urgentes ni Importantes";
                break;
        }

        if (collection != null)
        {
            var page = new CollectionsMatrixPage(collection, title);
            await Navigation.PushAsync(page);
        }


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