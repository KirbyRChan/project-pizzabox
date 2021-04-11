using PizzaBox.Storing;
using PizzaBox.Domain;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Client
{
    public static class Dependencies
    {
        public static IRepository CreateRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PizzaBox.Storing.Entities.PizzaBoxDbContext>();
            optionsBuilder.UseSqlServer("Server=tcp:kirbyrevature.database.windows.net,1433;Initial Catalog=PizzaBoxDb;Persist Security Info=False;User ID=dev;Password=AzureMonkey1994;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var dbContext = new PizzaBox.Storing.Entities.PizzaBoxDbContext(optionsBuilder.Options);
            return new DbRepository(dbContext);
        }
    }
}