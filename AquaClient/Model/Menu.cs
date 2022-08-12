using AquaClient;
using AquaClient.Model.DefaultControls;

namespace AquaClient.Model
{
    public class Menu : DefaultForm
    {
        public Text Title { get; set; }
        public Text Footer { get; set; }
        public Text Subtitle { get; set; }
        public PictureBox Logo { get; set; }
        public Separator TopSep { get; set; }
        public Separator NavSep { get; set; }
        public Button CloseButton { get; set; }
        
        public Panel Content { get; set; }
        public Panel NavPanel { get; set; }

        public ControlManager ControlManager;

        public int NextNavButton = 1;
        
        public LinkedList<Scene> Scenes = new();

        public Menu(Form background, MenuStyle menuStyle, string titleText, int cornerRadius, Point location, bool nav)
        {
            FormBorderStyle = menuStyle.BorderStyle;
            BackColor = menuStyle.BackColor;
            Opacity = menuStyle.Opacity;
            StartPosition = menuStyle.FormStartPosition;
            DesktopLocation = PointToScreen(location);
            ClientSize = menuStyle.Size;
            Owner = background;
            ShowInTaskbar = true;
            TopMost = menuStyle.TopMost;
            Region = Region.FromHrgn(Utils.CreateRoundRectRgn(0, 0, Width, Height, cornerRadius, cornerRadius));
            if (menuStyle.Draggable)
            {
                Load += (sender, e) =>
                {
                    ControlExtension.Draggable(this, true);
                };
            }

            var closeButton = new Button
            {
                Text = "x",
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Size = new Size(27, 27),
                Location = new Point(Width - 27, 27 / 2 - 15),
                Font = Styles.DefaultTitleStyle.Font,
                TabStop = false
            };
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.Click += (sender, e) =>
            {
                Application.Exit();
            };
            Controls.Add(closeButton);
            CloseButton = closeButton;

            var miniButton = new Button
            {
                Text = "━",
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Size = new Size(27, 27),
                Location = new Point(Width - 54, 27 / 2 - 15),
                TextAlign = ContentAlignment.BottomCenter,
                Font = Styles.DefaultTitleStyle.Font,
                TabStop = false
            };
            miniButton.FlatAppearance.BorderSize = 0;
            miniButton.Click += (sender, e) =>
            {
                WindowState = FormWindowState.Minimized;
            };
            Controls.Add(miniButton);

            var content = new Panel
            {
                Size = new Size(Width, Height - 25),
                Location = new Point(0, 25),
                BackColor = ColorTranslator.FromHtml("#222222")
            };

            var title = new Text(titleText, new Point(Width - Styles.DefaultTitleStyle.Size.Width), Styles.DefaultTitleStyle);
            content.Controls.Add(title);
            Title = title;
            
            var subtitle = new Text($"v{Program.VERSION}", new Point(Width - 48, title.Bottom), Styles.DefaultTitleStyle);
            subtitle.ForeColor = ColorTranslator.FromHtml("#40CCFF");
            subtitle.AutoSize = true;
            subtitle.Font = new Font("Arial", 10, FontStyle.Regular);
            content.Controls.Add(subtitle);
            Subtitle = subtitle;

            var footer = new Text("Copyright © 2022 Aquatic Labs", new Point(Width, Bottom - 58), Styles.DefaultFooterStyle);
            footer.Location = new Point((Width / 2) - (footer.Width / 2), Bottom - 58);
            footer.TextAlign = ContentAlignment.BottomCenter;
            footer.Dock = DockStyle.None;
            
            
            
            content.Controls.Add(footer);
            Footer = footer;

            // Logo Container
            var logo = new PictureBox
            {
                Location = new Point(14, 0),
                Size = new Size(55, 55),
                Image = menuStyle.Logo,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            content.Controls.Add(logo);
            Logo = logo;
            
            var topSep = new Separator(new Point(0, logo.Bottom), Width, Styles.SeparatorColor);
            content.Controls.Add(topSep);
            TopSep = topSep;

            if (nav)
            {
                var navSep = new Separator(new Point(Styles.DefaultMainNavButtonStyle.Size.Width, logo.Height), Height - logo.Height, ColorTranslator.FromHtml("#333333"), false);
                content.Controls.Add(navSep);
                NavSep = navSep;
    
                var navPanel = new Panel()
                {
                    Size = new Size(navSep.Left, Height - topSep.Bottom),
                    Location = new Point(0, topSep.Bottom)
                };
                content.Controls.Add(navPanel);
                NavPanel = navPanel;
            }

            SizeChanged += (sender, e) =>
            {
                Region = Region.FromHrgn(Utils.CreateRoundRectRgn(0, 0, Width, Height, cornerRadius, cornerRadius));
            };
            ControlManager = new ControlManager(this);

            Controls.Add(content);
            Content = content;

        }



        protected void AddNavButton(MainNavButton button)
        {
            button.Location = new Point(NavPanel.Left, NextNavButton);
            NextNavButton += button.Size.Height;
            NavPanel.Controls.Add(button);
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            foreach (var scene in Scenes)
            {
                scene.Location = new Point(NavSep.Right, TopSep.Bottom);
            }
        }

        protected void CompleteLayout()
        {
            var controls = ControlManager.GetBuiltMenuControls();
            for (var i = 0; i < controls.Count; i++)
            {
                // if debug//
                Console.WriteLine("CtrlName:" + controls[i].Name + "" + controls[i].Location);
                Content.Controls.Add(controls[i]);
            }
        }
    }
}