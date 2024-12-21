using PosApp.Application.DTOs;
using PosApp.Application.Interfaces;
using PostApp.Domain.Interfaces;

namespace PosApp.Application.Services
{
    public class ChangeService : IChangeService
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IChangeCalculator _changeCalculator;

        /// <summary>
        /// Initializes a new instance of the ChangeService/> class.
        /// </summary>
        /// <param name="currencyRepository">The repository to retrieve currency information.</param>
        /// <param name="changeCalculator">The calculator to determine denomination breakdown.</param>
        public ChangeService(ICurrencyRepository currencyRepository, IChangeCalculator changeCalculator)
        {
            _currencyRepository = currencyRepository;
            _changeCalculator = changeCalculator;
        }
        /// <summary>
        /// Calculates the change to be returned based on the total price and total paid amount.
        /// </summary>
        /// <param name="changeRequest">The details of the transaction, including total price and total paid.</param>

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
