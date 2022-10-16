using System.Data.SqlClient;
using FlashCards.Backend.Contracts;
using FlashCards.Backend.Entities;

namespace FlashCards.Backend.DataAccess;

public class Database : IDatabase
{
    private string connectionsString = @"Server=(localdb)\MSSQLLocalDB;Database=FlashCardsManagerDb";
    private SqlConnection _connection;

    public Database()
    {
        _connection = new SqlConnection(connectionsString);
    }

    public IFlashCardRepository FlashCards =>  new FlashCardRepo(_connection);

    public IStackRepository Stacks => new StackRepo(_connection);

}