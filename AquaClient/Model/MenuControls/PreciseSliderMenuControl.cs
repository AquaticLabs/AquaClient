
using AquaClient.Model.DefaultControls;

namespace AquaClient.Model.MenuControls;

public class PreciseSliderMenuControl : MenuControl
{
    private LDoubleTrackBar slider;
    private Label sliderLabel;
    private string label;

    private int barSize;
    private bool isRound;
    private double min, max, value;
    
    

    public PreciseSliderMenuControl(int barSize, bool isRound, double min, double max, double value, string label = "", EventHandler handler = null)
    {
        controlType = ControlType.Precise_Slider;
        this.barSize = barSize;
        this.isRound = isRound;
        this.min = min;
        this.max = max;
        this.value = value;
        
        
        if (handler != null)
        {
            EventHandlers.Add(handler);
        }

        this.label = label;

        EventHandlers.Add(SliderMath);
    }


    public override List<Control> SetupControls(int locationX, int locationY, int sizeW, int sizeH)
    {
        return SetupControls(locationX, locationY);
    }


    private List<Control> SetupControls(int locationX, int locationY, int sizeW = 150, int sizeH = 15, int labelSpacing = 1)
    {
        var controls = new List<Control>();

        var adjLocX = locationX + (sizeW / 6);

        
        if (!label.Equals(""))
        {
            sliderLabel = new Label
            {
                Location = new Point(adjLocX, locationY),
                Size = new Size(250, Styles.DefaultOptionStyle.Font.Height + 1),
                Text = label.Replace("%value%", value + ""),
                Font = Styles.DefaultOptionStyle.Font,
                Name = "PreciseSliderMenuControl",
                ForeColor = Color.LightGray,
            };
        }
        controls.Add(sliderLabel);

        locationY += labelSpacing + sliderLabel.Size.Height;


        slider = new LDoubleTrackBar()
        {
            Location = new Point(locationX, locationY),
            AutoSize = false,
            Size = new Size(150, 17),
            Font = Styles.DefaultOptionStyle.Font,
            Name = "PreciseSliderMenuControl",
            ForeColor = Color.Black,
            L_IsRound = isRound,
            L_BarColor = Styles.DisabledColor,
            L_SliderColor = Styles.EnabledColor,
            L_Orientation = LTrackBarOrientation.Horizontal_LR,
            L_BarSize = barSize,
            L_Maximum = max,
            L_Minimum = min,
            L_Value = value,
        };
        slider.LValueChanged += CallEvents;
        controls.Add(slider);
        
        return controls;
    }

    private void SliderMath(object sender, EventArgs e)
    {
        value = slider.L_Value;
        sliderLabel.Text = label.Replace("%value%", value + "");
    }

    public double GetValue()
    {
        return value;
    }
}