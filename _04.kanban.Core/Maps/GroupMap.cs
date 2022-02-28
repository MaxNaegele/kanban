using kanban.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _04.kanban.Core.Maps
{
    public static class GroupMap
    {
        public static void Configure(this EntityTypeBuilder<Group> entity)
        {

            entity.HasKey(e => e.GrpId)
                .HasName("pk_groups");

            entity.ToTable("groups");

            entity.Property(e => e.GrpId).HasColumnName("grp_id");

            entity.Property(e => e.BrdId).HasColumnName("brd_id");

            entity.Property(e => e.GrpCreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("grp_create_date");

            entity.Property(e => e.GrpSequence).HasColumnName("grp_sequence");

            entity.Property(e => e.GrpTitle)
                .HasMaxLength(60)
                .HasColumnName("grp_title");

            entity.HasOne(d => d.Brd)
                .WithMany(p => p.Groups)
                .HasForeignKey(d => d.BrdId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_groups_reference_board");

        }
    }
}