using Gof.Design.Patterns.Winforms.Entities.Shared;
using System.Collections.Generic;

namespace Gof.Design.Patterns.Winforms.Entities
{
    public class Employee: BaseEntity
    {
        public double TotalHours { get; set; }
        public double TotalDeduction { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public List<Contact> Contacts { get; set; }
        public List<Address> Addresses { get; set; }

    }
}
