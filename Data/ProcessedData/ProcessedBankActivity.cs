using Common.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ProcessedData
{
    [Serializable]
    internal class ProcessedBankActivity
    {
        public Euro Amount { get; set; }

        public Category Category { get; set; }

        public DateTime Date { get; set; }
    }
}
