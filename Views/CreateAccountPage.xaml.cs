using TODOListInteligence.Models;
using TODOListInteligence.Storage;

namespace TODOListInteligence.Views;


public partial class CreateAccountPage : ContentPage
{
    public CreateAccountPage()
    {
        InitializeComponent();
    }

    private async void CreateAccount(object sender, EventArgs e)
    {
        UserConfig.Instance.Name = Name.Text;
        UserConfig.Instance.Email = Email.Text;
        UserConfig.Instance.Password = Password.Text;
        UserConfigStorage.Save();
        await Navigation.PushAsync(new ThemeConfigurationPage());
    }
    private async void InitSession(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}