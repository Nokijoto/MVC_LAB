using Microsoft.AspNetCore.Mvc.ActionConstraints;
using MVC_LAB.Context;
using MVC_LAB.Models.Person;
using SQLitePCL;

namespace MVC_LAB.Services
{
    public class PersonService : IPersonService
    {
        private readonly PersonContext _context;
        public PersonService(PersonContext context)
        {
            _context = context;
        }
        public List<PersonModel> GetPersons()
        {
            return _context.Persons.ToList();
        }
        public void CreatePerson(string name, string city, GenderEnum gender)
        {
            var lastID = _context.Persons.OrderByDescending(x => x.ID).FirstOrDefault()?.ID;
            _context.Persons.Add(new PersonModel()
            {
                ID = (int)lastID + 1,
                Name = name,
                City = city,
                Gender = gender
            }); 
            _context.SaveChanges();
        }

        public PersonModel GetPerson(int id)
        {
            var person = _context.Persons.FirstOrDefault(x => x.ID == id);
            return person ?? new PersonModel();
        }
        public void EditPerson(long id, string name, string city, GenderEnum gender)
        {
           
            var person = _context.Persons.FirstOrDefault(x => x.ID == id);
            if (person != null)
            {
                person.Name = name;
                person.City = city;
                person.Gender = gender;
                _context.Persons.Update(person);
                _context.SaveChanges();
            
            }
        }
        
    }
}

