namespace TODOListInteligence.Views;

public partial class LenguageConfigurationPage : ContentPage
{
	public LenguageConfigurationPage()
	{
		InitializeComponent();
	}
	private async void OnSaveConfiguration(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new InitialQuestionnairePage());
	}
}