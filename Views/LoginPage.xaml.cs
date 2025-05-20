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
            if (email == null || password == null)
            {
                return;
            }

            if (EmailEntry.Text.Equals(email) && PasswordEntry.Text.Equals(password))
            { 
                await Navigation.PushAsync(new AddTaskPage());
            }
            else
            {
                ErrorEntry.Text = "Email o contraseña incorrectos";
            }
        }
    }
}
