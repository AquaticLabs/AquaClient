namespace AquaClient.Model.DefaultControls;

public class Scene : Panel
{
    public Menu Owner { get; }
    public ControlManager ControlManager;
    public Scene(Menu owner, Point location, Size size)
    {
        Owner = owner;
        ControlManager = new ControlManager(this);
        Location = PointToScreen(location);
        Size = size;
        Hide();
        owner.Content.Controls.Add(this);
    }
    
    
    protected void CompleteLayout()
    {
        var controls = ControlManager.GetBuiltMenuControls();
        for (var i = 0; i < controls.Count; i++)
        {
            // if debug//
            Console.WriteLine("CtrlName:" + controls[i].Name + "" + controls[i].Location);
            Controls.Add(controls[i]);
        }
    }
}