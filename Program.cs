namespace CollegePractice;

/// <summary>
/// Точка входа в приложение, реализующая консольное меню для CRUD-операций.
/// </summary>
public class Program
{
    /// <summary>
    /// Главный метод приложения.
    /// </summary>
    public static void Main()
    {
        // Автоматически создаем базу данных и таблицы при первом запуске.
        using (var context = new AppDbContext())
        {
            context.Database.EnsureCreated();
        }

        var adoManager = new AdoNetManager();
        var efManager = new EfCoreManager();

        var isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Показать всех студентов (EF Core)");
            Console.WriteLine("2. Добавить студента (ADO.NET)");
            Console.WriteLine("3. Обновить студента (EF Core)");
            Console.WriteLine("4. Удалить студента (ADO.NET)");
            Console.WriteLine("5. Выход");
            Console.Write("Ваш выбор: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    efManager.ReadAll();
                    break;
                case "2":
                    Console.Write("Введите имя студента: ");
                    var firstName = Console.ReadLine() ?? string.Empty;
                    Console.Write("Введите номер группы: ");
                    var groupName = Console.ReadLine() ?? string.Empty;
                    adoManager.Create(firstName, groupName);
                    break;
                case "3":
                    Console.Write("Введите ID студента для обновления: ");
                    if (int.TryParse(Console.ReadLine(), out var updateId))
                    {
                        Console.Write("Введите новое имя: ");
                        var newFirstName = Console.ReadLine() ?? string.Empty;
                        Console.Write("Введите новую группу: ");
                        var newGroupName = Console.ReadLine() ?? string.Empty;
                        efManager.Update(updateId, newFirstName, newGroupName);
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ID.");
                    }
                    break;
                case "4":
                    Console.Write("Введите ID студента для удаления: ");
                    if (int.TryParse(Console.ReadLine(), out var deleteId))
                    {
                        adoManager.Delete(deleteId);
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ID.");
                    }
                    break;
                case "5":
                    isRunning = false;
                    Console.WriteLine("Завершение работы программы...");
                    break;
                default:
                    Console.WriteLine("Неверный ввод, попробуйте снова.\n");
                    break;
            }
        }
    }
}
