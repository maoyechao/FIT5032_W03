namespace Assignment2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Ass_Model : DbContext
    {
        public Ass_Model()
            : base("name=Ass_Model")
        {
        }
        public System.Data.Entity.DbSet<Assignment2.Models.Image> Images { get; set; }

        public System.Data.Entity.DbSet<Assignment2.Models.Location> Locations { get; set; }
    }
}
