namespace MatrixLibrary;

public static class Calculator
{
    public static double[] CalculateVector(double[,] matrix)
    {
        var columnsCount = matrix.GetUpperBound(0) + 1;
        var rowsCount = matrix.Length / columnsCount;

        var rowIndexWithMaxSum = GetRowIndexWithMaxSum(matrix, columnsCount, rowsCount);
        return GetRowElements(matrix, rowIndexWithMaxSum, columnsCount);
    }

    public static double CalculateVectorFunction(double[] vector)
    {
        return vector.Select((element, index) => element * ((index + 1) % 2)).Sum();
    }

    private static int GetRowIndexWithMaxSum(double[,] matrix, int columnsCount, int rowsCount)
    {
        var index = -1;
        var maxSum = double.MinValue;

        for (var rowIndex = 0; rowIndex < rowsCount; rowIndex++)
        {
            var rowElements = GetRowElements(matrix, rowIndex, columnsCount);
            var currentSum = rowElements.Sum();

            if (maxSum >= currentSum) continue;

            maxSum = currentSum;
            index = rowIndex;
        }

        return index;
    }

    private static double[] GetRowElements(double[,] matrix, int rowIndex, int columnCount)
    {
        var rowElements = new double[columnCount];

        for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            rowElements[columnIndex] = matrix[columnIndex, rowIndex];
        }

        return rowElements;
    }
}
