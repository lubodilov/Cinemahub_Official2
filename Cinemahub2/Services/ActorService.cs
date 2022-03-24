using Cinemahub2.Data;
using Cinemahub2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemahub2.Services
{
    //
    //Summary:
    //  Implements CRUD operations with the DB for the Class Actor
    //
    public class ActorService : IActorService
    {
        private UserDbContext dbContext;
        private MoviesService movieService;
        public ActorService(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.movieService = new MoviesService(dbContext);
            foreach (var actor in dbContext.Actors.ToList<Actor>())
            {
                actor.Movie = movieService.GetById(actor.Movie.Id);
            }
        }
        //
        //Summary:
        //  Creates a new actor and ads it to the DB
        //
        public void Create(Actor actor)
        {
            dbContext.Actors.Add(actor);
            dbContext.SaveChanges();
        }
        //
        //Summary:
        //  Deletes a actor found by its id and removes it from the DB
        //
        public void Delete(int id)
        {
           /movieService.Delete(GetById(id).Movie.Id);
        }
        //
        //Summary:
        //  Edits a actor and updates the DB
        //
        public void Edit(Actor actor)
        {
            Actor oldActor = GetById(actor.Id);
            oldActor.Name = actor.Name;
            oldActor.Nationality = actor.Nationality;
            oldActor.Status = actor.Status;
            oldActor.Birthday = actor.Birthday;
            oldActor.Movie.Name = actor.Movie.Name;
            oldActor.Movie.Genre = actor.Movie.Genre;
            oldActor.Movie.Director = actor.Movie.Director;
            oldActor.Movie.Released = actor.Movie.Released;
            oldActor.Movie.Duration = actor.Movie.Duration;
            dbContext.SaveChanges();
        }
        //
        //Summary:
        //  Finds a actor by Id
        //
        public Actor GetById(int id)
        {
            return dbContext.Actors.FirstOrDefault(p => p.Id == id);
        }
        //
        //Summary:
        //  Returns all actors in the DB
        //
        public List<Actor> GetAll()
        {
            return dbContext.Actors.ToList<Actor>();
        }
        //
        //Summary:
        //  Returns all actors having the given userId
        //
        public List<Actor> GetUserActors(int id)
        {
            return dbContext.Actors.Where(p => p.UserId == id).ToList<Actor>();
        }
     
    }
}
