using System.Drawing;
using System.Windows.Forms;

namespace Match_3_game
{
    public class SwapAnimation : Animation
    {

        public event AnimationEndHandler AnimationEnd = null;

        public SwapAnimation(GameForm game) : base(game)
        {
            steps = 8;
        }

        public void Start(TileView a, TileView b)
        {
            var distance = new Point(b.Location.X - a.Location.X, b.Location.Y - a.Location.Y);
            var speed = new Point(distance.X / steps, distance.Y / steps);
            var last = steps - 1;
            count = 0;
            timer = new Timer();
            timer.Interval = time / steps;
            timer.Tick += delegate
            {
                if (count > last)
                {
                    timer.Dispose();
                    return;
                }
                if (count < last)
                {
                    a.Location = new Point(a.Location.X + speed.X, a.Location.Y + speed.Y);
                    b.Location = new Point(b.Location.X - speed.X, b.Location.Y - speed.Y);
                }
                else
                {
                    a.Location = new Point(a.Location.X + (distance.X - speed.X * last), a.Location.Y + (distance.Y - speed.Y * last));
                    b.Location = new Point(b.Location.X - (distance.X - speed.X * last), b.Location.Y - (distance.Y - speed.Y * last));
                }
                count++;
                game.Refresh();
            };

            timer.Disposed += delegate
            {
                if (AnimationEnd != null)
                {
                    AnimationEnd();
                }
            };

            timer.Start();
        }
    }
}
