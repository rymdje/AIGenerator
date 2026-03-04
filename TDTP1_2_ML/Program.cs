using Microsoft.ML;
using Microsoft.ML.Data;

namespace TDTP1_2_ML
{
    public class CarData
    {
        [LoadColumn(0)] public float Puissance { get; set; }
        [LoadColumn(1)] public float PoidsAVide { get; set; }
        [LoadColumn(2)] public float ConsoMixte { get; set; }
        [LoadColumn(3)] public string Energie { get; set; }
        [LoadColumn(4)] public float CO2 { get; set; }
    }

    public class CarPrediction
    {
        [ColumnName("Score")]
        public float CO2 { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var mlContext = new MLContext();

            var data = mlContext.Data.LoadFromTextFile<CarData>(
                path: "ADEME-CarLabelling.csv",
                hasHeader: true,
                separatorChar: ';'
            );

            var preview = data.Preview(maxRows: 5);

            foreach (var row in preview.RowView)
            {
                foreach (var col in row.Values)
                {
                    Console.Write($"{col.Key}:{col.Value} | ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Chargement des données OK !");
        }
    }
}