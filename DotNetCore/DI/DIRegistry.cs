using DotNetCore.Interfaces;
using DotNetCore.Services;
using Lamar;

namespace DotNetCore.DI
{
    public class DIRegistry : ServiceRegistry
    {

        public DIRegistry()
        {
            For<IWeatherForecast>().Use<WeatherForecastService>().Scoped();
            For<IProducts>().Use<ProductsService>().Scoped();
            For<IToken>().Use<TokenService>().Scoped();
        }
    }
}
