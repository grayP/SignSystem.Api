using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using nightowlsign.data;
using nightowlsign.data.Models.Schedule;
using nightowlsign.data.Models.ScheduleImage;
using SignSystem.DTO.Models.Schedule;
using SignSystem.DTO.Models.Store;

namespace SignSystemApi.Controllers
{
    [RoutePrefix("api/schedule")]
    public class ScheduleController : ApiController
    {
        private IScheduleManager _scheduleManager;
        private ScheduleDto scheduleDto;

        public ScheduleController(IScheduleManager scheduleManager)
        {
            _scheduleManager = scheduleManager;
        }
        [HttpGet]
        [Route("getschedules")]
        public IHttpActionResult Get()
        {
            try
            {
                var schedules =_scheduleManager.Get(null);

                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Schedule/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Schedule
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Schedule/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Schedule/5
        public void Delete(int id)
        {
        }
    }
}
