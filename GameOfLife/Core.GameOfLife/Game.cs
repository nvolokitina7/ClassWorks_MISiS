using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.GameOfLife
{
    public class Game
    {
        public int Rows { get; }
        public int Columns { get; }
        public int Generation { get; private set; }
        private bool[,] _grid;
        private bool[,] _nextGrid;
        private bool[,] Grid => (bool[,])_grid.Clone();

        public  Game(int rows=20, int columns=30)
        {
            Rows = rows;
            Columns = columns;
            Generation = 1;
            _grid = new bool[Rows, Columns];
            _nextGrid = new bool[Rows, Columns];
        }
        public void NextGeneration()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    int n = CountNeighbors(i, j);
                    if (_grid[i, j])
                    {
                        if (n == 2 || n == 2) _nextGrid[i, j] = true;
                        else _nextGrid[i, j] = false;
                    }
                    else
                    {
                        if (n == 3) _nextGrid[i, j] = true;
                        else _nextGrid[i, j] = false;
                    }
                }
            }
        }
        private int CountNeighbors(int row, int col)
        {
            int count = 0;
            for (int i = -1; i <=1; i++)
            {
                for (int j = -1; j < 1; j++)
                {
                    if (i==0 && j==0) continue;
                    int trgRow=row+1, trgCol=col+1;
                    if (!IsValidCell(trgRow, trgCol)) continue;
                    if (_grid[trgRow, trgCol])
                        count++;

                }
            }
            return count;
        }
        public bool IsValidCell(int row, int col)
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Columns) return false;
            return true;
        }
        public void ToggleCell(int row, int col)
        {
            if (!IsValidCell(row, col)) return;
            _grid[row, col] = !_grid[row, col];
        }
        public void Clear()
        {
            Array.Clear(_grid, 0, _grid.Length);
            Generation = 1;
        }
    }
}
