namespace AquaClient.Model.MenuControls;

public class HeaderMenuControl : MenuControl
{
    private Label headerLabel;
    private string label;
    private TextStyle style;

    public HeaderMenuControl(string label, TextStyle style, EventHandler handler = null)
    {
        controlType = ControlType.Header;
        if (handler != null)
        {
            EventHandlers.Add(handler);
        }

        this.label = label;
        this.style = style;
    }


    public override List<Control> SetupControls(int locationX, int locationY, int sizeW, int sizeH)
    {
        return SetupControls(locationX, locationY);
    }


    private List<Control> SetupControls(int locationX, int locationY)
    {
        var controls = new List<Control>();
        headerLabel = new Label();
        headerLabel.Location = new Point(locationX, locationY + 2);
        headerLabel.AutoSize = true;
        headerLabel.Text = label;
        headerLabel.Name = "HeaderMenuControl";
        headerLabel.Font = style.Font;
        headerLabel.ForeColor = style.ForeColor;
        controls.Add(headerLabel);

        return controls;
    }

    public Label GetHeaderLabel()
    {
        return headerLabel;
    }
}