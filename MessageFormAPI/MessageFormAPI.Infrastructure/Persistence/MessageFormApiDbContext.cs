using MessageFormApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace MessageFormApi.Infrastructure.Persistence
{
    public class MessageFormApiDbContext : DbContext
    {
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public MessageFormApiDbContext(DbContextOptions<MessageFormApiDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка связей и ограничений
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Theme)
                .WithMany(t => t.Messages)
                .HasForeignKey(m => m.ThemeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Contact)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ContactId)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }
    }
}