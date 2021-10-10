using System.Collections.Generic;
using System.Drawing;

namespace Match_3_game
{
    public class Bitmaps
    {
        public static Dictionary<int, Bitmap> GetBitmaps(int tileSize)
        {
            var size = new Size(tileSize, tileSize);
            var greenSquare = new Bitmap(Properties.Resources.green_square, size);
            var blueSquare = new Bitmap(Properties.Resources.blue_square, size);
            var redSquare = new Bitmap(Properties.Resources.red_square, size);
            var orangeSquare = new Bitmap(Properties.Resources.orange_square, size);
            var purpleSquare = new Bitmap(Properties.Resources.purple_square, size);
            var greenTriangle = new Bitmap(Properties.Resources.green_triangle, size);
            var blueTriangle = new Bitmap(Properties.Resources.blue_triangle, size);
            var redTriangle = new Bitmap(Properties.Resources.red_triangle, size);
            var orangeTriangle = new Bitmap(Properties.Resources.orange_triangle, size);
            var purpleTriangle = new Bitmap(Properties.Resources.purple_triangle, size);
            var greenBomb = new Bitmap(Properties.Resources.green_bomb, size);
            var blueBomb = new Bitmap(Properties.Resources.blue_bomb, size);
            var redBomb = new Bitmap(Properties.Resources.red_bomb, size);
            var orangeBomb = new Bitmap(Properties.Resources.orange_bomb, size);
            var purpleBomb = new Bitmap(Properties.Resources.purple_bomb, size);
            var bitmaps = new Dictionary<int, Bitmap> { {0, greenSquare }, {1, blueSquare }, { 2, redSquare }, { 3, orangeSquare }, { 4, purpleSquare }, { 5, greenTriangle },
                {6, blueTriangle }, { 7, redTriangle }, { 8, orangeTriangle }, { 9, purpleTriangle },
                { 10, greenBomb }, { 11, blueBomb }, { 12, redBomb }, { 13, orangeBomb }, { 14, purpleBomb }  };
            return bitmaps;
        }
    }
}
