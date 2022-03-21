using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemahub2.Models.DTOs
{
    public class MoviesDTO
    {
        public MoviesDTO()
        {

        }
        public MoviesDTO(int id, string name, string genre, string director, DateTime released)
        {
            this.Id = id;
            this.Name = name;
            this.Genre = genre;
            this.Director = director;
            this.Released = released;
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "The name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The genre is required.")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "The director name is required.")]
        public string Director { get; set; }
        [Required(ErrorMessage = "The duration is required.")]
        public int Duration { get; set; }
        [Required(ErrorMessage = "The release date is required.")]
        public DateTime Released { get; set; }
    }
}
