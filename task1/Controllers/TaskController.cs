using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpGet("hello")]
        public ActionResult GetName(string? Name = null)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                return Ok(new { greeting = $"hello,{Name}" });


            }

            return BadRequest(new { greeting = "hello world" });
        }
        [HttpGet("Info")]
        public ActionResult GetInfo()
        {
            string reqestTime = DateTime.UtcNow.ToString("o");
            string clinetAddress = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "UnKnown";
            string hostName = Environment.MachineName;
            var clientRequestHedar = Request.Headers;
            var specificHeaders = new Dictionary<string, string>();

           

            if (clientRequestHedar.ContainsKey("Accept"))
              {
                    specificHeaders.Add("Accept", clientRequestHedar["Accept"].ToString());
              }
            if (clientRequestHedar.ContainsKey("User-Agent"))
             {

                specificHeaders.Add("user-Agent", clientRequestHedar["user-Agent"].ToString());
             }

            var responce = new
                {
                    time = reqestTime,
                    cilent_address = clinetAddress,
                    host_name = hostName,
                    header = specificHeaders,
                };

            Response.ContentType = "application/json";
            return Ok(responce);

            }

        }
    }

