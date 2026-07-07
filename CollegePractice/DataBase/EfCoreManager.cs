namespace CollegePractice;

public class EfCoreManager
{
    /// <summary>
    /// Создает нового студента в базе данных.
    /// </summary>
    /// <param name="firstName">Имя студента.</param>
    /// <param name="groupName">Номер группы.</param>
    public void Create(string firstName, string groupName)
    {
        using var context = new AppDbContext();
        var student = new Student
        {
            FirstName = firstName,
            GroupName = groupName
        };

        context.Students.Add(student);
        context.SaveChanges();
        Console.WriteLine("Студент успешно добавлен (EF Core).");
    }

    /// <summary>
    /// Выводит список всех студентов в консоль.
    /// </summary>
    public void ReadAll()
    {
        using var context = new AppDbContext();
        var students = context.Students.ToList();

        Console.WriteLine("\n--- Список студентов (EF Core) ---");
        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.Id} | Имя: {student.FirstName} | Группа: {student.GroupName}");
        }
        Console.WriteLine("---------------------------------\n");
    }

    /// <summary>
    /// Обновляет данные студента по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор студента.</param>
    /// <param name="newFirstName">Новое имя.</param>
    /// <param name="newGroupName">Новая группа.</param>
    public void Update(int id, string newFirstName, string newGroupName)
    {
        using var context = new AppDbContext();
        var studentToUpdate = context.Students.Find(id);

        if (studentToUpdate != null)
        {
            studentToUpdate.FirstName = newFirstName;
            studentToUpdate.GroupName = newGroupName;
            context.SaveChanges();
            Console.WriteLine("Данные студента успешно обновлены (EF Core).");
        }
        else
        {
            Console.WriteLine("Студент с таким ID не найден (EF Core).");
        }
    }

    /// <summary>
    /// Удаляет студента по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор студента.</param>
    public void Delete(int id)
    {
        using var context = new AppDbContext();
        var studentToDelete = context.Students.Find(id);

        if (studentToDelete != null)
        {
            context.Students.Remove(studentToDelete);
            context.SaveChanges();
            Console.WriteLine("Студент успешно удален (EF Core).");
        }
        else
        {
            Console.WriteLine("Студент с таким ID не найден (EF Core).");
        }
    }
}
