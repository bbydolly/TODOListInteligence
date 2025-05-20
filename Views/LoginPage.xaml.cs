using Microsoft.Maui.Controls;
using System.Diagnostics;
using TODOListInteligence.Models;
using TODOListInteligence.Storage;

namespace TODOListInteligence.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
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

            if (EmailEntry.Text == null || PasswordEntry.Text == null) { 
                ErrorEntry.Text = "Email o contraseña incorrectos";
                
                return;
            };

            if (EmailEntry.Text.Equals(email) && PasswordEntry.Text.Equals(password))
            { 

                await Navigation.PushAsync(UserConfig.Instance.UserTasks.Count() == 0 ? new AddTaskPage() : new AppShell());
            }
            else
            {
                ErrorEntry.Text = "Email o contraseña incorrectos";
            }
        }
    }
}
