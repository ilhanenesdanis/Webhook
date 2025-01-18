using Microsoft.EntityFrameworkCore;

namespace Webhook.API.Models
{
    public sealed class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<WebhookSubscrition> Webhooks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(x => x.id);
            modelBuilder.Entity<Order>().Property(x => x.customerName).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Order>().Property(x => x.amount).IsRequired();
            modelBuilder.Entity<Order>().Property(x => x.createdDate).IsRequired();
        }
    }
}
