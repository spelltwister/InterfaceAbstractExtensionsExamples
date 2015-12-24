using System.Collections.Generic;

namespace Example
{
    public interface IMatrixMinimal<T>
    {
        int RowCount { get; }
        int ColumnCount { get; }

        IList<T> Row(int i);
        IList<T> Column(int j);
        
        void SetValueAt(int i, int j, T newValue);

        void InsertRow(int i);
        void InsertColumn(int j);

        void RemoveRow(int i);
        void RemoveColumn(int j);
    }
}
