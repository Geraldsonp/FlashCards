using FlashCards.Backend.Entities;

namespace FlashCards.Backend.Contracts;

public interface IFlashCardRepository
{
    void Create(FlashCard card);

    void Update(FlashCard card);

    void Delete(int cardId);

    FlashCard Get(int cardId);

    IEnumerable<FlashCard> GetAll(int stackId);
}