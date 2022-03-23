using Microsoft.EntityFrameworkCore;
using kanban.Core.Entities;
using _04.kanban.Core.Maps;

namespace _03.kanban.Data.Context
{
    public class kanbanContext : DbContext
    {
        public kanbanContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public virtual DbSet<Board> Boards { get; set; } = null!;
        public virtual DbSet<Card> Cards { get; set; } = null!;
        public virtual DbSet<Departament> Departaments { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Board>().Configure();
            modelBuilder.Entity<Card>().Configure();
            modelBuilder.Entity<Departament>().Configure();
            modelBuilder.Entity<Group>().Configure();
            modelBuilder.Entity<Status>().Configure();
            modelBuilder.Entity<User>().Configure();
        }
    }
}
