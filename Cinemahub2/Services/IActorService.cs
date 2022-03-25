using Cinemahub2.Models;
using Cinemahub2.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemahub2.Services
{
    public interface IActorService
    {
        void Edit(Actor actor);
        void Delete(int id);
        Actor GetById(int id);
        void Create(Actor actor, User user);
        List<ActorDTO> GetAll();
        List<ActorDTO> GetUserActors(int id);
        List<ActorDTO> GetMovieActors(int id);
    }
}
