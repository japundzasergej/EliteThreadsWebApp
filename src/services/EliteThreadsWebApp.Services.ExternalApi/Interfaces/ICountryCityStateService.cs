using EliteThreadsWebApp.Services.ExternalApi.DTO;

namespace EliteThreadsWebApp.Services.ExternalApi.Interfaces
{
    public interface ICountryCityStateService
    {
        Task<IEnumerable<CountryDTO>> GetCountries();
        Task<IEnumerable<StateDTO>> GetStates(string country);
        Task<IEnumerable<CityDTO>> GetCities(string state);
    }
}
