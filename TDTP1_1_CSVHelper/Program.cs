using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace TDTP1_1_CSVHelper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture);
            config.Delimiter = ";";
            config.ReadingExceptionOccurred = (ex) => { return false; };

            using var reader = new StreamReader("vehicules.csv");
            using var csvReader = new CsvReader(reader, config);
            csvReader.Context.RegisterClassMap<CarDataMap>();

            var vehicules = csvReader.GetRecords<CarData>();

            using var writer = new StreamWriter("vehicules_output.csv");
            using var csvWriter = new CsvWriter(writer, config);
            csvWriter.WriteHeader<CarData>();
            csvWriter.NextRecord();
            foreach (var car in vehicules)
            {
                csvWriter.WriteRecord<CarData>(car);
                csvWriter.NextRecord();
            }
            Console.WriteLine("Fin de nettoyage");
        }

        public class CarData
        {
            public float Puissance { get; set; }
            public float PoidsAVide { get; set; }
            public float ConsoMixte { get; set; }
            public float CO2 { get; set; }
            public string Energie { get; set; }
        }

        public class CarDataMap : ClassMap<CarData>
        {
            public CarDataMap()
            {

                Map(m => m.Puissance).Convert(row =>
                {
                    var pMax = row.Row.GetField("Puissance maximale");
                    var pElec = row.Row.GetField("Puissance nominale électrique");
                    var puissance = !string.IsNullOrWhiteSpace(pMax) ? pMax : pElec;
                    return float.Parse(puissance.Replace(',', '.'), CultureInfo.InvariantCulture);
                });
                Map(m => m.PoidsAVide).Name("Poids à vide").Convert(row =>
                {
                    var poids = row.Row.GetField("Poids à vide");
                    return float.Parse(poids.Replace(',', '.'), CultureInfo.InvariantCulture);
                });
                Map(m => m.ConsoMixte).Name("Conso vitesse mixte Min").Convert(row =>
                {
                    var conso = row.Row.GetField("Conso vitesse mixte Min");
                    return float.Parse(conso.Replace(',', '.'), CultureInfo.InvariantCulture);
                });
                Map(m => m.CO2).Name("CO2 vitesse mixte Min").Convert(row =>
                {
                    var co2 = row.Row.GetField("CO2 vitesse mixte Min");
                    return float.Parse(co2.Replace(',', '.'), CultureInfo.InvariantCulture);
                });
                Map(m => m.Energie).Name("Energie");
            }
        }
    }
}
