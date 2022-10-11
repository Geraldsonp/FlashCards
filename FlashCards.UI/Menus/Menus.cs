using FlashCards.Backend.Entities;
using FlashCards.UI.Menus.Interfaces;

namespace FlashCards.UI.Menus;

public class Menus : IMenus
{
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

    public void ShowSelectStack(IEnumerable<Stack> stacks)
    {
        //Chose Stack Menu
        Console.WriteLine("+-------------+");
        Console.WriteLine("|     Name    |");
        Console.WriteLine("+-------------+");
        Console.WriteLine("");
        foreach (var stack in stacks)
        {
            Console.WriteLine("+-------------+");
            Console.WriteLine($"| {stack.Name} |");
            Console.WriteLine("+-------------+");
        }
        Console.WriteLine("");
        Console.WriteLine("Choose a stack of flashCards to interact with");
        Console.WriteLine("");
        Console.WriteLine("+---------------------------+");
        Console.WriteLine("Input a current stack name");
        Console.WriteLine("Or input 0 to exit input");
        Console.WriteLine("+---------------------------+");
    }

    public void ShowManageCards(string name)
    {
        //When Stack is selected

    }
}