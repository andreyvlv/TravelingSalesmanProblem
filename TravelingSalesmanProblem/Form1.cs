using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelingSalesmanProblem
{
    public partial class Form1 : Form
    {
        PictureBox pictureBox1 = new PictureBox();

        public Form1()
        {
            // Form настройки
            Text = "Pathfinder";
            ClientSize = new Size(800, 600);
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            // PictureBox настройки
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Height = 600;
            pictureBox1.Width = 800;
            pictureBox1.BackColor = Color.White;
            pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
            //
            Controls.Add(pictureBox1);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            // перерисовать форму, вызвав тем самым событие pictureBox1_Paint
            pictureBox1.Invalidate();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.Clear(Color.FromArgb(0x1e, 0x39, 0x64));
            var size = ClientSize;
            var background = new SolidBrush(Color.FromArgb(0x1e, 0x39, 0x64)); // #002d3c #1E3964          
            graphics.FillRectangle(background, 0, 0, ClientSize.Width, ClientSize.Height);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            PathVisualizer visualizer = new PathVisualizer();
            visualizer.VisualizePath(graphics, size);
        }
    }
}
