using kanban.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _04.kanban.Core.Maps
{
    public static class StatusMap
    {
        public static void Configure(this EntityTypeBuilder<Status> entity)
        {
            entity.HasKey(e => e.SttId)
                .HasName("pk_status");

            entity.ToTable("status");

            entity.Property(e => e.SttId).HasColumnName("stt_id");

            entity.Property(e => e.SttColor)
                .HasMaxLength(15)
                .HasColumnName("stt_color");

            entity.Property(e => e.SttDescription)
                .HasMaxLength(30)
                .HasColumnName("stt_description");
        }
    }
}