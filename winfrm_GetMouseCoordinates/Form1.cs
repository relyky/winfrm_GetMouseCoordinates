using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winfrm_GetMouseCoordinates
{
    public partial class Form1 : Form
    {
        private int preX = 0;
        private int preY = 0;
        private string preS = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // 此段原碼參考改良自：https://www.youtube.com/watch?v=YRcs4Rym_0Q
            labelX.Text = e.X.ToString();
            labelY.Text = e.Y.ToString();

            Graphics g = this.CreateGraphics();

            // erase
            //g.DrawLine(Pens.White, 0, 0, preX, preY);
            g.DrawLines(Pens.White, new Point[] { new Point(0, 0), new Point(preX, preY), new Point(this.Width, 0) });
            g.DrawString(preS, this.Font, Brushes.White, preX, preY);

            // draw
            string s = string.Format("({0},{1})", e.X, e.Y);
            int x = e.Location.X;
            int y = (int)(e.Location.Y - this.Font.Size);
            //g.DrawLine(Pens.Aqua, 0, 0, x, y);
            g.DrawLines(Pens.Aqua, new Point[] { new Point(0, 0), new Point(x, y), new Point(this.Width, 0) });
            g.DrawString(s, this.Font, Brushes.Blue, x, y);

            // for next round
            preX = x;
            preY = y;
            preS = s;
        }

    }
}
