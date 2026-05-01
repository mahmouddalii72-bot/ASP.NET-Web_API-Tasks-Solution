using Day01_Task.Data.DbContexts;
using Day01_Task.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day01_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        

        private readonly CourseDbContext context;

        public CourseController(CourseDbContext context)
        {
            this.context = context;
        }


       // GetAll
        [HttpGet]
        public IActionResult GetAll()
        {
            var courses = context.Courses.ToList();

            if (courses.Count == 0)
                return NotFound();

            return Ok(courses);
        }

        // ById
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var course = context.Courses.FirstOrDefault(c => c.Id == id);

            if (course != null)
                return Ok(course);

            return NotFound();
        }

        //  CourseByName(name)
        [HttpGet("{name:alpha}")]
        public IActionResult CourseByName(string name)
        {
            var course = context.Courses
                .FirstOrDefault(c => c.Crs_name == name);

            if (course != null)
                return Ok(course);

            return NotFound();
        }

        // post(course)
        [HttpPost]
        public IActionResult Post(Course course)
        {
            if (course == null)
                return BadRequest();

            context.Courses.Add(course);
            context.SaveChanges();

            return StatusCode(201);
        }

        //  put(id, course)
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Course newCourse)
        {
            if (id != newCourse.Id)
                return BadRequest();

            var oldCourse = context.Courses
                .FirstOrDefault(c => c.Id == id);

            if (oldCourse == null)
                return NotFound();

            oldCourse.Crs_name = newCourse.Crs_name;
            oldCourse.Crs_desc = newCourse.Crs_desc;
            oldCourse.Duration = newCourse.Duration;

            context.SaveChanges();

            return NoContent();
        }

        // ✅ deleteCourse(id)
        [HttpDelete("{id:int}")]
        public IActionResult DeleteCourse(int id)
        {
            var course = context.Courses
                .FirstOrDefault(c => c.Id == id);

            if (course == null)
                return NotFound();

            context.Courses.Remove(course);
            context.SaveChanges();

            return Ok(context.Courses.ToList());
        }
    }
}
