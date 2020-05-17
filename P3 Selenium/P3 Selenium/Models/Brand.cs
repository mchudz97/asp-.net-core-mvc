using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P3_Selenium.Models
{
    public class Brand
    {

        public virtual int Id { get; set; }

        [Required]
        [StringLength(30)]
        public virtual string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

    }
}
