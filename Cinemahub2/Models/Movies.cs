using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemahub2.Models
{
    public class Movies
    {
        public int Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 1)]
        public string Name { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Genre { get; set; }
        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string Director { get; set; }
        public DateTime Released { get; set; }
        [Range(1, 1000)]
        [Required]
        public int Duration { get; set; }
        
        [ForeignKey("Actor")]
        public int? ActorsId { get; set; }
        public Actor Actor { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public Movies(int id, string name, Actor actor, int userId, User user, DateTime released, int duration)
        {
            Id = id;
            Name = name;
            Actor = actor;
            UserId = userId;
            User = user;
            Released = released;
            Duration = duration;
        }
        public Movies()
        {

        }
    }
}
