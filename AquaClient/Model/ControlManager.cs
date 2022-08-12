using AquaClient.Model.DefaultControls;
using AquaClient.Model.MenuControls;

namespace AquaClient.Model;

public enum ControlType
{
    Button,
    CheckBox,
    ColorBox,
    ComboBox,
    Header,
    Slider,
    Precise_Slider,
    Spacer,
    Text_Field,
}

public enum AnchorPoint
{
    Left,
    Middle,
    Right,
    Custom
}

public class ControlManager
{
    private Dictionary<string, MenuControl> controls;

    public int spacing = 2;
    private Point LeftAnchor = new Point(5, 5);
    private Point MiddleAnchor = new Point(150, 5);
    private Point RightAnchor = new Point(250, 5);

    public ControlManager(Scene owningScene)
    {
        var width = owningScene.Width;
        var height = owningScene.Height;

        var right = owningScene.Right - (width / 3);
        var middle = owningScene.Left + (width / 2);


        LeftAnchor = new Point(owningScene.Location.X + 15, owningScene.Location.Y);
        MiddleAnchor = new Point(middle, owningScene.Location.Y);
        RightAnchor = new Point(right, owningScene.Location.Y);

        /*LeftAnchor = new Point(owningScene.Location.X + 85, owningScene.Location.Y);
        MiddleAnchor = new Point(owningScene.Location.X + 175, owningScene.Location.Y);
        RightAnchor = new Point(owningScene.Location.X + 320, owningScene.Location.Y);*/

        controls = new Dictionary<string, MenuControl>();
    }

    public ControlManager(Menu owningMenu)
    {
        var width = owningMenu.Width;
        var height = owningMenu.Height;
        var y = owningMenu.TopSep.Bottom;

        var right = owningMenu.Right - (width / 3);
        var middle = owningMenu.Left + (width / 2);


        LeftAnchor = new Point(0, y);
        MiddleAnchor = new Point(middle, y);
        RightAnchor = new Point(right, y);

        Console.WriteLine("Left: " + LeftAnchor);
        Console.WriteLine("Mid: " + MiddleAnchor);
        Console.WriteLine("Right: " + RightAnchor);

        controls = new Dictionary<string, MenuControl>();
    }

    public void AddControl(string key, MenuControl menuControl, AnchorPoint anchorPoint, bool resetLine = true,
        int xAdjustment = 0, int yAdjustment = 0)
    {
        menuControl.ResetLine = resetLine;
        menuControl.XAdjustment = xAdjustment;
        menuControl.YAdjustment = yAdjustment;
        AddControl(key, menuControl, anchorPoint);
    }

    public void AddControl(string key, MenuControl menuControl, AnchorPoint anchorPoint, int cX = 0, int cY = 0)
    {
        menuControl.CustomX = cX;
        menuControl.CustomY = cY;
        AddControl(key, menuControl, anchorPoint);
    }

    public void AddControl(string key, MenuControl menuControl, AnchorPoint anchorPoint)
    {
        menuControl.AnchorPoint = anchorPoint;

        if (controls.Keys.Contains(key))
        {
            int i = 1;

            while (controls.Keys.Contains(key))
                key += i++;
        }

        controls.Add(key, menuControl);
    }

    public void RemoveControl(string key)
    {
        controls.Remove(key);
    }

    public MenuControl GetControl(string key)
    {
        return controls[key];
    }


    public List<Control> GetBuiltMenuControls()
    {
        var finalControls = new List<Control>();

        for (var i = 0; i < controls.Count; i++)
        {
            var menuControl = controls.Values.ToArray()[i];
            var allCtrls = new List<Control>();
            if (menuControl.AnchorPoint == AnchorPoint.Right)
            {
                // Right

                if (menuControl is SpacerMenuControl)
                {
                    RightAnchor.X += ((SpacerMenuControl)menuControl).SpaceX();
                    RightAnchor.Y += ((SpacerMenuControl)menuControl).SpaceY();
                    continue;
                }
                
                allCtrls = menuControl.SetupControls(RightAnchor.X + menuControl.XAdjustment, RightAnchor.Y + menuControl.YAdjustment);
                finalControls.AddRange(allCtrls);
                if (menuControl.ResetLine)
                    RightAnchor.Y += GetTotalHeight(allCtrls) + spacing;
                continue;
            }

            if (menuControl.AnchorPoint == AnchorPoint.Left)
            {
                //Left
                if (menuControl is SpacerMenuControl)
                {
                    LeftAnchor.X += ((SpacerMenuControl)menuControl).SpaceX();
                    LeftAnchor.Y += ((SpacerMenuControl)menuControl).SpaceY();
                    continue;
                }
                allCtrls = menuControl.SetupControls(LeftAnchor.X + menuControl.XAdjustment, LeftAnchor.Y + menuControl.YAdjustment);
                finalControls.AddRange(allCtrls);
                if (menuControl.ResetLine)
                    LeftAnchor.Y += GetTotalHeight(allCtrls) + spacing;
                continue;
            }

            if (menuControl.AnchorPoint == AnchorPoint.Middle)
            {
                //Middle
                if (menuControl is SpacerMenuControl)
                {
                    MiddleAnchor.X += ((SpacerMenuControl)menuControl).SpaceX();
                    MiddleAnchor.Y += ((SpacerMenuControl)menuControl).SpaceY();
                    continue;
                }
                allCtrls = menuControl.SetupControls(MiddleAnchor.X + menuControl.XAdjustment, MiddleAnchor.Y + menuControl.YAdjustment);
                finalControls.AddRange(allCtrls);
                if (menuControl.ResetLine)
                    MiddleAnchor.Y += GetTotalHeight(allCtrls) + spacing;
            }
        }

        return finalControls;
    }

    public void AdjustAnchor(AnchorPoint anchorPoint, int xAdj, int yAdj)
    {
        switch (anchorPoint)
        {
            case AnchorPoint.Left:
                LeftAnchor.X += xAdj;
                LeftAnchor.Y += yAdj;
                break;
            case AnchorPoint.Middle:
                MiddleAnchor.X += xAdj;
                MiddleAnchor.Y += yAdj;
                break;
            case AnchorPoint.Right:
                RightAnchor.X += xAdj;
                RightAnchor.Y += yAdj;
                break;
        }
    }

    private int GetTotalHeight(List<Control> ctrls)
    {
        int top = -1;
        int bottom = -1;
        for (var i = 0; i < ctrls.Count; i++)
        {
            var ctrl = ctrls[i];
            if (top == -1 || ctrl.Top < top)
            {
                top = ctrl.Top;
            }

            if (bottom == -1 || ctrl.Bottom > bottom)
            {
                bottom = ctrl.Bottom;
            }
        }

        return bottom - top;
    }
}