using Business;
using CompanyAPI.RedisCache;
using Data.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private ISalaryService _salaryService;
        private ICacheService _cacheService;
        public BaseController(ISalaryService salaryService, ICacheService cacheService)
        {
            _salaryService = salaryService;
            _cacheService = cacheService;
        }

        [HttpGet("{CompanyId:int}")]
        public ActionResult<int> TotalSalary(int companyId)
        {
            if (_cacheService.IsThere(companyId.ToString()))
            {
                return Ok(_cacheService.Get<int>(companyId.ToString()));
            }
            int sum = _salaryService.TotalSalary(companyId);
            _cacheService.Add(companyId.ToString(), sum);
            return Ok(sum);
        }
    }
}
