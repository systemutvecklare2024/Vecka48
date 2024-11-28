using AdoDotNet.Sakila;
using AdoDotNet.Sakila.Menu;

namespace AdoDotNet
{
    internal class App
    {
        private SakilaService _service;
        private SakilaBaseMenu _menu;
        private SakilaController _controller;

        public App() {
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sakila;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            _service = new SakilaService(connectionString);
            _controller = new SakilaController(_service);
            _menu = new SakilaMainMenu(this, _controller);
        }
        public void Run()
        {
            while (true)
            {
                _menu.Show();
            }
        }

        public void ChangeMenu(SakilaBaseMenu newMenu)
        {
            _menu = newMenu;
        }
    }
}
