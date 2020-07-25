using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class PeopleController : ApiController
    {
        public static List<Person> people = new List<Person>();

        public PeopleController() 
        {
            if (people.Count == 0) 
            {                
                people.Add(new Person() { FirstName = "Subhajit", Id = 1, LastName = "Banerjee" });
                people.Add(new Person() { FirstName = "Devtapa", Id = 2, LastName = "Nag" });
                people.Add(new Person() { FirstName = "Poltu", Id = 3, LastName = "Bhodu" });
            }
        }

        [Route("api/People/GetPersonFirstNames/{id:int}")]
        [HttpGet]
        public List<string> GetPersonFirstNames(int id) 
        {
            var output = new List<string>();

            foreach (var person in people)
            {
                output.Add(person.FirstName);
            }

            return output;
        }

        // GET: api/People
        public List<Person> Get()
        {
            return people;
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            return people.Where(m => m.Id == id).FirstOrDefault() ;
        }

        // POST: api/People
        public bool Post(Person value)
        {
            try
            {
                people.Add(value);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        // PUT: api/People/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
        }
    }
}
