using Cinemahub2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemahub2.Services
{
    interface IActorService
    {
        void Edit(Actor actor);
        void Delete(int id);
        Actor GetById(int id);
        void Create(Actor actor);
        List<Actor> GetAll();
        List<Actor> GetUserActors(int id);
    }
}
