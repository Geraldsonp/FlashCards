using FlashCards.Backend.Entities;

namespace FlashCards.Backend.Services.Interfaces;

public interface IFlashCardService
{
    public IEnumerable<FlashCard> GetFlashCards(int stackId);
    public FlashCard GetFlashCard(int id);
    public void DeleteFlashCard(int cardId);
    public FlashCard UpdateFlashCard(FlashCard flashCard);
    void AddFlashCard(FlashCard card);
    void UpdateFlashCards(IEnumerable<FlashCard> cards);
}