namespace TODOListInteligence
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
           // this.CurrentItemChanged += AppShell_CurrentItemChanged;
        }
        //Tratar de ir a la vista que quiero, con el problema de pilas

        //public Action<object, EventArgs> CurrentItemChanged { get; }

        //private async void AppShell_CurrentItemChanged(object sender, EventArgs e)
        //{
        //    // Obtiene la ruta de la pestaña actual
        //    var route = (CurrentItem?.CurrentItem as ShellSection)?.Route;

        //    // Comprueba la pestaña y navega a la raíz de la misma
        //    if (route == "EisenhowerMatrixPage")
        //    {
        //        await Shell.Current.GoToAsync("//EisenhowerMatrixPage");
        //    }
        //    else if (route == "AddTaskPage")
        //    {
        //        await Shell.Current.GoToAsync("//AddTaskPage");
        //    }
        //    else if (route == "UserPage")
        //    {
        //        await Shell.Current.GoToAsync("//UserPage");
        //    }
        //}
    }
}
