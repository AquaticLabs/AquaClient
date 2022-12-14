using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaClient.Model.DefaultControls
{
    public class Separator : Label
    {
        public Separator(Point location, int length, Color color, bool horizontal = true)
        {
            BackColor = color;
            if (horizontal)
            {
                Size = new Size(length, 2);
            } else
            {
                Size = new Size(2, length);
            }
            Location = location;
        }
    }
}
