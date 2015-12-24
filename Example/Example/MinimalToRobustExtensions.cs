using System.Collections.Generic;
using System.Linq;

namespace Example
{
    public static class MinimalToRobustExtensions
    {
        public static T GetValueAt<T>(this IMatrixMinimal<T> minMatrix, int i, int j)
        {
            return minMatrix.Row(i)[j];
        }

        public static void SetRowValues<T>(this IMatrixMinimal<T> minMatrix, int i, IList<T> rowValues)
        {
            for (int j = 0; j < minMatrix.ColumnCount; j++)
            {
                minMatrix.SetValueAt(i, j, rowValues[j]);
            }
        }
        public static void SetColumnValues<T>(this IMatrixMinimal<T> minMatrix, int j, IList<T> newValues)
        {
            for (int i = 0; i < minMatrix.ColumnCount; i++)
            {
                minMatrix.SetValueAt(i, j, newValues[i]);
            }
        }

        public static void AddRow<T>(this IMatrixMinimal<T> minMatrix)
        {
            minMatrix.InsertRow(minMatrix.RowCount - 1);
        }
        public static void AddRow<T>(this IMatrixMinimal<T> minMatrix, IList<T> rowValues)
        {
            minMatrix.AddRow();
            minMatrix.SetRowValues(minMatrix.RowCount - 1, rowValues);
        }
        public static void AddRows<T>(this IMatrixMinimal<T> minMatrix, int i)
        {
            while (i-- > 0)
            {
                minMatrix.AddRow();
            }
        }
        public static void InsertRows<T>(this IMatrixMinimal<T> minMatrix, int position, int count)
        {
            while (count-- > 0)
            {
                minMatrix.InsertRow(position);
            }
        }
        public static void InsertRows<T>(this IMatrixMinimal<T> minMatrix, ICollection<int> positions)
        {
            foreach (int p in positions.OrderByDescending(x => x)) // make sure to do descending so that the indicies are not affected as we add
            {
                minMatrix.InsertRow(p);
            }
        }
        public static void RemoveRows<T>(this IMatrixMinimal<T> minMatrix, int position, int count)
        {
            while (count-- > 0)
            {
                minMatrix.RemoveRow(position);
            }
        }
        public static void RemoveRows<T>(this IMatrixMinimal<T> minMatrix, ICollection<int> position)
        {
            foreach (int p in position.OrderByDescending(x => x))
            {
                minMatrix.RemoveRow(p);
            }
        }

        public static void AddColumn<T>(this IMatrixMinimal<T> minMatrix)
        {
            minMatrix.InsertColumn(minMatrix.ColumnCount - 1);
        }
        public static void AddColumn<T>(this IMatrixMinimal<T> minMatrix, IList<T> columnValues)
        {
            minMatrix.AddColumn();
            minMatrix.SetColumnValues(minMatrix.ColumnCount - 1, columnValues);
        }
        public static void AddColumns<T>(this IMatrixMinimal<T> minMatrix, int i)
        {
            while (i-- > 0)
            {
                minMatrix.AddColumn();
            }
        }
        public static void InsertColumns<T>(this IMatrixMinimal<T> minMatrix, int position, int count)
        {
            while (count-- > 0)
            {
                minMatrix.InsertColumn(position);
            }
        }
        public static void InsertColumns<T>(this IMatrixMinimal<T> minMatrix, ICollection<int> positions)
        {
            foreach (var p in positions.OrderByDescending(x => x))
            {
                minMatrix.InsertColumn(p);
            }
        }
        public static void RemoveColumns<T>(this IMatrixMinimal<T> minMatrix, int position, int count)
        {
            while (count-- > 0)
            {
                minMatrix.RemoveColumn(position);
            }
        }
        public static void RemoveColumns<T>(this IMatrixMinimal<T> minMatrix, ICollection<int> positions)
        {
            foreach (var p in positions.OrderByDescending(x => x))
            {
                minMatrix.RemoveColumn(p);
            }
        }
    }
}
