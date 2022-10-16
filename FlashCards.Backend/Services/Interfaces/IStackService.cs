using FlashCards.Backend.Entities;

namespace FlashCards.Backend.Services.Interfaces;

public interface IStackService
{
    public IEnumerable<Stack> GetStacks();
    public Stack GetStack(int id);
    public void DeleteStack(int stackId);
    public bool UpdateStack(Stack stack);
    public bool Create(Stack stack);
}