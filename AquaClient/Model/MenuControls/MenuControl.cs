namespace AquaClient.Model;

public class MenuControl
{
    protected ControlType controlType;
    protected readonly List<EventHandler> EventHandlers = new List<EventHandler>();
    protected readonly List<object> EventHandlers2 = new List<object>();
    public AnchorPoint AnchorPoint;

    public int CustomX;
    public int CustomY;

    public bool ResetLine = true;
    public int XAdjustment = 0;
    public int YAdjustment = 0;

    protected MenuControl()
    {
    }


    public virtual List<Control> SetupControls(int locationX, int locationY, int sizeW = 0, int sizeH = 0)
    {
        return null;
    }

    protected void CallEvents(object sender, EventArgs eventArgs)
    {
        foreach (var eventHandler in EventHandlers)
        {
            eventHandler.Invoke(sender, eventArgs);
        }
    }

    public event EventHandler Fire
    {
        add => EventHandlers.Add(value);
        remove => EventHandlers.Remove(value);
    }

}