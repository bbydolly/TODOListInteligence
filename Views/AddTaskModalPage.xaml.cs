using System.Collections.ObjectModel;
using TODOListInteligence.Models;

namespace TODOListInteligence.Views
{
    public partial class AddTaskModalPage : ContentPage
    {
        private ObservableCollection<UserTask> _collection;

        public AddTaskModalPage(ObservableCollection<UserTask> collection)
        {
            InitializeComponent();
            _collection = collection;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TaskNameEntry.Text))
            {
                await DisplayAlert("Error", "El título es obligatorio.", "OK");
                return;
            }

            var newTask = new UserTask
            {
                Title = TaskNameEntry.Text,
                Description = TaskDescriptionEditor.Text
            };

            _collection.Add(newTask);

            await Navigation.PopModalAsync();
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}

