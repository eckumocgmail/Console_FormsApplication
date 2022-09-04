


/// <summary>
/// Модель динамической страницы разработанной пользователем
/// </summary>
public class BusinessPageModel : DimensionTable
{

    /// <summary>
    /// URL_страницы
    /// </summary>
    [Label("URI")]
    [UniqValidation]    
    public string Location { get; set; }





    [NotInput]
    public int FormID { get; set; }

    [NotInput]
    public virtual InputFormModel Form { get; set; }


}