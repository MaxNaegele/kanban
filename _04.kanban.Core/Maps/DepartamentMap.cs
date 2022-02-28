using kanban.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _04.kanban.Core.Maps
{
    public static class DepartamentMap
    {
        public static void Configure(this EntityTypeBuilder<Departament> entity)
        {
            entity.HasKey(e => e.DptId)
                .HasName("pk_departament");

            entity.ToTable("departament");

            entity.Property(e => e.DptId).HasColumnName("dpt_id");

            entity.Property(e => e.DptCreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dpt_create_date");

            entity.Property(e => e.DptName)
                .HasMaxLength(50)
                .HasColumnName("dpt_name");

            entity.HasMany(d => d.Crds)
                .WithMany(p => p.Dpts)
                .UsingEntity<Dictionary<string, object>>(
                    "TasksDepartament",
                    l => l.HasOne<Card>().WithMany().HasForeignKey("CrdId").OnDelete(DeleteBehavior.Restrict).HasConstraintName("fk_tasks_de_reference_card"),
                    r => r.HasOne<Departament>().WithMany().HasForeignKey("DptId").OnDelete(DeleteBehavior.Restrict).HasConstraintName("fk_tasks_de_reference_departam"),
                    j =>
                    {
                        j.HasKey("DptId", "CrdId").HasName("pk_tasks_departament");

                        j.ToTable("tasks_departament");

                        j.IndexerProperty<long>("DptId").HasColumnName("dpt_id");

                        j.IndexerProperty<long>("CrdId").HasColumnName("crd_id");
                    });
        }
    }
}