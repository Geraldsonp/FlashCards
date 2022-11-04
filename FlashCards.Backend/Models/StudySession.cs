namespace FlashCards.Backend.Entities;

public class StudySession
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public int Score { get; set; }
    public int StackId { get; set; }

}