using adobe_color_picker_clone_part_1;
using EventHandler = System.EventHandler;

namespace AquaClient.Model.MenuControls;

public class ColorBoxMenuControl : MenuControl
{
    private Ctrl2DColorBox colorBox;
    private CtrlVerticalColorSlider verticalSlider;
    private Button colorViewer;
    private Label colorBoxLabel;
    private string label;

    private Color rgb;
    private AdobeColors.HSL hsl;
    private AdobeColors.CMYK cmyk;


    public ColorBoxMenuControl(Color defaultColor, string label = "", EventHandler handler = null)
    {
        controlType = ControlType.ColorBox;

        rgb = defaultColor;
        hsl = AdobeColors.RGB_to_HSL(rgb);
        cmyk = AdobeColors.RGB_to_CMYK(rgb);
        this.label = label;

        if (handler != null)
        {
            EventHandlers.Add(handler);
        }
    }


    public override List<Control> SetupControls(int locationX, int locationY, int sizeW, int sizeH)
    {
        return SetupControls(locationX, locationY);
    }


    private List<Control> SetupControls(int locationX, int locationY, int sizeW = 190, int sizeH = 20,
        int labelSpacing = 1)
    {
        var controls = new List<Control>();

        if (!label.Equals(""))
        {
            colorBoxLabel = new Label
            {
                Location = new Point(locationX, locationY),
                Size = new Size(250, Styles.DefaultOptionStyle.Font.Height + 1),
                Text = label,
                Name = "ColorboxMenuControl",
                Font = Styles.DefaultOptionStyle.Font,
                ForeColor = Color.LightGray,
            };
        }

        controls.Add(colorBoxLabel);
        locationY += labelSpacing + colorBoxLabel.Size.Height;

        colorViewer = new Button()
        {
            Enabled = false,
            BackColor = rgb,
            Name = "ColorboxMenuControl",
            Location = new Point(locationX, locationY),
            Size = new Size(sizeW, 20),
            FlatStyle = FlatStyle.Flat,
        };
        colorViewer.FlatAppearance.BorderSize = 0;
        controls.Add(colorViewer);

        locationY += labelSpacing + colorViewer.Size.Height;

        colorBox = new Ctrl2DColorBox()
        {
            DrawStyle = Ctrl2DColorBox.eDrawStyle.Hue,
            Location = new Point(locationX, locationY),
            AutoSize = false,
            Name = "ColorboxMenuControl",
            Size = new Size(160, 160),
            HSL = hsl,
            RGB = rgb,
            BorderStyle = BorderStyle.None,
        };
        colorBox.Reset_Marker(true);
        colorBox.Scroll += BigBoxChange;
        controls.Add(colorBox);


        verticalSlider = new CtrlVerticalColorSlider()
        {
            DrawStyle = CtrlVerticalColorSlider.eDrawStyle.Hue,
            Location = new Point(locationX + colorBox.Width, locationY),
            AutoSize = false,
            Size = new Size(30, 160),
            HSL = hsl,
            RGB = rgb,
            Name = "ColorboxMenuControl",
            TabStop = false,
            BorderStyle = BorderStyle.None,
            BackColor = Color.FromArgb(54, 54, 54),
            ForeColor = Color.FromArgb(54, 54, 54),
        };
        verticalSlider.Reset_Slider(true);
        verticalSlider.Scroll += VerticalBoxChange;
        
        controls.Add(verticalSlider);

        return controls;
    }

    private void BigBoxChange(object sender, EventArgs e)
    {
        hsl = colorBox.HSL;
        rgb = AdobeColors.HSL_to_RGB(hsl);
        cmyk = AdobeColors.RGB_to_CMYK(rgb);

        verticalSlider.HSL = hsl;
        colorViewer.BackColor = rgb;
    }

    private void VerticalBoxChange(object sender, EventArgs e)
    {
        hsl = verticalSlider.HSL;
        rgb = AdobeColors.HSL_to_RGB(hsl);
        cmyk = AdobeColors.RGB_to_CMYK(rgb);

        colorBox.HSL = hsl;
        colorViewer.BackColor = rgb;
    }

    public Color GetColor()
    {
        return rgb;
    }
}