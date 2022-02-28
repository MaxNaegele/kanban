using kanban.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _04.kanban.Core.Maps
{
    public static class UserMap
    {
        public static void Configure(this EntityTypeBuilder<User> entity)
        {

            entity.HasKey(e => e.UseId)
                .HasName("pk_users");

            entity.ToTable("users");

            entity.Property(e => e.UseId).HasColumnName("use_id");

            entity.Property(e => e.UseCreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("use_create_date");

            entity.Property(e => e.UseEmail)
                .HasMaxLength(100)
                .HasColumnName("use_email");

            entity.Property(e => e.UseName)
                .HasMaxLength(50)
                .HasColumnName("use_name");

            entity.Property(e => e.UsePassword)
                .HasMaxLength(100)
                .HasColumnName("use_password");

            entity.HasMany(d => d.Crds)
                .WithMany(p => p.Uses)
                .UsingEntity<Dictionary<string, object>>(
                    "Team",
                    l => l.HasOne<Card>().WithMany().HasForeignKey("CrdId").OnDelete(DeleteBehavior.Restrict).HasConstraintName("fk_team_reference_card"),
                    r => r.HasOne<User>().WithMany().HasForeignKey("UseId").OnDelete(DeleteBehavior.Restrict).HasConstraintName("fk_team_reference_users"),
                    j =>
                    {
                        j.HasKey("UseId", "CrdId").HasName("pk_team");

                        j.ToTable("team");

                        j.IndexerProperty<long>("UseId").HasColumnName("use_id");

                        j.IndexerProperty<long>("CrdId").HasColumnName("crd_id");
                    });
        }
    }
}