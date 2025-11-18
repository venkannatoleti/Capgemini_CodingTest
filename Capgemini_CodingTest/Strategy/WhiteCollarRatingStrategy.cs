namespace Capgemini_CodingTest.Strategy
{
    public class WhiteCollarRatingStrategy : IOccupationRatingStrategy
    {
        public decimal GetRatingFactor() => 2.25m;
    }
}
