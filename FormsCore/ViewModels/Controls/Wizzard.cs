using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Wizzard: PanelItem
{
    public int Step { get; set; } = 0;


    public Pane CurrentView { get; set; } = new Pane();


    [JsonIgnore()]

    public List<ViewItem> WizzardItems = new List<ViewItem>();

    public Wizzard() : base()
    {        
    }

    public void SetNextDialog(ViewItem next) {
        WizzardItems.Add(next);
    }

    public void Start()
    {
        if (WizzardItems.Count() == 0)
        {
            throw new Exception("Элементы мастера не заданы");
        }
        Step = 1;
        CurrentView.Item = WizzardItems.ToArray()[Step];
    }


    public void Next()
    {         
        Step++;
        CurrentView.Item = WizzardItems.ToArray()[Step];
    }



    public void Complete()
    {
        Step++;        
    }

}