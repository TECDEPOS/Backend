namespace DEP.Repository.Models
{
    public class FileTagUserRole
    {
        // Foreign key to FileTag
        public int FileTagId { get; set; }
        public FileTag FileTag { get; set; }

        // The allowed user role (stored as an int in the database)
        public UserRole Role { get; set; }
    }
}
