using TODOListInteligence.Models;

namespace TODOListInteligence
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            //Cargo la primera vista al ejecutar mi programa
            MainPage = new AppShell();

            if (UserConfig.Instance.UserDataIsComplete()) // Implementa este método según tu lógica
            {
                MainPage = new AppShell(); // Menú principal
            }
            else
            {
                    MainPage = new NavigationPage(new Views.WelcomePage());
                
            }
        }
    }
}
