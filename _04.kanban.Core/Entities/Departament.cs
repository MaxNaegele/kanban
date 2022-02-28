using System;
using System.Collections.Generic;

namespace kanban.Core.Entities
{
    public partial class Departament
    {
        public Departament()
        {
            Crds = new HashSet<Card>();
        }

        public long DptId { get; set; }
        public string DptName { get; set; } = null!;
        public DateTime DptCreateDate { get; set; }

        public virtual ICollection<Card> Crds { get; set; }
    }
}
