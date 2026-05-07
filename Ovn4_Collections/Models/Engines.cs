namespace Ovn4_Collections.Models;

public interface IEngineStats
{
    int MaxPowerHP { get; }
    string Description { get; }
}

public readonly struct FuelEnginesStats(int maxPowerHP, decimal displacementLiters, FuelTypes fuelType) : IEngineStats
{
    public int MaxPowerHP { get; } = maxPowerHP;
    public decimal DisplacementLiters {get; } = displacementLiters;
    public FuelTypes FuelType { get; } = fuelType;

    public string Description => $"{FuelType}, {DisplacementLiters}L";
}

public readonly struct ElectricEnginesStats(int maxPowerHP, decimal batteryCapacityKwh) : IEngineStats
{
    public int MaxPowerHP { get; } = maxPowerHP;
    public decimal BatteryCapacityKwh { get; } = batteryCapacityKwh;

    public string Description => $"Electric, {BatteryCapacityKwh} kWh";
}
