
using System.Collections.Generic;

namespace Gof.Design.Patterns.Winforms.Patterns.Facade
{
    public class Address
    {
        public Address()
        {

        }
        
        public void SaveAddresses(Entities.Employee employee, List<Entities.Address> addresses)
        {
            employee.Addresses.Clear();
            employee.Addresses = addresses;
        }
    }
}
