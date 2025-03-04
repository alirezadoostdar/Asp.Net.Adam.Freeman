using Microsoft.EntityFrameworkCore;

namespace LanguageFeatures.Models
{
    public class ApplicationDbContext
    {
        public DbSet<User> Users { get;  set; }
    }

    public class User
    {

    }
}