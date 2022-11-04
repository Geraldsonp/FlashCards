using FlashCards.Backend.Entities;
using FlashCards.Backend.Services.Interfaces;

namespace FlashCards.Backend.Services;

public class StudySessionService: IStudySession
{
    private readonly IFlashCardService _flashCardService;

    public StudySessionService(IFlashCardService flashCardService)
    {
        _flashCardService = flashCardService;
    }
    public IEnumerable<FlashCard> StartSession()
    {
        var cards = _flashCardService.GetStudySessionCards()
            .OrderBy(x => x.LastScore)
            .ThenBy(x => x.LastStudied)
            .Take(5);
        return cards;
    }

    public void FinishSession(IEnumerable<FlashCard> cards)
    {
        foreach (var flashCard in cards)
        {
            var timeSpan = flashCard.AnsweredAt - flashCard.ShownAt;
            var result = 15 - timeSpan.TotalSeconds;
            flashCard.LastStudied = DateTime.UtcNow;
            if (result > 15)
            {
                flashCard.LastScore = 0;
            }else if (result < 15 && result > 10)
            {
                flashCard.LastScore = 5;
            }else if (result < 10 && result > 7)
            {
                flashCard.LastScore = 4;
            }else if (result < 7 && result > 4)
            {
                flashCard.LastScore = 3;
            }
            else
            {
                flashCard.LastScore = 1;
            }
        }

        _flashCardService.UpdateFlashCards(cards);
    }
}