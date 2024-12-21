using Newtonsoft.Json;
using PostApp.Domain.Entities;
using PostApp.Domain.Interfaces;

namespace PosApp.Persistence
{
    public class InMemoryCurrencyRepository : ICurrencyRepository
    {
        private readonly List<Currency> _currencies;
        private readonly string _defaultCurrencyCode;



        public InMemoryCurrencyRepository(List<Currency> currencies, string defaultCurrencyCode)
        {
            _currencies = currencies;
            _defaultCurrencyCode = defaultCurrencyCode;
        }
       

        public Currency GetDefaultCurrency()
        {
            var defaultCurrency = _currencies.FirstOrDefault(c => c.CurrencyCode == _defaultCurrencyCode);
            if (defaultCurrency == null)
                throw new InvalidOperationException("Default currency is not set.");

            return defaultCurrency;
        }
    }
}
