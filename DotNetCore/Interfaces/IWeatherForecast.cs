namespace DotNetCore.Interfaces
{
    public interface IWeatherForecast
    {
        IEnumerable<WeatherForecast> GetWeatherForecast();
    }
}
