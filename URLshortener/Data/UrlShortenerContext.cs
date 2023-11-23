using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using URLshortener.Entities;

namespace URLshortener.Data
{
    public class UrlShortenerContext : DbContext
    {
        public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options) : base(options) 
        { 

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Url> Urls { get; set; }
    }
}
