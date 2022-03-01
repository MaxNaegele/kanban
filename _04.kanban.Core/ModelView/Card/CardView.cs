namespace _04.kanban.Core.ModelView.Card
{
    public class CardView
    {        
        public long GrpId { get; set; }
        public long SttId { get; set; }
        public int CrdSequence { get; set; }
        public string CrdTitle { get; set; } = null!;
        public string? CrdDescription { get; set; }
        public DateTime? CrdExpectedDate { get; set; }
        public TimeOnly CrdEstimatedTime { get; set; }
        public TimeOnly? CrdBalanceTime { get; set; }
    }
}