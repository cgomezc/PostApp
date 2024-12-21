using PostApp.Domain.Entities;
using PostApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostApp.Domain.Services
{
    public class ChangeCalculatorService : IChangeCalculator
    {
        public ChangeCalculatorService() { }
        public Dictionary<decimal, int> CalculateChange(List<Denomination> denominations, decimal changeAmount)
        {
            if (changeAmount < 0)
                throw new ArgumentException("Change amount cannot be negative.", nameof(changeAmount));

            var change = new Dictionary<decimal, int>();
            var sortedDenominations = denominations.OrderByDescending(d => d.Value).ToList();

            foreach (var denomination in sortedDenominations)
            {
                if (changeAmount == 0) break;

                int count = (int)(changeAmount / denomination.Value);
                if (count > 0)
                {
                    change[denomination.Value] = count;
                    changeAmount -= count * denomination.Value;
                }
            }

            if (changeAmount > 0)
                throw new InvalidOperationException("Exact change cannot be provided with the given denominations.");

            return change;
        }
    }
}
