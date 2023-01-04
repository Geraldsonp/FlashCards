using System.ComponentModel.DataAnnotations;

namespace FlashCards.UI.Menus;

public enum MainMenuOptions
{
    [Display(Name = "Manage Stacks")]
    ManageStacks,
    [Display(Name = "Manage FlashCards")]
    ManageFlashCards,
    [Display(Name = "Study FlashCards")]
    Study,
    [Display(Name = "View Study Data")]
    ViewStudysessiondata,
    [Display(Name = "Exit")]
    Exit
}