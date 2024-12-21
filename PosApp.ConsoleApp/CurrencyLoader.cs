using Newtonsoft.Json;
using PostApp.Domain.Entities;

namespace PosApp.ConsoleApp
{
    public class CurrencyLoader
    {
        public static async Task<List<Currency>> LoadCurrenciesFromJsonAsync(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Configuration file not found: {filePath}");

            var json = await File.ReadAllTextAsync(filePath);

            var tempCurrencies = JsonConvert.DeserializeAnonymousType(
                json,
                new[]
                {
                new
                {
                    Name = string.Empty,
                    CurrencyCode = string.Empty,
                    Denominations = new List<decimal>(),
                    IsDefault = false
                }
                });

            return tempCurrencies.Select(tc => new Currency
            {
                Name = tc.Name,
                CurrencyCode = tc.CurrencyCode,              
                Denominations = tc.Denominations.Select(d => new Denomination(d)).ToList()
            }).ToList();
        }
    }
}
