using FlashCards.Backend.Entities;

namespace FlashCards.UI.Menus.Interfaces;

public interface IMenus
{
    void ShowMainMenu();
    void ShowSelectStack(IEnumerable<Stack> stacks);
    void ShowManageCards(string name);

}