using AdoDotNet.Utils;

namespace AdoDotNet.Sakila.Menu
{
    internal class FindActorMoviesMenu : SakilaBaseMenu
    {
        public FindActorMoviesMenu(SakilaBaseMenu menu) : base(menu)
        {
        }

        public override void Show()
        {
            Console.WriteLine("Search for actor appearances");
            var firstName = PrintHelper.GetStringInput("First name");
            var lastName = PrintHelper.GetStringInput("Last name");

            var results = Controller.FindActorByName(firstName, lastName);
            if (results.Count <= 0)
            {
                Console.WriteLine("Unable to find any movies by that actor.");
                PrintHelper.Halt();
                PrintHelper.Clear();
                return;
            }

            Console.WriteLine($"{firstName} {lastName} appeared in the following movies");
            foreach (var movie in results)
            {
                Console.WriteLine(movie);
            }

            PrintHelper.Halt();
            App.ChangeMenu(new SakilaMainMenu(this));
            PrintHelper.Clear();
        }
    }
}