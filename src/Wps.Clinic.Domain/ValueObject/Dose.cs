namespace Wps.Clinic.Domain.ValueObject
{
    public record Dose
    {
        public Dose(decimal quantity, UnitofMeasure unit)
        {
            Quantity = quantity;
            Unit = unit;
        }

        public decimal Quantity { get; init; }
        public UnitofMeasure Unit { get; init; }
    }
    public enum UnitofMeasure
    {
        mg,
        ml,
        tablet
    }
}