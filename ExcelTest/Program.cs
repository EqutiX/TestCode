using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace ExcelTest
{
    public class Base
    {

    }

    public class Child : Base
    {

    }
    public class Cubus<T> : IEnumerable<T>
    {
        private readonly T[,,] _array;
        private readonly int _size = 0;

        public Cubus(int size)
        {
            _size = size;
            _array = new T[size, size, size];
        }
        public T this[int x, int y, int z]
        {
            get
            {
                return _array[x, y, z];
            }
            set
            {
                _array[x, y, z] = value;
            }
        }

        public T[] GetXRange(int y, int z)
        {
            var result = new T[_size];
            for (int i = 0; i < _size; i++)
            {
                result[i] = _array[i, y, z];
            }
            
            return result;
        }

        public T[] GetYRange(int x, int z)
        {
            var result = new T[_size];
            for (int i = 0; i < _size; i++)
            {
                result[i] = _array[x, i, z];
            }

            return result;
        }

        public T[] GetZRange(int x, int y)
        {
            var result = new T[_size];
            for (int i = 0; i < _size; i++)
            {
                result[i] = _array[x, y, i];
            }
            
            return result;
        }

        /*public delegate bool WhereStatement(T item);
        public T[] Where(WhereStatement statement)
        {
            return _array.Cast<T>().Where(statement.Invoke).ToArray();
        }*/

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var obj in _array)
            {
                yield return obj;
            }
        }
    }

    class Program
    {
        private static void Main(string[] args)
        {

            var cu = new Cubus<string>(10)
            {
                [0, 1, 1] = "A",
                [1, 1, 1] = "B",
                [2, 1, 1] = "C",
                [3, 1, 1] = "D",
                [4, 1, 1] = "E",
                [5, 1, 1] = "F",
                [6, 1, 1] = "G",
                [7, 1, 1] = "H",
                [8, 1, 1] = "I",
                [9, 1, 1] = "J"
            };
            var res = cu.GetXRange(1, 1);
            var aValues = cu.Where(item => item == "A");
            var aVals = cu.Select(item => item == "B");
        }
    }
}
