using FlashCards.Backend.Entities;
using FlashCards.Backend.Services.Interfaces;
using FlashCards.UI.Controllers;
using FlashCards.UI.Menus.Interfaces;

namespace FlashCards.UI;

public class App
{
    private readonly StacksController _stacksController;
    private readonly FlashCardsController _flashCardsController;

    //Todo: remove what is not being used
    public App(IMenus menus, IFlashCardService flashCardService, IStackService stackService,
        StacksController stacksController, FlashCardsController flashCardsController)
    {
        _stacksController = stacksController;
        _flashCardsController = flashCardsController;
    }

    public void Run()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Welcome to Cards Rain");
        Console.WriteLine("Where you can create sets of cards to forge them in your brain");
        Console.ForegroundColor = ConsoleColor.White;
        while (true)
        {
            ShowMainMenu();
            var result = Console.ReadLine();
            switch (result.ToUpper())
            {
                case "0":
                    Console.WriteLine("Have a good One");
                    return;
                case "S":
                    ManageStacks();
                    break;
                case "F":
                    ManageFlashCards();
                    break;
                case "R":
                    Console.WriteLine("Study");
                    break;
                case "L":
                    Console.WriteLine("View Study session data");
                    break;
            }
        }
    }

    private void ManageStacks()
    {
        //Todo: Complete This Section
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("------------Manage Stacks------------");
        Console.ForegroundColor = ConsoleColor.White;
        var continueManageStack = true;
        while (continueManageStack)
        {
            var answer = _stacksController.ShowStackOperationsMenu();

            switch (answer)
            {
                case "0":
                    return;
                case "C":
                    _stacksController.CreateStack();
                    break;
                case "D":
                    _stacksController.DeleteStack();
                    break;
                case "R":
                    _stacksController.UpdateStack();
                    break;
                case "F":
                    ManageFlashCards();
                    break;
                default: continue;
            }
        }
    }

    private void ManageFlashCards()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("------------Manage Flash Cards------------");
        Console.ForegroundColor = ConsoleColor.White;

        var selectedStack = _stacksController.ChooseStackMenu();

        var doContinue = true;

        while (doContinue)
        {
            var result = _flashCardsController.ShowFlashCardsMenu(selectedStack);
            switch (result)
            {
                case "0":
                    return;
                case "X":
                    selectedStack = _stacksController.ChooseStackMenu();
                    continue;
                case "V":
                    _flashCardsController.ShowFlashCard(selectedStack);
                    continue;
                case "A":
                    Console.WriteLine("Enter Amount");
                    var amount = Console.ReadLine();
                    _flashCardsController.ShowFlashCard(selectedStack, Int32.Parse(amount));
                    continue;
                case "C":
                    _flashCardsController.CreateCard(selectedStack);
                    continue;
                case "E":
                    _flashCardsController.EditCard(selectedStack);
                    continue;
                case "D":
                    _flashCardsController.DeleteCard(selectedStack);
                    continue;
            }
        }
    }

    public void ShowMainMenu()
    {
        Console.WriteLine("______________________________");
        Console.WriteLine("0 to exit");
        Console.WriteLine("S to Manage Stacks");
        Console.WriteLine("F to Manage FlashCards");
        Console.WriteLine("R to Study");
        Console.WriteLine("L to View Study session data");
        Console.WriteLine("______________________________");
    }
}