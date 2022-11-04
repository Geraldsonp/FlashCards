using FlashCards.Backend.Entities;

namespace FlashCards.Backend.Services.Interfaces;

public interface IStudySession
{
    IEnumerable<FlashCard> StartSession();
    void FinishSession(IEnumerable<FlashCard> cards);
}