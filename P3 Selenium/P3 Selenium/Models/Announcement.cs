using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P3_Selenium.Models
{
    public enum FuelTypes { DIESEL, PETROL, LPG }

    public class Announcement
    {
        public virtual int Id { get; set; }


        [Display(Name = "Horsepower")]
        [Range(5, 2000)]
        public virtual int HorsePower { get; set; }

        [Required]
        [Range(1000, 10000000)]
        [DataType(DataType.Currency)]
        public virtual float Price { get; set; }
        [Required]
        [Display(Name = "Production year")]
        [Range(1900, 2020)]
        public virtual int ProductionDate { get; set; }


        public virtual FuelTypes FuelType { get; set; }

        [StringLength(250)]
        public virtual string Description { get; set; }

        public int CarId { get; set; }

        public int OwnerId { get; set; }


        public virtual Car Car { get; set; }

        public virtual Owner Owner { get; set; }


    }

}
