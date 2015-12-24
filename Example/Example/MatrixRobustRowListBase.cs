using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public abstract class MatrixRobustRowListsBase<T> : IMatrixRobust<T>
    {
        abstract public int ColumnCount { get; }
        abstract public int RowCount { get; }

        abstract public IList<T> Column(int j);
        abstract public IList<T> Row(int i);

        abstract public void InsertRow(int i);
        abstract public void RemoveRow(int i);

        abstract public void InsertColumn(int j);
        abstract public void RemoveColumn(int j);

        abstract public void SetValueAt(int i, int j, T newValue);

        virtual public void AddColumn()
        {
            MinimalToRobustExtensions.AddColumn(this);
        }

        virtual public void AddColumn(IList<T> columnValues)
        {
            MinimalToRobustExtensions.AddColumn(this, columnValues);
        }

        virtual public void AddColumns(int i)
        {
            MinimalToRobustExtensions.AddColumns(this, i);
        }

        virtual public void AddRow()
        {
            MinimalToRobustExtensions.AddRow(this);
        }

        virtual public void AddRow(IList<T> rowValues)
        {
            MinimalToRobustExtensions.AddRow(this, rowValues);
        }

        virtual public void AddRows(int i)
        {
            MinimalToRobustExtensions.AddRows(this, i);
        }

        virtual public T GetValueAt(int i, int j)
        {
            return MinimalToRobustExtensions.GetValueAt(this, i, j);
        }

        virtual public void InsertColumns(ICollection<int> positions)
        {
            MinimalToRobustExtensions.InsertColumns(this, positions);
        }

        virtual public void InsertColumns(int position, int count)
        {
            MinimalToRobustExtensions.InsertColumns(this, position, count);
        }

        virtual public void InsertRows(ICollection<int> positions)
        {
            MinimalToRobustExtensions.InsertRows(this, positions);
        }

        virtual public void InsertRows(int position, int count)
        {
            MinimalToRobustExtensions.InsertRows(this, position, count);
        }

        virtual public void RemoveColumns(ICollection<int> positions)
        {
            MinimalToRobustExtensions.RemoveColumns(this, positions);
        }

        virtual public void RemoveColumns(int position, int count)
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

        virtual public void SetColumnValues(int j, IList<T> newValues)
        {
            MinimalToRobustExtensions.SetColumnValues(this, j, newValues);
        }

        virtual public void SetRowValues(int i, IList<T> rowValues)
        {
            MinimalToRobustExtensions.SetRowValues(this, i, rowValues);
        }
    }
}
