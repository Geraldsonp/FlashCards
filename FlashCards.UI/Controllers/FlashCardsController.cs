using FlashCards.Backend.Entities;
using FlashCards.Backend.Services.Interfaces;
using FlashCards.UI.Menus.Interfaces;
using Sharprompt;

namespace FlashCards.UI.Controllers;

public class FlashCardsController
{
    private readonly IFlashCardService _flashCardService;
    private readonly IMenus _menus;

    public FlashCardsController(IFlashCardService flashCardService, IMenus menus)
    {
        _flashCardService = flashCardService;
        _menus = menus;
    }

    public string? ShowFlashCardsMenu(Stack stackName)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("+--------------------------------------+");
        Console.WriteLine($"Current working stack: {stackName.Name}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("");
        Console.WriteLine("0 to return to main menu");
        Console.WriteLine("X to change current stack");
        Console.WriteLine("DS to delete current stack");
        Console.WriteLine("V to view all flashcards in stack");
        Console.WriteLine("A to view X amount of cards in stack");
        Console.WriteLine("C to Create a FlashCard in current stack");
        Console.WriteLine("E to Edit a FlashCard in current stack");
        Console.WriteLine("D to Delete a FlashCard in current stack");
        Console.WriteLine("+--------------------------------------+");

        return Console.ReadLine();
    }

    private void DisplayCards(IEnumerable<FlashCard> cards, string stackName)
    {
        Console.WriteLine($"+----------{stackName.PadLeft(20, '-')}---------------+");
        Console.WriteLine($"|{"Id", -3} {"|", -5}{"Front", -15}{"|", -5} {"Back", -15}{"|", -5}");
        Console.WriteLine($"+--------------------------------------------------+");
        foreach (var card in cards)
        {
            Console.WriteLine($"|{card.Id, -3} {"|", -5}{card.Front, -15}{"|", -5}{card.Back, -15} {"|", -5}");
            Console.WriteLine($"+----------------------------------------------------+");
        }
        Console.WriteLine($"");
    }


    public void ShowFlashCard(Stack selectedStack, int? amount = null)
    {
        if (amount is null)
        {
            var flashCards = _flashCardService.GetFlashCards(selectedStack.Id);
            DisplayCards(flashCards, selectedStack.Name);
        }
        else
        {
            var flashCards = _flashCardService.GetFlashCards(selectedStack.Id).Take(amount.Value);
            DisplayCards(flashCards, selectedStack.Name);
        }

    }

    public void CreateCard(Stack selectedStack)
    {
        Console.Clear();
        Console.WriteLine($"+----+-----------{selectedStack.Name}-----------+----+");
        Console.WriteLine("-------------------Creating New Card--------------------");
        var card = new FlashCard();
        Console.Write("Enter Card Front: ");
        card.Front = Console.ReadLine();
        Console.Write("Enter Card Back: ");
        card.Back = Console.ReadLine();
        card.StackId = selectedStack.Id;

        _flashCardService.AddFlashCard(card);

    }

    public void EditCard(Stack selectedStack)
    {
        var isCardSelected = true;
        var cardId = 0 ;
        var cards = _flashCardService.GetFlashCards(selectedStack.Id);
        DisplayCards(cards, selectedStack.Name);

        while (isCardSelected)
        {
            cardId = Int32.Parse(Console.ReadLine()!);

            if (cards.Any(x => x.Id == cardId))
            {
                isCardSelected = false;
                break;
            }
            Console.WriteLine("Please Try Again id is not correct");
        }

        var card = _flashCardService.GetFlashCard(cardId);

        Console.WriteLine($"Front:{card.Front} Front:{card.Back}");

        Console.WriteLine($"1 - Update Front; 2 - Update back;");

        var input = Console.ReadLine();

        switch (input)
        {
            case "1" :
                Console.Write("Enter Card Front: ");
                card.Front = Console.ReadLine();
                break;
            case "2" :
                Console.Write("Enter Card Back: ");
                card.Back = Console.ReadLine();
                break;
        }

        _flashCardService.UpdateFlashCard(card);

    }

    public void DeleteCard(Stack selectedStack)
    {
        var cards = _flashCardService.GetFlashCards(selectedStack.Id);

        DisplayCards(cards, selectedStack.Name);

        Console.Write("Please enter a card Id to delete it:");

        var isCardSelected = true;
        int cardId = 0;

        while (isCardSelected)
        {
            cardId = Int32.Parse(Console.ReadLine()!);

            if (cards.Any(x => x.Id == cardId))
            {
                break;
            }
            Console.WriteLine("Please Try Again Id is not correct");
        }

        Console.WriteLine($"Are you sure you want to delete card id:{cardId}");
        Console.WriteLine("Y - Yes");
        Console.WriteLine("N - No");

        var response = Console.ReadLine().ToUpper();

        if (response == "Y")
        {
            _flashCardService.DeleteFlashCard(cardId);
            Console.WriteLine("Card Deleted");
        }else if (response == "N")
        {
            Console.WriteLine("Please try again with Another Card");
        }
    }

    public void StartStudySession()
    {
        Console.WriteLine("Please Enter the other side of the card");
        var rnd = new Random();
        var cards = _flashCardService.GetStudySessionCards().OrderBy(x => rnd.Next());
        foreach (var card in cards.ToList())
        {
            var answers = cards.Select(x => x.Back)
                .OrderBy(x => rnd.Next())
                .Where(x => x != card.Back)
                .Take(3).ToList();

            answers.Add(card.Back);
            var orderedAnswers = answers.OrderByDescending(x => rnd.Next()).ToList();

            Prompt.Select(card.Front, orderedAnswers);
            //Todo: Continue with points and strikes logic
        }
    }
}