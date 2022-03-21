using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemahub2.Models.DTOs
{
    public class ActorDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The nationality is required.")]
        public string Nationality { get; set; }

        public bool Status { get; set; }

        [Required(ErrorMessage = "The birthday is required.")]
        public DateTime Birthday { get; set; }
        public string MovieName { get; set; }
        public string CreatedBy { get; set; }
        public string UserEmail { get; set; }

        public ActorDTO()
        {

        }
        public ActorDTO(int id, string name, string nationality, bool status, DateTime birthday, string createdBy, String userEmail, string movieName)
        {
            this.Id = id;
            this.Name = name;
            this.Nationality = nationality;
            this.Status = status;
            this.Birthday = birthday;
            this.CreatedBy = createdBy;
            this.UserEmail = userEmail;
            this.MovieName = movieName;

        }
    }
}
