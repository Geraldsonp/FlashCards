using System.ComponentModel.DataAnnotations;

namespace FlashCards.UI.MenusOptionsEnums;

public enum StackOperationsOptions
{
    [Display(Name = "Go Back")]
    GoBack,
    [Display(Name = "Create new stack")]
    Create,
    [Display(Name = "Delete a stack")]
    Delete,
    [Display(Name = "Rename a stack")]
    Rename,
    [Display(Name = "Manage stack's cards")]
    ManageCards
}