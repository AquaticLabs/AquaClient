using AquaClient.Model;

namespace AquaClient.View
{
    public class Background : DefaultForm
    {
        public Background()
        {
            AutoScaleMode = AutoScaleMode.None;
            StartPosition = FormStartPosition.Manual;
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.Magenta;
            TransparencyKey = Color.Magenta;
            ClientSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Location = new Point(0, 0);
            Text = "Mod Menu";
        }
    }
}
