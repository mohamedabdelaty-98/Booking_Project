using Microsoft.EntityFrameworkCore;

namespace Booking_Project.Models
{
    public class Context :DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<ReservationRoom> ReservationRooms { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Image_Room> Image_Rooms { get; set; }
        public DbSet<Image_Hotel> Image_Hotels { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<AmenitiesRoom> AmenitiesRooms { get; set; }
        public DbSet<Amenities_Hotel> Amenities_Hotels { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Booking_DB;Integrated Security=True;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => entity.HasIndex(e => e.Email).IsUnique());
        }
    }
}
