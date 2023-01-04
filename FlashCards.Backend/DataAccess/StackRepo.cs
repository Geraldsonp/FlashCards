using System.Data;
using System.Data.SqlClient;
using FlashCards.Backend.Contracts;
using FlashCards.Backend.Entities;
using Newtonsoft.Json;

namespace FlashCards.Backend.DataAccess;

public class StackRepo : IStackRepository
{
    private readonly SqlConnection _connection;

    public StackRepo(SqlConnection connection)
    {
        _connection = connection;
    }

    public bool Create(Stack stack)
    {
        var command = new SqlCommand()
        {
            Connection = _connection,
            CommandText = $"Insert into {TableNames.Stacks} (Name) values ('{stack.Name}')"
        };

        try
        {
            _connection.Open();

            var operationResult = command.ExecuteNonQuery();

            _connection.Close();
            command.Dispose();

            if (operationResult > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        finally
        {
            _connection.Close();
            command.Dispose();
        }
    }

    public bool Update(Stack stack)
    {
        var command = new SqlCommand()
        {
            Connection = _connection,
            CommandText = $"Update {TableNames.Stacks}" +
                          $"set Name = '{stack.Name}' " +
                          $"Where Id = {stack.Id}"
        };

        try
        {
            _connection.Open();

            var operationResult = command.ExecuteNonQuery();

            _connection.Close();
            command.Dispose();

            if (operationResult > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        finally
        {
            _connection.Close();
            command.Dispose();
        }
    }

    public bool Delete(int stackId)
    {
        var command = new SqlCommand()
        {
            Connection = _connection,
            CommandText = $"Delete {TableNames.Stacks} Where Id = {stackId}"
        };

        try
        {
            _connection.Open();

            var operationResult = command.ExecuteNonQuery();

            _connection.Close();
            command.Dispose();

            if (operationResult > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        finally
        {

            _connection.Close();
            command.Dispose();
        }
    }

    public Stack Get(int stackId)
    {
        var command = new SqlCommand()
        {
            Connection = _connection,
            CommandText = $"Select * From {TableNames.Stacks} Where ID = {stackId}"
        };

        try
        {
            _connection.Open();

            var reader = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            reader.Fill(data);

            var serializedData = JsonConvert.SerializeObject(data);
            var stacks = JsonConvert.DeserializeObject<IEnumerable<Stack>>(serializedData);

            _connection.Close();
            command.Dispose();
            data.Dispose();

            return stacks.FirstOrDefault();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
        finally
        {
            _connection.Close();
            command.Dispose();

        }
    }

    public IEnumerable<Stack> GetAll()
    {
        var command = new SqlCommand()
        {
            Connection = _connection,
            CommandText = $"Select * From {TableNames.Stacks}"
        };

        try
        {
            _connection.Open();

            var reader = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            reader.Fill(data);

            var serializedData = JsonConvert.SerializeObject(data);
            var stacks = JsonConvert.DeserializeObject<IEnumerable<Stack>>(serializedData);

            _connection.Close();
            command.Dispose();
            data.Dispose();

            return stacks;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
        finally
        {
            _connection.Close();
            command.Dispose();

        }
    }
}