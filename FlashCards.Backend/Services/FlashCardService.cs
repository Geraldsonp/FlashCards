using FlashCards.Backend.Contracts;
using FlashCards.Backend.DataAccess;
using FlashCards.Backend.Entities;
using FlashCards.Backend.Services.Interfaces;

namespace FlashCards.Backend.Services;

public class FlashCardService : IFlashCardService
{
    private readonly IDatabase _repository;
    public FlashCardService()
    {
        _repository = new Database();
    }
    public IEnumerable<FlashCard> GetFlashCards(int stackId)
    {
        return _repository.FlashCards.GetAll(stackId);
    }

    public IEnumerable<FlashCard> GetStudySessionCards()
    {
        var cards = _repository.FlashCards.GetAll()
            .OrderBy(x => x.LastStudied)
            .ThenBy(x => x.LastScore)
            .Take(15);

        return cards;
    }

    public FlashCard GetFlashCard(int id)
    {
        return _repository.FlashCards.Get(id);
    }

    public void DeleteFlashCard(int cardId)
    {
        _repository.FlashCards.Delete(cardId);
    }

    public FlashCard UpdateFlashCard(FlashCard flashCard)
    {
        _repository.FlashCards.Update(flashCard);
        Console.WriteLine($"New Card Info: Front: {flashCard.Front} - Back: {flashCard.Back}");
        return flashCard;
    }

    public void AddFlashCard(FlashCard card)
    {

        _repository.FlashCards.Create(card);
        Console.WriteLine("Added");
    }

    public void UpdateFlashCards(IEnumerable<FlashCard> cards)
    {
       _repository.FlashCards.Update(cards);
    }
}