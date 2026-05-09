using ADO.NetConnectionOrientedArchitecture_InCore_Example.Models;
using ADO.NetConnectionOrientedArchitecture_InCore_Example.Repositories;
using System.Diagnostics.Eventing.Reader;

namespace ADO.NetConnectionOrientedArchitecture_InCore_Example.Services
{
    public class DepartmentServices
    {
        DepartmentRepository _departmentRepository = new DepartmentRepository();

        public async Task<List<DepartmentDTO>> GetAllDepartment()
        {
            List<DepartmentDTO> lstdeptdto =new List<DepartmentDTO>();
            var dept = await _departmentRepository.GetAllDepartment();
            foreach(Department deptobj in dept)
            {
                // Here I am converting Model class obj data intio DTO class object 
                DepartmentDTO deptdto = new DepartmentDTO();
                deptdto.DeptID= deptobj.DeptID;
                deptdto.DeptName= deptobj.DeptName;
                deptdto.DeptLocation=deptobj.DeptLocation;
                lstdeptdto.Add(deptdto);
            }
            return lstdeptdto;
        }

        public async Task<DepartmentDTO> GetDepartmentByid(int deptid)
        {
            var deptobj = await _departmentRepository.GetDepartmentByDeptid(deptid);
            DepartmentDTO deptdto = new DepartmentDTO();
            deptdto.DeptID = deptobj.DeptID;
            deptdto.DeptName= deptobj.DeptName;
            deptdto.DeptLocation = deptobj.DeptLocation;
            return deptdto;
        }

        public async Task<bool> AddDepartment(DepartmentDTO deptdetail)
        {
            Department deptobj = new Department();

            //// Just for understanding of DTO concept
            if (deptdetail.FalgValue == 1)
            {
                deptobj.DeptName = "Softwate";
            }
            else { deptobj.DeptName = "Hardware"; };

            deptobj.DeptID= deptdetail.DeptID;
            //deptobj.DeptName= deptdetail.DeptName;
            deptobj.DeptLocation = deptdetail.DeptLocation;
            await _departmentRepository.AddDepartment(deptobj);
            return true;
        }

        public async Task<bool> UpdateDepartment(DepartmentDTO deptdetail)
        {
            Department deptobj = new Department();
            deptobj.DeptID=deptdetail.DeptID;
            deptobj.DeptName=deptdetail.DeptName;
            deptobj.DeptLocation=deptdetail.DeptLocation;
            await _departmentRepository.UpdateDepartment(deptobj);
            return true;
        }

        public async Task<bool> DeleteDepartment(int deptid)
        {
            await _departmentRepository.DeleteDepartmentByDeptid(deptid);
            return true;
        }
    }
}
