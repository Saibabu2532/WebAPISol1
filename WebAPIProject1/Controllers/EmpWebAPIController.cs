using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPIProject1.DataAccess;
using WebAPIProject1.DataAccess.IRepository;
using WebAPIProject1.Filters;
using WebAPIProject1.Models;

namespace WebAPIProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpWebAPIController : ControllerBase
    {
        public IEmpRepository IEmpRef;
        public EmpWebAPIController(IEmpRepository _empRef)
        {
            IEmpRef = _empRef;
        }

        /// <summary>
        /// This method is used to insert a new employee record into the database
        /// </summary>
        /// <param name="Emp">Emp is a Employee Model Object</param>
        /// <returns>It Return The Db Effected Save Changed Count</returns>

        [HttpPost]
        [Route("InsertEmployee")]
        public async Task<IActionResult> InsertEmployee([FromBody]Employee Emp)
        {
            try
            {
               if(ModelState.IsValid)
                {
                    var count = await IEmpRef.InsertEmployee(Emp);
                    if (count > 0)
                    {
                        return Ok(count);
                    }
                    else
                    {
                        return BadRequest("Record is Not Inserted.....!");
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                } 
            }
            catch(Exception ex)
            {
                return BadRequest("Somethig went Wrong ..!\n" + "Issue : " + ex.Message + ".\nwe will solve this issue soon ...1");
            }
        }

        /// <summary>
        /// This Web Api is used to read all the available employee data from database
        /// </summary>
        /// <returns>It returns a employee collection objectz</returns>
        [HttpGet]
        [Route("AllEmployees")]
        [MyActionFilters]
        [MyResultFilters]
        [MyExceptionFilters]
        public async Task<IActionResult> AllEmployees()
        {
             try
             {
               // throw new DivideByZeroException();
                // throw new FormatException();
                var ListEmps = await IEmpRef.AllEmployees( );
                if (ListEmps.Count > 0)
                {
                    return Ok(ListEmps);
                }
                else
                {
                    return NotFound("Records are Not Available in the Database.....!");
                }
            }
            catch (Exception ex)
                  {
                //Log : Error Information [Exception Logging]
               return BadRequest("Somethig went Wrong ..!\n" + "Issue : " + ex.Message + ".\nwe will solve this issue soon ...1");
                }
        }

        [HttpGet]
        [Route("EmployeeByEmpId")]
        public async Task<IActionResult> EmployeeByEmpId( int EmpId)
        {
            try
            {
                var Emp = await IEmpRef.GetEmployeeByEmpId(EmpId);
                if (Emp != null)
                {
                    return Ok(Emp);
                }
                else
                {
                    return NotFound("Records is Not Available in the Database.....!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somethig went Wrong ..!\n" + "Issue : " + ex.Message + ".\nwe will solve this issue soon ...1");
            }
        }

        [HttpGet]
        [Route("EmployeeByDeptNo")]
        public async Task<IActionResult> EmployeeByDeptNo(int DeptNo)
        {
            try
            {
                var EmpList = await IEmpRef.GetEmployeeByDeptNo(DeptNo);
                if (EmpList.Count > 0)
                {
                    return Ok(EmpList);
                }
                else
                {
                    return NotFound("Record is Not Available in the Database.....!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somethig went Wrong ..!\n" + "Issue : " + ex.Message + ".\nwe will solve this issue soon ...1");
            }
        }

        [HttpGet]
        [Route("EmployeeByEmailAndPassword")]
        public async Task<IActionResult> EmployeeByEmailAndPassword(string Email,string Password)
        {
            try
            {
                var Emp = await IEmpRef.GetEmployeeByEmailAndPassword(Email,Password);
                if (Emp != null)
                {
                    return Ok(Emp);
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

        [HttpPut]
        [Route("updateEmployee")]
        public async Task<IActionResult> updateEmployee(Employee Emp)
        {
            try
            {
                var count = await IEmpRef.updateEmployee(Emp);
                if (count > 0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Record is Not Inserted.....!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somethig went Wrong ..!\n" + "Issue : " + ex.Message + ".\nwe will solve this issue soon ...1");
            }
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int EmpId)
        {
            try
            {
                var count = await IEmpRef.DeleteEmployee(EmpId);
                if (count > 0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Record is Not Inserted.....!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somethig went Wrong ..!\n" + "Issue : " + ex.Message + ".\nwe will solve this issue soon ...1");
            }
        }

        [HttpDelete]
        [Route("DeleteAllEmployee")]
        public async Task<IActionResult> DeleteAllEmployee()
        {
            try
            {
                var count = await IEmpRef.DeleteAllEmployee();
                if (count > 0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Records are Not Inserted.....!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somethig went Wrong ..!\n" + "Issue : " + ex.Message + ".\nwe will solve this issue soon ...1");
            }
        }
    }
}
