namespace MatrixLibrary;

public static class MatrixGenerator
{
    public static double[,] GenerateMatrix(int columns, int rows, Func<int, int, double> fillAction)
    {
        var matrix = new double[columns, rows];
        return FillMatrix(matrix, fillAction);
    }

    private static double[,] FillMatrix(double[,] matrix, Func<int, int, double> fillAction)
    {
        var columnsCount = matrix.GetUpperBound(0) + 1;
        var rowsCount = matrix.Length / columnsCount;

        for (var columnIndex = 0; columnIndex < columnsCount; columnIndex++)
        {
            for (var rowIndex = 0; rowIndex < rowsCount; rowIndex++)
            {
                matrix[columnIndex, rowIndex] = fillAction(columnIndex + 1, rowIndex + 1);
            }
        }

        return matrix;
    }
}
