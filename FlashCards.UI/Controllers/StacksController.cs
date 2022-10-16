using FlashCards.Backend.Entities;
using FlashCards.Backend.Services.Interfaces;
using FlashCards.UI.Menus.Interfaces;

namespace FlashCards.UI.Controllers;

public class StacksController
{
    private readonly IStackService _stackService;
    private readonly IMenus _menus;

    public StacksController(IStackService stackService, IMenus menus)
    {
        _stackService = stackService;
        _menus = menus;
    }

    public string ShowStackOperationsMenu()
    {
        Console.WriteLine("0 - To go back");
        Console.WriteLine("C - To create new Stack");
        Console.WriteLine("D - To delete Stack");
        Console.WriteLine("R - To rename Stack");
        Console.WriteLine("F - To manage stack Flash Cards");

        return Console.ReadLine().ToUpper();
    }

    public Stack ChooseStackMenu()
    {
        var isMatch = true;
        var stacks = _stackService.GetStacks();
        Console.WriteLine("|-------------Stack Name-------------|");
        foreach (var stack in stacks)
        {
            Console.WriteLine("+------------------------------------+");
            Console.WriteLine($"|     {stack.Name, 18}             |");
        }

        while (isMatch)
        {
            Console.WriteLine("");
            Console.Write("Input a current stack name: ");
            var result = Console.ReadLine();
            if (stacks.Any(x => x.Name == result))
            {
                return stacks.SingleOrDefault(x => x.Name == result);
            }

            if (result == "0")
            {
                return null;
            }

            Console.WriteLine("Please Verify the name");
        }

        return null;
    }

    public void DeleteStack()
    {
        var stack = ChooseStackMenu();

        Console.WriteLine($"Are you sure to delete stack: {stack.Name}");
        Console.WriteLine("");
        Console.WriteLine($"Y - Yes");
        Console.WriteLine($"N - NO");

        while (true)
        {
            var answer = Console.ReadLine().ToUpper();

            switch (answer)
            {
                case "Y":
                    _stackService.DeleteStack(stack.Id);
                    return;
                case "N":
                    return;
                default:
                    Console.WriteLine("Please check answer");
                    continue;
            }
        }
    }

    public void CreateStack()
    {
        var stack = new Stack();

        while (true)
        {
            Console.Write("Enter Stack Name: ");

            stack.Name = Console.ReadLine();

            Console.WriteLine("Are you sure you want to create a stack with this information: ");

            Console.WriteLine("");
            Console.WriteLine($"Name: {stack.Name}");
            Console.WriteLine("");

            Console.WriteLine("Y - Yes");
            Console.WriteLine("N - No");
            Console.WriteLine("");

            var result = Console.ReadLine().ToUpper();

            switch (result)
            {
                case "Y":
                    var isSucess = _stackService.Create(stack);
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

                case "N":
                    return;

                default:
                    Console.WriteLine("Please check your input");
                    continue;
            }
        }
    }

    public void UpdateStack()
    {
        var stack = ChooseStackMenu();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter new Stack Name: ");
        Console.ForegroundColor = ConsoleColor.White;

        var newName = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Are you sure you want to rename stack: {stack.Name} to {newName} ?");
        Console.WriteLine("");

        Console.WriteLine("Y - Yes");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("N - No");
        Console.ForegroundColor = ConsoleColor.White;

        while (true)
        {
            var answer = Console.ReadLine().ToUpper();

            switch (answer)
            {
                case "Y":
                    stack.Name = newName;
                    _stackService.UpdateStack(stack);
                    return;
                case "N":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Operation Cancelled");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error!! Please Verify your Input");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
            }
        }

    }
}