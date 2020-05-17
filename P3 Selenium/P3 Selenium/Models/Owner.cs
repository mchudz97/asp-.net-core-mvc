using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P3_Selenium.Models
{
    public class Owner
    {
        public virtual int Id { get; set; }

        [Required]
        [StringLength(32)]
        [RegularExpression("[A-Z][a-z]*")]
        public virtual String Name { get; set; }

        [Required]
        [StringLength(32)]
        [RegularExpression("[A-Z][a-z]*")]
        public virtual String Surname { get; set; }

        [Required]
        [EmailAddress]
        //[RegularExpression("^[a - zA - Z0 - 9_\\.-] +@([a - zA - Z0 - 9 -] +\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid email adress.")]
        [Display(Name = "Email adress")]
        public virtual String EmailAdress { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }

    }
}
