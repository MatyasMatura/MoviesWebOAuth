using Microsoft.EntityFrameworkCore;
using MoviesWebProjectOAuth.Models;

namespace MoviesWebProjectOAuth.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<AppUser> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Review>().HasOne(x => x.Movie).WithMany(x => x.Reviews).HasForeignKey(x => x.MovieId);
            modelBuilder.Entity<Review>().HasOne(x => x.User).WithMany(x => x.Reviews).HasForeignKey(x => x.UserId);


            modelBuilder.Entity<Movie>().HasData(new Movie { Id = Guid.NewGuid(), Name = "GodFather", Description = "Mafia", Year = 1972, Director = "Coppola", Score = 96 });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = Guid.Parse("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), Name = "GodFather 2", Description = "Mafia", Year = 1974, Director = "Coppola", Score = 95 });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = Guid.NewGuid(), Name = "GodFather 3", Description = "Mafia", Year = 1990, Director = "Coppola", Score = 80 });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = Guid.Parse("891c93d7-8120-485b-80a7-f31691613a88"), Name = "Interstellar", Description = "A movie about space and family. Beautiful soundtrack by Hans Zimmer", 
                Year = 2014, Director = "Christopher Nolan", Score = 87 });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = Guid.NewGuid(), Name = "The Dark Knight", Description = "Batman goes againts the joker", Year = 2008, Director = "Christopher Nolan", Score = 90 });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = Guid.NewGuid(), Name = "Ulice", Description = "film podle serialu", Year = 2025, Director = "Malinka", Score = 17 });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = Guid.NewGuid(), Name = "Rocky", Description = "The Italian stallion goes boxing", Year = 1976, Director = "Sylvester Stallone", Score = 87 });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = Guid.NewGuid(), Name = "The Devil All the Time", Description = "Creepy priest", Year = 2020, Director = "Antonio Campos", Score = 77 });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = Guid.NewGuid(), Name = "The Shawshank Redemption", Description = "Life in prison", Year = 1994, Director = "Frank Darabont", Score = 97 });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = Guid.NewGuid(), Name = "The Irishman", Description = "Mafia", Year = 2019, Director = "Martin Scorsese", Score = 75 });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = Guid.NewGuid(), Name = "Dont look up", Description = "Comedy about scientists and people not believing them", Year = 2021, Director = "Adam McKay", Score = 76 });

            modelBuilder.Entity<AppUser>().HasData(new AppUser { Id = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541", Email = "Josef.Pepik@pslib.cz", Name = "Josef Pepík" });

            modelBuilder.Entity<Review>().HasData(new Review { Id = Guid.NewGuid(), Content = "Great Movie", Liked = true, MovieId = Guid.Parse("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541", Author = "Josef Pepík" });
            modelBuilder.Entity<Review>().HasData(new Review { Id = Guid.NewGuid(), Content = "One of the best i have ever seen", Liked = true, MovieId = Guid.Parse("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541", Author = "Josef Pepík" });
            modelBuilder.Entity<Review>().HasData(new Review { Id = Guid.NewGuid(), Content = "Not bad", Liked = true, MovieId = Guid.Parse("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541", Author = "Josef Pepík" });
            modelBuilder.Entity<Review>().HasData(new Review { Id = Guid.NewGuid(), Content = "Not my cup of tea", Liked = false, MovieId = Guid.Parse("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541", Author = "Josef Pepík" });
            modelBuilder.Entity<Review>().HasData(new Review { Id = Guid.NewGuid(), Content = "Timeless classic!", Liked = true, MovieId = Guid.Parse("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541", Author = "Josef Pepík" });
            modelBuilder.Entity<Review>().HasData(new Review { Id = Guid.NewGuid(), Content = "Enjoyed, but could have been way better. Too much death! Think of the children!!", Liked = true, MovieId = Guid.Parse("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541", Author = "Josef Pepík" });
            modelBuilder.Entity<Review>().HasData(new Review { Id = Guid.NewGuid(), Content = "Crazy good!!!", Liked = true, MovieId = Guid.Parse("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541", Author = "Josef Pepík" });
            modelBuilder.Entity<Review>().HasData(new Review { Id = Guid.NewGuid(), Content = "Amazing", Liked = true, MovieId = Guid.Parse("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541", Author = "Josef Pepík" });
            modelBuilder.Entity<Review>().HasData(new Review { Id = Guid.NewGuid(), Content = "WOW", Liked = true, MovieId = Guid.Parse("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541", Author = "Josef Pepík" });
            modelBuilder.Entity<Review>().HasData(new Review { Id = Guid.NewGuid(), Content = "Really good", Liked = true, MovieId = Guid.Parse("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541", Author = "Josef Pepík" });
            modelBuilder.Entity<Review>().HasData(new Review { Id = Guid.NewGuid(), Content = "Enjoyed!", Liked = true, MovieId = Guid.Parse("d0bb1f7e-6bff-4b26-9d3b-9f013acb72a6"), UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541", Author = "Josef Pepík" });
            
            modelBuilder.Entity<Review>().HasData(new Review { Id = Guid.NewGuid(), Content = "Enjoyed!", Liked = true, MovieId = Guid.Parse("891c93d7-8120-485b-80a7-f31691613a88"), UserId = "b4f3317a-2d1a-4c0e-9f58-5359d9a74541", Author = "Josef Pepík" });

        }
    }
}
