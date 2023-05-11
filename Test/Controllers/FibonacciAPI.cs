using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FibonacciAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FibonacciController : ControllerBase
    {
        [HttpGet("{x}")]
        public ActionResult<long> Get(int x)
        {
            if (x < 1 || x > 100)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "x doit être compris entre 1 et 100.");
            }

            long result = Fibonacci(x);

            return Ok(result);
        }

        private static long Fibonacci(int x)
        {
            if (x == 0)
            {
                return 0;
            }

            if (x == 1)
            {
                return 1;
            }

            long[] fib = new long[x + 1];
            fib[0] = 0;
            fib[1] = 1;

            for (int i = 2; i <= x; i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
            }

            return fib[x];
        }
    }
}
