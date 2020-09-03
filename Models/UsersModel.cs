using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApp.Models
{
    public class UsersModel
    {
        // primary key
        [Key]
        public int UserId { get; set; }
        // firt name of user 
        public string FirstName { get; set; }
        // last  name of user
        public string LastName { get; set; }
        // email address for user
        public string Email { get; set; }
        // user's address
        // foreign key from table Address
        [ForeignKey("AddressModel")]
        public int AddressId { get; set; }
        public AddressModel Address { get; set; }
        // used for foregin relationship
        public List<RentalsModel> Rental { get; set; }
        // constructor
        public UsersModel()
        {
            Rental = new List<RentalsModel>();
        }
    }
}
