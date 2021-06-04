using System.Collections.Generic;

namespace Gof.Design.Patterns.Winforms.Patterns.Facade
{
    public class Contact
    {
        public Contact()
        {            
        }

        public void SaveContacts(Entities.Employee employee, List<Entities.Contact> contacts)
        {
            employee.Contacts.Clear();
            employee.Contacts = contacts;
        }
    }
}
