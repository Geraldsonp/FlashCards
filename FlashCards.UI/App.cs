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
    private readonly StacksManager _stacksManager;
    private readonly FlashCardsManager _flashCardsManager;

    public App(IMenus menus, IFlashCardService flashCardService, IStackService stackService,
        StacksManager stacksManager, FlashCardsManager flashCardsManager)
    {
        _menus = menus;
        _flashCardService = flashCardService;
        _stackService = stackService;
        _stacksManager = stacksManager;
        _flashCardsManager = flashCardsManager;
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
            var stack = _stacksManager.SelectStack();
            if (stack is null)
            {
                return;
            }
            _stacksManager.UpdateOrDeleteStack(stack);
        }
    }

    private void ManageFlashCards()
    {
        var selectedStack = _stacksManager.SelectStack();

        var isTrue = true;
        while (isTrue)
        {
            var result = _flashCardsManager.ShowFlashCardsMenu(selectedStack);
            switch (result)
            {
                case "0":
                    return;
                case "X":
                    selectedStack = _stacksManager.SelectStack();
                    continue;
                case "V":
                    _flashCardsManager.ShowFlashCard(selectedStack);
                    continue;
                case "A":
                    Console.WriteLine("Enter Amount");
                    var amount = Console.ReadLine();
                    _flashCardsManager.ShowFlashCard(selectedStack, Int32.Parse(amount));
                    continue;
                case "C":
                    _flashCardsManager.CreateCard(selectedStack);
                    continue;
                case "E":
                    _flashCardsManager.EditCard(selectedStack);
                    continue;
                case "D":
                    _flashCardsManager.DeleteCard(selectedStack);
                    continue;
            }
        }


    }
}