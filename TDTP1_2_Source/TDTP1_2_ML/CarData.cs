using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace TDTP1_2_ML
{
    public class CarData
    {
        [LoadColumn(0)]
        public float Puissance { get; set; }

        [LoadColumn(1)]
        public float PoidsAVide { get; set; }

        [LoadColumn(2)]
        public float ConsoMixte { get; set; }

        [LoadColumn(4)]
        public string Energie { get; set; }

        // Label (ce qu’on veut prédire)
        [LoadColumn(3)]
        public float CO2 { get; set; }
    }
}
