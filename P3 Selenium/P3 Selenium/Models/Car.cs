using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P3_Selenium.Models
{
    public class Car
    {
        public virtual int Id { get; set; }


        [Required]
        [StringLength(60)]
        [Display(Name = "Model name")]
        public virtual String ModelName { get; set; }

        public int BrandId { get; set; }

        [Display(Name = "Brand")]
        public virtual Brand Brand { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }

    }
}
