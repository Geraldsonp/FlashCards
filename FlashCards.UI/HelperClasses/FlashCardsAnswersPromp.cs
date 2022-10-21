namespace FlashCards.UI.HelperClasses;

public class FlashCardsAnswersPromp
{
    private string CorrectAnswer { get; set; }
    private string FakeAnswer1 { get; set; }
    private string FakeAnswer2 { get; set; }
    private string FakeAnswer3 { get; set; }


    public FlashCardsAnswersPromp(string validAnswer, string[] fakeAnswers)
    {
        CorrectAnswer = validAnswer;
        FakeAnswer1 = fakeAnswers[0];
        FakeAnswer2 = fakeAnswers[1];
        FakeAnswer3 = fakeAnswers[2];
    }

}