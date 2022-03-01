namespace kanban.Core.Entities
{
    public partial class Board
    {
      
        public long BrdId { get; set; }
        public long UseId { get; set; }
        public string BrdName { get; set; } = null!;
        public string? BrdDescription { get; set; }
        public DateTime BrdCreateDate { get; set; }

        public virtual User Use { get; set; } = null!;
        public virtual ICollection<Group> Groups { get; set; }
    }
}
