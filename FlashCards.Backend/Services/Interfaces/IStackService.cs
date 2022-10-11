using FlashCards.Backend.Entities;

namespace FlashCards.Backend.Services.Interfaces;

public interface IStackService
{
    public IEnumerable<Stack> GetStacks();
    public Stack GetStack();
    public void DeleteStack(int stackId);
    public Stack UpdateStack(Stack stack);
}