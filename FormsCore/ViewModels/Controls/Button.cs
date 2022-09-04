using Newtonsoft.Json;
using System;

[EntityIcon("home")]
[EntityLabel("Кнопка")]
[Description(
    "По нажатию выполняет функцию заданную в переменной OnClick. " +
    "Может отображаться в 2 вариантах: надпись/иконка")]
public class Button: ViewItem
{


    [Label("Текст")]
     
    [NotNullNotEmpty("Необходимо задать текст надписи на кнопки")]
    public string Label { get => Get<string>("Label"); set => Set<string>("Label", value); }


    [Label("Иконка")]
    [InputIcon()]
    public string Icon { get => Get<string>("Icon"); set => Set<string>("Icon", value); }

    
    [JsonIgnore()]
    public Action<Button> OnClick { get => Get<Action<Button>>("OnClick"); set => Set<Action<Button>>("OnClick", value); }


    [Label("Вкл/Выкл")]
    public bool Enabled { get => Get<bool>("Enabled"); set => Set<bool>("Enabled", value); }

    [Label("Иконка/текст")]
    public bool IconOrText { get => Get<bool>("IconOrText"); set => Set<bool>("IconOrText", value); }



    [Label("Семантическая раскраска")]
    [SelectControl("info,danger,warning,secondary,success,debug")]
    
    public string BootstrapColor { get => Get<string>("BootstrapColor"); set => Set<string>("BootstrapColor", value); }




    public Button() : base()
    {
        Tag = "button";
        BootstrapColor = "primary";
 
        UpdateClassList();
        IconOrText = false;
        Enabled = true;
        Label = "Готово";
        Icon = "home";
        this.OnClick = (button) => {
            this.Label = "Clicked";
            this.Changed = true;
        };
       
        OnEvent += (message) =>
        {
            if( message is PropertyChangedMessage)
            {
                Changed = true;
            }
        };
    }

    [OnChange("BootstrapColor")]
    public void UpdateClassList(){
        ClassList.Add("btn");
        ClassList.Add("btn-"+BootstrapColor);
    }


    public void Click()
    {
        if(OnClick != null)
        {
            OnClick(this);
        }
    }

    
}


