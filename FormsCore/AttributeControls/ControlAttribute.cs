using System;

public abstract class ControlAttribute : Attribute
{
    public abstract ViewItem CreateControl(InputFormField field);
    public abstract ViewItem CreateControl(FormField field);
    public virtual void Layout(Form form) { }
}