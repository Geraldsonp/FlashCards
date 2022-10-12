using FlashCards.Backend.Entities;

namespace FlashCards.Backend.Services.Interfaces;

public interface IFlashCardService
{
    public IEnumerable<FlashCard> GetFlashCards();
    public FlashCard GetFlashCard(int id);
    public void DeleteFlashCard();
    public FlashCard UpdateFlashCard(FlashCard flashCard);
    void AddFlashCard(FlashCard card);
}