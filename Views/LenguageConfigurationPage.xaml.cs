using TODOListInteligence.Config;

namespace TODOListInteligence.Views;

public partial class LenguageConfigurationPage : ContentPage
{
    public LenguageConfigurationPage()
    {
        InitializeComponent();
    }
    private async void OnSaveConfiguration(object sender, EventArgs e)
    {
        string selectedLang = null;

        foreach (var child in IdiomaRadioGroup.Children)
        {
            if (child is RadioButton rb && rb.IsChecked)
            {
                selectedLang = rb.Value?.ToString();
                break;
            }
        }

        if (!string.IsNullOrEmpty(selectedLang))
        {
            UserConfig.Instance.UserLanguage = selectedLang;
            Microsoft.Maui.Storage.Preferences.Set("UserLanguage", selectedLang);
            await Navigation.PushAsync(new InitialQuestionnairePage());
        }
    }
}