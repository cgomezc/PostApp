using Moq;
using PosApp.Application.DTOs;
using PosApp.Application.Services;
using PostApp.Domain.Entities;
using PostApp.Domain.Interfaces;
using PostApp.Domain.Services;

namespace TestProject.Services
{
    public class ChangeCalculatorServiceTests
    {
        private Mock<ICurrencyRepository> _currencyRepositoryMock;
        
        private ChangeService _changeService;

        [SetUp]
        public void Setup()
        {

            var currencies = new List<Currency>
    {
        new Currency
        {
            Name = "US Dollar",
            CurrencyCode = "USD",
            Denominations = new List<Denomination>
            {
                new Denomination(0.01m),
                new Denomination(0.05m),
                new Denomination(0.10m),
                new Denomination(0.25m),
                new Denomination(1.00m),
                new Denomination(2.00m),
                new Denomination(5.00m),
                new Denomination(10.00m),
                new Denomination(20.00m),
                new Denomination(50.00m),
                new Denomination(100.00m)
            }
        },
        new Currency
        {
            Name = "Mexican Peso",
            CurrencyCode = "MXN",
            Denominations = new List<Denomination>
            {
                new Denomination(0.05m),
                new Denomination(0.10m),
                new Denomination(0.50m),
                new Denomination(1.00m),
                new Denomination(2.00m)
            }
        }
    };
            _currencyRepositoryMock = new Mock<ICurrencyRepository>();
            var changeCalculator = new ChangeCalculatorService();
            var defaultCurrency = currencies.First(c => c.CurrencyCode == "USD");

            _currencyRepositoryMock.Setup(repo => repo.GetDefaultCurrency())
                                   .Returns(defaultCurrency);

            _changeService = new ChangeService(_currencyRepositoryMock.Object, changeCalculator);
        }

        [Test]
        public void GetChange_ShouldThrowArgumentException_WhenTotalPaidIsLessThanTotalPrice()
        {
            // Arrange
            var changeRequest = new ChangeRequestDto
            {
                TotalPaid = 50,
                TotalPrice = 100
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(
                () => _changeService.GetChange(changeRequest),
                "Total paid must be greater than or equal to the total price");
        }

        [Test]
        public void CalculateChange_ShouldReturnCorrectChange()
        {


            var request = new ChangeRequestDto
            {
                TotalPrice = 1.59m,
                TotalPaid = 2.00m
            };

            // Act
            var result = _changeService.GetChange(request);

            // Assert
            Assert.That(result.DenominationBreakdown.Count, Is.EqualTo(4));
            Assert.That(result.DenominationBreakdown[0.25m], Is.EqualTo(1));
            Assert.That(result.DenominationBreakdown[0.10m], Is.EqualTo(1));
            Assert.That(result.DenominationBreakdown[0.05m], Is.EqualTo(1));
            Assert.That(result.DenominationBreakdown[0.01m], Is.EqualTo(1));
        }
    }
}