using PostApp.Domain.Entities;

namespace PostApp.Domain.Interfaces
{
    public interface IChangeCalculator
    {
        /// <summary>
        /// Calculates the minimum number of denominations required to return the given change amount.
        /// </summary>
        /// <param name="denominations"></param>
        /// <param name="changeAmount"></param>
        /// <returns></returns>
        Dictionary<decimal, int> CalculateChange(List<Denomination> denominations, decimal changeAmount);
    }
}
