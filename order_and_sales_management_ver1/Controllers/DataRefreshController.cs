using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Order_And_Sales_Management_ver1.Hubs;

namespace Order_And_Sales_Management_ver1
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataRefreshController : ControllerBase
    {

        private readonly IHubContext<RefreshSignalHub> _hubContext;

        public DataRefreshController(IHubContext<RefreshSignalHub> hubContext)
        {
            _hubContext = hubContext;
        }


        // GET api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _hubContext.Clients.All.SendAsync("Send", "Merhaba Ben Hakan");
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}