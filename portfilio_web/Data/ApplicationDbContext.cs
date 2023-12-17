using Microsoft.EntityFrameworkCore;
using portfilio_web.Models;

namespace portfilio_web.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<UserMessage> UserMessages { get; set; }

    }

   

}
