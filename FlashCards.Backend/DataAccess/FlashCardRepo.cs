using System.Data;
using System.Data.SqlClient;
using System.Text.Json;
using System.Text.Json.Serialization;
using FlashCards.Backend.Contracts;
using FlashCards.Backend.Entities;
using Newtonsoft.Json;

namespace FlashCards.Backend.DataAccess;

public class FlashCardRepo : IFlashCardRepository
{
    private readonly SqlConnection _connection;

    public FlashCardRepo(SqlConnection connection)
    {
        _connection = connection;
    }

    public void Create(FlashCard card)
    {
        _connection.Open();
        SqlCommand command = new SqlCommand()
        {
            Connection = _connection,
            CommandText =
                $"Insert into FLASH_CARDS (Front, Back, StackId) values ('{card.Front}', '{card.Back}', {card.StackId})"
        };

        var result = command.ExecuteNonQuery();

        _connection.Close();
        command.Dispose();
    }

    public void Update(FlashCard card)
    {
        _connection.Open();
        SqlCommand command = new SqlCommand()
        {
            Connection = _connection,
            CommandText = $"Update FLASH_CARDS set Front = '{card.Front}', Back = '{card.Back}' WHERE Id = {card.Id};"
        };

        var result = command.ExecuteNonQuery();

        _connection.Close();
        command.Dispose();
    }

    public void Delete(int cardId)
    {
        _connection.Open();
        SqlCommand command = new SqlCommand()
        {
            Connection = _connection,
            CommandText = $"Delete From FLASH_CARDS WHERE ID = {cardId};"
        };

        var result = command.ExecuteNonQuery();

        _connection.Close();
        command.Dispose();
    }

    public FlashCard Get(int cardId)
    {
        _connection.Open();
        SqlCommand command = new SqlCommand()
        {
            Connection = _connection,
            CommandText = $"Select * From FLASH_CARDS WHERE Id = {cardId};"
        };

        var reader = new SqlDataAdapter(command);
        DataTable data = new DataTable();
        reader.Fill(data);

        var serializedData = JsonConvert.SerializeObject(data);
        var cardObj = JsonConvert.DeserializeObject<IEnumerable<FlashCard>>(serializedData);

        _connection.Close();
        command.Dispose();
        data.Dispose();

        return cardObj.FirstOrDefault();
    }

    public IEnumerable<FlashCard> GetAll(int stackId)
    {
        _connection.Open();
        SqlCommand command = new SqlCommand()
        {
            Connection = _connection,
            CommandText = $"Select * From FLASH_CARDS where StackId = {stackId};"
        };

        var reader = new SqlDataAdapter(command);
        DataTable data = new DataTable();
        reader.Fill(data);

        var serializedData = JsonConvert.SerializeObject(data);

        var cardObj = JsonConvert.DeserializeObject<IEnumerable<FlashCard>>(serializedData);

        _connection.Close();
        command.Dispose();
        data.Dispose();

        return cardObj;
    }

    public IEnumerable<FlashCard> GetAll()
    {
        _connection.Open();
        SqlCommand command = new SqlCommand()
        {
            Connection = _connection,
            CommandText = $"Select * From FLASH_CARDS;"
        };

        var reader = new SqlDataAdapter(command);
        DataTable data = new DataTable();
        reader.Fill(data);

        var serializedData = JsonConvert.SerializeObject(data);

        var cardObj = JsonConvert.DeserializeObject<IEnumerable<FlashCard>>(serializedData);

        _connection.Close();
        command.Dispose();
        data.Dispose();

        return cardObj;
    }

    public void Update(IEnumerable<FlashCard> cards)
    {
        var updateCommand = new List<string>();
        foreach (var flashCard in cards)
        {
            updateCommand.Add(
                $"Update FLASH_CARDS set Front = '{flashCard.Front}', Back = '{flashCard.Back}' WHERE Id = {flashCard.Id};");
        }

        _connection.Open();
        SqlCommand command = new SqlCommand()
        {
            Connection = _connection,
            CommandText = string.Join("", updateCommand)
        };

        var result = command.ExecuteNonQuery();

        _connection.Close();
        command.Dispose();
    }
}