using FlashCards.Backend.DataAccess;
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
                StackId = 1,
                CardFront = "Testing",
                CardBack = "testing back"
            },
            new FlashCard()
            {
                Id = 2,
                StackId = 1,
                CardFront = "Testing 2",
                CardBack = "testing back 2"
            }
        };
    }

    public FlashCard GetFlashCard(int id)
    {
        return new FlashCard()
        {
            Id = 1,
            CardFront = "Waseqpwoe",
            CardBack = "test"
        };
    }

    public void DeleteFlashCard(int cardId)
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
        var repo = new Database();
        repo.FlashCards.Create(card);
        Console.WriteLine("Added");
    }
}