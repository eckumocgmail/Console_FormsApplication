using ApplicationDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
///   Такие события будут порождать новые сообщения с уведомлениями и ссылками 
/// </summary>
public class UserEvent: EventsTable, OnCreated
{

    [Label("Пользовательское сообщение")]
    public int MessageID { get; set; }

    [Label("Пользовательское сообщение")]
    public virtual UserMessage Message { get; set; }


    /// <summary>
    /// Событие передаётся из контекста данных при создании записи
    /// </summary>
    /// <param name="record">изменяемая запись</param>
    public void OnCreated(BaseEntity record)
    {
        throw new NotImplementedException();
    }
}
