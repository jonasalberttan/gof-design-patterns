
using Gof.Design.Patterns.Winforms.Entities.Shared;

namespace Gof.Design.Patterns.Winforms.Entities
{
    public class Contact: BaseEntity
    {
        public long EmployeeId { get; set; }
        public long ContactTypesId { get; set; }

    }
}
