using Gof.Design.Patterns.Winforms.Entities;
using System.Collections.Generic;

namespace Gof.Design.Patterns.Winforms.Patterns.Facade
{
    public class EmployeeFacade
    {
        private static Facade.Employee _employee=null;
        private static Facade.Contact _contact=null;
        private static Facade.Address _address=null;

        public EmployeeFacade()
        {
            _employee = _employee==null ? new Facade.Employee(): _employee;
            _contact = _contact==null ? new Facade.Contact(): _contact;
            _address = _address==null ? new Facade.Address(): _address;
        }

        public void SaveEmployee(Entities.Employee employee)
        {
            _employee.Add(employee);
        }
        public void SaveEmployee(Entities.Employee employee, int index)
        {
            _employee.Update(index, employee);
        }
        public void RemoveEmployee(int index)
        {
            _employee.Remove(index);
        }
        public List<Entities.Employee> EmployeeList
        {
            get { return _employee.List; }
        }

        public Entities.Employee GetEmployee(int index)
        {
            return _employee.List[index];
        }

        public void SaveContacts(Entities.Employee employee, List<Entities.Contact> contacts)
        {
            _contact.SaveContacts(employee, contacts);
        }
        public void SaveAddresses(Entities.Employee employee, List<Entities.Address> addresses)
        {
            _address.SaveAddresses(employee, addresses);
        }

    }
}
