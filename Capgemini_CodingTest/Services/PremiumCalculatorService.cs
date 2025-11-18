using Capgemini_CodingTest.Models;
using Capgemini_CodingTest.Strategy;

namespace Capgemini_CodingTest.Services
{
    public class PremiumCalculatorService
    { 
        private readonly IOccupationRatingStrategy _strategy;

        // Initializes a new instance of the PremiumCalculatorService with the specified strategy.
        public PremiumCalculatorService(IOccupationRatingStrategy strategy)
        {
            _strategy = strategy;
        }

        public decimal Calculate(decimal sumInsured, int age)
        {
            // Get the occupation rating factor from the strategy.
            decimal factor = _strategy.GetRatingFactor();
            // Calculate the premium using the provided formula.
            return (sumInsured * factor * age) / 1000 * 12;
        }
      
    }
}
