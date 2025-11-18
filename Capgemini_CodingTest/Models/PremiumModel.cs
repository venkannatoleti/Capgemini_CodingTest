using Capgemini_CodingTest.Services;
using Capgemini_CodingTest.Strategy;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace Capgemini_CodingTest.Models
{

    public class PremiumModel
    {
        public string Name { get; set; }
        public int AgeNextBirthday { get; set; }
        public string DOB { get; set; }
        public string Occupation { get; set; }
        public decimal DeathSumInsured { get; set; }
        public decimal MonthlyPremium { get; set; }

        public decimal CalculatePremium()
        {
            //Creating a instance based on strategy  
            var strategy = OccupationRatingStrategyFactory.GetStrategy(Occupation);

            var calculator = new PremiumCalculatorService(strategy);

            // Calculating the Premium 
            MonthlyPremium = calculator.Calculate(DeathSumInsured, AgeNextBirthday);

            return MonthlyPremium;
        } 

        public static readonly Dictionary<string, string> OccupationRatings = new()
        {
            { "Cleaner", "Light Manual" },
            { "Doctor", "Professional" },
            { "Author", "White Collar" },
            { "Farmer", "Heavy Manual" },
            { "Mechanic", "Heavy Manual" },
            { "Florist", "Light Manual" },
            { "Other", "Heavy Manual" }
        };       

    }
}