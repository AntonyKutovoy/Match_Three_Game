using System;
using System.Collections.Generic;

namespace Match_3_game
{
    public class Game
    {
        private int mapSize;
        private int[,] grid;
        private int tileTypesCount;
        private int score;

        public delegate void TileRemoveHandler(int x, int y);
        public event TileRemoveHandler TileRemoved;

        public delegate void TilesRemoveHandler();
        public event TilesRemoveHandler TilesRemoved;

        public delegate void TilesFallHandler(List<TileIndex> tiles);
        public event TilesFallHandler TilesFalled;

        public Game(int mapSize, int tileTypesCount)
        {
            this.mapSize = mapSize;
            this.tileTypesCount = tileTypesCount;
            score = 0;
            grid = new int[mapSize, mapSize];
        }

        public void FillGrid()
        {
            var random = new Random();
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    int valueTile;
                    var repeat = false;
                    do
                    {
                        valueTile = random.Next(0, tileTypesCount);
                        repeat = false;
                        if (j >= 2 && (grid[i, j - 2] == grid[i, j - 1] && grid[i, j - 2] == valueTile))
                        {
                            repeat = true;
                        }
                        else
                        {
                            if (i >= 2 && (grid[i - 2, j] == grid[i - 1, j] && grid[i - 2, j] == valueTile))
                            {
                                repeat = true;
                            }
                        }
                    }
                    while (repeat != false);
                    grid[i, j] = valueTile;
                }
            }
        }

        public bool RemoveTiles()
        {
            var lines = new List<TilesLine>();
            var newGrid = (int[,])grid.Clone();
            for (int y = 0; y < mapSize; y++)
            {
                for (int x = 0; x < mapSize; x++)
                {
                    if (newGrid[y, x] == -1)
                    {
                        continue;
                    }
                    var count = 1;
                    for (int i = x + 1; i < mapSize; i++)
                    {
                        if (newGrid[y, i] == newGrid[y, x])
                        {
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (count >= 3)
                    {
                        for (int i = x; i < x + count; i++)
                        {
                            newGrid[y, i] = -1;
                        }
                        lines.Add(new TilesLine { Begining = new TileIndex { X = x, Y = y }, End = new TileIndex { X = x + count - 1, Y = y } });
                    }
                }
            }
            newGrid = (int[,])grid.Clone();
            for (int y = 0; y < mapSize; y++)
            {
                for (int x = 0; x < mapSize; x++)
                {
                    if (newGrid[y, x] == -1)
                    {
                        continue;
                    }
                    var count = 1;
                    for (int i = y + 1; i < mapSize; i++)
                    { 
                        if (newGrid[i, x] == newGrid[y, x])
                        {
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (count >= 3)
                    {
                        for (int i = y; i < y + count; i++)
                        {
                            newGrid[i, x] = -1;
                        }
                        lines.Add(new TilesLine { Begining = new TileIndex { X = x, Y = y }, End = new TileIndex { X = x, Y = y + count - 1 } });
                    }
                }
            }
            if (lines.Count == 0)
            {
                return false;
            }

            foreach (TilesLine line in lines)
            {
                var count = 0;
                if (line.Begining.Y == line.End.Y)
                {
                    for (int i = line.Begining.X; i <= line.End.X; i++)
                    {
                        grid[line.Begining.Y, i] = -1;
                        if (TileRemoved != null)
                        {
                            TileRemoved(i, line.Begining.Y);
                        }
                        count++;
                    }
                }
                else
                {
                    for (int i = line.Begining.Y; i <= line.End.Y; i++)
                    {
                        grid[i, line.Begining.X] = -1;
                        if (TileRemoved != null)
                        {
                            TileRemoved(line.Begining.X, i);
                        }
                        count++;
                    }
                }
                var value = (count - 2) * 10;
                score += count * value;
            }
            if (TilesRemoved != null)
            {
                TilesRemoved();
            }
            return true;
        }

        public bool Fall()
        {
            var tiles = new List<TileIndex>();
            for (int y = mapSize - 2; y >= 0; y--)
            {
                for (int x = mapSize - 1; x >= 0; x--)
                {
                    if (grid[y + 1, x] == -1)
                    {
                        grid[y + 1, x] = grid[y, x];
                        grid[y, x] = -1;
                        tiles.Add(new TileIndex { X = x, Y = y + 1 });
                    }
                }
            }
            Random random = new Random();
            for (int x = 0; x < mapSize; x++)
            {
                if (grid[0, x] == -1)
                {
                    grid[0, x] = random.Next(0, tileTypesCount);
                    tiles.Add(new TileIndex { X = x, Y = 0 });
                }
            }
            if (TilesFalled != null && tiles.Count != 0)
            {
                TilesFalled(tiles);
            }
            if (tiles.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int GetValue(int x, int y)
        {
            return grid[y, x];
        }

        public void Swap(TileIndex a, TileIndex b)
        {
            var t = grid[a.Y, a.X];
            grid[a.Y, a.X] = grid[b.Y, b.X];
            grid[b.Y, b.X] = t;
        }

        public int GetScore()
        {
            return score;
        }
    }
}
