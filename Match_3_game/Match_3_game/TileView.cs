using System.Drawing;

namespace Match_3_game
{
    public class TileView
    {
        protected GameForm form;
        private static TileView checkedTile;

        public TileView(GameForm form)
        {
            this.form = form;
        }

        public Color BackColor { get; set; }
        public Rectangle Rectangle { get; set; }
        public Image Image { get; set; }
        public TileIndex Index { get; set; } = new TileIndex();
        public Point Location 
        { 
            get 
            { 
                return Rectangle.Location; 
            } 
            set 
            { 
                Rectangle = new Rectangle(value, Rectangle.Size); 
            } 
        }
        public Size Size 
        { 
            get 
            {
                return Rectangle.Size; 
            } 
            set 
            {
                Rectangle = new Rectangle(Rectangle.Location, value); 
            } 
        }

        public void Click()
        {
            if (form.Active == false)
            {
                return;
            }
            if (checkedTile != null)
            {
                if (checkedTile == this)
                {
                    BackColor = Color.Transparent;
                    checkedTile = null;
                }
                else
                {
                    var near = false;
                    if ((checkedTile.Index.X == Index.X - 1 && checkedTile.Index.Y == Index.Y) || (checkedTile.Index.X == Index.X + 1 && checkedTile.Index.Y == Index.Y) ||
                        (checkedTile.Index.X == Index.X && checkedTile.Index.Y == Index.Y - 1) || (checkedTile.Index.X == Index.X && checkedTile.Index.Y == Index.Y + 1))
                    {
                        near = true;
                    }
                    if (!near)
                    {
                        checkedTile.BackColor = Color.Transparent;
                        BackColor = Color.LightSkyBlue;
                        checkedTile = this;
                    }
                    else
                    {
                        checkedTile.BackColor = Color.Transparent;
                        form.Active = false;
                        var newTile = checkedTile;
                        checkedTile = null;
                        var swap = new SwapAnimation(form);
                        swap.AnimationEnd += delegate
                        {
                            form.MoveTiles(newTile, this);
                        };
                        swap.Start(newTile, this);
                    }
                }
            }
            else
            {
                BackColor = Color.LightSkyBlue;
                checkedTile = this;
            }
            form.Refresh();
        }
    };
}
