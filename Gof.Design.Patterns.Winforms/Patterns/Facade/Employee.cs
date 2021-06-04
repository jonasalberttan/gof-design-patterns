
using Gof.Design.Patterns.Winforms.Entities;
using System.Collections.Generic;
using System.Security.Permissions;

namespace Gof.Design.Patterns.Winforms.Patterns.Facade
{
    /// <summary>
    /// Facade implementation for employee entries.
    /// </summary>
    public class Employee
    {
        private static List<Entities.Employee> _list = new List<Entities.Employee>();
        public Employee()
        {
            this.SeedEmployee();
        }

        public List<Entities.Employee> List
        {
            get { return _list; }
            set { _list = value; }
        }

        public void Add(Entities.Employee employee)
        {
            _list.Add(employee);
        }
        public void Update(int index, Entities.Employee employee)
        {
            _list[index] = employee;
        }
        public void Remove(int index)
        {
            _list.RemoveAt(index);
        }
        private void SeedEmployee()
        {
            _list.Add(new Entities.Employee()
            {
                Name= "Ferguson, Geneva Buchanan", 
                LastName= "Ferguson",
                FirstName= "Geneva",
                MiddleName= "Buchanan"
            });
            _list.Add(new Entities.Employee()
            {
                Name = "Gregory, Gross Anne",
                LastName = "Gregory",
                FirstName = "Gross",
                MiddleName = "Anne"
            });
            _list.Add(new Entities.Employee()
            {
                Name = "Sanders, Jacquelyn Bridgette",
                LastName = "Sanders",
                FirstName = "Jacquelyn",
                MiddleName = "Bridgette"
            });
            _list.Add(new Entities.Employee()
            {
                Name = "Ellison, Tonia Berger",
                LastName = "Ellison",
                FirstName = "Tonia",
                MiddleName = "Berger"
            });
            _list.Add(new Entities.Employee()
            {
                Name = "Pierce, Torres Tamera",
                LastName = "Pierce",
                FirstName = "Torres",
                MiddleName = "Tamera"
            });
        }

        
    }
}
