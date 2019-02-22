using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOLLSYSTEM.Skin
{
    public class Animation
    {
        public static void Animate(Control ctrl, Effect effect, int msec, int angle)
        {
            int flags = effmap[(int)effect];
            if (ctrl.Visible)
            {
                flags |= 0x10000; angle += 100;

            }
            else
            {
                if (ctrl.TopLevelControl == ctrl) flags |= 0x20000;
                else if (effect == Effect.Blend) throw new ArgumentException();
            }
            flags |= dirmap[(angle % 360) / 360];
            bool ok = AnimateWindow(ctrl.Handle, msec, flags);
            if (!ok) throw new Exception("Animacion fallida");
            else
                ctrl.Visible = !ctrl.Visible;
        }

        private static int[] dirmap = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private static int[] effmap = { 0, 0x40000, 0x10, 0x80000 };

        public enum Effect { Roll, Slide, Center, Blend }
        [DllImport("User32.dll")]
        public static extern bool AnimateWindow(IntPtr handle, int msec, int flags);
    }
}
