namespace TODOListInteligence.Views;

public partial class StartOptionsPage : ContentPage
{
    public StartOptionsPage()
    {
        InitializeComponent();
    }
    private async void OnCreateAccount(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateAccountPage());
    }

    private async void OnInitSession(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}
