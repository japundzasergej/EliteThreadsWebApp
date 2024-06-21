using EliteThreadsWebApp.Services.ExternalApi.DTO;
using EliteThreadsWebApp.Services.ExternalApi.Interfaces;
using EliteThreadsWebApp.Services.ExternalApi.JSON;

namespace EliteThreadsWebApp.Services.ExternalApi.Services
{
    public class CountryCityStateService(IHttpClientFactory httpClientFactory)
        : BaseCountryCityStateService(httpClientFactory),
            ICountryCityStateService
    {
        public async Task<IEnumerable<CountryDTO>> GetCountries()
        {
            var response = await SendAsync<IEnumerable<CountryJSON>>("/countries/");
            List<CountryDTO> countries =  [ ];
            foreach (var country in response)
            {
                countries.Add(
                    new()
                    {
                        CountryName = country.CountryName,
                        Flag = $"https://flagsapi.com/{country.CountryShortName}/flat/32.png"
                    }
                );
            }
            return countries;
        }

        public async Task<IEnumerable<StateDTO>> GetStates(string country)
        {
            return await SendAsync<IEnumerable<StateDTO>>($"/states/{country}");
        }

        public async Task<IEnumerable<CityDTO>> GetCities(string state)
        {
            return await SendAsync<IEnumerable<CityDTO>>($"/cities/{state}");
        }
    }
}
