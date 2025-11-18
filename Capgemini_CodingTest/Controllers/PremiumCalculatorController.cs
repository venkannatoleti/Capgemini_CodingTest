using Capgemini_CodingTest.Models;
using Capgemini_CodingTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Capgemini_CodingTest.Controllers
{
    public class PremiumCalculatorController : Controller
    {
        //private readonly IPremiumCalculator _premiumService;

        //public PremiumCalculatorController()
        //{
        //    _premiumService = new PremiumCalculatorService();
        //}

        [HttpGet]
        public IActionResult Calculate()
        {
            ViewBag.Occupations = PremiumModel.OccupationRatings.Keys.ToList();
            return View(new PremiumModel());
        }

        //[HttpPost]
        //public IActionResult Calculate(PremiumModel model)
        //{
        //    Validate(model);

        //    if (!ModelState.IsValid)
        //        return View(model);

        //    model.MonthlyPremium = _premiumService.Calculate(model);
        //    return View(model);
        //}
        [HttpPost]
        public IActionResult Calculate(PremiumModel model)
        {
            // Validate all required fields manually or using DataAnnotations
            ViewBag.Occupations = PremiumModel.OccupationRatings.Keys.ToList();
            ValidateModel(model);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // If all inputs are valid it will calculate premium
            if (!string.IsNullOrWhiteSpace(model.Occupation))
            {
                model.MonthlyPremium = model.CalculatePremium();
            }

            return View(model);
        }

        private void ValidateModel(PremiumModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
                ModelState.AddModelError("Name", "Name is required");

            if (model.AgeNextBirthday <= 0)
                ModelState.AddModelError("AgeNextBirthday", "Age is required");

            if (string.IsNullOrWhiteSpace(model.DOB))
                ModelState.AddModelError("DOB", "Date of Birth is required");

            if (string.IsNullOrWhiteSpace(model.Occupation))
                ModelState.AddModelError("Occupation", "Select an occupation");

            if (model.DeathSumInsured <= 0)
                ModelState.AddModelError("DeathSumInsured", "Death Sum Insured required");
        }
    }
}
