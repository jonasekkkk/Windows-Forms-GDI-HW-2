using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarozeninovyProjektik
{
    public class Ball
    {
        public int Size { get; set; } = 20;
        public Point Position { get; set; }
        public int Vx { get; set; }
        public int Vy { get; set; }
        private Random rng = new Random();

        public void Draw(Graphics g) {
            Brush b = Brushes.Magenta;
            g.FillEllipse(b, Position.X - Size / 2, Position.Y - Size / 2, Size, Size);
        }

        public void Move(PictureBox picBox)
        {
            int r = this.Size / 2;
            int width = picBox.Width;
            int height = picBox.Height;

            this.Position = new Point(Position.X + Vx, Position.Y + Vy);

            if (Position.X <= r || Position.X >= width - r)
            {
                Vx *= -1;
                this.Position = new Point(Math.Clamp(Position.X, r, width - r), Position.Y);
            }

            if (Position.Y <= r || Position.Y >= height - r)
            {
                Vy *= -1;
                this.Position = new Point(Position.X, Math.Clamp(Position.Y, r, height - r));
            }
        }
    }
}
