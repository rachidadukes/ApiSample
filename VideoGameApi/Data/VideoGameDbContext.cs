using Microsoft.EntityFrameworkCore;


namespace VideoGameApi.Data
{

    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<VideoGame>().HasData(
              new VideoGame
              {
                  Id = 1,
                  Title = "Halo",
                  Platform = "Xbox",
                  Developer = "Bungie",
                  Publisher = "Microsoft"
              },
              new VideoGame
              {
                  Id = 2,
                  Title = "The Legend of Zelda: Breath of the Wild",
                  Platform = "Nintendo Switch",
                  Developer = "Nintendo",
                  Publisher = "Nintendo"
              },
              new VideoGame
              {
                  Id = 3,
                  Title = "Final Fantasy VII",
                  Platform = "PlayStation",
                  Developer = "Square Enix",
                  Publisher = "Square Enix"
              }
            );
        }

    }
   

}
