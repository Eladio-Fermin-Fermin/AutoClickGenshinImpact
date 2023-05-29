using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Es necesario poner este using...
using System.Runtime.InteropServices;

namespace AutoClickGenshinImpact
{
    public partial class Form1 : Form
    {
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwflags, int dx, int dy, int cbuttons, int dwExtraInfo);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetCursorPos(out Point lpPoint);
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Keys vkeys);
        public static int xPos, yPos;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (GetAsyncKeyState(Keys.F1) == -32767)
            {
                timer1.Start();
            }
            if (GetAsyncKeyState(Keys.F2) == -32767)
            {
                timer1.Stop();
            }
        }
    }
}
