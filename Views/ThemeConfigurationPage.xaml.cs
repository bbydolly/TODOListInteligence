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
        await Navigation.PushAsync(new LenguageConfigurationPage());

    }
}