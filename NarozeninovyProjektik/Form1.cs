namespace NarozeninovyProjektik
{
    public partial class Form1 : Form
    {
        private Game game = new Game();
        private Point mouseDownPoint = new Point();

        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        private void MouseDownHandler(object sender, MouseEventArgs e)
        {
            // Vypočítat lokaci balónků s jejich radiusem.
            int xOrigin = e.Location.X;
            int yOrigin = e.Location.Y;

            game.Balls.RemoveAll(ball =>
            {
                int xDifference = Math.Abs(xOrigin - ball.Position.X);
                int yDifference = Math.Abs(yOrigin - ball.Position.Y);

                double sum = Math.Pow(xDifference, 2) + Math.Pow(yDifference, 2);
                double doubleDist = Math.Sqrt(sum);
                int dist = Convert.ToInt32(doubleDist);

                return dist <= ball.Size / 2;
            });

            mouseDownPoint = e.Location;
        }

        private void MouseUpHandler(object sender, MouseEventArgs e)
        {
            int xVector = e.Location.X - mouseDownPoint.X;
            int yVector = e.Location.Y - mouseDownPoint.Y;
            Point newVector = new Point(xVector, yVector);

            if (Math.Abs(xVector) < 5 || Math.Abs(yVector) < 5) { return; }

            game.Throw(e.Location, newVector);
        }

        private void PaintGame(object sender, PaintEventArgs e)
        {
            this.game.Draw(e.Graphics);
        }

        private void RenderStepped(object sender, EventArgs e)
        {
            this.game.Update(this.pictureBox1);
            this.pictureBox1.Refresh();
        }

        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                game.Balls.Clear();
            }
        }
    }
}
