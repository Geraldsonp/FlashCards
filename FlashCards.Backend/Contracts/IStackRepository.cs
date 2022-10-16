using FlashCards.Backend.Entities;

namespace FlashCards.Backend.Contracts;

public interface IStackRepository
{
    bool Create(Stack stack);

    bool Update(Stack stack);

    bool Delete(int stackId);

    Stack Get(int stackId);

    IEnumerable<Stack> GetAll();
}