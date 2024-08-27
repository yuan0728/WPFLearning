using Microsoft.AspNetCore.Mvc;

namespace XH.CoreWebApi.Controllers
{
    /// <summary>
    /// �����ṩҵ��ӿڵĶ������Դ��
    /// ����֮��˿��ǣ�5000
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class FirstController : ControllerBase
    {

        private readonly ILogger<FirstController> _logger;

        public FirstController(ILogger<FirstController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// ����һ��Get����
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetInfo")]
        public IEnumerable<WeatherForecast> GetInfo()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
            })
            .ToArray();
        }
        /// <summary>
        /// ����һ��Get���� ��������[Route("{id:int}")]
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        // ����
        [Route("{id:int}")]
        public IEnumerable<WeatherForecast> GetInfo(int id)
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
            })
            .ToArray();
        }

        /// <summary>
        /// ����һ��Put����
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public IEnumerable<WeatherForecast> PutInfo()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
            })
            .ToArray();
        }
        /// <summary>
        /// ����һ��Post����
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IEnumerable<WeatherForecast> PostInfo()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
            })
            .ToArray();
        }

        /// <summary>
        /// ����һ��Delete����
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public IEnumerable<WeatherForecast> DeleteInfo()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
            })
            .ToArray();
        }
    }
}
