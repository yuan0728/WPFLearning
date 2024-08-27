using Microsoft.AspNetCore.Mvc;

namespace XH.CoreWebApi.Controllers
{
    /// <summary>
    /// 对外提供业务接口的定义的资源类
    /// 发布之后端口是：5000
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
        /// 这是一个Get请求
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
        /// 这是一个Get请求 带参数：[Route("{id:int}")]
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        // 传参
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
        /// 这是一个Put请求
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
        /// 这是一个Post请求
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
        /// 这是一个Delete请求
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
