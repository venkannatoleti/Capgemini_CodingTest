using Capgemini_CodingTest.Models;
using Capgemini_CodingTest.Services;
using Capgemini_CodingTest.Strategy; 
using NUnit.Framework; 
using System;

namespace Capgemini_CodingTest.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PremiumModelTests
    {
        [Test]
        public void CalculatePremium_WithValidData_ReturnsCorrectPremium()
        {
            var model = new PremiumModel
            {
                Name = "John",
                AgeNextBirthday = 30,
                DOB = "01/1994",
                Occupation = "Doctor",
                DeathSumInsured = 100000
            };

            var premium = model.CalculatePremium();

            Assert.That(premium, Is.EqualTo((100000 * 1.5m * 30) / 1000 * 12));
        }

        [Test]
        public void CalculatePremium_ThrowsError_WhenOccupationMissing()
        {
            var model = new PremiumModel
            {
                Name = "John",
                AgeNextBirthday = 30,
                DOB = "01/1994",
                Occupation = "",
                DeathSumInsured = 100000
            };

            Assert.That(() => model.CalculatePremium(),
                Throws.Exception.TypeOf<KeyNotFoundException>());
        }

        [Test]
        public void OccupationRatings_HasAllRequiredJobs()
        {
            string[] expected = { "Cleaner", "Doctor", "Author", "Farmer", "Mechanic", "Florist", "Other" };

            foreach (var job in expected)
            {
                Assert.That(PremiumModel.OccupationRatings.ContainsKey(job), Is.True);
            }
        }

        [Test]
        public void ProfessionalStrategy_ReturnsCorrectFactor()
        {
            IOccupationRatingStrategy strategy = new ProfessionalRatingStrategy();

            Assert.That(strategy.GetRatingFactor(), Is.EqualTo(1.5m));
        }

        [Test]
        public void WhiteCollarStrategy_ReturnsCorrectFactor()
        {
            IOccupationRatingStrategy strategy = new WhiteCollarRatingStrategy();

            Assert.That(strategy.GetRatingFactor(), Is.EqualTo(2.25m));
        }

        [Test]
        public void LightManualStrategy_ReturnsCorrectFactor()
        {
            IOccupationRatingStrategy strategy = new LightManualRatingStrategy();

            Assert.That(strategy.GetRatingFactor(), Is.EqualTo(11.50m));
        }

        [Test]
        public void HeavyManualStrategy_ReturnsCorrectFactor()
        {
            IOccupationRatingStrategy strategy = new HeavyManualRatingStrategy();

            Assert.That(strategy.GetRatingFactor(), Is.EqualTo(31.75m));
        }
    }

}
