using TODOListInteligence.Config;
using TODOListInteligence.Helpers;

namespace TODOListInteligence.Views;

public partial class ThemeConfigurationPage : ContentPage
{
    public ThemeConfigurationPage()
    {
        InitializeComponent();
    }
    private async void OnSaveConfiguration(object sender, EventArgs e)
    {
        //Comprobar que radio button ha sido seleccionado 
        string selectedTheme = null;

        foreach (var child in ThemeRadioGroup.Children)
        {
            if (child is RadioButton rb && rb.IsChecked)
            {
                selectedTheme = rb.Value?.ToString();
                break;
            }
        }

        if (!string.IsNullOrEmpty(selectedTheme))
        {
            UserConfig.Instance.UserTheme = selectedTheme;
            Microsoft.Maui.Storage.Preferences.Set("UserTheme", selectedTheme);

            // Aplica el tema inmediatamente
            if (selectedTheme == "dark")
                Application.Current.UserAppTheme = AppTheme.Dark;
            else
                Application.Current.UserAppTheme = AppTheme.Light;

            await Navigation.PushAsync(new LenguageConfigurationPage());
        }
    
    

    }
}