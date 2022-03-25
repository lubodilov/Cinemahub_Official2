using Cinemahub2.Data;
using Cinemahub2.Models;
using Cinemahub2.Models.DTOs;
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
        public void Create(Movies movie, User user)
        {
            movie.User = user;
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
        public List<MoviesDTO> GetAll()
        {
           return dbContext.Movies
                .Select(p => ToDto(p))
                .ToList<MoviesDTO>();
        }
        //Summary:
        //  Finds a actor by Id
        //
        public Movies GetById(int id)
        {
            return dbContext.Movies.FirstOrDefault(p => p.Id == id);
        }

        public List<MoviesDTO> GetUserMovies(int id)
        {
           return dbContext.Movies
                .Where(p => p.UserId == id)
                .Select(p => ToDto(p))
                .ToList<MoviesDTO>();
        }

        public List<MoviesDTO> GetActorMovies(int id)
        {
            return dbContext.Movies
                 .Where(p => p.ActorsId == id)
                 .Select(p => ToDto(p))
                 .ToList<MoviesDTO>();
        }

        private static MoviesDTO ToDto(Movies a)
        {
            MoviesDTO movie = new MoviesDTO();

            movie.Name = a.Name;
            movie.Genre = a.Genre;
            movie.Director = a.Director;
            movie.Duration = a.Duration;
            movie.Released = a.Released;
            movie.ActorName = a.Actor.Name;
            movie.CreatedBy = $"{a.User.FirstName} {a.User.LastName}";
            movie.UserEmail = a.User.Email;

            return movie;
        }
    }
}
