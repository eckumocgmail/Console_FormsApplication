using ApplicationDb.Entities;
using System.Collections.Generic;

/// <summary>
/// Модель представления постраничного просмотра
/// </summary>
/// <typeparam name="T"></typeparam>
public class Book: Pagination
{
    public List<object> Results { get; set; }

    public Book() {
        
        Results = new List<object>() {
            /*PersonNamesProvider.GetRandomPerson(),
            PersonNamesProvider.GetRandomPerson(),
            PersonNamesProvider.GetRandomPerson(),
            PersonNamesProvider.GetRandomPerson(),
            PersonNamesProvider.GetRandomPerson(),
            PersonNamesProvider.GetRandomPerson(),
            PersonNamesProvider.GetRandomPerson(),
            PersonNamesProvider.GetRandomPerson(),
            PersonNamesProvider.GetRandomPerson(),
            PersonNamesProvider.GetRandomPerson(),
            PersonNamesProvider.GetRandomPerson(),
            PersonNamesProvider.GetRandomPerson(),
            PersonNamesProvider.GetRandomPerson(),
            PersonNamesProvider.GetRandomPerson()*/
        };
    }

}
