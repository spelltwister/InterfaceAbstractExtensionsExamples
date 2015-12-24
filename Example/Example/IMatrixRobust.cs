using System.Collections.Generic;

namespace Example
{
    public interface IMatrixRobust<T> : IMatrixMinimal<T>
    {
        T GetValueAt(int i, int j);

        void SetRowValues(int i, IList<T> rowValues);
        void SetColumnValues(int j, IList<T> newValues);

        void AddRow();
        void AddRow(IList<T> rowValues);
        void AddRows(int i);
        void InsertRows(int position, int count);
        void InsertRows(ICollection<int> positions);
        void RemoveRows(int position, int count);
        void RemoveRows(ICollection<int> positions);

        void AddColumn();
        void AddColumn(IList<T> columnValues);
        void AddColumns(int i);
        void InsertColumns(int position, int count);
        void InsertColumns(ICollection<int> positions);
        void RemoveColumns(int position, int count);
        void RemoveColumns(ICollection<int> positions);
    }
}
