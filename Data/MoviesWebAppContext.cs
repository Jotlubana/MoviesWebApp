using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Models;

namespace MoviesWebApp.Data
{
    public class MoviesWebAppContext : DbContext
    {
        public MoviesWebAppContext (DbContextOptions<MoviesWebAppContext> options)
            : base(options)
        {
        }
        // Movies model sets for DBContext
        public DbSet<MoviesWebApp.Models.MoviesModel> MoviesModel { get; set; }
        // Address model sets for DBContext
        public DbSet<MoviesWebApp.Models.AddressModel> AddressModel { get; set; }
        // Rentals model sets for DBContext
        public DbSet<MoviesWebApp.Models.RentalsModel> RentalsModel { get; set; }
        // Users model sets for DBContext
        public DbSet<MoviesWebApp.Models.UsersModel> UsersModel { get; set; }
    }
}
