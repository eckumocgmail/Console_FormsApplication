using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using BlazorFormsWebAssembly.Services;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NetCoreConstructorAngular.Data;
using System.Reflection;
using NetCoreConstructorAngular.ActionEvent.EventsAndMessages;
using System.ComponentModel.DataAnnotations;
using RootForms.Shared.Collections.ListCollections;
using RootForms.Shared.Collections.TableCollections;

public interface Validator<TData>
{
    public string Validate(TData value);
}

public abstract class Validate<TData>: InputModel
{
    public object Model { get; set; }
    public TData Value { get; set; }
    public bool IsValid { get; set; } = false;

    public Dictionary<string, Validator<TData>> Validators{ get; set; } = new Dictionary<string, Validator<TData>>();
    public Dictionary<string, string> ValidationErrors { get; set; } = new Dictionary<string, string>();
    public void DoValidation( )
    {
        ValidationErrors.Clear();
        foreach (var validator in Validators)
        {
            string message = validator.Value.Validate(Value);
            if(string.IsNullOrEmpty(message) == false)
            {
                ValidationErrors[validator.Key] = message;
            }
            
        }
    }
}
 
public abstract class InputModel 
{
    [SelectControl("account-login,account-logout,action-redo,action-undo,align-center,align-left,align-right,aperture,arrow-bottom,arrow-circle-bottom,arrow-circle-left,arrow-circle-right,arrow-circle-top,arrow-left,arrow-right,arrow-thick-bottom,arrow-thick-left,arrow-thick-right,arrow-thick-top,arrow-top,audio,audio-spectrum,badge,ban,bar-chart,basket,battery-empty,battery-full,beaker,bell,bluetooth,bold,bolt,book,bookmark,box,briefcase,british-pound,browser,brush,bug,bullhorn,calculator,calendar,camera-slr,caret-bottom,caret-left,caret-right,caret-top,cart,chat,check,chevron-bottom,chevron-left,chevron-right,chevron-top,circle-check,circle-x,clipboard,clock,cloud,cloud-download,cloud-upload,cloudy,code,cog,collapse-down,collapse-left,collapse-right,collapse-up,command,comment-square,compass,contrast,copywriting,credit-card,crop,dashboard,data-transfer-download,data-transfer-upload,delete,dial,document,dollar,double-quote-sans-left,double-quote-sans-right,double-quote-serif-left,double-quote-serif-right,droplet,eject,elevator,ellipses,envelope-closed,envelope-open,euro,excerpt,expand-down,expand-left,expand-right,expand-up,external-link,eye,eyedropper,file,fire,flag,flash,folder,fork,fullscreen-enter,fullscreen-exit,globe,graph,grid-four-up,grid-three-up,grid-two-up,hard-drive,header,headphones,heart,home,image,inbox,infinity,info,italic,justify-center,justify-left,justify-right,key,laptop,layers,lightbulb,link-broken,link-intact,list,list-rich,location,lock-locked,lock-unlocked,loop,loop-circular,loop-square,magnifying-glass,map,map-marker,media-pause,media-play,media-record,media-skip-backward,media-skip-forward,media-step-backward,media-step-forward,media-stop,medical-cross,menu,microphone,minus,monitor,moon,move,musical-note,paperclip,pencil,people,person,phone,pie-chart,pin,play-circle,plus,power-standby,print,project,pulse,puzzle-piece,question-mark,rain,random,reload,resize-both,resize-height,resize-width,rssvrss-alt,script,share,share-boxed,shield,signal,signpost,sort-ascending,sort-descending,spreadsheet,star,sun,tablet,tag,tags,target,task,terminal,text,thumb-down,thumb-up,timer,transfer,trash,underline,vertical-align-bottom,vertical-align-center,vertical-align-top,video,volume-high,volume-low,volume-off,warning,wifi,wrench,x,yen,zoom-in,zoom-out")]
    public string Icon { get; set; } = "oi-home";
    public string Name { get; set; } = "NewField";
    public string Label { get; set; } = "Новое поле";
    public bool IsNullable { get; set; } = true;    
    public bool IsToched { get; set; } = false;

}

public class InputDateModel: Validate<DateTime?>
{
    public string Format { get; set; } = "yyyy-MM-dd";
}

public class InputTextModel : Validate<string>
{
    public int MinLength { get; set; } = 0;
    public int MaxLength { get; set; } = 40;    
}

public class InputNumberModel : Validate<float>
{
    public int CountOfDigits { get; set; } = 2;
    public float MinValue { get; set; } = float.MinValue;
    public float MaxValue { get; set; } = float.MaxValue;
}

 

public class InputRadioModel : Validate<object>
{
}

public class InputRadioGroupModel : Validate<List<InputRadioModel>>
{
}

public class OptionModel
{

}

public class InputSelectModel : Validate<object>
{
    public Dictionary<object, object> Options { get; set; }
    public Action<object> Init { get; set; }

    public Dictionary<object, object> GetOptions()
    {
        Init(Model);
        return Options;
    }
}

public class InputTextAreaModel : Validate<object>
{
}

public class InputCheckboxModel : Validate<object>
{
}

public class InputFileModel : Validate<byte[]>
{
}

 
public class PaneModel: MyValidatableObject
{
    [Key]
    [InputHidden]
    public int ID { get; set; }

    [Label("Заголовок")]
    [InputText]
    public string Title { get; set; } = "Заголовок";

    [Label("Иконка")]
    [InputIcon]
    public string Icon { get; set; } = null;


    [Label("Описание")]
    [InputMultilineText]
    public string Description { get; set; } = "Краткое описание контента";
}

public class InputFormField: PaneModel
{

    private static int Counter = 0;
    private int N = Counter++;
    [InputHidden]
    public int InputFormModelID { get; set; }

    [NotInput]
    [NotMapped]
    [JsonIgnore]
    public virtual InputFormModel InputFormModel { get; set; }

    [Label("Наименование")]
    public string Name { get; set; }

    [SelectControl("{{GetInputTypes()}}")]
    public string Type { get; set; }

    [Label("Надпись")]
    public string Label { get; set; }

    [Label("Разрешено изменение")]
    public bool Edited { get; set; }


    [NotMapped]
    [JsonIgnore]
    public object Value { get; set; }
    
    [Label("Размер")]
    [SelectControl("small,normal,big")]
    public string Size { get; set; } = "normal";


    [Label("Состояние")]
    [SelectControl("valid,invalid,undefined")]
    public string State { get; set; }


    [NotMapped()]
    public object Control { get; set; }

    [NotMapped]
    [Label("Подсказка")]
    public string Help { get; set; }

    [Label("Ошибки")]
    [NotMapped]
    public List<string> Errors { get; set; } = new List<string>();

    [Label("Атрибуты")]
    [NotMapped]
    public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();


    [Label("Атрибуты")]
    [NotMapped]
    [JsonIgnore]
    public Dictionary<string, List<object>> CustomValidators { get; set; } = new Dictionary<string, List<object>>();


    public InputFormField() : base()
    {   
        this.Icon = "home";    
        this.Name = "Undefined";
        this.Type = "Text";
        this.State = "undefined";
        this.Label = "Неизвестно";
        this.Description = "Нет подробного описания";
        this.Help = "Нет справочной информации"; 
    }
    public string GetHtmlInputValue() => Value != null ? Value.ToString() : "";

    public string GetInputId() => Name + "Input-" + N;
    public InputFormField SetEdited(bool val)
    {
        this.Edited = val;
        return this;
    }
    public string GetInputName() => Name + "Input";
}



[EntityLabel("Редактор")]
[Description("Модель редактора")]
public class InputFormModel: PaneModel
{
 
    [Label("Состояние")]
    [NotInput]
    [UpdateWhenChanged(false)]
    public bool IsValid { get; set; }

    [Label("Сообщение об ошибке")]
    [NotInput]
    public string Error { get; set; }

    [Label("Контейнер")]
    [SelectControl("h-group,v-group")]
    public string Container { get; set; }

    /// <summary>
    /// установливает размеры formcontrol
    /// </summary>
    [Label("Размер")]
    [SelectControl("small,normal,big")]
    public string Size { get; set; }

    [Label("Ссылка на объект")]
    [NotMapped]
    public object Item { get; set; }

    [Label("Поля ввода")]
    [InputStructureCollection()]
 
    [NotMapped]
    public List<InputFormField> FormFields { get; set; } = new List<InputFormField>();


    [Label("Действие по завершению")]
    [JsonIgnore()]
    [NotInput("")]
    [NotMapped]
    public Action<object> OnComplete { get; set; }

    [Label("Разрешено изменение")]
    [NotInput]
    public bool Edited { get; internal set; }


    [NotMapped]
    [JsonIgnore]
    [NotInput]
    public Dictionary<string, List<string>> Errors = new Dictionary<string, List<string>>();

    public InputFormModel() : base()
    {
        IsValid = false;
        Title = "Заголовок";
        Description = "Описание";
        Error = "";
        Container = "group";
        Size = "normal";
        Icon = "home";
    }


    public InputFormModel(object item) : this()
    {
        if (item == null)
            throw new Exception("Аргумент item на задан");
        IsValid = false;
        Item = item;
        Title = Attrs.LabelFor(item.GetType());        
        Description = Attrs.DescriptionFor(item.GetType());
        Update(item.GetType().GetUserInputPropertyNames());
    }

    public InputFormModel(object item, params string[] propertyNames) : this()
    {
        if (item == null)
            throw new Exception("Аргумент item на задан");
        IsValid = false;
        Title = Attrs.LabelFor(item.GetType());         
        Description = Attrs.DescriptionFor(item.GetType());
        Item = item;
        Update(propertyNames);
        
    }





    public void EnsureThatItemIsValide()
    {
        if (Item is MyValidatableObject)
        {
            ((MyValidatableObject)Item).EnsureIsValide();
        }
        else
        {
            throw new Exception($"Объект не наследует тип {nameof(MyValidatableObject)}");
        }
    }




    /// <summary>
    /// Обновление изолированной области в модели
    /// </summary>
    /// <param name="model"></param>
    public object Update(string[] propertyNames)
    {
        var item = Item;
        var form = this;
        if (item == null)
        {
            throw new Exception("Установите свойство Item для модели "+GetType().Name);
        }
        form.Item = item;
        form.Title = form.Title == null ? Attrs.LabelFor(item) : form.Title;
        form.Description = Attrs.DescriptionFor(item);
        if (Typing.ReferenceIsDictionary(item) == false)
        {
            form.FormFields = CreateFormFields(item.GetType(), propertyNames, item);

        }
        else
        {
            FormFields = CreateFormFields(Item.GetType(), propertyNames, Item);
        }
        if (FormFields.Count() != propertyNames.Length)
        {
            string message = "";
            foreach(var name in propertyNames.Where(name => FormFields.Select(f => f.Name).Contains(name) == false))
            {
                message += "Отсутсвует поле ввода для свойства " + name + ". ";
            }
            throw new Exception("Поля формы ввода созданы некорректно. " + message);
        }
            
        FormFields.Sort(OnSort);
        return this;
    }

    public int OnSort(InputFormField left, InputFormField right)
    {
        if( left.Type.ToLower() =="multilinetext")
        {
            return 1;
        }
        else if (right.Type.ToLower() == "multilinetext")
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    /// <summary>
    /// Уникальные поля-1, примитивные-2, Многострочные и файловые-4, остальные-3
    /// </summary>
    /// <param name="field"></param>
    /// <returns></returns>
    private int SortOrder(FormField field)
    {

        if (field.Type == "MultilineText" || field.Type == "File" || field.Type == "Image" || field.Type == "Foto") return 3;
        return 2;
    }



 
    /// <summary>
    /// Создание модели табличного представления из свойств обьекта
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public global::Table ForDictionary(object model)
    {

        global::Table tm = new global::Table();

        tm.Columns = ReflectionService.GetOwnMethodNames(model.GetType());
        List<object[]> cells = new List<object[]>();

        //cells
        object[] row = new object[cells.Count()];
        int i = 0;
        foreach (string column in tm.Columns)
        {
            row[i++] = GetValue(model, column);
        }
        cells.Add(row);

        //tm.Cells = cells.ToArray();
        tm.Cells = new List<List<object>>();// new Newtonsoft.Json.Linq.JArray();
        return tm;
        //return ForDictionary(Formating.ToDictionaryLabels(model), Attrs.LabelFor(model.GetType()));
    }

    public Table ForDictionary(IDictionary<string, object> properties, string title)
    {
        var table = new Table();
        table.Title = title;
        table.Searchable = true;
        table.Columns = new List<string> { "Ключ", "Значение" };
        table.Cells = new List<List<object>>();
        foreach (var p in properties)
        {
            table.Cells.Add(new List<object> { p.Key, p.Value });
        }
        return table;
    }

    /// <summary>
    /// Создание полей формы для отображения и ввода информации
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public List<InputFormField> CreateFormFields(Type type, string[] propertyNames, object target = null)
    {
        List<InputFormField> fields = new List<InputFormField>();
        foreach (var propertyName in propertyNames)
        {
            try
            {
                var property = type.GetProperty(propertyName);
                if (property == null)
                {
                    throw new Exception("Ошибка при создании поля " + propertyName
                    );
                }
                var propertyType = Typing.ParsePropertyType(property.PropertyType);
                var Attributes = Attrs.ForProperty(type, property.Name);

                global::InputFormField field = new global::InputFormField();
                field.Attributes = Attributes;
                field.Name = property.Name;
                field.Label = Attrs.LabelFor(type, property.Name);
                field.Description = Attrs.DescriptionFor(type, property.Name);
                field.Icon = Attrs.IconFor(type, property.Name);
                field.Help = Attrs.HelpFor(type, property.Name);
                if (Attributes.ContainsKey(nameof(NotInputAttribute)))
                {
                    continue;
                }
                if (ReflectionService.IsPrimitive(propertyType) == false)
                {

                    if (Typing.IsCollectionType(property.PropertyType))
                    {
                        var collectionType = Typing.ParseCollectionType(property.PropertyType);
                        if (Typing.IsPrimitive(collectionType))
                        {
                            field.Control = ForCollectionOfPrimitivesProperty(Item, property.Name);
                        }
                        else
                        {
                            field.Control = ForCollectionProperty(Item, property.Name);
                        }
                       
                        
                    }
                    else
                    {
                        var table = new TableView();
                        object val = GetValue(Item, property.Name);
                        table.Columns = val.GetType().GetOwnPropertyNames();
                        table.Rows.Add(val);
                        field.Control = table;

                    }
                    

                }
                else
                {
                    bool isInput = Attrs.IsInput(type, property.Name);
            

                    field.Type = Attrs.GetControlType(type, property.Name);
                    if (field.Type != null)
                    {                        
                        string input =
                            Attributes.ContainsKey(field.Type) ? Attributes[field.Type] :
                            Attributes.ContainsKey(field.Type.Replace("Attribute", "")) ? Attributes[field.Type.Replace("Attribute", "")] :
                            Attributes.ContainsKey(field.Type + "Attribute") ? Attributes[field.Type + "Attribute"] :
                            throw new Exception("Не найден атрибут соответрующий типу элемента управления "+field.Type);
                        Type fieldType = ReflectionService.TypeForShortName(field.Type);
                        ControlAttribute attribute = ReflectionService.Create<ControlAttribute>(fieldType, new object[] { input });

                        field.Control = attribute.CreateControl(field);
                        field.Type = field.Type.Replace("Attribute", "");
                    }
                    else
                    {
                        field.Type = GetInputType(type, property.Name);
                        field.Type = field.Type.ToLower();
                    }
                }
                if (target != null)
                {
                    field.Value = GetValue(target, property.Name);
                }
                fields.Add(field);
            }
            catch (Exception ex)
            {
                Writing.ToConsole(ex.Message);
                //                throw new Exception("Ошибка при создании поля ввода для свойства "+propertyName, ex);
            }


        }
        return fields;
    }

    private object CreateControl(InputFormField field)
    {
        throw new NotImplementedException();
    }

    private object ForCollectionProperty(object item, string name)
    {
        return new Table();
    }

    private object ForCollectionOfPrimitivesProperty(object item, string name)
    {
        return new ListView()
        {
            Items = ((IEnumerable<object>)GetValue(item, name)).ToList(),
        };

    }

    public string GetInputType(Type type, string property)
    {
        string result = Attrs.GetInputType(type, property);
        if (result != null) return result;
        var propertyInfo = type.GetProperty(property);
        string propertyType = Typing.ParsePropertyType(propertyInfo.PropertyType);

        if (Typing.IsDateTime(propertyInfo))
        {
            return "date";
        }
        else if (Typing.IsBoolean(propertyInfo))
        {
            return "checkbox";
        }
        else if (Typing.IsNumber(propertyInfo))
        {
            return "number";
        }
        else
        {
            return "text";
        }




    }

    private bool IsEnumerable(Type type)
    {
        return type.Name.StartsWith("List") || type.Name.StartsWith("HashSet");
    }


    /// <summary>
    /// Извлекает значение свойства из обьекта по наименованию
    /// </summary>
    /// <param name="model"></param>
    /// <param name="property"></param>
    /// <returns></returns>
    private object GetValue(object model, string property)
    {
        PropertyInfo propertyInfo = model.GetType().GetProperty(property);
        FieldInfo fieldInfo = model.GetType().GetField(property);
        return
            fieldInfo != null ? fieldInfo.GetValue(model) :
            propertyInfo != null ? propertyInfo.GetValue(model) :
            null;
    }

    private List<string> Validate(InputFormField field)
    {

        List<string> errors = new List<string>();
        foreach (var validationInfo in field.CustomValidators)
        {
            try
            {
                MyValidation validation = ReflectionService.Create<MyValidation>(validationInfo.Key, validationInfo.Value.ToArray());
                string error = validation.Validate(Item, field.Name, field.Value);
                if (string.IsNullOrEmpty(error) == false)
                {
                    errors.Add(error);
                }
            }
            catch (Exception ex)
            {
                errors.Add($"Элемент ввода: {field.Name}" + "Ошибка при выподлнении валидации. Забавно! " + ex.Message);
            }

        }
        return errors;

    }
    public override Dictionary<string, List<string>> Validate()
    {

        Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
        if (Item is BaseEntity)
        {
            result = ((BaseEntity)Item).Validate();
        }
        else
        {
            if (Typing.ReferenceIsDictionary(Item))
            {
                foreach (var field in FormFields)
                {
                    List<string> errors = Validate((InputFormField)field);
                    if (errors != null && errors.Count() > 0)
                    {
                        result[((InputFormField)field).Name] = errors;
                    }
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        return result;
    }


    public Dictionary<string, object> GetValues()
    {
        Dictionary<string, object> values = new Dictionary<string, object>();
        this.FormFields.ForEach((field) => {
            values[((InputFormField)field).Name] = ((InputFormField)field).Value;
        });
        return values;
    }

    public InputFormField FindFieldByName(string propertyName)
    {
        return (InputFormField)(from p in FormFields where ReflectionService.GetValueFor(p, "Name").ToString() == propertyName select p).SingleOrDefault();
    }




}

public interface IInputFormService
{
    
    public InputFormModel CreateInputModel(Type type );
    public InputFormModel CreateInputModel(Type type, object target);
    public void CreateFormField(InputFormModel form);
    public void RemoveFormField(InputFormModel form, object formField);
    public void UpdateFormField(InputFormModel form, object formField);
    public void Create();
    public void Remove(InputFormModel form);
    public void Update(InputFormModel form);

    public List<InputFormModel> GetForms();
    public void SetErrors(InputFormModel form, Dictionary<string, List<string>> errors);
    public Dictionary<string, List<string>> ValidateOnInput(InputFormModel form, InputEvent evt);
}


namespace BlazorFormsWebAssembly.Services
{
    public class InputFormService: IInputFormService
    {
        private readonly InputFormDbContext _context;
        public InputFormService(InputFormDbContext context) {
            _context = context;
            if(_context.InputFormModels.Count() == 0)
            {
                _context.InputFormModels.Add(new InputFormModel()
                {
                   /* FormFields = new HashSet<InputModel>(){
                        new InputTextModel(){
                            Value = "username@home.com"
                        },
                        new InputDateModel(){
                            Value = DateTime.Now
                        }
                    }*/
                });
                _context.SaveChanges();
            }
        }
        public void SetErrors(InputFormModel form, Dictionary<string, List<string>> errors)
        {
            form.Errors = errors;
            foreach (var field in form.FormFields)
            {
                if (errors.ContainsKey(field.Name))
                {
                    field.Errors = errors[field.Name];
                    field.State = "invalid";
                }
                else
                {
                    field.Errors = new List<string>();
                    field.State = "valid";
                }
            }
            form.IsValid = errors.Count() == 0;
        }

        public void Create()
        {
            _context.InputFormModels.Add(new InputFormModel());
            _context.SaveChanges();
        }
        /*
        public void CreateFormField(InputFormModel form)
        {
            form.FormFields.Add(new InputDateModel());
            _context.SaveChanges();
        }

        public InputFormModel CreateInputModel(Type type)
        {
            InputFormModel form = new InputFormModel();                              
            //form.PropertyNames = ReflectionService.GetOwnPropertyNames(type).ToArray();
            form.Title = form.Title == null ? Attrs.LabelFor(type) : form.Title;
            form.Summary = Attrs.DescriptionFor(type);     
            
            return form;
        }

        public InputFormModel CreateInputModel(Type type, object target)
        {
            InputFormModel model = new InputFormModel();
            foreach(var prop in type.GetProperties())
            {
                switch (prop.PropertyType.Name)
                {
                    case "Int":
                    case "Int64":
                    case "Int32":
                        model.FormFields.Add(new InputNumberModel() {
                            Label = prop.Name,
                            Name = prop.Name
                        });
                        break;                    
                    case "System.DateTime":
                    case "DateTime":
                        model.FormFields.Add(new InputDateModel()
                        {
                            Label = prop.Name,
                            Name = prop.Name,
                        });
                        break;
                    case "String":
                        model.FormFields.Add(new InputTextModel()
                        {
                            Label = prop.Name,                            
                            Name = prop.Name
                        });
                        break;
                }
            }
            return model;
        }
        */
        public List<InputFormModel> GetForms()
        {
            return _context.InputFormModels.ToList();
        }

        public void Remove(InputFormModel form)
        {
            _context.InputFormModels.Remove(form);
            _context.SaveChanges();
        }

        public void RemoveFormField(InputFormModel form, object formField)
        {
            throw new NotImplementedException();
        }

        public void Update(InputFormModel form)
        {
            _context.Update(form);
            _context.SaveChanges();
        }

        public void UpdateFormField(InputFormModel form, object formField)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, List<string>> ValidateOnInput(InputFormModel form, InputEvent evt)
        {
          
            Setter.SetValue(form.Item, evt.Property, evt.Value);
            if(form.Item is MyValidatableObject)
            {
                return ((MyValidatableObject)form.Item).Validate();
            }
            else
            {
                throw new Exception("ValidateOnInput");
            }
        }

        public InputFormModel CreateInputModel(Type type)
        {
            throw new NotImplementedException();
        }

        public InputFormModel CreateInputModel(Type type, object target)
        {
            throw new NotImplementedException();
        }

        public void CreateFormField(InputFormModel form)
        {
            form.FormFields.Add(new InputFormField());
        }
    }
}


[EntityIcon("account_tree")]
[EntityLabel("Динамические формы")]
[Description("Сохраняет динамически созданные интерфейсы в БД")]
public class InputFormDbContext : DbContext
{
    public static int Counter = FormsHelper.Add((services)=> {
        services.AddInputForm();
    });


    public virtual DbSet<InputFormModel> InputFormModels { get; set; }
    public virtual DbSet<BusinessPageModel> BusinessPageModel { get; set; }

    
    public InputFormDbContext(DbContextOptions<InputFormDbContext> options) : base(options) 
    {
    }
}


public static class InputFormServiceExtension
{
    public static IServiceCollection AddInputForm(this IServiceCollection services)
    {
        services.AddScoped<JsonValidationService>();
        services.AddScoped<FormService>();
        services.AddScoped<IInputFormService, InputFormService>();
        services.AddDbContext<InputFormDbContext>(options => options.UseInMemoryDatabase(nameof(InputFormDbContext)));

        return services;
    }

    public static global::Form ToForm(this Type target)
    {
        return target.ToForm( target.Name.New() );
    }
    public static global::InputModel CreateControl(this Type target, object instance,string type,string value)
    {
        switch (type.Replace("Attribute","")+"Attribute")
        {
            case nameof(SelectControlAttribute):

                var model = new InputSelectModel();
                model.Init = (instance) =>
                {
                    model.Options = new Dictionary<object, object>();
                    string interrpolationValue = Expression.Interpolate(value, instance);
                    foreach (string s in interrpolationValue.Split(","))
                    {
                        model.Options[s] = s;
                    }
                };
                return model;
            default: throw new Exception("Не реализована функция создания элемента управления данными помеченными атрибутом "+type+"("+value+")");
        }
    }
    public static global::Form ToForm(this Type target, object instance)
    {
        /*var model = new InputFormModel();
        foreach (var propertyName in target.GetUserInputPropertyNames())
        {
            var value = ReflectionService.GetValueFor(instance, propertyName);
            string controlType=Attrs.GetControlType(target,propertyName);
            if (controlType != null)
            {
                string input = Attrs.ForProperty(target, propertyName)[controlType];
                global::InputModel control = target.CreateControl(instance,controlType,input);
                model.FormFields.Add(control);
            }
            else
            {
                model.FormFields.Add(new InputTextModel()
                {
                    Name = propertyName,
                    Label = Attrs.LabelFor(target, propertyName),
                    Value = value == null ? null : value.ToString()
                });
            }
             ;
        }*/
        Form model = new Form(instance);
        return model;
    }
}

 