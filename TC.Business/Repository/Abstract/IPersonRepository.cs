using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.Business.Entities;

namespace TC.Business.Repository.Abstract
{
    public interface IPersonRepository
    {
        IEnumerable<Person> Get();
        Person GetById(int id);
        void Update(Person person);
        void Delete(int personId);
        void Add(Person person);
    }
}
