using FlashCards.Backend.Services.Interfaces;
using FlashCards.UI.Controllers;
using FlashCards.UI.Menus;
using FlashCards.UI.Menus.Interfaces;
using FlashCards.UI.MenusOptionsEnums;
using Spectre.Console;

namespace FlashCards.UI;

public class App
{
    private readonly StacksController _stacksController;
    private readonly FlashCardsController _flashCardsController;
    private readonly IMenus _menus;

    //Todo: remove what is not being used
    public App(StacksController stacksController, FlashCardsController flashCardsController, IMenus menus,
        IStackService stackService)
    {
        _stacksController = stacksController;
        _flashCardsController = flashCardsController;
        _menus = menus;
    }

    public void Run()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Welcome to Cards Rain");
        Console.WriteLine("Where you can create sets of cards to forge them in your brain");
        Console.ForegroundColor = ConsoleColor.White;
        while (true)
        {
            var sectionTitle = new Rule("[red]Main Menu[/]");
            AnsiConsole.Write(sectionTitle);

            var answer = _menus.ShowMainMenu();

            switch (answer)
            {
                case MainMenuOptions.Exit:
                    Console.WriteLine("Have a good One");
                    return;
                case MainMenuOptions.ManageStacks:
                    ManageStacks();
                    break;
                case MainMenuOptions.ManageFlashCards:
                    ManageFlashCards();
                    break;
                case MainMenuOptions.Study:
                    _flashCardsController.StartStudySession();
                    break;
                case MainMenuOptions.ViewStudysessiondata:
                    Console.WriteLine("View Study session data");
                    break;
            }
        }
    }

    private void ManageStacks()
    {
        var title = new Rule("[red]Manage Stacks[/]");
        AnsiConsole.Write(title);
        var continueManageStack = true;
        while (continueManageStack)
        {
            var operationAnswer = _menus.ShowStackOperationsMenu();

            switch (operationAnswer)
            {
                case StackOperationsOptions.GoBack:
                    return;
                case StackOperationsOptions.Create:
                    CreateStack();
                    break;
                case StackOperationsOptions.Delete:
                    DeleteStack();
                    break;
                case StackOperationsOptions.Rename:

                    UpdateStack();
                    break;
                case StackOperationsOptions.ManageCards:
                    ManageFlashCards();
                    break;
                default: continue;
            }
        }
    }

    private void UpdateStack()
    {
        var selectedStack = _stacksController.GetByName();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter new Stack Name: ");
        Console.ForegroundColor = ConsoleColor.White;

        var newName = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Are you sure you want to rename stack: {selectedStack.Name} to {newName} ?");
        Console.WriteLine("");

        var promptAnswer = _menus.YesOrNoPrompt();

        switch (promptAnswer)
        {
            case YesOrNo.Yes:
                selectedStack.Name = newName;
                _stacksController.UpdateStack(selectedStack);
                return;
            case YesOrNo.No:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Operation Cancelled");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error!! Please Verify your Input");
                Console.ForegroundColor = ConsoleColor.White;
                return;
        }
    }


    private void ManageFlashCards()
    {
        var title = new Rule("[red]Manage Stacks[/]");

        AnsiConsole.Write(title);

        var selectedStack = _stacksController.GetByName();

        var doContinue = true;

        while (doContinue)
        {
            var result = _flashCardsController.ShowFlashCardsMenu(selectedStack);

            switch (result)
            {
                case "0":
                    return;
                case "X":
                    selectedStack = _stacksController.GetByName();
                    continue;
                case "V":
                    _flashCardsController.ShowStackFlashCards(selectedStack);
                    continue;
                case "A":
                    Console.WriteLine("Enter Amount");
                    var amount = Console.ReadLine();
                    _flashCardsController.ShowStackFlashCards(selectedStack, Int32.Parse(amount));
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


    private void CreateStack()
    {
        Console.Write("Enter Stack Name: ");

        var name = Console.ReadLine();

        Console.WriteLine("Are you sure you want to create a stack with this information: ");

        Console.WriteLine("");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine("");

        var answer = _menus.YesOrNoPrompt();

        do
        {
            switch (answer)
            {
                case YesOrNo.Yes:
                    var isSucess = _stacksController.CreateStack(name);
                    if (isSucess)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Stack Was Added SuccessFully");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("There was an Error");
                    }

                    return;

                case YesOrNo.No:
                    return;

                default:
                    Console.WriteLine("Please check your input");
                    continue;
            }
        } while (true);
    }

    private void DeleteStack()
    {
        var selectedStack = _stacksController.GetByName();

        Console.WriteLine($"Are you sure to delete stack: {selectedStack.Name}");

        var yesOrNoAnswer = _menus.YesOrNoPrompt();

        switch (yesOrNoAnswer)
        {
            case YesOrNo.Yes:
                _stacksController.DeleteStack(selectedStack);
                return;
            case YesOrNo.No:
                return;
            default:
                Console.WriteLine("Please check answer");
                return;
        }
    }
}