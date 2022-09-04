using NetCoreConstructorAngular.Data.DataAttributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 



/// <summary>
/// Предоставляет фуцнкции валидации объектов сериализованных в JSON
/// </summary>
public class JsonValidationTest: TestingElement
{
    protected override void OnTest()
    {



        try
        {

            var someData = new BusinessResource();
            var baseValidationResult = someData.Validate();
            string type = someData.GetType().GetTypeName();
            string json = someData.ToJson();

            var validation = new JsonValidationService();
            var targetValifdationResult = validation.ValidateModel(type, json);

            baseValidationResult.ToJsonOnScreen().WriteToConsole();
            targetValifdationResult.ToJsonOnScreen().WriteToConsole();

            if (baseValidationResult.ToJsonOnScreen() != targetValifdationResult.ToJsonOnScreen())
                throw new Exception("Проверь функецию валидации модели сериализованной в JSON");
            else this.Messages.Add("Проверка модели работает для текстовых данных сериализованных в JSON");
        }
        catch (Exception ex)
        {
            this.Messages.Add($"[{nameof(JsonValidationService)}]Проверка модели не работает для текстовых данных сериализованных в JSON");
        }
    }
}
 