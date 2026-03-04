using Microsoft.ML;
using Microsoft.ML.Trainers;
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
        // 
        // Étape 1 : Encodage One-Hot
        var energieEncoding = mlContext.Transforms.Categorical.OneHotEncoding(
            outputColumnName: "EnergieEncoded",
            inputColumnName: "Energie");

        // Étape 2 : Construction du vecteur de features
        var featureConcatenation = mlContext.Transforms.Concatenate(
            "Features",
            "Puissance",
            "PoidsAVide",
            "ConsoMixte",
            "EnergieEncoded");

        // Étape 3 : Choix du modèle de régression
        var trainer = mlContext.Regression.Trainers.FastTree(
            labelColumnName: "CO2",
            featureColumnName: "Features");

        // Assemblage final du pipeline
        var pipeline = energieEncoding
            .Append(featureConcatenation)
            .Append(trainer);

        // 
        var model = pipeline.Fit(data);

        var predictions = model.Transform(data);
        var metrics = mlContext.Regression.Evaluate(predictions, labelColumnName: "CO2");

        Console.WriteLine($"RMSE : {metrics.RootMeanSquaredError}");
        Console.WriteLine($"R² : {metrics.RSquared}");

    }
}