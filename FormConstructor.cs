
using Microsoft.AspNetCore.Mvc;

using System.Collections;

public class FormConstructor: Controller, IFormConstructorEvents 
{
    private readonly IFormConstructorActions controller;

    public FormConstructor(IFormConstructorActions controller)
    {
        this.controller = controller;
    }

    public IActionResult OnStart()
    {
        controller.AddForm("NewForm", "Post", "Post");
        return PartialView("Form");
    }

    public IActionResult OnAddPropertyButtonClicked()
    {
        throw new System.NotImplementedException();
    }

    public IActionResult OnRemovePropertyButtonClicked()
    {
        throw new System.NotImplementedException();
    }

    public IActionResult OnPropertyChanged(string property, string value)
    {
        throw new System.NotImplementedException();
    }

    public IActionResult OnComplete()
    {
        throw new System.NotImplementedException();
    }

    public IActionResult OnUpdate()
    {
        throw new System.NotImplementedException();
    }
}
