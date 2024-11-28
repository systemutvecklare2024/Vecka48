namespace AdoDotNet.Sakila
{
    internal class SakilaController
    {
        private SakilaService _service;
        public SakilaController(SakilaService service) {
            _service = service;
        }

        public List<string> GetFilmsByActor(string firstName, string lastName)
        {
            var result = _service.FindFilmsByActorNames(firstName, lastName);

            return result;
        }
    }
}
