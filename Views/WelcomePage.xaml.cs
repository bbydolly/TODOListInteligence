namespace TODOListInteligence.Views;

public partial class WelcomePage : ContentPage
{
	public WelcomePage()
	{
		InitializeComponent();
	}

	//*
	// M�todo que gestiona la creaci�n de una cuenta
	//@async permite llamar a m�todos as�ncronos, como PushAsync, que pertenece a la clase Navigation
	// @await 
	//
	//*
	private async void OnStartNowClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new StartOptionsPage());
	}

	
}