using Microsoft.Maui.Controls;
using System.Diagnostics;

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
            
            await Navigation.PushAsync(new ThemeConfigurationPage());

        }
    }
}
