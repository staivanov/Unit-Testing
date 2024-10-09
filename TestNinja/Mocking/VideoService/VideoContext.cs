using System.Data.Entity;

namespace TestNinja.Mocking
{
    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}