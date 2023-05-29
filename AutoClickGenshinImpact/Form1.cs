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
            Point newPoint = new Point();
            GetCursorPos(out newPoint);
            int x = newPoint.X;
            int y = newPoint.Y;
            Cursor.Position = new Point(xPos, yPos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            Cursor.Position = new Point(x, y);
            label1.Text = x.ToString();
            label2.Text = y.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (GetAsyncKeyState(Keys.F3) == -32767)
            {
                Point cursor = new Point();
                GetCursorPos(out cursor);
                xPos = cursor.X;
                yPos = cursor.Y;
                textBox1.Text = xPos.ToString();
                textBox2.Text = yPos.ToString();
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            int intTimer = Convert.ToInt16(trackBar1.Value);
            timer1.Interval = intTimer;
            textBox3.Text = intTimer.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" F1 = Start.   F2 = Stop.   F3 = Fijar Coordenadas.");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //Este codigo es para Activar y desactivar el AutoClick.
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
