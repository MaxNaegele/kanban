namespace kanban.Core.Entities
{
    public partial class Card
    {
        public long CrdId { get; set; }
        public long UseId { get; set; }
        public long GrpId { get; set; }
        public long SttId { get; set; }
        public int CrdSequence { get; set; }
        public string CrdTitle { get; set; } = null!;
        public string? CrdDescription { get; set; }
        public DateTime CrdCreateDate { get; set; }
        public DateTime? CrdExpectedDate { get; set; }
        public TimeOnly CrdEstimatedTime { get; set; }
        public TimeOnly? CrdBalanceTime { get; set; }
        public DateTime? CrdUpdateDate { get; set; }

        public virtual Group Grp { get; set; } = null!;
        public virtual Status Stt { get; set; } = null!;
        public virtual User Use { get; set; } = null!;

        public virtual ICollection<Departament> Dpts { get; set; }
        public virtual ICollection<User> Uses { get; set; }
    }
}
