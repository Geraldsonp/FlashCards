using FlashCards.Backend.Entities;
using FlashCards.Backend.Services.Interfaces;
using FlashCards.UI.Menus.Interfaces;

namespace FlashCards.UI.Controllers;

public class FlashCardsManager
{
    private readonly IFlashCardService _flashCardService;
    private readonly IMenus _menus;

    public FlashCardsManager(IFlashCardService flashCardService, IMenus menus)
    {
        _flashCardService = flashCardService;
        _menus = menus;
    }

    public string ShowFlashCardsMenu(Stack stackName)
    {
        Console.WriteLine("+--------------------------------------+");
        Console.WriteLine($"Current working stack: {stackName.Name}");
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
        Console.WriteLine($"+----+-----------{stackName}-----------+----+");
        Console.WriteLine($"| Id |    Front       |     Back       |----|");
        Console.WriteLine($"+----+----------------+----------------+----+");
        foreach (var card in cards)
        {
            Console.WriteLine($"| {card.Id} | {card.CardFront}  | {card.CardBack} |----|");
            Console.WriteLine($"+----+----------------+-------------------------+----+");
        }
        Console.WriteLine($"");
        Console.WriteLine($"+----+----------------+-------------------------+----+");
        Console.WriteLine($"Input an Id of a flashCard");
        Console.WriteLine($"Or 0 to exit");
        Console.WriteLine($"+----+----------------+-------------------------+----+");
    }


    public void ShowFlashCard(Stack selectedStack, int? amount = null)
    {
        if (amount is null)
        {
            var flashCards = _flashCardService.GetFlashCards().Where(x => x.StackId == selectedStack.Id);
            DisplayCards(flashCards, selectedStack.Name);
        }
        else
        {
            var flashCards = _flashCardService.GetFlashCards().Where(x => x.StackId == selectedStack.Id).Take(amount.Value);
            DisplayCards(flashCards, selectedStack.Name);
        }

    }

    public void CreateCard(Stack selectedStack)
    {
        Console.WriteLine($"+----+-----------{selectedStack.Name}-----------+----+");
        Console.WriteLine("-------------------Creating New Card--------------------");
        var card = new FlashCard();
        Console.Write("Enter Card Name: ");
        card.Name = Console.ReadLine();
        Console.Write("Enter Card Front: ");
        card.CardFront = Console.ReadLine();
        Console.Write("Enter Card Back: ");
        card.CardBack = Console.ReadLine();
        card.StackId = selectedStack.Id;

        _flashCardService.AddFlashCard(card);

    }

    public void EditCard(Stack selectedStack)
    {
        var isCardSelected = true;
        var cardId = 0;
        var cards = _flashCardService.GetFlashCards().Where(x => x.Id == selectedStack.Id);
        DisplayCards(cards, selectedStack.Name);

        while (isCardSelected)
        {
            cardId = Int32.Parse(Console.ReadLine());
            if (cards.Any(x => x.Id == cardId))
            {
                isCardSelected = false;
            }
            Console.WriteLine("Please Try Again id is not correct");
        }

        var card = _flashCardService.GetFlashCard(cardId);

        Console.Write($"CardFront:{card.CardFront} CardFront:{card.CardBack}");

        Console.Write($"1 - Update Front; 2 - Update back;");
        var input = Console.ReadLine();

        switch (input)
        {
            case "1" :
                Console.Write("Enter Card Front: ");
                card.CardFront = Console.ReadLine();
                break;
            case "2" :
                Console.Write("Enter Card Back: ");
                card.CardBack = Console.ReadLine();
                break;
        }

        _flashCardService.UpdateFlashCard(card);

    }

    public void DeleteCard(Stack selectedStack)
    {
        throw new NotImplementedException();
    }
}