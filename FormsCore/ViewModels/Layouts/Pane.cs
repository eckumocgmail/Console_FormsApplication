using Newtonsoft.Json;

using System;

public class Pane: ViewItem
{



    [Label("Тип представления")]
    [SelectControlWithoutValidation("{{GetViewComponents()}}")]
    [JsonIgnore()]
    public virtual string View { get => Get<string>("View"); set => Set<string>("View", value); }

    [JsonIgnore()]
    public virtual object Item { get => Get<object>("Item"); set => Set<object>("Item", value); }
  

    public Pane()
    {
      
        ClassList.Add("content-box");
        var ctrl = this;
        View = "Table";
        Init();
        this.Item = null;
        OnEvent += (message) =>
        {
            if (message is PropertyChangedMessage)
            {
                PropertyChangedMessage changed = (PropertyChangedMessage)message;
                /*if( OnChange == null)
                {

                }
                else
                {
                    OnChange(changed);
                }*/
                
                if (changed.Property == "View" )
                {
                    ctrl.Item = ReflectionService.CreateWithDefaultConstructor<object>(changed.After.ToString().Replace("ViewComponent",""));
                    ctrl.Changed = true;
                }
            }
        };
        OnEvent += (message) =>
        {

        };
        ContextMenu = null;
        Changed = false;
    }

    [OnChange("View")]
    public void UpdateView()
    {
        Writing.ToConsole("Изменилось свойство определяющее тип представления");
        Item = ReflectionService.CreateWithDefaultConstructor<object>(View.Replace("ViewComponent", ""));
        Changed = true;
    }


/*    -webkit-tap-highlight-color: transparent;
--blue: #007bff;
--indigo: #6610f2;
--purple: #6d49cb;
--pink: #e83e8c;
--red: #dc3545;
--orange: #fd7e14;
--yellow: #ffc107;
--green: #28a745;
--teal: #20c997;
--cyan: #17a2b8;
--white: #fff;
--gray: #5e5e5e;
--gray-dark: #404040;
--primary: #007bff;
--secondary: #f0f0f0;
--success: #108548;
--info: #1f75cb;
--warning: #ab6100;
--danger: #dd2b0e;
--light: #dbdbdb;
--dark: #404040;
--breakpoint-xs: 0;
--breakpoint-sm: 576px;
--breakpoint-md: 768px;
--breakpoint-lg: 992px;
--breakpoint-xl: 1200px;
--font-family-sans-serif: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Noto Sans", Ubuntu, Cantarell, "Helvetica Neue", sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji";
--font-family-monospace: "Menlo", "DejaVu Sans Mono", "Liberation Mono", "Consolas", "Ubuntu Mono", "Courier New", "andale mono", "lucida console", monospace;
*/
    public string SetView(string view)
    {
        return View = view;        
    }

    public object Clear()
    {
        var item = Item;
        Item = null;
        return item;
    }
}