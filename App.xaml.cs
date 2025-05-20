using TODOListInteligence.Helpers;
using TODOListInteligence.Models;
using TODOListInteligence.Views;

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
            AppSettings.ApplyCulture();
            AppSettings.ApplyTheme();
            if (UserConfig.Instance.UserDataIsComplete())
            {
                MainPage = new NavigationPage(new LoginPage()); // Menú principal
            }
            else
            {
                MainPage = new NavigationPage(new Views.WelcomePage());
                
            }
        }
    }
}
