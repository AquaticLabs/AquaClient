using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaClient.Model
{
    public class Style
    {
        public Color BackColor { get; }
        public Color ForeColor { get; }
        public Size Size { get; }
        
        public Style(string backColor, string foreColor, Size size)
        {
            if (backColor != null)
            {
                BackColor = ColorTranslator.FromHtml(backColor);
            }

            if (foreColor != null)
            {
                ForeColor = ColorTranslator.FromHtml(foreColor);
            }
            Size = size;
        }
        public Style(Color backColor, Color foreColor, Size size)
        {
            if (backColor != null)
            {
                BackColor = backColor;
            }

            if (foreColor != null)
            {
                ForeColor = foreColor;
            }
            Size = size;
        }
        
    }
}
