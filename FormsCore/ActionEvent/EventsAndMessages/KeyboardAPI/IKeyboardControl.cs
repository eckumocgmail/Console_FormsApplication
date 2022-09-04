using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeleReportsDataProvider.Core.Controls
{
    /// <summary>
    /// Интерфейс для контроллеров реализующих управление с клавиатуры
    /// </summary>
    public interface IKeyboardControl
    {
        public string onkeypress(string message);
        public object onkeypressed(KeyboardEventMessage message);
    }
}
