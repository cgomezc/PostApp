using PosApp.Application.DTOs;

namespace PosApp.ConsoleApp.Services
{
    public class OutPutReader
    {
        public void DisplayChange(ChangeResponseDto response)
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
