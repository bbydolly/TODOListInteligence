using Microsoft.Maui.Controls;
using System.Diagnostics;
using TODOListInteligence.Helpers;
using TODOListInteligence.Models;
using TODOListInteligence.Resources.Strings;
using TODOListInteligence.Storage;

namespace TODOListInteligence.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            AppSettings.ApplyCulture();
            AppSettings.ApplyTheme();
            InitializeComponent();

        }

       private async void OnCreateAccount(object sender, EventArgs e)
        {
            // TODO
            // 0. Comprobar que el usuario no exista 
            // 1. Validar los datos del usuario
            // 2. Crear objeto user
            // 3. Guardarlo en una base de datos ligera
            UserConfigStorage.Load();
            string email = UserConfig.Instance.Email;
            string password = UserConfig.Instance.Password;

            if (string.IsNullOrEmpty(EmailEntry.Text) || string.IsNullOrEmpty(PasswordEntry.Text))
            {   
                ErrorEntry.Text = AppResources.WrongCredentials;
                
                return;
            };

            if (EmailEntry.Text.Equals(email) && PasswordEntry.Text.Equals(password))
            { 

                await Navigation.PushAsync(UserConfig.Instance.UserTasks.Count() == 0 ? new AddTaskPage() : new AppShell());
            }
            else
            {
                ErrorEntry.Text = AppResources.WrongCredentials;
            }
        }
    }
}
