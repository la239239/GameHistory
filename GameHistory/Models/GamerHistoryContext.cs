using Microsoft.EntityFrameworkCore;

namespace GameHistory.Models
{
    // DbContext pour gérer la base GamerHistoryDB
    // Conforme à l'examen : utilisation EF Core avec SDK .NET 8
    public class GamerHistoryContext : DbContext
    {
        public GamerHistoryContext(DbContextOptions<GamerHistoryContext> options) : base(options) { }

        // DbSet pour chaque table
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Support> Supports { get; set; }
        public DbSet<UserGameHistory> UserGameHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Table Users
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Pseudo)
                .IsUnique();

            // Table Games
            modelBuilder.Entity<Game>()
                .Property(g => g.EstimatedTime)
                .IsRequired();

            // Relation N:N entre Games et Supports via GameSupports
            modelBuilder.Entity<Game>()
                .HasMany<Support>()
                .WithMany()
                .UsingEntity(j => j.ToTable("GameSupports"));

            // Table UserGameHistory : FK User et Game
            modelBuilder.Entity<UserGameHistory>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(ugh => ugh.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserGameHistory>()
                .HasOne<Game>()
                .WithMany()
                .HasForeignKey(ugh => ugh.GameId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}