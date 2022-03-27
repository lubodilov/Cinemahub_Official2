using Cinemahub2.Models;
using Cinemahub2.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemahub2.Services
{
    public interface IMoviesService
    {
        /*void Edit(Movies movie);
        void Delete(int id);
        Movies GetById(int id);
        void Create(Movies movie, User user);*/
        List<MoviesDTO> GetAll();
        //List<MoviesDTO> GetUserMovies(int id);
    }
}
