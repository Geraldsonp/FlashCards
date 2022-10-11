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

    public FlashCard GetFlashCard()
    {
        return new FlashCard()
        {
            Id = 1,
            Name = "Waseqpwoe"
        };
    }

    public void DeleteFlashCard()
    {
        throw new NotImplementedException();
    }

    public FlashCard UpdateFlashCard()
    {
        throw new NotImplementedException();
    }

    public void AddFlashCard(FlashCard card)
    {
        throw new NotImplementedException();
    }
}