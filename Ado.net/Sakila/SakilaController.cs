namespace AdoDotNet.Sakila
{
    internal class SakilaController
    {
        private SakilaService _service;
        public SakilaController(SakilaService service) {
            _service = service;
        }

        public List<string> FindActorByName(string firstName, string lastName)
        {
            var result = _service.FindFilmByActor(firstName, lastName);

            return result;
        }
    }
}
