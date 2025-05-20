using System.Collections.ObjectModel;
using System.Globalization;
using TODOListInteligence.Models;
using TODOListInteligence.Resources.Strings;

namespace TODOListInteligence.Views
{
    public partial class UserTaskDetailPage : ContentPage
    {
        private UserTask _task;
        private ObservableCollection<UserTask> _parentCollection;

        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }

        public UserTaskDetailPage(UserTask task, ObservableCollection<UserTask> parentCollection)
        {
            var userLang = UserConfig.Instance.UserLanguage ?? "es";
            AppResources.Culture = new CultureInfo(userLang);

            InitializeComponent();
            _task = task;
            _parentCollection = parentCollection;

            // Si es una tarea existente, carga los datos
            if (_task != null)
            {
                TaskTitle = _task.Title;
                TaskDescription = _task.Description;
            }
            else
            {
                TaskTitle = "";
                TaskDescription = "";
            }

            BindingContext = this;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            if (_task != null)
            {
                // Modificar descripción de tarea existente
                _task.Description = TaskDescription;
            }
            else
            {
                // Crear nueva tarea (el título no es editable aquí, puedes pedirlo en otra vista si lo prefieres)
                var newTask = new UserTask
                {
                    Title = TaskTitle,
                    Description = TaskDescription
                };
                _parentCollection.Add(newTask);
            }
            await Navigation.PopAsync();
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            //Cierra la página actual y vuelve a la anterior
            await Navigation.PopAsync();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (_task != null && _parentCollection.Contains(_task))
            {

                //TODO MODIFICAR, MULTIIDIOMA
                bool confirm = await DisplayAlert(
                    "Confirmar",
                    "¿Seguro que quieres eliminar esta tarea?",
                    "Sí", "No");
                if (confirm)
                {
                    _parentCollection.Remove(_task);
                    await Navigation.PopAsync();
                }
            }
        }
    }
}
