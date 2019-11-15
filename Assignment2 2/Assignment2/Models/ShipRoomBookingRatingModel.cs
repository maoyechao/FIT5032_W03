namespace Assignment2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShipRoomBookingRatingModel : DbContext
    {
        public ShipRoomBookingRatingModel()
            : base("name=ShipRoomBookingRatingModel")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Ship> Ships { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Room)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ship>()
                .HasMany(e => e.Ratings)
                .WithRequired(e => e.Ship)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ship>()
                .HasMany(e => e.Rooms)
                .WithRequired(e => e.Ship)
                .WillCascadeOnDelete(false);
        }
    }
}
