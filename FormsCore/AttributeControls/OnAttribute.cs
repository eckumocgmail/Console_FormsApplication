using System;


/// <summary>
/// Регистрация обработчика события, на передачу аргументов методу
/// действия, маркерованного атрибутом OnAttribute.
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class OnAttribute: Attribute
{
    public string Event { get; set; }

    public OnAttribute(string @event)
    {
        Event = @event;
    }
}