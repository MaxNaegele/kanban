using kanban.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _04.kanban.Core.Maps
{
    public static class BoardMap
    {
        public static void Configure(this EntityTypeBuilder<Board> entity)
        {
            entity.HasKey(e => e.BrdId)
                .HasName("pk_board");

            entity.ToTable("board");

            entity.Property(e => e.BrdId).HasColumnName("brd_id");

            entity.Property(e => e.BrdCreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("brd_create_date");

            entity.Property(e => e.BrdDescription).HasColumnName("brd_description");

            entity.Property(e => e.BrdName)
                .HasMaxLength(50)
                .HasColumnName("brd_name");

            entity.Property(e => e.UseId).HasColumnName("use_id");

            entity.HasOne(d => d.Use)
                .WithMany(p => p.Boards)
                .HasForeignKey(d => d.UseId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_board_reference_users");
        }
    }
}