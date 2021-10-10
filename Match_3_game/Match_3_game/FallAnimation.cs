using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Match_3_game
{
    public class FallAnimation : Animation
    {

        public event AnimationEndHandler AnimationEnd = null;

        public FallAnimation(GameForm game) : base(game)
        {
            time = 100;
        }

        public void Start(List<TileView> tiles)
        {
            var distance = tiles.First().Size.Height;
            var speed = distance / steps;
            for (int j = 0; j < tiles.Count; j++)
            {
                var tile = tiles[j];
                tile.Location = new Point(tile.Location.X, tile.Location.Y - distance);
            }
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
                    for (int j = 0; j < tiles.Count; j++)
                    {
                        var tile = tiles[j];
                        tile.Location = new Point(tile.Location.X, tile.Location.Y + speed);
                    }
                }
                else
                {
                    var delta = distance - speed * last;
                    for (int j = 0; j < tiles.Count; j++)
                    {
                        var tile = tiles[j];
                        tile.Location = new Point(tile.Location.X, tile.Location.Y + delta);
                    }
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
            game.Refresh();
            timer.Start();
        }
    }
}
