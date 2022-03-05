using _04.kanban.Core.ModelView.Departament;
using _04.kanban.Core.ModelView.Status;
using _04.kanban.Core.ModelView.User;
using kanban.Core.Entities;
namespace _04.kanban.Core.ModelView.Card
{
    public class CardView
    {
        public long GrpId { get; set; }
        public int CrdSequence { get; set; }
        public string CrdTitle { get; set; } = null!;
        public string? CrdDescription { get; set; }
        public DateTime? CrdExpectedDate { get; set; }
        public string CrdEstimatedTime { get; set; }
        public string? CrdBalanceTime { get; set; }
        public StatusView Stt { get; set; }
        public  ICollection<DepartamentView> Dpts { get; set; }
        public  ICollection<DataUserView> Uses { get; set; }
    }
}