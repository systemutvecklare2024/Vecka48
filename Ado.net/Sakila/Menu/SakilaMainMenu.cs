using AdoDotNet.Utils;

namespace AdoDotNet.Sakila.Menu
{
    internal class SakilaMainMenu : SakilaBaseMenu
    {
        // Menu alternatives
        const string SearchActor = "1";
        const string Exit = "0";

        public SakilaMainMenu(App app, SakilaController sc) : base(app, sc) { }
        public SakilaMainMenu(SakilaBaseMenu menu) : base(menu) { }

        public override void Show()
        {
            Console.WriteLine("Welcome to Sakila");
            Console.WriteLine();
            Console.WriteLine("Choose menu option.");
            Console.WriteLine("1. Search for actor appearances");
            Console.WriteLine("0. Exit");

            var response = Utils.PrintHelper.GetStringInput("Choice");

            if (string.IsNullOrEmpty(response))
            {
                return;
            }

            switch (response)
            {
                case SearchActor:
                    App.ChangeMenu(new FindActorMoviesMenu(this));
                    break;
                case Exit:
                    Environment.Exit(1);
                    break;
            }

            PrintHelper.Clear();
        }

    }
}
