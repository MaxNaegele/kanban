using System;
using System.Collections.Generic;

namespace kanban.Core.Entities
{
    public partial class User
    {
        public User()
        {
            Boards = new HashSet<Board>();
            Cards = new HashSet<Card>();
            Crds = new HashSet<Card>();
        }

        public long UseId { get; set; }
        public string UseName { get; set; } = null!;
        public string UseEmail { get; set; } = null!;
        public DateTime UseCreateDate { get; set; }
        public string UsePassword { get; set; } = null!;

        public virtual ICollection<Board> Boards { get; set; }
        public virtual ICollection<Card> Cards { get; set; }

        public virtual ICollection<Card> Crds { get; set; }
    }
}
