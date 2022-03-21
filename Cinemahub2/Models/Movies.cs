using System;
using System.Collections.Generic;
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
        public int ActorsId { get; set; }
        //public Actor Actor { get; set; }
        public int UserId { get; set; }
        public string Author { get; set; }
        public string AuthorEmail { get; set; }
       
       /* public Movies(int id, string name, Actor Actor, int userId, string author, string authorEmail, DateTime released, int duration)
        {
            Id = id;
            Name = name;
            Actor = Actor;
            UserId = userId;
            Author = author;
            AuthorEmail = authorEmail;
            Released = released;
            Duration = duration;
        }*/
        public Movies()
        {
        }
    }
}
