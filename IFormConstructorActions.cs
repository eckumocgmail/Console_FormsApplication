using System.Collections.Generic;

public interface IFormConstructorActions
{
    void AddForm(string name, string action, string method, string parent=null);
    void AddTextbox(string formname, string name, string value, IEnumerable<string> validators);
    void AddSelectbox(string formname, string name, string value, IEnumerable<string> validators);
    void AddCheckbox(string formname, string name, string value, IEnumerable<string> validators);
    void AddCombobox(string formname, string name, string value, IEnumerable<string> validators);    
}
