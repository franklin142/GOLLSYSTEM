using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOLLSYSTEM.Skin
{
    public class MoveForm
    {
        public static void moverForm(IntPtr handle,Control ctrl)
        {
            ReleaseCapture();
            SendMessage(handle, WM_SYSCOMMAND, MOUSE_MOVE, 0);
        }
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        // 
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        const int WM_SYSCOMMAND = 0x112;
        const int MOUSE_MOVE = 0xF012;
        
    }
}
