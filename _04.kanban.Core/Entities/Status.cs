using System;
using System.Collections.Generic;

namespace kanban.Core.Entities
{
    public partial class Status
    {
        public Status()
        {
            Cards = new HashSet<Card>();
        }

        public long SttId { get; set; }
        public string SttDescription { get; set; } = null!;
        public string SttColor { get; set; } = null!;

        public virtual ICollection<Card> Cards { get; set; }
    }
}
