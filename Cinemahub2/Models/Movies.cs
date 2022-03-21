using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemahub2.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public DateTime Released { get; set; }
        public int Duration { get; set; }
        
        [ForeignKey("Actor")]
        public int ActorsId { get; set; }
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
