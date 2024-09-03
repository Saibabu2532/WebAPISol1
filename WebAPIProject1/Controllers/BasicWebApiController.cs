using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;

namespace WebAPIProject1.Controllers
{
   // http://Hostpath/api/BasicWebApi
    [Route("api/[controller]")]  // http://localhost:14571/api/BasicWebApi
    [ApiController]
    public class BasicWebApiController : ControllerBase
    {
        public int a = 10;
        public string name = "Virat";
        public int[] NVals = { 1, 2, 3, 4 ,5, 6, 7, 8, 9, 10 };
        public ArrayList names = new ArrayList() { "Raju", "Kum,ar", "Prakash", "Mohan", "Gopi" };

        // [HttpGet]
        [HttpPost]
        [Route("Show")]
        public IActionResult Show() //http://localhost:14571/api/BasicWebApi/Show
        {
            try
            {
                // We can write any logic 
                return Ok("Method Excuted Successfully ....!");
            }
            catch (Exception ex)
            {
                return BadRequest("Somethig went Wrong ..!\n" + "Issue : " + ex.Message + ".\nwe will solve this issue soon ...1");
            }

        }

        [HttpGet]
        [Route("Test")]
        public IActionResult Test()
        {
            try
            {
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest("Somethig went Wrong ..!\n" + "Issue : " + ex.Message + ".\nwe will solve this issue soon ...1");
            }

        }

        [HttpGet]
        [Route("Addition")]
        public IActionResult Addition(int x, int y)
        {
            try
            {
                return Ok(x + y);
            }
            catch (Exception ex)
            {
                return BadRequest("Somethig went Wrong ..!\n" + "Issue : " + ex.Message + ".\nwe will solve this issue soon ...1");
            }
        }

        [HttpGet]
        [Route("Test2")]
        public IActionResult Test2()
        {
            try
            {
                return Ok(name);
            }
            catch (Exception ex)
            {
                return BadRequest("Somethig went Wrong ..!\n" + "Issue : " + ex.Message + ".\nwe will solve this issue soon ...1");
            }
        }

        [HttpGet]
        [Route("Test3")]
        public IActionResult Test3()
        {
            try
            {
                return Ok(NVals);
            }
            catch (Exception ex)
            {
                return BadRequest("Somethig went Wrong ..!\n" + "Issue : " + ex.Message + ".\nwe will solve this issue soon ...1");
            }
        }

        [HttpGet]
        [Route("Names")]
        public IActionResult Names()
        {
            try
            {
                return Ok(names);
            }
            catch (Exception ex)
            {
                return BadRequest("Somethig went Wrong ..!\n" + "Issue : " + ex.Message + ".\nwe will solve this issue soon ...1");
            }
        }

            [HttpGet]
        [Route("Operations")]
        public IActionResult Operations(int x, int y,int opt)
        {
            try
            {
                int res = 0;
                switch (opt)
                {
                    case 1: { res = x + y; break; }
                    case 2: { res = x - y; break; }
                    case 3: { res = x * y; break; }
                    case 4: { res = x % y; break; }
                    case 5: { res = x / y; break; }
                    default: { res = 0; break; }
                }
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest ("Somethig went Wrong ..!\n" + "Issue : " + ex.Message + ".\nwe will solve this issue soon ...1");
            }
             
        }

        [HttpGet]
        [Route("FindEvenOrOdd")]
        public IActionResult FindEvenOrOdd(int n)
        {
            try
            {
                if (n % 2 == 0)
                {
                    return Ok("Even");
                }
                else
                {
                    return Ok("Odd");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somethig went Wrong ..!\n" + "Issue : " + ex.Message + ".\nwe will solve this issue soon ...1");
            }
        }

        [HttpGet]
        [Route("FindPrime")]
        public IActionResult FindPrime(int n)
        {
            try
            {
                int i = 1, count = 0;
                while (i <= n)
                {
                    if (n % i == 0)
                    { count++; }
                    i++;
                }
                if (count == 2)
                {
                    return Ok("Prime");
                }
                else
                {
                    return Ok("Not Prime");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somethig went Wrong ..!\n" + "Issue : " + ex.Message + ".\nwe will solve this issue soon ...1");
            }
        }
    }
}
