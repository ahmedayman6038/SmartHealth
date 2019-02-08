using Microsoft.Extensions.Configuration;
using SmartHealth.Helper;
using SmartHealth.Models;
using System.Linq;

namespace SmartHealth.Data
{
    public static class DbInitializer
    {
       
        public static void Initialize(HealthContext context, IConfiguration configuration)
        {
            context.Database.EnsureCreated();

            if (context.Admins.Any())
            {
                return;
            }

            var name = configuration["MyConfig:AdminName"];
            var password = configuration["MyConfig:AdminPassword"];
            var email = configuration["MyConfig:AdminEmail"];

            var admin = new Admin
            {
                Name = name,
                Email = email,
                Password = Encrypt.EncryptString(password),
            };

            context.Users.Add(admin);
            context.SaveChanges();
        }
    }
}
