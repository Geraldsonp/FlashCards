using FlashCards.Backend.Contracts;
using FlashCards.Backend.Entities;
using FlashCards.Backend.Services.Interfaces;

namespace FlashCards.Backend.Services;

public class StackService : IStackService
{
    private readonly IDatabase _database;

    public StackService(IDatabase database)
    {
        _database = database;
    }
    public IEnumerable<Stack> GetStacks()
    {
        return _database.Stacks.GetAll();
    }

    public Stack GetStack(int id)
    {
        return _database.Stacks.Get(id);
    }

    public void DeleteStack(int stackId)
    {
        var result = _database.Stacks.Delete(stackId);
    }

    public bool UpdateStack(Stack stack)
    {
        return _database.Stacks.Update(stack);
    }

    public bool Create(Stack stack)
    {
        return _database.Stacks.Create(stack);
    }
}