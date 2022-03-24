using Cinemahub2.Data;
using Cinemahub2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemahub2.Services
{
    public class MoviesService : IMoviesService
    {
        private UserDbContext dbContext;
        private ActorService actorService;
        public MoviesService(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.actorService = new ActorService(dbContext);
            foreach (var movie in dbContext.Movies.ToList<Movies>())
            {
                movie.Actor = actorService.GetById(movie.Actor.Id);
            }
        }
        //Summary:
        //  Creates a new movie and ads it to the DB
        //
        public void Create(Movies movie)
        {
           dbContext.Movies.Add(movie);
           dbContext.SaveChanges();
        }
        //Summary:
        //  Deletes a actor found by its id and removes it from the DB
        //

        public void Delete(int id)
        {
           actorService.Delete(GetById(id).Actor.Id);
        }

        public void Edit(Movies movie)
        {
            Movies oldMovie = GetById(movie.Id);
            oldMovie.Name = movie.Name;
            oldMovie.Genre = movie.Genre;
            oldMovie.Director = movie.Director;
            oldMovie.Released = movie.Released;
            oldMovie.Duration = movie.Duration;
            oldMovie.Actor.Name = movie.Actor.Name;
            oldMovie.Actor.Nationality = movie.Actor.Nationality;
            oldMovie.Actor.Status = movie.Actor.Status;
            oldMovie.Actor.Birthday = movie.Actor.Birthday;
            dbContext.SaveChanges();
        }
        //Summary:
        //  Returns all actors in the DB
        //
        public List<Movies> GetAll()
        {
           return dbContext.Movies.ToList<Movies>();
        }
        //Summary:
        //  Finds a actor by Id
        //
        public Movies GetById(int id)
        {
            return dbContext.Movies.FirstOrDefault(p => p.Id == id);
        }

        public List<Movies> GetUserMovies(int id)
        {
           return dbContext.Movies.Where(p => p.UserId == id).ToList<Movies>();
        }
    }
}
