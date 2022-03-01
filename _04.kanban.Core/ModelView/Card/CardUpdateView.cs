namespace _04.kanban.Core.ModelView.Card
{
    public class CardUpdateView : CardView
    {
        public long CrdId { get; set; }
        public DateTime? CrdUpdateDate { get; set; }
    }
}