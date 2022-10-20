using FlashCards.Backend.Entities;

namespace FlashCards.Backend.Services.Interfaces;

public interface IStudySession
{
    IEnumerable<FlashCard> StartSession(int stackId);
    void FinishSession(IEnumerable<FlashCard> cards);
}