using FlashCards.Backend.Services.Interfaces;

namespace FlashCards.Backend.Contracts;

public interface IDatabase
{
    public IFlashCardRepository FlashCards { get;}
    public IStackRepository Stacks { get; }
}