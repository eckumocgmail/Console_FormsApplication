using NetCoreConstructorAngular.ActionEvent.EventsAndMessages;
using NetCoreConstructorAngular.Data;
using NetCoreConstructorAngular.Data.DataAttributes.AttributeControls;
using NetCoreConstructorAngular.Views.Shared.Components.Form;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

public class FormService
{
    protected readonly JsonValidationService _validation;
    public void SetErrors(object K, object V)
    {
        throw new NotImplementedException("Нужно релизовать SetErrors( .. )");
    }
    public FormService(JsonValidationService validation)
    {
        _validation = validation;
    }
    public Dictionary<string, List<string>> ValidateOnInput(Form form,InputEvent evt) {

        throw new NotImplementedException("Нужно релизовать SetErrors( .. )");
        
    }

    /// <summary>
    /// Создание модели формы связанной с обьектом
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public global::Form CreateForm(object item)
    {
        global::Form form = new global::Form();

        Update(form, item);
        return form;
    }



    /// <summary>
    /// Обновление изолированной области в модели
    /// </summary>
    /// <param name="model"></param>
    public void Update(global::Form form, object item)
    {
        if (item == null)
        {
            return;
        }
        


        form.Item = item;
        form.Title = form.Title==null? Attrs.LabelFor(item): form.Title;
        form.Description = Attrs.DescriptionFor(item);
        if (form.PropertyNames == null)
        {
            form.PropertyNames = ReflectionService.GetOwnPropertyNames(item.GetType()).ToArray();
        }
        if (Typing.ReferenceIsDictionary(item) == false)
        {
            form.FormFields = CreateFormFields(item.GetType(), form.PropertyNames, item);
            
        }
        form.FormFields.ForEach((f) =>
        {
            ((FormField)f).Edited = form.Edited ? false: true;
        });
        if( form.StructuresAreEditable)
        {
            form.TopMenu.ToContextMenu();
            foreach (string property in form.PropertyNames)
            {
                if (ReflectionService.IsPrimitive(property) == false)
                {
                    var showEditorButton = new Button() { Label = property, Icon= Attrs.IconFor(item.GetType(), property), IconOrText=true };
                    showEditorButton.FontSize = 12;
                    showEditorButton.Width = 10;
                    showEditorButton.OnClick = (button) =>
                    {
                    };
                    //showEditorButton.Width;
                    form.TopMenu.Append(showEditorButton);
                }
            }
            
            
        }
    }


    public List<object> CreateFormFields(Type type)
    {
        return CreateFormFields(type,ReflectionService.GetOwnPropertyNames(type).ToArray());
    }


    /// <summary>
    /// Создание полей формы для отображения и ввода информации
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public List<object> CreateFormFields(Type type, string[] propertyNames, object target=null)
    {
        List<object> fields = new List<object>();
        
        foreach (var propertyName in propertyNames)
        {
            var property = type.GetProperty(propertyName);
            try
            {

                var propertyType = Typing.ParsePropertyType(property.PropertyType);
                if (ReflectionService.IsPrimitive(propertyType) == false)
                {
                    continue;
                }
                global::FormField field = new global::FormField() { };

                var Attributes = Attrs.ForProperty(type, property.Name);
                field.Attributes = Attributes;
                bool isInput = Attrs.IsInput(type, property.Name);
                if (isInput == false)
                {
                    continue;
                }
                field.Name = property.Name;                
                field.Type = Attrs.GetControlType(type, property.Name);
                if(field.Type != null)
                {
                    
                    string input = Attributes[field.Type];
                    Type fieldType = ReflectionService.TypeForShortName(field.Type);
                    ControlAttribute attribute = ReflectionService.Create<ControlAttribute>(fieldType, new object[] { input });
                    field.Control = attribute.CreateControl(field);
                    field.Type = field.Type.Replace("Attribute", "");
                }
                else
                {
                    field.Type = GetInputType(type, property.Name);
                }
                
                field.Label = Attrs.LabelFor(type, property.Name);
                field.Description = Attrs.DescriptionFor(type, property.Name);
                field.Icon = Attrs.IconFor(type, property.Name);
                field.Visible = property.Name == "ID" ? false : Attrs.IsVisible(type, property.Name);
                field.Help = Attrs.HelpFor(type, property.Name);
                if( target != null)
                {
                    field.Value = GetValue(target, property.Name);
                    field._Value.Subscribe((PropertyChangedMessage message) => {
                        property.SetValue(target, message.After);
                        if (target is ViewItem)
                        {
                            ((ViewItem)target).Changed = true;
                        }
                    });
                }
                


                Writing.ToConsoleJson(new
                {
                    Property = field.Name,
                    FormField = field
                });
                fields.Add(field);

                field.Name = property.Name;
            }
            catch (SkipFieldException)
            {
                continue;
            }
            catch(Exception ex)
            {
                Writing.ToConsole("Ошибка при создании поля формы ввода для свойства "+property+ex.Message);
            }

        }
        return fields;
    }


    public string GetInputType(Type type, string property)
    {
        string result = Attrs.GetInputType(type,property);
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


        /*string type = null;
        try
        {

            if (property == "ID") return "Hidden";

            string inputType = Attrs.GetInputType(model, property);            
            type = inputType != null ? inputType : type;

            if (type == null)
            {
                object value = new ReflectionService().GetValue(model, property);
                if (value == null)
                {
                    //throw new Exception("Необходимо установить значение по-умолчанию для свойства "+property+" в классе "+model.GetType().Name);
                    type = model.GetType().GetProperty(property).PropertyType.Name;
                    using (var db = new ApplicationDbContext())
                    {
                        if (db.GetEntityTypeNames().Contains(type))
                        {
                            throw new SkipFieldException(property);
                        }
                    }
                }
                else
                {
                    bool isBaseEntity = value is BaseEntity;
                    if (isBaseEntity)
                    {
                        throw new SkipFieldException(property);
                    }
                }


                if (type != null)
                {
                    if (IsEnumerable(type))
                    {
                        type = "Collection";
                    }
                    else
                    {
                        switch (type.ToLower())
                        {
                            case "bool":
                            case "boolean":
                                type = "Checkbox";
                                break;
                            case "string":
                            case "text":
                                type = "Text";
                                break;
                            case "int":
                            case "float":
                            case "double":
                            case "decimal":
                            case "int32":
                            case "int64":
                                type = "Number";
                                break;
                            case "date":
                                type = "Date";
                                break;
                            case "datetime":
                                type = "Date";
                                break;
                            default:
                                throw new Exception($"Невозможно определить тип ввода для свойства {property} типа {value.GetType().Name} класса {model.GetType().Name}");
                        }
                    }

                }
            }

        }
        catch (SkipFieldException ex)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при получении типа поля ввода для свойства " + property + " " + ex.Message);
        }
        return type;*/
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

    public virtual object OnInput( object model, InputEvent message)
    {
        string propertyName = message.Property.Substring(0, message.Property.Length - "Input".Length);
        Form form = ((Form)model);
        object Properties = ((Form)model).Item;
        if (Typing.ReferenceIsDictionary(Properties))
        {
            FormField field = form.FindFieldByName(propertyName);
            Setter.SetValue(field, "Value", message.Value);


            Dictionary<string, List<string>> validationResult = form.Validate();

            form.IsValid = validationResult.Count() == 0;

            return new
            {
                Status = "Success",
                Result = validationResult
            };
        }
        else
        {
            PropertyInfo property = Properties.GetType().GetProperty(propertyName);
            if (property == null)
            {
                return new
                {
                    Status = "Error",
                    Type = "PropertyNotDefinedException",
                    Errors = new
                    {
                        Property = message.Property
                    }
                };
            }
            else
            {
                try
                {
                    FormField field = form.FindFieldByName(propertyName);
                    //Setter.SetValue(field, "Value", message.Value);
                    Setter.SetValue(Properties, propertyName, message.Value);
                }
                catch (Exception ex)
                {
                    return new
                    {
                        Status = "Error",
                        Type = "ErrorWhileSetPropertyValue",
                        StatusText = ex.Message,
                        Errors = new
                        {
                            Value = message.Value
                        }
                    };
                }

                var intrestedResult = new Dictionary<string, List<string>>();
                Dictionary<string, List<string>> validationResult = null;
                if (Properties is MyValidatableObject)
                {                    
                    validationResult = ((MyValidatableObject)Properties).Validate(form.PropertyNames);
                }
                else
                {
                    validationResult = _validation.ValidateModel(Properties);
                    
                }
                intrestedResult = new Dictionary<string, List<string>>();
                foreach (string k in validationResult.Keys.Intersect(new List<string>(form.PropertyNames)))
                {
                    intrestedResult[k] = validationResult[k];
                }
                form.IsValid = intrestedResult.Count() == 0;
                
                return new
                {
                    Status = "Success",
                    Result = intrestedResult
                };
            }
        }
    }
}