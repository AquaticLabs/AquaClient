using AquaClient.Properties;

namespace AquaClient.Model
{
    internal static class Styles
    {
        public static MenuStyle DefaultMenuStyle = new MenuStyle("#333333", null, new Size(650, 425), 0.92, Resources.AquaticLabs_logo, FormBorderStyle.None, FormStartPosition.Manual, true, true);       
        public static TextStyle DefaultTitleStyle = new TextStyle(new Font("Arial", 14, FontStyle.Regular), ContentAlignment.BottomRight, null, "#FFFFFF", new Size(160, 25));
        public static TextStyle DefaultFooterStyle = new TextStyle(new Font("Arial", 7, FontStyle.Regular), ContentAlignment.BottomCenter, Color.Black, Color.DimGray, new Size(155, 12));
        public static TextStyle DefaultCategoryStyle = new TextStyle(new Font("Arial", 11.25F, FontStyle.Bold), ContentAlignment.TopLeft, null, "#FFFFFF", new Size(160, 20));
        public static TextStyle DefaultBoldOptionStyle = new TextStyle(new Font("Arial", 9.25F, FontStyle.Bold), ContentAlignment.TopLeft, null, "#FFFFFF", new Size(160, 20));
        public static TextStyle DefaultOptionStyle = new TextStyle(new Font("Arial", 9.25F, FontStyle.Regular), ContentAlignment.TopLeft, null, "#FFFFFF", new Size(160, 20));
        public static TextStyle NunitoExtraBoldSmall = new TextStyle(new Font("Nunito ExtraBold", 7.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0), ContentAlignment.TopLeft, null, "#FFFFFF", new Size(160, 20));
        public static TextStyle NunitoExtraBoldMedSm = new TextStyle(new Font("Nunito ExtraBold", 9.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0), ContentAlignment.TopLeft, null, "#FFFFFF", new Size(160, 20));
        public static TextStyle NunitoExtraBoldMed = new TextStyle(new Font("Nunito ExtraBold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0), ContentAlignment.TopLeft, null, "#FFFFFF", new Size(160, 20));
        public static TextStyle NunitoExtraBoldLarge = new TextStyle(new Font("Nunito ExtraBold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0), ContentAlignment.TopLeft, null, "#FFFFFF", new Size(160, 20));
     
        public static TextStyle ComboBoxStyle = new TextStyle(new Font("Nunito ExtraBold", 9.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0), ContentAlignment.TopLeft, Color.FromArgb(82, 82, 82), Color.DeepSkyBlue, new Size(160, 20));

        public static RadioButtonStyle DefaultMainNavButtonStyle = new RadioButtonStyle("#363d6e", "#FFFFFF", "#585174", "#000000", new Size(83, 45), ContentAlignment.MiddleCenter, FlatStyle.Flat, Appearance.Button, 1);
      
        public static Color BluishGray = Color.FromArgb(125, 161, 159);
        public static Color EnabledColor = Color.FromArgb(28, 172, 255);
        public static Color SubtleBlueChangeColor = Color.FromArgb(120, 206, 255);
        public static Color DisabledColor = Color.FromArgb(82, 82, 82);
        
        public static Color SeparatorColor = Color.FromArgb(50, 50, 50);    
        
        public static Color DarkGrayColor = Color.FromArgb(32, 32, 32);        
    }
}
