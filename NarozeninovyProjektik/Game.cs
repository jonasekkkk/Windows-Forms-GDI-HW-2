using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarozeninovyProjektik
{
    public class Game
    {
        private Random rng = new Random();
        public List<Ball> Balls { get; set; } = new List<Ball>();

        public void Draw(Graphics g)
        {
            foreach (Ball b in Balls)
            {
                b.Draw(g);
            }
        }

        public void Throw(Point position, Point vector)
        {
            Ball newBall = new Ball() { Position = position, Vx = vector.X / 20, Vy = vector.Y / 20};
            Balls.Add(newBall);
        }

        public void Click(Point position)
        {
            Balls.Add(new Ball() { Position = position, Vx = Convert.ToInt32(rng.Next(-50, 50) * 0.25) + 1, Vy = Convert.ToInt32(rng.Next(-50, 50) * 0.25) + 1 });
        }

        public void Update(PictureBox picBox)
        {
            foreach (Ball b in Balls)
            {
                b.Move(picBox);
            }
        }
    }
}
