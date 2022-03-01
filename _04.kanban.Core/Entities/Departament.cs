namespace kanban.Core.Entities
{
    public partial class Departament
    {      
        public long DptId { get; set; }
        public string DptName { get; set; } = null!;
        public DateTime DptCreateDate { get; set; }

        public virtual ICollection<Card> Crds { get; set; }
    }
}
