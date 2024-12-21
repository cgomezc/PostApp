namespace PosApp.Application.DTOs
{
    public class ChangeResponseDto
    {
        public decimal ChangeAmount { get; set; }
        public Dictionary<decimal, int> DenominationBreakdown { get; set; } = new();
    }
}
