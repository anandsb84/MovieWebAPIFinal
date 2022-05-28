using MovieDemoWebAPI.Context;
using MovieDemoWebAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace MovieDemoWebAPI.Service
{
    public class MovieDemoWebAPIServ : IMovieDemoWebAPI
    {
        public readonly MovieDbContext _movieDbContex;

        public MovieDemoWebAPIServ(MovieDbContext movieDbContex)
        {
            _movieDbContex = movieDbContex;
        }

        public void CreateActor(Actor actor)
        {
            _movieDbContex.Actors.Add(actor);
            _movieDbContex.SaveChanges();
        }

        public void CreateMovie(Movie movie)
        {
            movie.Actor = FindActById(movie.Actor.ToList());
            movie.Producer = FindProducerById(movie.Producer);
           _movieDbContex.Movies.Add(movie);
            _movieDbContex.SaveChanges();
        }

        public void CreateProducer(Producer producer)
        {
            _movieDbContex.Producers.Add(producer);
            _movieDbContex.SaveChanges();
        }

        public void EditMovie(Movie movie)
        {
            Movie editmov = _movieDbContex.Movies.FirstOrDefault(x => x.MovieId == movie.MovieId);
            if (editmov != null)
            {
                editmov.Actor = FindActById(movie.Actor.ToList());
                editmov.Producer = FindProducerById(movie.Producer);         
                _movieDbContex.Update(editmov);
                _movieDbContex.SaveChanges();
            }
           
        }

        public List<Actor> GetActors()
        {
            return _movieDbContex.Actors.ToList();
        }

        public Movie GetMovieById(int id)
        {

            Movie mov = _movieDbContex.Movies.Find(id);
            return mov;
        }

        public List<Movie> GetMoviesList()
        {
            return _movieDbContex.Movies.ToList();
        }

        public List<Producer> GetProducerList()
        {
           return _movieDbContex.Producers.ToList();
        }

        private List<Actor> FindActById(List<Actor> actor)
        {
            var lst = new List<Actor>();
            foreach(var act in actor)
            {
                var res = _movieDbContex.Actors.Where(x => x.ActorId == act.ActorId).FirstOrDefault();
                if(res != null)
                {
                    lst.Add(res);
                }
            }
            return lst;
        }
        private Producer FindProducerById(Producer producer )
        {

            Producer prod= _movieDbContex.Producers.FirstOrDefault(x => x.ProducerId == producer.ProducerId);
            return prod;


        }
    }
}
