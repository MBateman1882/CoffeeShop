using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Models
{
    public partial class Users
    {
        public Users()
        {
            UserItems = new HashSet<UserItems>();
        }

        public int Id { get; set; }
        //add DataAnnotations to allow for JQuery Validation
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a User Name.")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Length between 3 and 20 characters")]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Password { get; set; }
        public decimal? Funds { get; set; }

        public virtual ICollection<UserItems> UserItems { get; set; }
    }
}
