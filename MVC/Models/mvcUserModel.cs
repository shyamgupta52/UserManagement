using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVC.Models
{
    public class mvcUserModel
    {
        public int Id { get; set; }
        [Display(Name ="First Name")]
        [Required(ErrorMessage ="First Name is Required")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public Nullable<int> Status { get; set; }
    }
}