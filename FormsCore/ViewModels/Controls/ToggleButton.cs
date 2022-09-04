using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ToggleButton : Button
{
    public bool ToggleButtonActive { get => Get<bool>("ToggleButtonActive"); set => Set<bool>("ToggleButtonActive", value); }



    public ToggleButton()
    {
        ToggleButtonActive = false;
        OnClick = (button) =>
        {
            ToggleButtonActive = ToggleButtonActive ? false : true;
            Changed = true;
            FireEvent(new PropertyChangedMessage ()
            {
                Source = this,
                Property = "Enabled",
                Before = Enabled ? false : true,
                After = Enabled
            });
        };
        Changed = false;
    }

    

}