using PostApp.Domain.Entities;

namespace PostApp.Domain.Interfaces
{
    public interface ICurrencyRepository
    {
        /// <summary>
        /// Retrieves the default currency configuration for the POS system.
        /// </summary>
        /// <returns></returns>
        Currency GetDefaultCurrency();
    }
}
