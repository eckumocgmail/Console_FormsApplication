using Microsoft.EntityFrameworkCore;
using System;


namespace ApplicationDb.Entities
{

    [EntityLabel("Личные данные")]
    [Index(nameof(SurName))]
    public class UserPerson: BaseEntity
    {
        public string GetFullName()
        {
            return $"{SurName} {FirstName} {LastName}";
        }

        [Label("Фамилия")]        
        [NotNullNotEmpty("Не указана фамилия пользователя")]        
        [RusText("Записывайте фамилию кирилицей")]     
        [Icon("person")]
        public string SurName { get; set; }

        [Label("Имя")]
        [NotNullNotEmpty("Не указано имя пользователя")]        
        [RusText("Записывайте имя кирилицей")]
        [Icon("person")]
        public string FirstName { get; set; }


        [Label("Отчество")]
        [NotNullNotEmpty("Не указано отчество пользователя")]
        [RusText("Записывайте отчество кирилицей")]
        [Icon("person")]
        public string LastName { get; set; }


        [Label("Дата рождения")]
        [InputDate( )]
        [NotNullNotEmpty("Не указана дата рождения пользователя")]
        [Icon("person")]
        public DateTime? Birthday { get; set; }

        [InputPhone("Номер телефона указан неверно")]
        [UniqValidation("Этот номер телефона уже зарегистрирован")]
        [Label("Номер телефона")]                
        [NotNullNotEmpty("Не указана номер телефона")]
        [Icon("phone")]
        public string Tel { get; set; }


        [Label("Файл")]
        [InputImage()]
        [Icon("add_a_photo")]
        public byte[] Data { get; set; }

    }
}
