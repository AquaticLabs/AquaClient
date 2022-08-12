namespace AquaClient.Model.DefaultControls;

public class ButtonEx : Button
{

    public ButtonEx()
    {
        this.SetStyle(ControlStyles.Selectable, false);
    }
    protected override bool ShowFocusCues
    {
        get { return false; }
    }
}