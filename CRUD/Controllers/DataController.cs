using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using WebApplication1.Models.Request;
using WebApplication1.Models.Response;
using WebApplication1.Service.Interface;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IDataService _dataService;
        public DataController(IDataService dataservice)
        {
            _dataService = dataservice;
        }

        /// <summary>
        /// Get Contact details
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dataService.Get());
        }

        /// <summary>
        /// Get indivisual contact detail
        /// </summary>
        /// <param name="ContactId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{ContactId}")]
        public async Task<IActionResult> Get(int ContactId)
        {
            if(ContactId <= 0) 
            {
                return BadRequest("Contact Id can not be 0 or less");
            }
            return Ok(await _dataService.Get(ContactId));
        }

        /// <summary>
        /// Add data to DB 
        /// </summary>
        /// <param name="Contact"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateData(Contacts Contact)
        {
            ContactDetails details = _dataService.CreateData(Contact);
            if (details.Equals != null)
            {
                return Created("Added data Successfully!", details);
            }
            return NoContent();
        }

        /// <summary>
        /// Add data to DB 
        /// </summary>
        /// <param name="ContactId"></param>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(int ContactId)
        {
            int result = _dataService.Delete(ContactId);
            if (result == 1)
            {
                return Ok(string.Format("{0} Contact Id is deleted successfully!", ContactId));
            }
            return new ObjectResult(string.Format("{0} Contact Id is not present!", ContactId));
        }

        /// <summary>
        /// Update data to DB 
        /// </summary>
        /// <param name="ContactId"></param>
        /// <returns></returns>
        //[HttpPut("[action]")]
        //public async Task<IActionResult> Update(ContactUpdate ContactUpdate)
        //{
        //    int result = _dataService.Update(ContactUpdate);
        //    if (result == 1)
        //    {
        //        return Ok(string.Format("{0} Contact Id is updated successfully!", ContactUpdate.ContactId));
        //    }
        //    return new ObjectResult(string.Format("{0} Contact Id is not present!", ContactUpdate.ContactId));
        //}
    }
}
