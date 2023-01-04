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

    public void DeleteStack(Stack selectedStack)
    {
        _stackService.DeleteStack(selectedStack.Id);
    }

    public bool CreateStack(string stackName)
    {
        return _stackService.Create(new Stack()
        {
            Name = stackName
        });
    }

    public void UpdateStack(Stack selectedStack)
    {
        _stackService.UpdateStack(selectedStack);
    }

    public void ShowStacks()
    {
        _menus.BuildTable(_stackService.GetStacks());
    }


    public Stack GetByName()
    {
        ShowStacks();
        var names = _stackService.GetStacks().Select(x => x.Name);
        var selected = _menus.ChooseByNameMenu(names, "Stack");
        return _stackService.GetStacks().FirstOrDefault(stack => stack.Name == selected);
    }
}