using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureManagementSystem.Models
{
    public class BalanceWithTransfersEnumerable
    {
        public decimal Balance { get; set; }
        public IEnumerable<Transfer> Transfers { get; set; }
    }
}
