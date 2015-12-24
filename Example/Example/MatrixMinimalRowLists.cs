using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example
{
    public class MatrixMinimalRowLists<T> : IMatrixMinimal<T>
    {
        private IList<IList<T>> _matrix;

        public MatrixMinimalRowLists(int size) : this(size, size) { }
        public MatrixMinimalRowLists(int rows, int columns)
        {
            this._matrix = new List<IList<T>>(rows);
            for(int i = 0; i < rows; i++)
            {
                this._matrix.Add(DefaultRow(columns));
            }
        }

        private static List<T> DefaultRow(int length)
        {
            return Enumerable.Repeat(default(T), length).ToList();
        }

        public int ColumnCount
        {
            get { return this._matrix[0].Count; }
        }

        public int RowCount
        {
            get { return this._matrix.Count; }
        }

        public IList<T> Column(int j)
        {
            return this._matrix.Select(x => x[j]).ToList();
        }

        public void InsertColumn(int j)
        {
            Parallel.ForEach(this._matrix, (row) => row.Insert(j, default(T)));
        }

        public void InsertRow(int i)
        {
            this._matrix.Insert(i, DefaultRow(this.ColumnCount));
        }

        public void RemoveColumn(int j)
        {
            Parallel.ForEach(this._matrix, (row) => row.RemoveAt(j));
        }

        public void RemoveRow(int i)
        {
            this._matrix.RemoveAt(i);
        }

        public IList<T> Row(int i)
        {
            return this._matrix[i].ToList();
        }

        public void SetValueAt(int i, int j, T newValue)
        {
            this._matrix[i][j] = newValue;
        }
    }
}