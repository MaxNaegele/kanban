namespace kanban.Core.Entities
{
    public partial class Group
    {
        public long GrpId { get; set; }
        public long BrdId { get; set; }
        public string GrpTitle { get; set; } = null!;
        public DateTime GrpCreateDate { get; set; }
        public int GrpSequence { get; set; }

        public virtual Board Brd { get; set; } = null!;
        public virtual ICollection<Card> Cards { get; set; }
    }
}
