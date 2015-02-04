using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.Business.Entities;
using TC.Business.Repository.Abstract;

namespace TC.Business.Repository.Concrete
{
    public class PersonRepository : IPersonRepository
    {
       private static HashSet<Person> personList = new HashSet<Person>(Person.IdComparer)
        {
            new Person()
            {
                Age = 10,
                FirstName = "John",
                LastName = "Smith",
                Id = 1
            },
            new Person()
            {
                Age = 11,
                FirstName = "Jack",
                LastName = "Renshaw",
                Id = 2
            }
        };

        public IEnumerable<Entities.Person> Get()
        {
            return personList;
        }

        public void Update(Entities.Person person)
        {
            if (personList.Contains(person))
            {
                personList.Remove(person);
            }
            personList.Add(person);
        }

        public void Delete(int personId)
        {
            personList.RemoveWhere(x => x.Id == personId);
        }

        public void Add(Entities.Person person)
        {
            int? newId = null;
            if (personList.Count > 0)
            {
                newId = personList.Max(x => x.Id) + 1;
            }
            person.Id = newId.GetValueOrDefault(1);
            personList.Add(person);
        }

        public Person GetById(int id)
        {
            return personList.First(x => x.Id == id);
        }
    }
}
