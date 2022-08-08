
using BLL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class TestContext : DbContext
    {

        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {

        }
        public DbSet<Place> Places { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Event> Events { get; set; } 


        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Speaker> Speakers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            #region place
            modelBuilder.Entity<Place>().HasKey(e => e.Id);
            modelBuilder.Entity<Place>().Property(e => e.Title).IsRequired();
            #endregion  
            #region person
            modelBuilder.Entity<Person>().HasKey(e => e.Id);
            modelBuilder.Entity<Person>().Property(e => e.Name).IsRequired();
            #endregion
            #region organizer
            modelBuilder.Entity<Organizer>().HasKey(e => e.Id);
            modelBuilder.Entity<Organizer>().HasOne(t => t.Person).WithMany(e => e.Organizers).HasForeignKey(e => e.PersonId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            #endregion
            #region speaker
            modelBuilder.Entity<Speaker>().HasKey(e => e.Id);
            modelBuilder.Entity<Speaker>().HasOne(t => t.Person).WithMany(e => e.Speakers).HasForeignKey(e => e.PersonId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            #endregion
            #region event
            modelBuilder.Entity<Event>().HasKey(e => e.Id);
            modelBuilder.Entity<Event>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<Event>().Property(e => e.Discription).IsRequired();
            modelBuilder.Entity<Event>().Property(e => e.Plan).IsRequired();
            modelBuilder.Entity<Event>().Property(e => e.CreatedDate).IsRequired();
            modelBuilder.Entity<Event>().HasOne(e => e.Organizer).WithMany(e => e.Events).HasForeignKey(e => e.OrganizerId).IsRequired().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Event>().HasOne(e => e.Speaker).WithMany(e => e.Events).HasForeignKey(e => e.SpeakerId).IsRequired().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Event>().HasOne(e => e.Place).WithMany(e => e.Events).HasForeignKey(e => e.PlaceId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            #endregion

            base.OnModelCreating(modelBuilder);
        }

    }
}