using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AquaClient.Model
{
    static internal class Utils
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public static void OpenBrowserUrl(string url)
        {
            var psi = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = url
            };
            Process.Start(psi);
        }
    }
    
    public enum LTrackBarOrientation
    {
        Horizontal_LR,
        Horizontal_RL,
        Vertical_BT,
        Vertical_TB,
    }

    public class LEventArgs : EventArgs
    {
        public object Value
        {
            get;
            set;
        }
        public LEventArgs(object value)
        {
            Value = value;
        }
    }
    public enum MouseStatus
    {
        Enter,
        Leave, 
        Down,
        Up
    }

    public enum ClickType
    {
        Left,
        Right,
        Middle
    }

}
