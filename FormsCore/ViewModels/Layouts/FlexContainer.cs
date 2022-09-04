using System;

public class FlexContainer: ViewItem
{
    public string View = "FlexContainer";

    public bool Horizontal { get => Get<bool>("Horizontal"); set => Set<bool>("Horizontal", value); }


    [SelectControl("'wrap','nowrap'")]
    public string FlexWrap { get => Get<string>("FlexWrap"); set => Set<string>("FlexWrap", value); }

    public FlexContainer()
    {       
        Horizontal = true;
        FlexWrap = "wrap";
        Changed = false;
    }

    public void ToContextMenu()
    {
        View = "ContextMenu";
    }
}
