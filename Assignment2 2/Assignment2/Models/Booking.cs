namespace Assignment2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Booking
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        [Required]
        [StringLength(128)]
        public string CustomerId { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public string NumOfPeople { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime BookingDate { get; set; }

        public virtual Room Room { get; set; }
    }
}
