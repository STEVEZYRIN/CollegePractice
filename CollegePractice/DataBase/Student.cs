namespace CollegePractice;

/// <summary>
/// Модель данных студента.
/// </summary>
public class Student
{
    /// <summary>
    /// Уникальный идентификатор студента.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Имя студента.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Номер группы студента.
    /// </summary>
    public string GroupName { get; set; } = string.Empty;
}
