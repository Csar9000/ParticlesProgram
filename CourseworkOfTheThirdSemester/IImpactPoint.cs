using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkOfTheThirdSemester
{
    public class IImpactPoint
    {
        public float X; 
        public float Y;


        public virtual void ImpactParticle(Particle particle) { }



        public virtual void Render(Graphics g)
        {
            g.FillEllipse(
                    new SolidBrush(Color.Red),
                    X - 5,
                    Y - 5,
                    10,
                    10
                );
        }
    }


    public class ParticleRadar : IImpactPoint // радар
    {
        public int Power = 100;
        public Color color;
        public int count = 0;           


        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY);
            if(r + particle.Radius < Power / 2)// попадание точки в радар
            {
                particle.FromColor = color;
                particle.ToColor = color;
                particle.ActiveRadar = true;
            }
            else
                particle.ActiveRadar = false;
        }

        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                   new Pen(Color.Red),
                   X - Power / 2,
                   Y - Power / 2,
                   Power,
                   Power
               );
           

        }

    }
}

