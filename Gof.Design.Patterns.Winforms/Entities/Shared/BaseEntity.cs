namespace Gof.Design.Patterns.Winforms.Entities.Shared
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public string UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public string DeletedAt { get; set; }
    }
}
