namespace Assignment2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TinyModel : DbContext
    {
        public TinyModel()
            : base("name=TinyModel")
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .Property(e => e.Contents)
                .IsUnicode(false);
        }
    }
}
