namespace Assignment2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rating
    {
        public int Id { get; set; }

        public int ShipId { get; set; }

        [Required]
        [StringLength(128)]
        public string CustomerId { get; set; }

        [Column("Rating")]
        public decimal Rating1 { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        public virtual Ship Ship { get; set; }
    }
}
