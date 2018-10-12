namespace AnimalMatcher.Services.Location.Interfaces
{
    using AnimalMatcher.Services.Models.Location;

    public interface ILocationService
    {
        double Distance(LocationDTO locationFrom, LocationDTO locationTo, DistanceUnit unit = DistanceUnit.Kilometers);
    }
}
