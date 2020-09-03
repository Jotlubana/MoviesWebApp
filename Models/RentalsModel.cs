using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApp.Models
{
    public class RentalsModel
    {
        // primary key
        [Key]
        public int RentalsId { get; set; }

        // used as foreign key
        [ForeignKey("UsersModel")]
        public int UserId { get; set; }
        public UsersModel User { get; set; }

        // used as foreign key
        [ForeignKey("MoviesModel")]
        public int MovieId { get; set; }
        public MoviesModel Movie { get; set; }

        // booking date and time property
        public DateTime BookingDate { get; set; }
        // check for delivery address
        public bool IsDeliveryAddress { get; set; }

    }
}
