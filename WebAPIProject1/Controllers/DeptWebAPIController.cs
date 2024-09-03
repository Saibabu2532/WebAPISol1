using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPIProject1.DataAccess;
using WebAPIProject1.DataAccess.IRepository;
using WebAPIProject1.Models;

namespace WebAPIProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    //Design Pattern Abstract Repository
    public class DeptWebAPIController : ControllerBase
    {
        public IDeptRepository IDeptRef;

        public DeptWebAPIController(IDeptRepository _IDeptRef)
        {
            IDeptRef = _IDeptRef;
        }

        //Creating Web API 

        [HttpPost]
        [Route("InsertDepartment")]
        public async Task<IActionResult> InsertDepartment([FromBody] Department Dept)
        {
            try
            {
                var count = await IDeptRef.InsertDepartment(Dept);
                if (count > 0) 
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Record is Not Inserted.....!");
                }
            }
            catch(Exception ex)
            {
                return BadRequest("Somethig went Wrong ..!\n" + "Issue : " + ex.Message + ".\nwe will solve this issue soon ...1");
            }
        }

        [HttpGet]
        [Route("AllDepartments")]
        public async Task<IActionResult> AllDepartments()
        {
            try
            {
                var ListDept = await IDeptRef.AllDepartments( );
                if (ListDept.Count > 0)
                {
                    return Ok(ListDept);
                }
                else
                {
                    return NotFound("Records are Not Available in the Database.....!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somethig went Wrong ..!\n" + "Issue : " + ex.Message + ".\nwe will solve this issue soon ...1");
            }
        }

        [HttpGet]
        [Route("DepartmentByDeptNo")]
        public async Task<IActionResult> DepartmentByDeptNo( int DeptNo)
        {
            try
            {
                var Dept = await IDeptRef.GetDepartmentByDeptNo(DeptNo);
                if (Dept != null)
                {
                    return Ok(Dept);
                }
                else
                {
                    return NotFound("Record is Not Available in the Database with DeptN o= '" + DeptNo + "'.....!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somethig went Wrong ..!\n" + "Issue : " + ex.Message + ".\nwe will solve this issue soon ...1");
            }
        }

        [HttpGet]
        [Route("DepartmentByLocation")]
        public async Task<IActionResult> DepartmentByLocation(string Location)
        {
            try
            {
                var Dept = await IDeptRef.GetDepartmentByLocation(Location);
                if (Dept != null)
                {
                    return Ok(Dept);
                }
                else
                {
                    return NotFound("Record is Not Available in the Database with Location '" + Location +"'.....!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somethig went Wrong ..!\n" + "Issue : " + ex.Message + ".\nwe will solve this issue soon ...1");
            }
        }

        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult>UpdateDepartment([FromBody] Department Dept)
        {
            try
            {
                var count = await IDeptRef.updateDepartment(Dept);
                if (count > 0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Record is Not updated.....!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somethig went Wrong ..!\n" + "Issue : " + ex.Message + ".\nwe will solve this issue soon ...1");
            }
        }

        [HttpDelete]
        [Route("DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment( int DeptNo)
        {
            try
            {
                var count = await IDeptRef.DeleteDepartment(DeptNo);
                if (count > 0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Record is Not Deleted.....!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somethig went Wrong ..!\n" + "Issue : " + ex.Message + ".\nwe will solve this issue soon ...1");
            }
        }

    }
}
