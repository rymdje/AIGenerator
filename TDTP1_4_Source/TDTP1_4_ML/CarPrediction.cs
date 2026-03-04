using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;


namespace TDTP1_4_ML
{
    public class CarPrediction
    {
        [ColumnName("Score")]
        public float CO2 { get; set; }
    }
}
