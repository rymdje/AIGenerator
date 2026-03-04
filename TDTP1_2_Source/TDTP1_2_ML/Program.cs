using Microsoft.ML;
using System.Globalization;
using TDTP1_2_ML;

namespace VehicleMachineLearning;

class Program
{
    static void Main(string[] args)
    {
        var dataPath = Path.Combine("vehicules_output.csv");

        var mlContext = new MLContext();

        var data = mlContext.Data.LoadFromTextFile<CarData>(
            path: dataPath,
            hasHeader: true,
            separatorChar: ';'
        );

        var preview = data.Preview(maxRows: 5);
        foreach (var row in preview.RowView)
        {
            foreach (var col in row.Values)
                Console.Write($"{col.Key}: {col.Value} | ");
            Console.WriteLine();
        }
    }
}