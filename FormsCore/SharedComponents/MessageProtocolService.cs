using ApplicationDb.Entities;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

 
public class MessageProtocolService: BaseService
{
    public static int Counter = FormsHelper.AddScopedConfiguration<MessageProtocolService>();

    private readonly IAuthorizationContext _context;
    private readonly IBusinessModel _business;

    public MessageProtocolService(IAuthorizationContext context,IBusinessModel business )
    {
        _context = context;
        _business = business;
    }

    public List<MessageProtocol> GetMessageProtocolsForUser(int userId)
    {
        User user = _context.Users.Include(u => u.UserGroups).Where(u => u.ID == userId).SingleOrDefault();

        user.Groups = (from g in _context.Groups where (from p in user.UserGroups select p.GroupID).Contains(g.ID) select g).ToList();
        var userGroupIDs = (from p in user.Groups select p.ID).ToList();
        var bsfs = (from p in _business.GroupsBusinessFunctions where userGroupIDs.Contains(p.GroupID) select p.BusinessFunctionID).ToList();
        var protocols = (from p in _business.MessageProtocols.Include(p => p.Properties) where p.FromBusinessFunctionID != null && bsfs.Contains((int)p.FromBusinessFunctionID) select p).ToList();
        return protocols.ToList();
    }



    public string ToSql(MessageProtocol model){
        throw new Exception();
        //return (new BusinessDatabaseGenerator().CreateDataModel(model).toSql());
    }


    public Form ToForm( int id )
    
    {                     
        MessageProtocol protocol = GetMessage(id);
        return ToForm(protocol);                
    }

    public Form ToForm(MessageProtocol protocol){
        Form form = new Form();
        form.Item = new Dictionary<string, object>();
        form.Chapter = protocol.Name;
        protocol.Properties.ForEach(prop =>
        {
            prop.Join("Attribute");
            var field = new FormField()
            {
                Label = prop.Label,
                Name = prop.Name,
                Help = prop.Help,
                Icon = prop.Attribute.Icon,
                Type = prop.Attribute.InputType               
            };
            Type type = ReflectionService.TypeForShortName($"Input{field.Type}Attribute");
            if( type != null)
            {
                field.CustomValidators[$"Input{field.Type}Attribute"] =
                    new List<object>() { null };
            }

            if (prop.Required)
            {
                field.CustomValidators[nameof(NotNullNotEmptyAttribute)] =
                    new List<object>() { "Свойство " + prop.Label + " нужно определить" };
            }
            if( prop.Unique)
            {
                field.CustomValidators[nameof(UniqValidationAttribute)] =
                    new List<object>() { "Свойство " + prop.Label + " должно иметь уникальное значение" };                
            }
            form.FormFields.Add(field);
        });



        var createButton = new Button()
        {
            Label = "Создать",
            OnClick = (button) =>
            {
                form.OnComplete(form);

            }
        };

        createButton.Bind("Enabled", form, "IsValid");
        createButton.Enabled = false;
        form.Buttons.Add(createButton);
        form.EnableChangeSupport = true;
        createButton.EnableChangeSupport = true;
        form.Update(form.PropertyNames = (from p in protocol.Properties select p.Name).ToArray()); ;
        form.FormFields.Reverse();
        form.Title = Attrs.LabelFor(protocol.GetLabel());
         
        return form;
    }


    /// <summary>
    /// Выбор сведений о протоколе передачи сообщений
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public MessageProtocol GetMessage( int id )
    {
        MessageProtocol protocol = (from p in _business.MessageProtocols where p.ID==id select p).SingleOrDefault();
        protocol.Properties = (from p in _business.MessageProperties.Include(p => p.Attribute) where p.MessageProtocolID == protocol.ID select p).ToList();
        if (protocol == null)
        {
            throw new Exception("Не найден протокол с идентификатором "+id);
        }        
        return protocol;
    }

    public MessageProperty AddProperty(int messageProtocolId, int messageAttributeId)
    {            
        var messageProtocol = _business.MessageProtocols.Find(messageProtocolId);
        if (messageProtocol == null)
        {
            throw new Exception("DatasetNotFound");
        }
        MessageAttribute messageAttribute = _business.MessageAttributes.Find(messageAttributeId);
        if (messageAttribute == null)
        {
            throw new Exception("DatasetNotFound");
        }
        var property = new MessageProperty()
        {
            Label = "Новое свойство",
            Required = false,
            Unique = false,
            Index = false,
            Help = messageAttribute.Description,
            AttributeID = messageAttributeId,
            Name = messageAttribute.Name,
            MessageProtocolID = messageProtocolId
        };
        _business.MessageProperties.Add(property);
        _business.Save();
        return property;
    }

    public MessageAttribute GetMessageAttribute(int messageAttributeId)
    {
        return _business.MessageAttributes.Find(messageAttributeId);
    }

    public void UpdateMessageProperty(MessageProperty messageProperty)
    {
        _business.MessageProperties.Update(messageProperty);
        _context.Save();
    }

    public MessageProperty GetMessageProperty(int messageProtocolId, int messagePropertyId)
    {
        MessageProperty property = _business.MessageProperties.Find(messagePropertyId);
        property.MessageProtocol = _business.MessageProtocols.Find(property.MessageProtocolID);
        return property;
    }
}
 