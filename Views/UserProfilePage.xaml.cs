using TODOListInteligence.Helpers;
using TODOListInteligence.Models;
using TODOListInteligence.Storage;

namespace TODOListInteligence.Views;

public partial class UserProfilePage : ContentPage
{
    public UserProfilePage()
    {
        InitializeComponent();
        BindingContext = UserConfig.Instance; // Singleton como contexto de datos
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        Microsoft.Maui.Storage.Preferences.Set("UserLanguage", UserConfig.Instance.UserLanguage);

        AppSettings.ApplyCulture();

        Microsoft.Maui.Storage.Preferences.Set("UserTheme", UserConfig.Instance.UserTheme);

        AppSettings.ApplyTheme();

        UserConfigStorage.Save(); // Guarda los cambios en JSON o donde prefieras
        DisplayAlert("Perfil", "¡Cambios guardados!", "OK");
    }
}
