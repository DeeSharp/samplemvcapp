using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC.Business.Entities
{
    public class Person
    {
        private sealed class IdEqualityComparer : IEqualityComparer<Person>
        {
            public bool Equals(Person x, Person y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id;
            }

            public int GetHashCode(Person obj)
            {
                return obj.Id;
            }
        }

        private static readonly IEqualityComparer<Person> IdComparerInstance = new IdEqualityComparer();

        public static IEqualityComparer<Person> IdComparer
        {
            get { return IdComparerInstance; }
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
