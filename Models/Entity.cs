using Microsoft.EntityFrameworkCore;

namespace Task_Rubikans.Models
{
    public class Entity:DbContext
    {
        public Entity()
        { }
        public Entity(DbContextOptions options):base(options)
        { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Inventory> Inventories { get; set;}
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemTransaction> ItemTransactions { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-EIFLNP4;Initial Catalog=Task_Rubikans;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

     


    }
}
