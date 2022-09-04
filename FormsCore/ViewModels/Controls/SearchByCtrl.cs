using System.Collections.Generic;

public class SearchByCtrl : Book  
{
    public string Query { get => Get<string>("Query"); set => Set<string>("Query", value); }
    public List<string> Options { get; set; } = new List<string>();

    public string AspArea { get; set; }
    public string AspController { get; set; }        
    public string SearchQuery { get; set; }    

    public string GetEndpointUrl()
    {
        if (string.IsNullOrEmpty(AspArea))
        {
            return "/" + AspController;
        }
        else
        {
            return "/"+ AspArea + "/" + AspController;
        }
    }


    public SearchByCtrl() : base()
    {
        Init();
        this.Query = "";
        this.Changed = false;
    }
}
