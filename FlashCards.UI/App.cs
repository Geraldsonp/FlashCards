using FlashCards.Backend.Entities;
using FlashCards.Backend.Services.Interfaces;
using FlashCards.UI.Controllers;
using FlashCards.UI.Menus.Interfaces;

namespace FlashCards.UI;

public class App
{
    private readonly IMenus _menus;
    private readonly IFlashCardService _flashCardService;
    private readonly IStackService _stackService;
    private readonly StacksController _stacksController;
    private readonly FlashCardsController _flashCardsController;

    public App(IMenus menus, IFlashCardService flashCardService, IStackService stackService,
        StacksController stacksController, FlashCardsController flashCardsController)
    {
        _menus = menus;
        _flashCardService = flashCardService;
        _stackService = stackService;
        _stacksController = stacksController;
        _flashCardsController = flashCardsController;
    }

    public void Run()
    {
        _menus.ShowMainMenu();
        var result = Console.ReadLine();
        switch (result.ToUpper())
        {
            case "0":
                Console.WriteLine("Have a good One");
                break;
            case "S":
                ManageStacks();
                Console.WriteLine("Ended in Case S Main menu");
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

    private void ManageStacks()
    {
        var continueManageStack = true;
        while (continueManageStack)
        {
            var stack = _stacksController.SelectStack();
            if (stack is null)
            {
                return;
            }
            _stacksController.UpdateOrDeleteStack(stack);
        }
    }

    private void ManageFlashCards()
    {
        var selectedStack = _stacksController.SelectStack();

        var doContinue = true;

        while (doContinue)
        {
            var result = _flashCardsController.ShowFlashCardsMenu(selectedStack);
            switch (result)
            {
                case "0":
                    return;
                case "X":
                    selectedStack = _stacksController.SelectStack();
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
}