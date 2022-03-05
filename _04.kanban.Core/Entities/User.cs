using System.Text.Json.Serialization;

namespace kanban.Core.Entities
{
    public partial class User
    {
        public long UseId { get; set; }
        public string UseName { get; set; } = null!;
        public string UseEmail { get; set; } = null!;
        public DateTime UseCreateDate { get; set; }

        [JsonIgnore]
        public string UsePassword { get; set; } = null!;

        public virtual ICollection<Board> Boards { get; set; }
        public virtual ICollection<Card> Cards { get; set; }

        public virtual ICollection<Card> Crds { get; set; }
    }
}
