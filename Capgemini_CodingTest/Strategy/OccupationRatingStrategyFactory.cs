namespace Capgemini_CodingTest.Strategy
{
    public static class OccupationRatingStrategyFactory
    {
        public static IOccupationRatingStrategy GetStrategy(string occupation)
        {
            return occupation switch
            {
                "Cleaner" => new LightManualRatingStrategy(),
                "Florist" => new LightManualRatingStrategy(),

                "Doctor" => new ProfessionalRatingStrategy(),

                "Author" => new WhiteCollarRatingStrategy(),

                "Farmer" => new HeavyManualRatingStrategy(),
                "Mechanic" => new HeavyManualRatingStrategy(),
                "Other" => new HeavyManualRatingStrategy(),

                _ => throw new ArgumentException("Invalid occupation")
            };
        }
    }
}
