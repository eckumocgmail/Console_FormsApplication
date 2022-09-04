using System;
using System.Collections.Generic;
using UserAuthorization.Views.Shared.Components.ContextMenu;

public class ContextMenu
{
    public string Icon { get; set; }
    public string Label { get; set; }
    public Action<ContextMenu> OnClick { get; set; }

    public List<ContextMenu> Items { get; set; } = new List<ContextMenu>();


    public void Click()
    {
        if (OnClick != null)
        {
            OnClick(this);
        }
    }
}