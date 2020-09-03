using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApp.Models
{
    // model class for address
    public class AddressModel
    {
        // primary key 
        [Key]
        public int AddressId { get; set; }
        // address property
        public string Address { get; set; }
        // pincode propery
        public int PinCode { get; set; }
        // for foreign relationship
        public List<UsersModel> User { get; set; }
        // constructor
        public AddressModel()
        {
            User = new List<UsersModel>();
        }
    }
}
