using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XH.WPFServices;
using XH.WPFInterfaces;
using XH.WPFDbModels.Models;

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
        private readonly IScoreInfoService _scoreInfoService;

        public FirstController(ILogger<FirstController> logger, IScoreInfoService scoreInfoService)
        {
            _logger = logger;
            _scoreInfoService = scoreInfoService;
        }
        /// <summary>
        /// ����һ��Get����
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetInfo")]
        [Authorize(AuthenticationSchemes= JwtBearerDefaults.AuthenticationScheme)] // ֧��JWT��������Ȩ
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
        /// ����һ��GetScoreInfoList����
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetScoreInfoList")]
        [Authorize(AuthenticationSchemes= JwtBearerDefaults.AuthenticationScheme)] // ֧��JWT��������Ȩ
        public IActionResult GetScoreInfoList()
        {
            var scoreList = _scoreInfoService.Set<ScoreInfo>().ToList();
            return new JsonResult(scoreList);
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
