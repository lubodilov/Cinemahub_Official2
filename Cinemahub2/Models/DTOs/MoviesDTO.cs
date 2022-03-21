using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemahub2.Models.DTOs
{
    public class MoviesDTO
    {
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

        public string ActorName { get; set; }
        public string CreatedBy { get; set; }
        public string UserEmail { get; set; }

        public MoviesDTO()
        {

        }
        public MoviesDTO(int id, string name, string genre, string director, DateTime released, string createdBy, String userEmail, string actorName)
        {
            this.Id = id;
            this.Name = name;
            this.Genre = genre;
            this.Director = director;
            this.Released = released;
            this.CreatedBy = createdBy;
            this.UserEmail = userEmail;
            this.ActorName = actorName;

        }
    }
}
