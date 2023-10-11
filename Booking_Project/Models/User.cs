using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IdentityModel.Tokens.Jwt;

namespace Booking_Project.Models
{
  
    public class User
    {
        public User()
        {
            reviews = new List<Reviews>();
            reservations = new List<Reservations>();
            payments = new List<Payments>();
        }
        public int Id { get; set; }
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
        public List<Payments>? payments { get; set; }
        public List<Reviews>? reviews { get; set; }
        public List<Reservations>? reservations { get; set; }
        [ForeignKey("ApplicationIdentityUser")]
        public string ApplicationIdentityUser_id { get; set; }
        public ApplicationIdentityUser? ApplicationIdentityUser { get; set; }


    }
}