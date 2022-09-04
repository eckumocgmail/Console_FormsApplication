
using Microsoft.AspNetCore.Mvc;

public interface IFormConstructorEvents
{
    public IActionResult OnStart();
    public IActionResult OnAddPropertyButtonClicked();
    public IActionResult OnRemovePropertyButtonClicked();
    public IActionResult OnPropertyChanged( string property, string value );
    public IActionResult OnComplete();
    public IActionResult OnUpdate();

}
