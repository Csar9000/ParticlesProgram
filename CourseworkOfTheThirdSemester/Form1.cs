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
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter; // добавим поле для эмиттера

        bool radar = false;

        private int MousePositionX = 0;
        private int MousePositionY = 0;

        

        ParticleRadar radarParticle = null; //объект радара

        GravityPoint point1; // добавил поле под первую точку

        public Form1()
        {
            InitializeComponent();

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = pictureBox1.Width / 2,
                Y = pictureBox1.Height / 2,
            };

            emitters.Add(this.emitter); // все равно добавляю в список emitters, чтобы он рендерился и обновлялся

            point1 = new GravityPoint
            {
                X = pictureBox1.Width / 2 + 100,
                Y = pictureBox1.Height / 2,
            };

            // привязываем поля к эмиттеру
            //emitter.impactPoints.Add(point1);
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

            radarParticle = new ParticleRadar
            {
                color = Color.Blue
            };

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
            int counter = 0; //количество частиц из всех эммитеров, которые попали в область действия радара
            emitter.UpdateState();


            using (var g = Graphics.FromImage(pictureBox1.Image))
            {
                g.Clear(Color.Black);
                foreach (var emit in emitters)
                {

                    emit.Render(g);
                    counter += emit.CounterActiveRadar(); //подсчёт частиц, которые попали в область действия радара
                }
                if (counter > 0)
                {   //рисование чисел в области радара (количество частиц попавших в его область действия)
                    g.DrawString($"{counter}",
                    new Font("Verdana", 12),
                    new SolidBrush(Color.White),
                    MousePositionX-10,
                    MousePositionY-15);
                }
            }

            
            pictureBox1.Invalidate();
        }


       

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;

            MousePositionX = e.X;
            MousePositionY = e.Y;

            foreach (var emitter in emitters)
            {
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
            }

            // а тут передаем положение мыши, в положение гравитона
            point1.X = e.X;
            point1.Y = e.Y;

            //добавил...
            radarParticle.X = e.X;
            radarParticle.Y = e.Y;
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
            lblDirection.Text = $"{tbDirection.Value}°"; // добавил вывод значения
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            emitter.Spreading = trackBar1.Value;
            lblSpreading.Text = $"{trackBar1.Value}°"; // добавил вывод значения
        }

       /* private void tbGravitation_Scroll(object sender, EventArgs e)
        {
            foreach (var p in emitter.impactPoints)
            {
                if (p is GravityPoint) // так как impactPoints не обязательно содержит поле Power, надо проверить на тип 
                {
                    // если гравитон то меняем силу
                    (p as GravityPoint).Power = tbGravitation.Value;
                }
            }
        }*/

        private void btnActivateRadar_Click(object sender, EventArgs e)
        {
            radar = !radar;
            if (radar)
            {
                foreach (var emit in emitters)
                    emit.impactPoints.Add(radarParticle); //при активации радара, он добавляется
                                                          //всем эмиттерам, для того, чтобы захватить все частицы
            }
            else
            {
                foreach (var emit in emitters)
                {
                    int index = (-1);
                    for (int i = 0; (i < emit.impactPoints.Count) && (index < 0); i++)
                    {
                        if (emit.impactPoints[i] is ParticleRadar)
                            index = i;
                    }

                    if (index >= 0)
                        emit.impactPoints.RemoveAt(index);
                    emit.AllNoActiveParticle();
                }
            }
        }
        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (radar)
            {
                int number = e.Delta * SystemInformation.MouseWheelScrollLines / 30;
                if ((radarParticle.Power + number) >= 0)
                    radarParticle.Power += number;
            }
        }
    }
}
