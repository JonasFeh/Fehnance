using Data.InputData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ProcessedData
{
    internal class Bankactivity
    {
        public RawBankActivity RawBankActivity { get; set; }

        public ProcessedBankActivity ProcessedBankActivity { get; set; }
    }
}
