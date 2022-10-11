using FlashCards.Backend.Entities;

namespace FlashCards.Backend.Services.Interfaces;

public interface IFlashCardService
{
    public IEnumerable<FlashCard> GetFlashCards();
    public FlashCard GetFlashCard();
    public void DeleteFlashCard();
    public FlashCard UpdateFlashCard();
    void AddFlashCard(FlashCard card);
}