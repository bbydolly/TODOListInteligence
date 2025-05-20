using TODOListInteligence.Models;

namespace TODOListInteligence.Views;

public partial class UserProfilePage : ContentPage
{
    public UserProfilePage()
    {
        InitializeComponent();
        BindingContext = UserConfig.Instance; // Usando el singleton como fuente de datos
    }

    private void OnEditProfileClicked(object sender, EventArgs e)
    {
        // L�gica para navegar a la p�gina de edici�n de perfil
    }
}
