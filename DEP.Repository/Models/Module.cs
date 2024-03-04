namespace DEP.Repository.Models
{
    public class Module
    {
        public int ModuleId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
