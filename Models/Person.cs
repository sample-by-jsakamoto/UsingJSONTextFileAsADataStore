using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsingJSONTextFileAsADataStore.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return string.Format("{{Id:{0}, Name:{1}, Age:{2}}}", this.Id, this.Name, this.Age);
        }
    }
}
