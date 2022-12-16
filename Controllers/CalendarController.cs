using ExamRoman.Services;
using ExamRoman.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamRoman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        public CalendarService _service;
        public CalendarController(CalendarService service)
        {
            _service = service;
        }

        [HttpPost("add-calendar")]
        public IActionResult AddCalendar([FromBody]CalendarVM calendar)
        {
            var tmp = _service.Add(calendar);
            if(tmp)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var tmp = _service.GetAll();
            if (tmp != null)
            {
                return Ok(tmp);
            }
            return BadRequest();
        }

        [HttpGet("get-calendar-by-id/{id}")]
        public IActionResult GetCalendarById(int id)
        {
            var tmp = _service.GetById(id);
            if (tmp != null)
            {
                return Ok(tmp);
            }
            return BadRequest();
        }

        [HttpGet("get-calendar-by-word/{word}")]
        public IActionResult GetCalendarByWord(string word)
        {
            var tmp = _service.GetByWord(word);
            if (tmp != null)
            {
                return Ok(tmp);
            }
            return BadRequest();
        }

        [HttpPut("update-calendar/{id}")] 
        public IActionResult UpdateCalendar(int id, [FromBody]CalendarVM item)
        {
            var tmp = _service.UpdateById(id, item);
            if(tmp)
            {
                return Ok(tmp);
            }
            return BadRequest();
        }

        [HttpDelete("delete-calendar/{id}")]
        public IActionResult DeleteCalendar(int id)
        {
            var tmp = _service.DeleteById(id);
            if(tmp)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
