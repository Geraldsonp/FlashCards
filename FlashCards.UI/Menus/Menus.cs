using FlashCards.Backend.Entities;
using FlashCards.UI.Menus.Interfaces;
using FlashCards.UI.MenusOptionsEnums;
using Sharprompt;
using Spectre.Console;

namespace FlashCards.UI.Menus;

public class Menus : IMenus
{
    public MainMenuOptions ShowMainMenu()
    {
        return Prompt.Select<MainMenuOptions>("Select an option");
    }

    public StackOperationsOptions ShowStackOperationsMenu()
    {
        return Prompt.Select<StackOperationsOptions>("Select an option");
    }

    public YesOrNo YesOrNoPrompt()
    {
        return Prompt.Select<YesOrNo>("Select an option");
    }

    public void BuildTable<T>(IEnumerable<T> listItems)
    {
        var table = new Table();

        foreach (var stack in listItems)
        {
            var propsValues = new List<string>();
            if (!table.Columns.Any())
            {
                foreach (var prop in stack.GetType().GetProperties())
                {
                    table.AddColumn(new TableColumn($"[yellow]{prop.Name}[/]").Centered().Width(15));
                }
            }

            foreach (var prop in stack.GetType().GetProperties())
            {
                propsValues.Add(prop.GetValue(stack, null).ToString());
            }

            table.AddRow(propsValues.ToArray());
        }

        AnsiConsole.Write(table);
    }

    public void ShowManageCards(string name)
    {
    }

    public string ChooseByNameMenu(IEnumerable<string> options, string modelName)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>($"[green]Please the name of a {modelName}[/]")
                .PromptStyle("blue")
                .ValidationErrorMessage($"[red]That is not a valid {modelName} name[/]")
                .Validate(name =>
                {
                    if (options.Any(x => x == name))
                    {
                        return ValidationResult.Success();
                    }
                    else
                    {
                        return ValidationResult.Error($"[red]That is no a valid {modelName} name[/]");
                    }
                }));
    }
}