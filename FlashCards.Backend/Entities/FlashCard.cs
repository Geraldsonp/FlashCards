namespace FlashCards.Backend.Entities;

public class FlashCard
{
    public int Id { get; set; }

    public string? CardFront { get; set; }

    public string? CardBack { get; set; }
    public int StackId { get; set; }
}