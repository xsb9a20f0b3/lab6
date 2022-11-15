using MatrixLibrary;

string GetNotNullableVariable(string variableName)
{
    while (true)
    {
        Console.Write($"Enter {variableName} value: ");
        var input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input))
        {
            return input;
        }

        Console.WriteLine("The entered value cannot be null.");
    }
}

int GetIntegerFromCommandLine(string variableName = "variable")
{
    while (true)
    {
        var stringNumber = GetNotNullableVariable(variableName);

        if (int.TryParse(stringNumber, out var parsed)) return parsed;

        Console.WriteLine("The entered number must be of type int.");
    }
}


var columnsCount = GetIntegerFromCommandLine("columns count");
var rowsCount = GetIntegerFromCommandLine("rows count");

var matrix = MatrixGenerator.GenerateMatrix(columnsCount, rowsCount,
    double(int columnIndex, int rowIndex) =>
        Math.Pow(Math.Log(9 * columnIndex + rowIndex, 3), 3) + Math.Pow(-Math.E, columnIndex));
Printer.PrintMatrix(matrix);

var vector = Calculator.CalculateVector(matrix);
Printer.PrintVector(vector);

var vectorFunctionResult = Calculator.CalculateVectorFunction(vector);
Console.WriteLine($"\n{vectorFunctionResult:F3}");
