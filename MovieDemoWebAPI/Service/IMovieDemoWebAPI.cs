using MovieDemoWebAPI.Model;
using System.Collections.Generic;

namespace MovieDemoWebAPI.Service
{
    public interface IMovieDemoWebAPI
    {
        public List<Movie> GetMoviesList();

        public Movie GetMovieById(int id);

        public void CreateMovie(Movie movie);

        public void EditMovie(Movie movie);

        public void CreateActor(Actor actor);

        public void CreateProducer(Producer producer);

        public List<Actor> GetActors();

        public List<Producer> GetProducerList();
    }
}
