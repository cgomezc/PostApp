using PosApp.Application.DTOs;
using PosApp.Application.Interfaces;
using PosApp.Application.Services;
using PosApp.ConsoleApp.Services;
using PosApp.Persistence;
using PostApp.Domain.Interfaces;
using PostApp.Domain.Services;
using Microsoft.Extensions.Configuration;



namespace PosApp.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Build configuration to load settings from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory) // Set the base path to the app's directory
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var filePath = configuration["CurrencyConfig:FilePath"];
            var defaultCurrencyCode = configuration["CurrencyConfig:DefaultCurrencyCode"];



            WelcomeScreen();

            var currencies = await CurrencyLoader.LoadCurrenciesFromJsonAsync(filePath);


            ICurrencyRepository currencyRepository = new InMemoryCurrencyRepository(currencies, defaultCurrencyCode);
            IChangeCalculator changeCalculator = new ChangeCalculatorService();
            IChangeService changeService = new ChangeService(currencyRepository, changeCalculator);

            // Read input from the user
            var inputReader = new InputReader();
            var changeRequest = inputReader.ReadInput();

            try
            {
                // Process the change calculation
                var changeResponse = changeService.GetChange(changeRequest);

                // Display results
                ResultScreen();
                // var outputReader = new OutputReader();
                DisplayChange(changeResponse);
            }
            catch (Exception ex)
            {
                // Handle errors gracefully
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

       
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static void WelcomeScreen()
        {
            Console.WriteLine("========================================");
            Console.WriteLine(" Welcome to CashMasters POS System ");
            Console.WriteLine("========================================");
        }

        public static void ResultScreen()
        {
            Console.WriteLine("========================================");
            Console.WriteLine(" Change Calculation Results ");
            Console.WriteLine("========================================");

        }

        public static void DisplayChange(ChangeResponseDto response)
        {
            Console.WriteLine($"Change Amount: {response.ChangeAmount:C}");
            Console.WriteLine("Denomination Breakdown:");

            foreach (var item in response.DenominationBreakdown)
            {
                Console.WriteLine($"{item.Key:C} x {item.Value}");
            }
        }
    }
}
