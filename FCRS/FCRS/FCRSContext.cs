using FCRS.Models;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace FCRS.Context
{
    public class FCRSContext : DbContext
    {
        public FCRSContext() : base("FCRSdb")
        {

        }

        public DbSet<User> Users { get; set; }
        //     public DbSet<Role> Roles { get; set; }
        public DbSet<Info> Infos { get; set; }
        public DbSet<Reservation> Reservationns { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        //    modelBuilder.Entity<ReservedField>().HasRequired(x => x.Field).WithMany().HasForeignKey(x => x.FieldId);
            
            base.OnModelCreating(modelBuilder);
        }
    
    }
}