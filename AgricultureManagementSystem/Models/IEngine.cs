namespace AgricultureManagementSystem.Models
{
    interface IEngine
    {
        public FuelType FuelType { get; set; }
        public ushort? FuelCapacity { get; set; }
        public ushort Power { get; set; }
    }
}
