using kanban.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _04.kanban.Core.Maps
{
    public static class CardMap
    {
        public static void Configure(this EntityTypeBuilder<Card> entity)
        {
            entity.HasKey(e => e.CrdId)
                .HasName("pk_card");

            entity.ToTable("card");

            entity.Property(e => e.CrdId).HasColumnName("crd_id");

            entity.Property(e => e.CrdBalanceTime).HasColumnName("crd_balance_time");

            entity.Property(e => e.CrdCreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("crd_create_date");

            entity.Property(e => e.CrdDescription).HasColumnName("crd_description");

            entity.Property(e => e.CrdEstimatedTime).HasColumnName("crd_estimated_time");

            entity.Property(e => e.CrdExpectedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("crd_expected_date");

            entity.Property(e => e.CrdSequence).HasColumnName("crd_sequence");

            entity.Property(e => e.CrdTitle)
                .HasMaxLength(50)
                .HasColumnName("crd_title");

            entity.Property(e => e.CrdUpdateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("crd_update_date");

            entity.Property(e => e.GrpId).HasColumnName("grp_id");

            entity.Property(e => e.SttId).HasColumnName("stt_id");

            entity.Property(e => e.UseId).HasColumnName("use_id");

            entity.HasOne(d => d.Grp)
                .WithMany(p => p.Cards)
                .HasForeignKey(d => d.GrpId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_card_reference_groups");

            entity.HasOne(d => d.Stt)
                .WithMany(p => p.Cards)
                .HasForeignKey(d => d.SttId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_card_reference_status");

            entity.HasOne(d => d.Use)
                .WithMany(p => p.Cards)
                .HasForeignKey(d => d.UseId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_card_reference_users");


        }
    }
}