using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenViewer
{
    public partial class Form1 : Form
    {
        Thread ScrV;
        Bitmap bmp;
        Graphics gr;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ScrV = new Thread(ScreenView);
            ScrV.Start();
        }

        void ScreenView()
        {
            bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            gr = Graphics.FromImage(bmp);
            while (true)
            {
                try
                {
                    gr.CopyFromScreen(0, 0, 0, 0, new Size(bmp.Width, bmp.Height));
                    pictureBox1.Image = bmp;
                }
                catch (InvalidOperationException) { }

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ScrV.Abort();
        }
    }
}
