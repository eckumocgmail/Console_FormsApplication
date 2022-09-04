



using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;

namespace ApplicationDb.Entities
{
    [EntityLabel("Факт авторизации пользователя")]
    [SystemEntity()]
    public class UserAuthEvent: EventsTable
    { 
        public int UserID { get; set; }
        [JsonIgnore()]
        public virtual User User { get; set; }
    }
}
