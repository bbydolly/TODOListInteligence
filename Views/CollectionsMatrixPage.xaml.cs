using System.Collections.ObjectModel;
using System.Globalization;
using TODOListInteligence.Models;
using TODOListInteligence.Resources.Strings;


namespace TODOListInteligence.Views
{
    public partial class CollectionsMatrixPage : ContentPage
    {
        public ObservableCollection<UserTask> ItemsSource { get; set; }
        public string CollectionTitle { get; set; }
        public CollectionsMatrixPage(ObservableCollection<UserTask> collection, string title)
        {
            var userLang = UserConfig.Instance.UserLanguage ?? "es";
            AppResources.Culture = new CultureInfo(userLang);
            InitializeComponent();
            ItemsSource = collection;
            CollectionTitle = title;
            BindingContext = this;
        }

        private async void OnAddButtonClicked(object sender, EventArgs e)
        {
            // Abre la vista para crear una nueva tarea (ajusta el nombre según tu vista)
           // await Navigation.PushAsync(new UserTaskDetailPage(null, ItemsSource));
        }


        // Evento al seleccionar una tarea
        private async void OnTaskSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is UserTask selectedTask)
            {
                // Abre la vista de detalle para modificar/eliminar la tarea
                await Navigation.PushAsync(new UserTaskDetailPage(selectedTask, ItemsSource));

                // Deselecciona el elemento para permitir futuras selecciones
                TasksCollectionView.SelectedItem = null;
            }
        }

    }
}