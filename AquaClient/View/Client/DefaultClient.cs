using AquaClient.Model;
using AquaClient.Model.MenuControls;

namespace AquaClient.View.Client;

public class DefaultClient : Menu
{
    public DefaultClient(Background background) : base(background, Styles.DefaultMenuStyle, "Aqua Client", 20,
        new Point(10, 10), false)
    {
        ControlManager.AddControl("HeaderControl", new HeaderMenuControl("Header Control", Styles.DefaultCategoryStyle), AnchorPoint.Left);
        
        CompleteLayout();
    }
    
}