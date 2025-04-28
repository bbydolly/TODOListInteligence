namespace TODOListInteligence
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            //Cargo la primera vista al ejecutar mi programa
            MainPage = new NavigationPage(new Views.WelcomePage());
        }
    }
}
