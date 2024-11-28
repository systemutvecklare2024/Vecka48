using Microsoft.Data.SqlClient;


namespace AdoDotNet.Sakila
{
    internal class SakilaService
    {
        private SqlConnection _conn;
        public SakilaService(string connString)
        {
            _conn = new SqlConnection(connString);
        }

        public List<string> FindFilmsByActorNames(string firstName, string lastName)
        {
            var queryString = "select actor.first_name, actor.last_name, film.title " +
                "from actor " +
                "inner join film_actor on actor.actor_id = film_actor.actor_id " +
                "inner join film on film.film_id = film_actor.film_id " +
                "where actor.first_name = @firstName and actor.last_name = @lastName;";

            _conn.Open();

            var cmd = new SqlCommand(queryString, _conn);
            SqlParameter[] parameters =
            {
                new SqlParameter("@firstName", firstName),
                new SqlParameter("@lastName", lastName)
            };
            cmd.Parameters.AddRange(parameters);

            var result = cmd.ExecuteReader();

            List<string> films = new List<string>();

            if (!result.HasRows)
            {
                Console.WriteLine("No films found");
                return films;
            }

            while (result.Read())
            {
                string title = result["title"].ToString() ?? "";
                if (!string.IsNullOrEmpty(title))
                    films.Add(title);
            }

            _conn.Close();

            return films;
        }
    }
}
