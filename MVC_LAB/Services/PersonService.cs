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
        public void CreatePerson(int id,string name, string city, GenderEnum gender)
        {
            _context.Persons.Add(new PersonModel()
            {
                ID = id,
                Name = name,
                City = city,
                Gender = gender
            });
            _context.SaveChanges();
        }
    }
}

