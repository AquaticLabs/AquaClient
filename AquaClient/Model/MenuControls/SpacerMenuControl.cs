namespace AquaClient.Model.MenuControls;

public class SpacerMenuControl : MenuControl
{
    private int xSpace;
    private int ySpace;

    public SpacerMenuControl(int xSpace, int ySpace)
    {
        controlType = ControlType.Spacer;
        this.xSpace = xSpace;
        this.ySpace = ySpace;
    }


    public override List<Control> SetupControls(int locationX, int locationY, int sizeW, int sizeH)
    {
        return null;
    }

    public int SpaceX()
    {
        return xSpace;
    }
    public int SpaceY()
    {
        return ySpace;
    }
    
}