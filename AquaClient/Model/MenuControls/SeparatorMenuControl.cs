using AquaClient.Model.DefaultControls;

namespace AquaClient.Model.MenuControls;

public class SeparatorMenuControl : MenuControl
{
    private Separator separator;
    private int width;
    private Color color;
    
    public SeparatorMenuControl(int width, Color color, EventHandler handler = null)
    {
        controlType = ControlType.Header;
        this.width = width;
        this.color = color;
        if (handler != null)
        {
            EventHandlers.Add(handler);
        }
    }


    public override List<Control> SetupControls(int locationX, int locationY, int sizeW, int sizeH)
    {
        return SetupControls(locationX, locationY);
    }


    private List<Control> SetupControls(int locationX, int locationY)
    {
        var controls = new List<Control>();
        separator = new Separator(new Point(locationX, locationY), width, color);
        separator.Name = "SeparatorMenuControl";
        controls.Add(separator);

        return controls;
    }

    public Separator GetSeparator()
    {
        return separator;
    }
}