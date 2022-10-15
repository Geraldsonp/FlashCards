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
    public Stack SelectStack()
    {
        Console.Clear();
        var isMatch = true;
        var stacks = _stackService.GetStacks();
        Console.WriteLine("+-------------------+");
        Console.WriteLine("|----Stack Name-----|");
        foreach (var stack in stacks)
        {
            Console.WriteLine("+-------------------+");
            Console.WriteLine($"|{stack.Name, 10}         |");
            Console.WriteLine("+-------------------+");
        }

        while (isMatch)
        {
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

    public void UpdateOrDeleteStack(Stack stack)
    {
        Console.Clear();
        Console.WriteLine("+--------------------------------------+");
        Console.WriteLine($"Current working stack: {stack.Name}");
        Console.WriteLine("");
        Console.WriteLine("0 to return to main menu");
        Console.WriteLine("X to change current stack");
        Console.WriteLine("D to delete current stack");
        Console.WriteLine("R to Change current stack Name");
        Console.WriteLine("+--------------------------------------+");

        var result = Console.ReadLine();

        switch (result)
        {
            case "0":
                return;
            case "X":
                break;
            case "D":
                _stackService.DeleteStack(stack.Id);
                Console.WriteLine("Stack Eliminado");
                return;
            case "R":
                Console.Write("Enter new Stack Name: ");
                var newName = Console.ReadLine();
                stack.Name = newName;
                _stackService.UpdateStack(stack);
                Console.WriteLine($"New stack Name: {stack.Name}");
                return;

        }
    }
}