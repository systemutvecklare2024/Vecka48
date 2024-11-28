namespace AdoDotNet.Sakila.Menu
{
    internal abstract class SakilaBaseMenu
    {
        public App App { get; set; }
        public SakilaController Controller { get; set; }
        public SakilaBaseMenu(App app, SakilaController sc)
        {
            App = app;
            Controller = sc;
        }

        public SakilaBaseMenu(SakilaBaseMenu menu)
        {
            App = menu.App;
            Controller = menu.Controller;
        }

        public abstract void Show();
    }
}
