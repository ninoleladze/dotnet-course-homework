using _08._24._26_DI1.Models;
using Microsoft.AspNetCore.Mvc;

namespace _08._24._26_DI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        List<Person> People = new List<Person>
        {
            new Person() { FullName = "Alice Johnson", Age = 25 },
            new Person() { FullName = "Bob Smith", Age = 40 },
            new Person() { FullName = "Charlie Brown", Age = 30 }
        };

        [HttpGet]
        public List<Person> GetAllPeople()
        {
            return People;
        }

        [HttpGet("byIndex/{index}")]
        public Person GetPersonByIndex(int index)
        {
            return People[index];
        }

        [HttpGet("byAge/{age}")]
        public List<Person> GetPeopleByAge(int age)
        {
            return People.Where(p => p.Age == age).ToList();
        }

        [HttpGet("oldest")]
        public Person GetOldestPerson()
        {
            return People.OrderByDescending(p => p.Age).First();
        }

        [HttpGet("count")]
        public int GetPersonCount()
        {
            return People.Count;
        }
    }
}
