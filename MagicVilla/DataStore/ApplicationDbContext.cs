using MagicVilla.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.DataStore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }
        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Sqft = 400,
                    Occupancy = 5,
                    Rate = 200,
                    ImageUrl = "",
                    Amenity = "Swimming pool, Adventure activities, 2 rooms, 1 Kitchen, Luxury Beds, Luxury furniture",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 2,
                    Name = "Serene Villa",
                    Sqft = 600,
                    Occupancy = 5,
                    Rate = 300,
                    ImageUrl = "",
                    Amenity = "Swimming pool, Adventure activities, 2 rooms, 1 Kitchen, Luxury Beds, Luxury furniture",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 3,
                    Name = "Heavenly Abode",
                    Sqft = 500,
                    Occupancy = 3,
                    Rate = 150,
                    ImageUrl = "",
                    Amenity = "Swimming pool, Adventure activities, 2 rooms, 1 Kitchen, Luxury Beds, Luxury furniture",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 4,
                    Name = "Peaceful Oasis",
                    Sqft = 800,
                    Occupancy = 8,
                    Rate = 300,
                    ImageUrl = "",
                    Amenity = "Swimming pool, Adventure activities, 2 rooms, 1 Kitchen, Luxury Beds, Luxury furniture",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 5,
                    Name = "Rustic Hideaway",
                    Sqft = 1000,
                    Occupancy = 9,
                    Rate = 300,
                    ImageUrl = "",
                    Amenity = "Swimming pool, Adventure activities, 2 rooms, 1 Kitchen, Luxury Beds, Luxury furniture",
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
