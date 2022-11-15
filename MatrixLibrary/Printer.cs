namespace MatrixLibrary;

public static class Printer
{
    public static void PrintMatrix(double[,] matrix)
    {
        Console.WriteLine();

        var columnsCount = matrix.GetUpperBound(0) + 1;
        var rowsCount = matrix.Length / columnsCount;

        var maxElementLength = GetMaxElementLengthFromMatrix(matrix, columnsCount, rowsCount);

        for (var columnIndex = 0; columnIndex < columnsCount; columnIndex++)
        {
            for (var rowIndex = 0; rowIndex < rowsCount; rowIndex++)
            {
                Console.Write($"{matrix[columnIndex, rowIndex].ToString("F1").PadLeft(maxElementLength)} ");
            }

            Console.WriteLine();
        }
    }

    public static void PrintVector(double[] vector)
    {
        Console.WriteLine();

        foreach (var vectorElement in vector)
        {
            Console.Write($"{vectorElement:F3}  ");
        }

        Console.WriteLine();
    }

    private static int GetMaxElementLengthFromMatrix(double[,] matrix, int columnsCount, int rowsCount)
    {
        var maxElementLength = 0;
        for (var columnIndex = 0; columnIndex < columnsCount; columnIndex++)
        {
            for (var rowIndex = 0; rowIndex < rowsCount; rowIndex++)
            {
                var matrixElementLength = matrix[columnIndex, rowIndex].ToString("F1").Length;
                if (maxElementLength < matrixElementLength) maxElementLength = matrixElementLength;
            }
        }

        return maxElementLength;
    }
}
