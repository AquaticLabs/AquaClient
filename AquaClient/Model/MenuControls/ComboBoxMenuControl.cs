using AquaClient.Model.DefaultControls;

namespace AquaClient.Model.MenuControls;

public class ComboBoxMenuControl : MenuControl
{
    private FlatComboBox comboBox;
    private List<ComboItem> itemList;
    private int defaultIndex = 0;

    public int sizeW = 80;
    public int sizeH = 25;
    
    
    private Label checkboxLabel;
    private string label;
    private TextStyle textStyle = Styles.NunitoExtraBoldMedSm;
    public Color TextColor = Color.White;

    public ComboBoxMenuControl(List<ComboItem> itemList, string label = "", TextStyle textStyle = null, EventHandler handler = null, int defaultIndex = 0)
    {
        controlType = ControlType.CheckBox;
        this.textStyle = textStyle;
        this.itemList = itemList;
        this.defaultIndex = defaultIndex;
        
        
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
    

    private List<Control> SetupControls(int locationX, int locationY,
        string buttonText = "", int labelSpacing = 3)
    {
        var controls = new List<Control>();
        var labelSpace = labelSpacing + sizeW;

        comboBox = new FlatComboBox();
        comboBox.Location = new Point(locationX, locationY);
        comboBox.Size = new Size(sizeW, sizeH);
        comboBox.Text = buttonText;
        comboBox.Name = "ComboBoxMenuControl";
        comboBox.FlatStyle = FlatStyle.Flat;
        comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox.BackColor =  textStyle.BackColor;
        comboBox.ForeColor =  textStyle.ForeColor;
        comboBox.DisplayMember = "Text";
        comboBox.ValueMember = "ID";
        comboBox.TabStop = false;
        comboBox.SelectionChangeCommitted += CallEvents;

        comboBox.Items.AddRange(itemList.ToArray());

        if (itemList.Count < defaultIndex) defaultIndex = itemList.Count;
        if (defaultIndex < 0) defaultIndex = 0;
        comboBox.SelectedIndex = defaultIndex;
        
        controls.Add(comboBox);


        if (!label.Equals(""))
        {

            checkboxLabel = new Label();
            checkboxLabel.Location = new Point(locationX + labelSpace, locationY);
            checkboxLabel.AutoSize = true;
            checkboxLabel.Text = label;
            checkboxLabel.Font = textStyle.Font;
            checkboxLabel.ForeColor = TextColor;
            controls.Add(checkboxLabel);

        }
        
        return controls;
    }

    public FlatComboBox GetComboBox()
    {
        return comboBox;
    }

}