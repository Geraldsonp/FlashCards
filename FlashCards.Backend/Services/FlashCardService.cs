using FlashCards.Backend.Entities;
using FlashCards.Backend.Services.Interfaces;

namespace FlashCards.Backend.Services;

public class FlashCardService : IFlashCardService
{
    public IEnumerable<FlashCard> GetFlashCards()
    {
        return new[]
        {
            new FlashCard()
            {
                Id = 1,
                Name = "Waseqpwoe",
                StackId = 1,
                CardFront = "Testing",
                CardBack = "testing back"
            }
        };
    }

    public FlashCard GetFlashCard(int id)
    {
        return new FlashCard()
        {
            Id = 1,
            Name = "Waseqpwoe"
        };
    }

    public void DeleteFlashCard()
    {
        Console.WriteLine("Deleted");
    }

    public FlashCard UpdateFlashCard(FlashCard flashCard)
    {
        Console.WriteLine($"New Card Info: Front:{flashCard.CardFront} - Bad:{flashCard.CardBack}");
        return flashCard;
    }

    public void AddFlashCard(FlashCard card)
    {
        Console.WriteLine("Added");
    }
}