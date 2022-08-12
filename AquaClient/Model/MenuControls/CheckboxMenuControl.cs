using AquaClient.Model.DefaultControls;

namespace AquaClient.Model.MenuControls;

public class CheckboxMenuControl : MenuControl
{
    private ButtonEx checkbox;
    private bool toggle;
    private Label checkboxLabel;
    private string label;
    private TextStyle textStyle = Styles.NunitoExtraBoldMedSm;

    public CheckboxMenuControl(string label = "", TextStyle textStyle = null, EventHandler handler = null, bool defaultToggle = false)
    {
        controlType = ControlType.CheckBox;
        this.textStyle = textStyle;
        if (handler != null)
        {
            EventHandlers.Add(handler);
        }
        this.label = label;
        this.toggle = defaultToggle;

        EventHandlers.Add(CheckBoxMath);
    }


    public override List<Control> SetupControls(int locationX, int locationY, int sizeW, int sizeH)
    {
        return SetupControls(locationX, locationY);
    }
    

    private List<Control> SetupControls(int locationX, int locationY, int sizeW = 20, int sizeH = 20,
        string buttonText = "", int labelSpacing = 3)
    {
        var controls = new List<Control>();
        var labelSpace = labelSpacing + sizeW;

        checkbox = new ButtonEx();
        checkbox.Location = new Point(locationX, locationY);
        checkbox.Size = new Size(sizeW, sizeH);
        checkbox.Text = buttonText;
        checkbox.Name = "CheckboxMenuControl";
        checkbox.FlatStyle = FlatStyle.Flat;
        checkbox.TabStop = false;
        checkbox.FlatAppearance.BorderSize = 0;
        checkbox.BackColor = toggle ? Styles.EnabledColor : Styles.DisabledColor;
        checkbox.Click += CallEvents;
        controls.Add(checkbox);
        
        

        if (!label.Equals(""))
        {

            checkboxLabel = new Label();
            checkboxLabel.Location = new Point(locationX + labelSpace, locationY);
            checkboxLabel.AutoSize = true;
            checkboxLabel.Text = label;
            checkboxLabel.Font = textStyle.Font;
            checkboxLabel.ForeColor = textStyle.ForeColor;
            controls.Add(checkboxLabel);

        }
        
        return controls;
    }

    private void CheckBoxMath(object sender, EventArgs e)
    {
        toggle = !toggle;
        checkbox.BackColor = toggle ? Styles.EnabledColor : Styles.DisabledColor;
    }

    public bool GetToggled()
    {
        return toggle;
    }
    
    
}