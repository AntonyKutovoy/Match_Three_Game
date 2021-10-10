using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Match_3_game
{
    public partial class GameForm : Form
    {
        private const int mapSize = 8;
        private const int tileTypes = 5;
        private Dictionary<int, Bitmap> bitmaps;
        private TileView[,] tiles;
        private Game game;
        private int tileSize;
        private bool active;
        private Timer timer;
        private int timerCount;

        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            timerCount = 60;
            timer = new Timer();
            timer.Interval = 1000;
            timerLabel.Text = (timerCount / 60).ToString("00") + ":" + (timerCount - 60 * (timerCount / 60)).ToString("00");
            timer.Tick += delegate
            {
                if (timerCount > 0)
                {
                    timerCount--;
                    timerLabel.Text = (timerCount / 60).ToString("00") + ":" + (timerCount - 60 * (timerCount / 60)).ToString("00");
                }
                else
                {
                    if (active)
                    {
                        Finish();
                    }
                }
            };
            game = new Game(mapSize, tileTypes);
            game.TileRemoved += Game_TileRemoved;
            game.TilesRemoved += Game_TilesRemoved;
            game.TilesFalled += Game_TilesFalled;
            game.FillGrid();
            gameMapPictureBox.Paint += GameMap_Paint;
            tileSize = Math.Min(gameMapPictureBox.Width, gameMapPictureBox.Height) / mapSize;
            bitmaps = Bitmaps.GetBitmaps(tileSize);
            tiles = new TileView[mapSize, mapSize];
            InitTiles();
            UpdateTiles();
            Active = true;
            timer.Start();
        }

        private void GameMap_Paint(object sender, PaintEventArgs e)
        {
            for (int y = 0; y < mapSize; y++)
            {
                for (int x = 0; x < mapSize; x++)
                {
                    var tile = tiles[y, x];
                    if (tile.BackColor != Color.Transparent)
                    {
                        var brush = new SolidBrush(tile.BackColor);
                        e.Graphics.FillRectangle(brush, tile.Rectangle);
                    }
                    if (tile.Image != null)
                    {
                        e.Graphics.DrawImage(tile.Image, tile.Rectangle);
                    }
                }
            }
        }

        private void Game_TileRemoved(int x, int y)
        {
            tiles[y, x].Image = null;
        }

        private void Game_TilesRemoved()
        {
            scoreLabel.Text = "Score: " + game.GetScore().ToString();
            game.Fall();
        }

        private void Game_TilesFalled(List<TileIndex> indices)
        {
            FallAnimation anim = new FallAnimation(this);
            var newTtiles = new List<TileView>();
            foreach (var index in indices)
            {
                newTtiles.Add(tiles[index.Y, index.X]);
            }
            anim.AnimationEnd += delegate
            {
                if (!game.Fall())
                {
                    if (game.RemoveTiles() == false)
                    {
                        Active = true;
                    }
                }
            };
            UpdateTiles();
            anim.Start(newTtiles);
        }

        private void Finish()
        {
            active = false;
            MessageBox.Show("The game is over. Your score is " + game.GetScore().ToString(), "Game over", MessageBoxButtons.OK);
            Close();
        }

        private void UpdateTiles()
        {
            var start = new Point((gameMapPictureBox.Width - tileSize * mapSize) / 2, (gameMapPictureBox.Height - tileSize * mapSize) / 2);
            for (int y = 0; y < mapSize; y++)
            {
                for (int x = 0; x < mapSize; x++)
                {
                    tiles[y, x].Location = new Point(start.X + x * tileSize, start.Y + y * tileSize);
                    tiles[y, x].Size = new Size(tileSize, tileSize);
                    var value = game.GetValue(x, y);
                    if (value >= 0)
                    {
                        tiles[y, x].Image = bitmaps[game.GetValue(x, y)];
                    }
                    else
                    {
                        tiles[y, x].Image = null;
                    }
                }
            }
        }

        private void InitTiles()
        {
            for (int y = 0; y < mapSize; y++)
            {
                for (int x = 0; x < mapSize; x++)
                {
                    tiles[y, x] = new TileView(this);
                    tiles[y, x].Index = new TileIndex { X = x, Y = y };
                }
            }
        }

        private void swapTiles(TileIndex a, TileIndex b)
        {
            var newTile = tiles[a.Y, a.X];
            tiles[a.Y, a.X] = tiles[b.Y, b.X];
            tiles[b.Y, b.X] = newTile;
            tiles[a.Y, a.X].Index = new TileIndex { X = a.X, Y = a.Y };
            tiles[b.Y, b.X].Index = new TileIndex { X = b.X, Y = b.Y };
        }

        public void MoveTiles(TileView a, TileView b)
        {
            var indexA = new TileIndex { X = a.Index.X, Y = a.Index.Y };
            var indexB = new TileIndex { X = b.Index.X, Y = b.Index.Y };
            game.Swap(indexA, indexB);
            swapTiles(indexA, indexB);
            var result = game.RemoveTiles();
            if (result == false)
            {
                SwapAnimation swap = new SwapAnimation(this);
                swap.AnimationEnd += delegate
                {
                    indexA = new TileIndex { X = a.Index.X, Y = a.Index.Y };
                    indexB = new TileIndex { X = b.Index.X, Y = b.Index.Y };
                    game.Swap(indexA, indexB);
                    swapTiles(indexA, indexB);
                    Active = true;
                };
                swap.Start(b, a);
            }
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && active)
            {
                timer.Dispose();
                Close();
            }
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Dispose();
        }

        private void gameMapPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            var start = new Point((gameMapPictureBox.Width - tileSize * mapSize) / 2, (gameMapPictureBox.Height - tileSize * mapSize) / 2);
            var position = new Point(e.Location.X - start.X, e.Location.Y - start.Y);
            var column = position.X / tileSize;
            int row = position.Y / tileSize;
            if (column < mapSize && row < mapSize)
            {
                tiles[row, column].Click();
            }
        }

        public bool Active
        {
            get { return active; }
            set
            {
                if (active == false && value == true && timerCount <= 0)
                {
                    Finish();
                }
                else
                {
                    active = value;
                }
            }
        }
    }
}
