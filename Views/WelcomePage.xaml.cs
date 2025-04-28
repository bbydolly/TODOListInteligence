namespace TODOListInteligence.Views;

public partial class WelcomePage : ContentPage
{
	public WelcomePage()
	{
		InitializeComponent();
	}

	//*
	// Método que gestiona la creación de una cuenta
	//@async permite llamar a métodos asíncronos, como PushAsync, que pertenece a la clase Navigation
	// @await 
	//
	//*
	private async void OnStartNowClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new StartOptionsPage());
	}

	
}