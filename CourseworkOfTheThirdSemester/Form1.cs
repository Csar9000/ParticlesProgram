using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CourseworkOfTheThirdSemester.IImpactPoint;

namespace CourseworkOfTheThirdSemester
{
    public partial class Form1 : Form
    {
        Emitter emitter;
        List<Particle> particles = new List<Particle>();
        public Form1()
        {
            InitializeComponent();

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            emitter = new TopEmitter
            {
                Width = pictureBox1.Width,
                GravitationY = 0.25f
            };

            /*// гравитон
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(pictureBox1.Width * 0.25),
                Y = pictureBox1.Height / 2
            });

            // в центре антигравитон
            emitter.impactPoints.Add(new AntiGravityPoint
            {
                X = pictureBox1.Width / 2,
                Y = pictureBox1.Height / 2
            });

            // снова гравитон
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(pictureBox1.Width * 0.75),
                Y = pictureBox1.Height / 2
            });*/

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Tick(object sender, EventArgs e)
        {

        }

       

        int counter = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
           emitter.UpdateState();

            using (var g = Graphics.FromImage(pictureBox1.Image))
            {
                g.Clear(Color.Black); // А ЕЩЕ ЧЕРНЫЙ ФОН СДЕЛАЮ
                emitter.Render(g);
            }

            pictureBox1.Invalidate();
        }


        private int MousePositionX = 0;
        private int MousePositionY = 0;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;
        }
    }
}
