namespace AquaClient.Model.MenuControls;

public class LabelButtonMenuControl : MenuControl
{
    private Label labelButton;
    private Label buttonLabel;
    private string label;

    private TextStyle style;
    public Color hoverColor = Styles.EnabledColor;
    public Color clickColor = Color.Aqua;
    public Color defaultColor = Color.White;

    public LabelButtonMenuControl(string label, TextStyle style, EventHandler handler = null)
    {
        controlType = ControlType.Button;
        this.style = style;
        defaultColor = style.ForeColor;
        if (handler != null)
        {
            EventHandlers.Add(handler);
        }
        this.label = label;
    }


    public override List<Control> SetupControls(int locationX, int locationY, int sizeW, int sizeH)
    {
        return SetupControls(locationX, locationY);
    }
    

    private List<Control> SetupControls(int locationX, int locationY)
    {
        var controls = new List<Control>();

        labelButton = new Label();
        labelButton.Location = new Point(locationX, locationY);
        labelButton.AutoSize = true;
        labelButton.Name = "LabelButtonMenuControl";
        labelButton.Text = label;
        labelButton.Font = style.Font;
        labelButton.ForeColor = defaultColor;
        labelButton.Click += CallEvents;
        labelButton.MouseEnter += MouseEnter;
        labelButton.MouseLeave += MouseExit;
        labelButton.MouseDown += MouseDown;
        labelButton.MouseUp += MouseUp;
        controls.Add(labelButton);

        return controls;
    }

    private void MouseEnter(object sender, EventArgs args)
    {
        labelButton.ForeColor = hoverColor;
    }
    private void MouseExit(object sender, EventArgs args)
    {
        labelButton.ForeColor = defaultColor;
    }
    private void MouseDown(object sender, EventArgs args)
    {
        labelButton.ForeColor = clickColor;
    }
    private void MouseUp(object sender, EventArgs args)
    {
        if (AquaClient.Utils.Utilities.ColorIsSame(labelButton.ForeColor, clickColor))
        {
            labelButton.ForeColor = hoverColor;
        }
    }
}