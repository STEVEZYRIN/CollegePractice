using Microsoft.Data.SqlClient;

namespace CollegePractice;

public class AdoNetManager
{
    private readonly string _connectionString;

    public AdoNetManager()
    {
        _connectionString = ConfigurationHelper.GetConnectionString();
    }

    /// <summary>
    /// Создает нового студента в базе данных.
    /// </summary>
    /// <param name="firstName">Имя студента.</param>
    /// <param name="groupName">Номер группы.</param>
    public void Create(string firstName, string groupName)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO Students (FirstName, GroupName)
            VALUES (@firstName, @groupName);
        ";
        command.Parameters.AddWithValue("@firstName", firstName);
        command.Parameters.AddWithValue("@groupName", groupName);

        command.ExecuteNonQuery();
        Console.WriteLine("Студент успешно добавлен (ADO.NET).");
    }

    /// <summary>
    /// Выводит список всех студентов в консоль.
    /// </summary>
    public void ReadAll()
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, FirstName, GroupName FROM Students;";

        using var reader = command.ExecuteReader();
        Console.WriteLine("\n--- Список студентов (ADO.NET) ---");
        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader.GetInt32(0)} | Имя: {reader.GetString(1)} | Группа: {reader.GetString(2)}");
        }
        Console.WriteLine("----------------------------------\n");
    }

    /// <summary>
    /// Обновляет данные студента по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор студента.</param>
    /// <param name="newFirstName">Новое имя.</param>
    /// <param name="newGroupName">Новая группа.</param>
    public void Update(int id, string newFirstName, string newGroupName)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            UPDATE Students 
            SET FirstName = @firstName, GroupName = @groupName 
            WHERE Id = @id;
        ";
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@firstName", newFirstName);
        command.Parameters.AddWithValue("@groupName", newGroupName);

        var rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Данные студента успешно обновлены (ADO.NET).");
        }
        else
        {
            Console.WriteLine("Студент с таким ID не найден (ADO.NET).");
        }
    }

    /// <summary>
    /// Удаляет студента по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор студента.</param>
    public void Delete(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Students WHERE Id = @id;";
        command.Parameters.AddWithValue("@id", id);

        var rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Студент успешно удален (ADO.NET).");
        }
        else
        {
            Console.WriteLine("Студент с таким ID не найден (ADO.NET).");
        }
    }
}