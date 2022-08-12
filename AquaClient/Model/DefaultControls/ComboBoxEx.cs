namespace AquaClient.Model.DefaultControls;

public class ComboBoxEx : ComboBox
{
    
    public ComboBoxEx()
    {
        this.SetStyle(ControlStyles.Selectable, false);
    }
    
    protected override bool ShowFocusCues
    {
        get { return false; }
    }
}