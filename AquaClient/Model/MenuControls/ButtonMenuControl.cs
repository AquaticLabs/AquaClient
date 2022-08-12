using AquaClient.Model.DefaultControls;

namespace AquaClient.Model.MenuControls;

public class ButtonMenuControl : MenuControl
{
    private ButtonEx button;
    private string buttonText = "";
    private Label buttonLabel;
    private string label;
    public int SizeW = 20;
    public int SizeH = 20;
    public Color BackColor = Styles.DisabledColor;
    public Color ForeColor = Color.White;
    private TextStyle textStyle = Styles.NunitoExtraBoldMedSm;

    public ButtonMenuControl(string label = "", string buttonText = "", TextStyle textStyle = null, EventHandler handler = null)
    {
        controlType = ControlType.Button;
        this.buttonText = buttonText;
        
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
    

    private List<Control> SetupControls(int locationX, int locationY, int labelSpacing = 3)
    {
        var controls = new List<Control>();
        var labelSpace = labelSpacing + SizeW;

        button = new ButtonEx();
        button.Location = new Point(locationX, locationY);
        button.Size = new Size(SizeW, SizeH);
        button.Text = buttonText;
        button.Name = "ButtonMenuControl";
        button.Font = textStyle.Font;
        button.ForeColor = ForeColor;
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.BackColor = BackColor;
        button.TabStop = false;
        button.Click += CallEvents;
        controls.Add(button);
        
        if (!label.Equals(""))
        { 
            buttonLabel = new Label();
            buttonLabel.Location = new Point(locationX + labelSpace, locationY + 2);
            buttonLabel.Text = label;
            buttonLabel.Font = Styles.DefaultOptionStyle.Font;
            buttonLabel.ForeColor = Color.LightGray;
            controls.Add(buttonLabel);

        }
        
        return controls;
    }
    
    public Button Button
    {
        get => button;
    }
}