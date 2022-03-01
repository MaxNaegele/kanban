namespace kanban.Core.Entities
{
    public partial class Status
    {   
        public long SttId { get; set; }
        public string SttDescription { get; set; } = null!;
        public string SttColor { get; set; } = null!;

        public virtual ICollection<Card> Cards { get; set; }
    }
}
