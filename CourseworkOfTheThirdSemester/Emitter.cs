using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CourseworkOfTheThirdSemester.Particle;

namespace CourseworkOfTheThirdSemester
{
   public class Emitter
   {
        public float GravitationX = 0;
        public float GravitationY = 1; // гравитация 

        public int X; // координата X центра эмиттера
        public int Y; // соответствующая координата Y 
        public int Direction = 0; // вектор направления в градусах
        public int Spreading = 0; // разброс частиц относительно Direction

        public int SpeedMin = 1; // начальная минимальная скорость движения частицы
        public int SpeedMax = 10; // начальная максимальная скорость движения частицы

        public int RadiusMin = 2; // минимальный радиус частицы
        public int RadiusMax = 10; // максимальный радиус частицы

        public int LifeMin = 20; // минимальное время жизни частицы
        public int LifeMax = 100; // максимальное время жизни частицы

        public Color ColorFrom = Color.White; // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.Black); // конечный цвет частиц

        public int ParticlesPerTick = 1;

        List<Particle> particles = new List<Particle>();
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>(); // 


        public int MousePositionX;
        public int MousePositionY;


        /// <summary>
        /// метод для генерации частицы
        /// </summary>
        public virtual Particle CreateParticle()
        {
            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;

            return particle;
        }


        /// <summary>
        /// Метод обновления системы
        /// </summary>
        public void UpdateState()
        {
            int particlesToCreate = ParticlesPerTick;

            foreach (var particle in particles)
            {
                particle.Life -= 1; // уменьшаю здоровье
                                    // если здоровье кончилось
                if (particle.Life <= 0)
                {
                    if (particlesToCreate > 0)
                    {
                        particlesToCreate -= 1; 
                        ResetParticle(particle);
                    }
                }
                else
                {
                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;

                    particle.Life -= 1;
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                }
            }
            // этот цикл будет срабатывать только в самом начале работы эмиттера
            // пока не накопится критическая масса частиц
            while (particlesToCreate >= 1)
            {
                particlesToCreate -= 1;
               var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
            }
        }
        public void Render(Graphics g)
        {
            IImpactPoint p = null;
            foreach(var point in impactPoints)
                if(point is ParticleRadar)
				{
                    p = point;
                    break;
				}

            foreach (var particle in particles)
            {
                p?.ImpactParticle(particle);
                if (particle.ActiveRadar)// если частица попала на радар, то перекрашиваем
                {
                    particle.DrawRadar(g);
                }
                else  // иначе - без изменений
                {
                    particle.FromColor = ColorFrom;
                    particle.ToColor = ColorTo;
                    particle.Draw(g);
                }
            }

            foreach(var point in impactPoints) 
            {
                point.Render(g);
            }
        }

        /// <summary>
        /// метод в который вынесем момент генерации частицы и сброса ее состояния, когда жизнь кончается
        /// </summary>
        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = Particle.rand.Next(LifeMin, LifeMax);

            particle.X = X;
            particle.Y = Y;

            var direction = Direction
                + (double)Particle.rand.Next(Spreading)
                - Spreading / 2;

            var speed = Particle.rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);
        }
        
            /// <summary>
            /// Подсчёт количества частиц принадлежащих области действия радара
            /// </summary>
            /// <returns>Количество частиц принадлежащих области действия радара (общее количество, количество маленьких,средних и больших по величине)</returns>
            public int[] CounterActiveRadar()
            {
                int[] counter =new int[4];
                foreach (var particle in particles)
                {
                if (particle.ActiveRadar)
                {
                    counter[0]+=1;
                    if (particle.Radius >= 2 && particle.Radius<5 )
                    {
                        counter[1] += 1;
                    }
                    if (particle.Radius >= 5 && particle.Radius < 8)
                    {
                        counter[2] += 1;
                    }
                    if (particle.Radius >= 8)
                    {
                        counter[3] += 1;
                    }

                }
                }

                return counter;
            }

            /// <summary>
            /// Отменяет принадлежность к области радара всем частицам
            /// </summary>
            public void NoActiveParticle()
            {
                foreach (var particle in particles)
                {
                    particle.ActiveRadar = false;
                }
            }
        


    }

}


