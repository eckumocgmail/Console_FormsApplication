using ApplicationDb.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Core.SharedData.DataModels.Authorization
{
    /// <summary>
    /// Обьект модели пользователя сеансов
    /// </summary>
    [EntityLabel("Микрослужба")]
    [EntityIcon("build")]
    public class Service : ActiveObject
    {

        [InputUrl]
        [Label("URL")]
        public string URL { get; set; }



        [NotNullNotEmpty()]
        [Label("Закрытый ключ")]
        [Description("Получаем после регистрации")]
        public byte[] Private { get; set; }


       
        [Label("Открытый ключ")]
        [Description("Создаём на клиенте на время жизни сенас")]
        public byte[] Public { get; set; }

        public Service()
        {                       
            Name = "[user]";
        }
        
    }
}
