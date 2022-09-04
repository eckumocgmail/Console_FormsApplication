using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events
{

    /// <summary>
    /// Фактические параметры вызова функции или метода ( или процедуры, или SQL-процедуры или командной строки, в зависимости от обработчика)
    /// </summary>
    public class ActionEvent: EventArgs
    {


        /// <summary>
        /// Наименование операции
        /// </summary>
        private string Action { get; set; }
        


        /// <summary>
        /// Констурктор
        /// </summary>
        /// <param name="action"> процедура</param>
        /// <param name="args">параметры</param>
        public ActionEvent( string action, params KeyValuePair<string,string>[] args)
        {
            this.Action = action + "?";
            if (args!=null)
            {
                foreach(var kv in args)
                {
                    this.Action += kv.Key + "=" + kv.Value + "&";
                }
            }
        }
    }


}
