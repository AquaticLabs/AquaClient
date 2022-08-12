
namespace AquaClient.Model.DefaultControls
{
    public class MainNavButton : RadioButton
    {
        public MainNavButton(string text, Point pos, RadioButtonStyle style, Scene scene, bool isChecked = false)
        {
            Location = pos;
            Size = style.Size;
            Appearance = style.Appearance;
            Text = text;
            TextAlign = style.ContentAlignment ;
            BackColor = style.DefaultBack;
            ForeColor = style.DefaultFore;
            FlatStyle = style.FlatStyle;
            FlatAppearance.BorderSize = style.BorderSize;
            CheckedChanged += (sender, e) =>
            {
                if (Checked)
                {
                    BackColor = style.CheckedBack;
                    ForeColor = style.CheckedFore;
                }
                else
                {
                    BackColor = style.DefaultBack;
                    ForeColor = style.DefaultFore;
                }
            };
            Checked = isChecked;
        }
        
        public MainNavButton(string text, RadioButtonStyle style, Scene scene, bool isChecked = false)
        {
            Location = new Point(0, 0);
            Size = style.Size;
            Appearance = style.Appearance;
            Text = text;
            TextAlign = style.ContentAlignment ;
            BackColor = style.DefaultBack;
            ForeColor = style.DefaultFore;
            FlatStyle = style.FlatStyle;
            FlatAppearance.BorderSize = style.BorderSize;
            CheckedChanged += (sender, e) =>
            {
                if (Checked)
                {
                    BackColor = style.CheckedBack;
                    ForeColor = style.CheckedFore;
                    scene.Show();
                }
                else
                {
                    BackColor = style.DefaultBack;
                    ForeColor = style.DefaultFore;
                    scene.Hide();
                }
            };
            Checked = isChecked;
        }
    }
}
