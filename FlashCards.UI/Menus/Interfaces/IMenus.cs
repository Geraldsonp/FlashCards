using FlashCards.Backend.Entities;
using FlashCards.UI.MenusOptionsEnums;

namespace FlashCards.UI.Menus.Interfaces;

public interface IMenus
{
    MainMenuOptions ShowMainMenu();
    StackOperationsOptions ShowStackOperationsMenu();
    YesOrNo YesOrNoPrompt();
    void BuildTable<T>(IEnumerable<T> listItems);
    void ShowManageCards(string name);
    string ChooseByNameMenu(IEnumerable<string> options, string modelName);

}