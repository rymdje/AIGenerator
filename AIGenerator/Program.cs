class Program
{

    private static string _filePath = @"ADEME-CarLabelling.csv";
    private static string _saveFilePath = @"ADEME-CarLabelling-Clean.csv";

    static void Main(string[] args)
    {

        try
        {
            var fichier = File.ReadAllLines(_filePath);
            var header = fichier[0].Split(';');

            int indexPuissance = Array.IndexOf(header, "\"Puissance maximale\"");
            int indexElec = Array.IndexOf(header, "\"Puissance nominale électrique\"");
            int indexPoidsVide = Array.IndexOf(header, "\"Poids à vide\"");
            int indexConsoVitMixtMin = Array.IndexOf(header, "\"Conso vitesse mixte Min\"");
            int indexCO2VitMixteMin = Array.IndexOf(header, "\"CO2 vitesse mixte Min\"");
            int indexEnergie = Array.IndexOf(header, "Energie");

            var output = new List<string>();
            output.Add("Puissance;PoidsAVide;ConsoMixte;Energie;CO2");

            foreach (var item in fichier.Skip(1))
            {
                var cols = item.Split(';');

                var puissance = cols[indexPuissance];
                var elec = cols[indexElec];

                if(string.IsNullOrWhiteSpace(puissance) )
                {
                    puissance = elec;
                }

                var poidsVide = cols[indexPoidsVide].Replace(",", ".");
                var consoMixte = cols[indexConsoVitMixtMin].Replace(",", ".");
                var energie = cols[indexEnergie];
                puissance = puissance.Replace(",", ".");
                var co2Mixte = cols[indexCO2VitMixteMin].Replace(",", ".");

                if (string.IsNullOrWhiteSpace(co2Mixte))
                {
                    co2Mixte = "0";
                }



                if (!(string.IsNullOrWhiteSpace(puissance)
                    && string.IsNullOrWhiteSpace(poidsVide)
                    && string.IsNullOrWhiteSpace(consoMixte)
                    && string.IsNullOrWhiteSpace(co2Mixte)
                    && string.IsNullOrWhiteSpace(energie)))
                {
                    output.Add($"{puissance};{poidsVide};{consoMixte};{energie};{co2Mixte}");
                    
                }

            }
            File.WriteAllLines(_saveFilePath, output);

        } catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}