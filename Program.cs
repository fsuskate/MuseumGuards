using System;
using System.Collections.Generic;

namespace MuseumGuards
{
    class Program
    {
        const int GUARD = 99;
        const int LOCKED = 98;
        const int OPEN = 0;

        static void Main(string[] args)
        {
            var p = new Program();
            p.Solve();
        }

        private int[,] grid = {
                {GUARD, 0, 0, 0},
                {0, LOCKED, LOCKED, 0},
                {0, LOCKED, 0, 0},
                {0, 0, GUARD, 0},
                {0, 0, 0, 0}
            };

        public void Solve()
        {
            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    if (grid[r,c] == GUARD)
                    {
                        Bfs(r, c);
                    }
                }
            }
        }

        private class NodeInfo
        {
            public int row;
            public int col;
            public int level;
        }

        public void Bfs(int r, int c)
        {
            var seen = new HashSet<string>();
            var q = new Queue<NodeInfo>();
            q.Enqueue(new NodeInfo { row = r, col = c, level = 0 } );
            while (q.Count > 0)
            {
                var curr = q.Dequeue();
                var currRow = curr.row;
                var currCol = curr.col;
                var currLevel = curr.level;

                seen.Add($"{currRow}:{currCol}");

                if (!InBounds(currRow, currCol)) continue;
                if (grid[currRow, currCol] != 0 && grid[currRow, currCol] < currLevel) continue;
                if (grid[currRow, currCol] == LOCKED) continue;

                if (grid[currRow, currCol] != GUARD) grid[currRow, currCol] = currLevel;

                // Mark all unvisited neighbors
                int north = currRow - 1; int south = currRow + 1; int east = currCol + 1; int west = currCol - 1; 
                if (ShouldExplore(south, currCol, seen)) q.Enqueue(new NodeInfo { row = south, col = currCol, level = currLevel + 1 });
                if (ShouldExplore(north, currCol, seen)) q.Enqueue(new NodeInfo { row = north, col = currCol, level = currLevel + 1 });
                if (ShouldExplore(currRow, east, seen)) q.Enqueue(new NodeInfo { row = currRow, col = east, level = currLevel + 1 });
                if (ShouldExplore(currRow, west, seen)) q.Enqueue(new NodeInfo { row = currRow, col = west, level = currLevel + 1 });
            }
            Print();
        }

        public bool InBounds(int currRow, int currCol)
        {
            if (currRow < 0 || currRow >= grid.GetLength(0) || currCol < 0 || currCol >= grid.GetLength(1)) return false;
            return true;
        }

        public bool ShouldExplore(int r, int c, HashSet<string> seen)
        {
            return InBounds(r, c) && !seen.Contains($"{r}:{c}");
        }

        public void Print()
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    if (grid[r,c] == GUARD)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write($"G, ");
                        Console.ForegroundColor = ConsoleColor.Gray ;
                    }
                    else if (grid[r,c] == LOCKED)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"L, ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else Console.Write($"{grid[r, c]}, ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ForegroundColor = oldColor;
        }
    }
}
