using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public class Percolation
    {
        private readonly bool[,] _open;
        private readonly bool[,] _full;
        private readonly int _size;
        private bool _percolate;

        public Percolation(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Taille de la grille négative ou nulle.");
            }

            _open = new bool[size, size];
            _full = new bool[size, size];
            _size = size;
        }

        private bool IsOpen(int i, int j)
        {
            if (_open[i, j] == true)
            {
                return true;
            }
            return false;
        }

        private bool IsFull(int i, int j)
        {
            if (_full[i, j] == true)
            {
                return true;
            }
            return false;
        }

        public bool Percolate()
        {
            for (int i = 0; i < _size; i++)
            {
                if (IsOpen(_size-1, i))
                {
                    return true;
                }
            }
            return false;
        }

        private List<KeyValuePair<int, int>> CloseNeighbors(int i, int j)
        {
            return new List<KeyValuePair<int, int>>();
        }

        public void Open(int i, int j)
        {
            _open[i, j] = true;
        }
    }
}
