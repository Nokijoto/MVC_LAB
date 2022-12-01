using MVC_LAB.Models.Person;

namespace MVC_LAB.Services
{
    public interface IPersonService
    {
        public List<PersonModel> GetPersons();
        public void CreatePerson(int id, string name, string city, GenderEnum gender);
    }
}
