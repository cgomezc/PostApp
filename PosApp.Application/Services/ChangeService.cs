using PosApp.Application.DTOs;
using PosApp.Application.Interfaces;
using PostApp.Domain.Interfaces;

namespace PosApp.Application.Services
{
    public class ChangeService : IChangeService
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IChangeCalculator _changeCalculator;
        public ChangeService(ICurrencyRepository currencyRepository, IChangeCalculator changeCalculator)
        {
            _currencyRepository = currencyRepository;
            _changeCalculator = changeCalculator;
        }
        public ChangeResponseDto GetChange(ChangeRequestDto changeRequest)
        {
            if (changeRequest.TotalPaid < changeRequest.TotalPrice)
                throw new ArgumentException("Total paid must be greater than or equal to the total price", nameof(changeRequest.TotalPaid));
            var currency = _currencyRepository.GetDefaultCurrency();
            var changeAmount = changeRequest.TotalPaid - changeRequest.TotalPrice;

            var change = _changeCalculator.CalculateChange(currency.Denominations, changeAmount);

            return new ChangeResponseDto
            {
                ChangeAmount = changeAmount,
                DenominationBreakdown = change
            };
        }
    }
}
