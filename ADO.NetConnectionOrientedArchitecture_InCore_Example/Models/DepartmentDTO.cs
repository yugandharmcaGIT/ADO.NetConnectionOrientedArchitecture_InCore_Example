using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ADO.NetConnectionOrientedArchitecture_InCore_Example.Models
{
    public class DepartmentDTO
    {
        public int DeptID { get; set; }
        public string DeptName {  get; set; }
        public string DeptLocation { get; set; }

        public int FalgValue { get; set; }
    }
}
