using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_Project.Models
{
    public enum Gender
    {
        male, female
    }
    public class ApplicationIdentityUser :IdentityUser
    {
        public ApplicationIdentityUser()
        {
            reviews = new List<Reviews>();
            reservations = new List<Reservations>();
            payments = new List<Payments>();
        }
        [MaxLength(10)]
        public string Fname { get; set; }
        [MaxLength(10)]
        public string Lname { get; set; }


        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(50)]
        public string? Address { get; set; }

        [MaxLength(20)]
        public string? City { get; set; }
        public virtual List<Payments>? payments { get; set; }
        public  virtual List<Reviews>? reviews { get; set; }
        public  virtual List<Reservations>? reservations { get; set; }
        [Required]
        [Column(TypeName ="varchar(10)")]
        public Gender gender { get; set; }
       
        //public User? user { get; set; }

    }
}
