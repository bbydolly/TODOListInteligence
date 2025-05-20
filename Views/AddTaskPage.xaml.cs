using System.Collections.ObjectModel;
using System.Globalization;
using TODOListInteligence.Models;
using TODOListInteligence.Services;
using TODOListInteligence.Storage;

namespace TODOListInteligence.Views;

public partial class AddTaskPage : ContentPage
{
    // Usamos ObservableCollection porque notifica automáticamente a la interfaz de usuario (UI)
    // cuando se agregan o eliminan elementos. Así, el CollectionView se actualiza en tiempo real.
    // Si usáramos List<T>, la UI no se enteraría de los cambios y no se actualizaría.
    public ObservableCollection<UserTask> Tasks { get; set; } = new();

    public AddTaskPage()
    {
        var userLang = UserConfig.Instance.UserLanguage ?? "es";
        var culture = userLang switch
        {
            "en" => new CultureInfo("en-US"),
            "es" => new CultureInfo("es-ES"),
            _ => new CultureInfo("es-ES")
        };

        Thread.CurrentThread.CurrentUICulture = culture;
        Thread.CurrentThread.CurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
        CultureInfo.DefaultThreadCurrentCulture = culture;
        InitializeComponent();

        //Inabilito que pueda volver al cuestionario
        NavigationPage.SetHasBackButton(this, false);

        // Establecemos el BindingContext para los bindings en XAML
        BindingContext = this;
    }

    private void AddTaskButton_Clicked(object sender, EventArgs e)
    {
        // Validación simple
        if (string.IsNullOrWhiteSpace(TaskNameEntry.Text))
        {
            //TODO cambiarlo  amultiidioma
            DisplayAlert("Error", "Por favor, introduce el nombre de la tarea.", "OK");
            return;
        }

        // Crear la nueva tarea
        var newTask = new UserTask
        {
            Title = TaskNameEntry.Text.Trim(),
            Description = TaskDescriptionEditor.Text?.Trim() ?? "",
            IsUrgent = UrgentCheckBox.IsChecked,
            IsImportant = ImportantCheckBox.IsChecked
        };

        // Añadir a la newTask visual (ObservableCollection)
        Tasks.Add(newTask);

        // Añadir a la lista global de UserConfig
        UserConfig.Instance.UserTasks.Add(newTask);
        UserConfigStorage.Save();
        // Limpiar campos para la siguiente tarea
        TaskNameEntry.Text = "";
        TaskDescriptionEditor.Text = "";
        UrgentCheckBox.IsChecked = false;
        ImportantCheckBox.IsChecked = false;

        // foco de nuevo en el campo de título para facilitar la entrada rápida
        TaskNameEntry.Focus();
    }

    //Agrega tareas a la colección que le corresponde a partir del total de tareas que contiene Tasks
    private async void DistributeTasksButton_Clicked(object sender, EventArgs e)
    {
        //llamar a detectArea



        // 1. Llama al servicio para distribuir las tareas
        var distributionService = new TaskDistributionService();
        distributionService.DistributeTasksByAreaAndQuadrant(UserConfig.Instance);

        // 2. Navega a la vista de cuadrantes o de áreas (por ejemplo, EisenhowerMatrixPage)
       // await Navigation.PushAsync(new EisenhowerMatrixPage());

        Application.Current.MainPage = new AppShell();

    }
}