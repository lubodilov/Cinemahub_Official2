using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemahub2.Models
{
    public class Actor
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]

        public string Nationality { get; set; }
        public bool Status{ get; set; }
        
        [Required]

        public DateTime Birthday { get; set; }
        
        [ForeignKey("Movies")]
        public int MoviesId { get; set; }
        public Movies Movie { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public Actor(int id, string name, string nationality, bool status, DateTime birthday, Movies movie, int userId, User user)
        {
            Id = id;
            Name = name;
            Nationality = nationality;
            Status = status;
            Birthday = birthday;
            Movie = movie;
            UserId = userId;
            User = user;
        }
        public Actor()
        {

        }
    }
}
