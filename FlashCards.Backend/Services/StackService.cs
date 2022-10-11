using FlashCards.Backend.Entities;
using FlashCards.Backend.Services.Interfaces;

namespace FlashCards.Backend.Services;

public class StackService : IStackService
{
    public IEnumerable<Stack> GetStacks()
    {
        return new[]
        {
            new Stack()
            {
                Id = 1,
                Name = "Randon"
            }
        };
    }

    public Stack GetStack()
    {
        throw new NotImplementedException();
    }

    public void DeleteStack(int stackId)
    {
        throw new NotImplementedException();
    }

    public Stack UpdateStack(Stack stack)
    {
        throw new NotImplementedException();
    }
}