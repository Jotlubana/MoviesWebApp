using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApp.Models
{
    public class MoviesModel
    {
        // primary Key
        [Key]
        public int MovieId { get; set; }
        // movie name property
        public string MovieName { get; set; }
        // released date property
        public DateTime Released { get; set; }
        // property for genre
        public String Genre { get; set; }
        // property of rating
        public int Rating { get; set; }
        // property to check block buster
        public bool IsBlockBuster { get; set; }
        // for foreign relationship
        public List<RentalsModel> Rental { get; set; }
        // constructr
        public MoviesModel()
        {
            Rental = new List<RentalsModel>();
        }

    }
}
