using ADO.NetConnectionOrientedArchitecture_InCore_Example.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADO.NetConnectionOrientedArchitecture_InCore_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        DepartmentServices deptServices = new DepartmentServices();

        [HttpGet]
        [Route("GetAllDepartment")]

        public string test()
        {
            return "asa";
        }
       
        //public async Task<IActionResult> 
    }
}
