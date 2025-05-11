using System.Collections.ObjectModel;
using System.Globalization;
using TODOListInteligence.Models;

namespace TODOListInteligence.Views;

public partial class AddTaskPage : ContentPage
{
    // Usamos ObservableCollection porque notifica autom�ticamente a la interfaz de usuario (UI)
    // cuando se agregan o eliminan elementos. As�, el CollectionView se actualiza en tiempo real.
    // Si us�ramos List<T>, la UI no se enterar�a de los cambios y no se actualizar�a.
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
        // Validaci�n simple
        if (string.IsNullOrWhiteSpace(TaskNameEntry.Text))
        {
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

        // A�adir a la newTask visual (ObservableCollection)
        Tasks.Add(newTask);

        // A�adir a la lista global de UserConfig
        UserConfig.Instance.UserTasks.Add(newTask);

        // Limpiar campos para la siguiente tarea
        TaskNameEntry.Text = "";
        TaskDescriptionEditor.Text = "";
        UrgentCheckBox.IsChecked = false;
        ImportantCheckBox.IsChecked = false;

        // foco de nuevo en el campo de t�tulo para facilitar la entrada r�pida
        TaskNameEntry.Focus();
    }

}