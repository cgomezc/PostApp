
using PosApp.Application.DTOs;

namespace PosApp.ConsoleApp.Services
{
    public class InputReader
    {
        public ChangeRequestDto ReadInput()
        {
           
            var totalPrice = GetValidDecimalInput("Enter total price:");           
            var totalPaid = GetValidDecimalInput("Enter the payment (comma-separated):");

            return new ChangeRequestDto
            {
                TotalPrice = totalPrice.FirstOrDefault(),
                TotalPaid = totalPaid.Sum()
            };
        }

        // Helper function to get a valid decimal input
        static List<decimal> GetValidDecimalInput(string prompt)
        {
       
            bool isValid;
            string[] userInput;
            do
            {
                Console.WriteLine(prompt);
                userInput = Console.ReadLine().Split(',');
                isValid = userInput.All(i => IsValidDecimal(i.Trim()));



            } while (!isValid);

            return userInput.Select(decimal.Parse).ToList();
        }

        static bool IsValidDecimal(string input)
        {
            return decimal.TryParse(input, out _);
        }   



    }
}
