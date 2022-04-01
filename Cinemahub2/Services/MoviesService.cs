using Cinemahub2.Data;
using Cinemahub2.Models;
using Cinemahub2.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemahub2.Services
{
    public class MoviesService : IMoviesService
    {
        private UserDbContext dbContext;
        //private IActorService actorService;
        public MoviesService(UserDbContext dbContext/*, IActorService actorService*/)
        {
            this.dbContext = dbContext;
            //this.actorService = actorService;
            //dbContext.Movies.Include(m => m.Actor).ToList();
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
        //  Deletes a movie found by its id and removes it from the DB
        //

        public void Delete(int id)
        {
            dbContext.Movies.Remove(GetById(id));
            dbContext.SaveChanges();
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
        //  Returns all movies in the DB
        //
        public List<MoviesDTO> GetAll()
        {
           return dbContext.Movies
                .Select(p => ToDto(p))
                .ToList<MoviesDTO>();
        }
        //Summary:
        //  Finds a movie by Id
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
       
        private static MoviesDTO ToDto(Movies a)
        {
            MoviesDTO movie = new MoviesDTO();

            movie.Name = a.Name;
            movie.Genre = a.Genre;
            movie.Director = a.Director;
            movie.Duration = a.Duration;
            movie.Released = a.Released;
            //movie.ActorName = a.Actor.Name;
            //movie.CreatedBy = $"{a.User.FirstName} {a.User.LastName}";
            //movie.UserEmail = a.User.Email;

            return movie;
        }
    }
}
