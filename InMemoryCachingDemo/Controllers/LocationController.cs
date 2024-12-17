using InMemoryCachingDemo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InMemoryCachingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationRepository _repository; 
        private readonly ILogger<LocationController> _logger;

        public LocationController(LocationRepository repository, ILogger<LocationController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("countries")]
        public async Task<IActionResult> GetCountries()
        {
            _logger.LogInformation("Getting all the countries from InMemory Cache or directly from Db.");
            var countries = await _repository.GetCountriesAsync();
            _logger.LogInformation("Returning the result. {@countries}", countries);
            return Ok(countries);
        }

        [HttpGet("states/{countryId}")]
        public async Task<IActionResult> GetStates(int countryId)
        {
            _logger.LogInformation("Getting all the States by country from InMemory Cache or directly from Db.");
            var states = await _repository.GetStatesAsync(countryId);
            _logger.LogInformation("Returning the result. {@states}", states);
            return Ok(states);
        }

        [HttpGet("cities/{stateId}")]
        public async Task<IActionResult> GetCities(int stateId)
        {
            _logger.LogInformation("Getting all the Cities by state from InMemory Cache or directly from Db.");
            var cities = await _repository.GetCitiesAsync(stateId);
            _logger.LogInformation("Returning the result. {@cities}", cities);
            return Ok(cities);
        }
    }
}