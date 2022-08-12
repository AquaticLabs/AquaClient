namespace AquaClient.Utils;

public class Utilities
{
    
    
    public static bool ColorIsSame(Color color1, Color color2)
    {
        if (color1.R == color2.R && color1.G == color2.G && color1.B == color2.B)
        {
            return true;
        }
        return false;
    }
}