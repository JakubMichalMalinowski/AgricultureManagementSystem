using System.Collections.Generic;

namespace AgricultureManagementSystem.Models
{
    public class BalanceWithTransfersEnumerable
    {
        public decimal Balance { get; set; }
        public IEnumerable<Transfer> Transfers { get; set; }
    }
}
