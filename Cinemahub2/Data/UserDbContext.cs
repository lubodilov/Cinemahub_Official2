using Cinemahub2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemahub2.Data
{
    public class UserDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movies> Movies { get; set; }

        public UserDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
