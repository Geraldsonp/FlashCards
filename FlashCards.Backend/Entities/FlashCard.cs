namespace FlashCards.Backend.Entities;

public class FlashCard
{
    public int Id { get; set; }

    public string? Front { get; set; }

    public string? Back { get; set; }

    public DateTime LastStudied { get; set; }

    public int LastScore { get; set; }

    public DateTime ShownAt { get; set; }

    public DateTime AnsweredAt { get; set; }
    public int StackId { get; set; }
}