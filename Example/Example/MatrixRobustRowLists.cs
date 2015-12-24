using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example
{
    public class MatrixRobustRowLists<T> : IMatrixRobust<T>
    {
        private IMatrixMinimal<T> _internalMatrix;
        public MatrixRobustRowLists(int size) : this(size, size) { }
        public MatrixRobustRowLists(int i, int j) : this(new MatrixMinimalRowLists<T>(i, j)) { }
        public MatrixRobustRowLists(IMatrixMinimal<T> toWrap)
        {
            this._internalMatrix = toWrap;
        }
        public int ColumnCount
        {
            get { return this._internalMatrix.ColumnCount; }
        }

        public int RowCount
        {
            get { return this._internalMatrix.RowCount; }
        }

        public void AddColumn()
        {
            this._internalMatrix.AddColumn();
        }

        public void AddColumn(IList<T> columnValues)
        {
            this._internalMatrix.AddColumn(columnValues);
        }

        public void AddColumns(int i)
        {
            this._internalMatrix.AddColumns(i);
        }

        public void AddRow()
        {
            this._internalMatrix.AddRow();
        }

        public void AddRow(IList<T> rowValues)
        {
            this._internalMatrix.AddRow(rowValues);
        }

        public void AddRows(int i)
        {
            this._internalMatrix.AddRows(i);
        }

        public IList<T> Column(int j)
        {
            return this._internalMatrix.Column(j);
        }

        public T GetValueAt(int i, int j)
        {
            return this._internalMatrix.GetValueAt(i, j);
        }

        public void InsertColumn(int j)
        {
            this._internalMatrix.InsertColumn(j);
        }

        public void InsertColumns(ICollection<int> positions)
        {
            this._internalMatrix.InsertColumns(positions);
        }

        public void InsertColumns(int position, int count)
        {
            this._internalMatrix.InsertColumns(position, count);
        }

        public void InsertRow(int i)
        {
            this._internalMatrix.InsertRow(i);
        }

        public void InsertRows(ICollection<int> positions)
        {
            this._internalMatrix.InsertRows(positions);
        }

        public void InsertRows(int position, int count)
        {
            this._internalMatrix.InsertRows(position, count);
        }

        public void RemoveColumn(int j)
        {
            this._internalMatrix.RemoveColumn(j);
        }

        public void RemoveColumns(ICollection<int> positions)
        {
            this._internalMatrix.RemoveColumns(positions);
        }

        public void RemoveColumns(int position, int count)
        {
            this._internalMatrix.RemoveColumns(position, count);
        }

        public void RemoveRow(int i)
        {
            this._internalMatrix.RemoveRow(i);
        }

        public void RemoveRows(ICollection<int> positions)
        {
            this._internalMatrix.RemoveRows(positions);
        }

        public void RemoveRows(int position, int count)
        {
            this._internalMatrix.RemoveRows(position, count);
        }

        public IList<T> Row(int i)
        {
            return this._internalMatrix.Row(i);
        }

        public void SetColumnValues(int j, IList<T> newValues)
        {
            this._internalMatrix.SetColumnValues(j, newValues);
        }

        public void SetRowValues(int i, IList<T> rowValues)
        {
            this._internalMatrix.SetRowValues(i, rowValues);
        }

        public void SetValueAt(int i, int j, T newValue)
        {
            this._internalMatrix.SetValueAt(i, j, newValue);
        }
    }

    public class MatrixRobustRowListsFull<T> : IMatrixRobust<T>
    {
        private IList<IList<T>> _matrix;
        public MatrixRobustRowListsFull(int size) : this(size, size) { }
        public MatrixRobustRowListsFull(int rows, int columns) 
        {
            this._matrix = new List<IList<T>>(rows);
            for (int i = 0; i < rows; i++)
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

        public void AddColumn()
        {
            MinimalToRobustExtensions.AddColumn(this);
            // ((IMatrixMinimal<T>)this).AddColumn(); // this works but don't really want to have this minimal interface
        }

        public void AddColumn(IList<T> columnValues)
        {
            MinimalToRobustExtensions.AddColumn(this, columnValues);
        }

        public void AddColumns(int i)
        {
            MinimalToRobustExtensions.AddColumns(this, i);
        }

        public void AddRow()
        {
            MinimalToRobustExtensions.AddRow(this);
        }

        public void AddRow(IList<T> rowValues)
        {
            MinimalToRobustExtensions.AddRow(this, rowValues);
        }

        public void AddRows(int i)
        {
            MinimalToRobustExtensions.AddRows(this, i);
        }
        
        public T GetValueAt(int i, int j)
        {
            return MinimalToRobustExtensions.GetValueAt(this, i, j);
        }        

        public void InsertColumns(ICollection<int> positions)
        {
            MinimalToRobustExtensions.InsertColumns(this, positions);
        }

        public void InsertColumns(int position, int count)
        {
            MinimalToRobustExtensions.InsertColumns(this, position, count);
        }
        
        public void InsertRows(ICollection<int> positions)
        {
            MinimalToRobustExtensions.InsertRows(this, positions);
        }

        public void InsertRows(int position, int count)
        {
            MinimalToRobustExtensions.InsertRows(this, position, count);
        }

        public void RemoveColumns(ICollection<int> positions)
        {
            MinimalToRobustExtensions.RemoveColumns(this, positions);
        }

        public void RemoveColumns(int position, int count)
        {
            MinimalToRobustExtensions.RemoveColumns(this, position, count);
        }

        public void RemoveRows(ICollection<int> positions)
        {
            MinimalToRobustExtensions.RemoveRows(this, positions);
        }

        public void RemoveRows(int position, int count)
        {
            MinimalToRobustExtensions.RemoveRows(this, position, count);
        }

        public void SetColumnValues(int j, IList<T> newValues)
        {
            MinimalToRobustExtensions.SetColumnValues(this, j, newValues);
        }

        public void SetRowValues(int i, IList<T> rowValues)
        {
            MinimalToRobustExtensions.SetRowValues(this, i, rowValues);
        }
    }
}
