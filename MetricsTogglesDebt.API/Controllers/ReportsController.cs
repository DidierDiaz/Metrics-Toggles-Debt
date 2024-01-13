using MetricsTogglesDebt.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetricsTogglesDebt.API.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IMetricsService _metricsService;

        public ReportsController(IMetricsService metricsService) => _metricsService = metricsService;

        [HttpGet("depth-inheritance")]
        public IActionResult GetDepthOfInheritance()
        {
            return Ok(_metricsService.GetDepthOfInheritanceMetrics());
        }

        [HttpGet("lines-code")]
        public IActionResult LinesOfCode()
        {
            return Ok(_metricsService.GetLinesOfCodeMetrics());
        }

        [HttpGet("class-coupling")]
        public IActionResult ClassCoupling()
        {
            return Ok(_metricsService.GetClassCouplingMetrics());
        }

        [HttpGet("get-values/{type}")]
        public IActionResult GetValues(string type)
        {
            switch(type)
            {
                case "inheritance":
                    return Ok(_metricsService.GetClassesAndMethods());

                case "linesOfCode":
                    return Ok(_metricsService.GetLinesOfCode().Select(x => new
                    {
                        x.Id,
                        x.Language,
                        x.Lines,
                        x.File,
                        x.Comments
                    }));

                case "classCoupling":
                    return Ok(_metricsService.GetClassesAndMethods());

                default:
                    return Ok(new List<string>());
            }
        }
    }
}
