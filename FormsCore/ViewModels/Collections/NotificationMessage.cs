using ApplicationDb.Entities;


public class NotificationMessage: NewsMessage
{
    /// <summary>
    /// "Error" - если сообщение содержит информацию об ошибке
    /// </summary>
    public string Type { get; set; }
}

