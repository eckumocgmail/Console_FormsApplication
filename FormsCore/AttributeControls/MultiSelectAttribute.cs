
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalConstructor.Server.DataAttributes.AttributeControls
{
    public class MultiSelectAttribute: ControlAttribute
    {
        [InputText]
        [NotNullNotEmpty()]        
        public string DictionaryName { get; set; }

        [NotNullNotEmpty()]
        public string OptionValueProperty { get; set; }

        [NotNullNotEmpty()]
        public string OptionLabelProperty { get; set; }

       
        public override ViewItem CreateControl(FormField field)
        {
            /*if(new ApplicationDbContext().GetEntityTypeNames().Contains(DictionaryName) == false)
            {
                throw new Exception("Свойство атрибута "+GetType().Name+"."+nameof(DictionaryName)+" должно содержать действительное наименование таблицы стравочника в базе данных");
            }
            return new Select() { 
                Options = new Dictionary<object, object>()
            };*/
            return null;
        }

        public override ViewItem CreateControl(InputFormField field)
        {
            throw new NotImplementedException();
        }

        public override void Layout(Form form)
        {
            
        }
    }
}
