namespace Capgemini_CodingTest.Strategy
{
    public class ProfessionalRatingStrategy : IOccupationRatingStrategy
    {
        public decimal GetRatingFactor() => 1.5m;
    }
}
