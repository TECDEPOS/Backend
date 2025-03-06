namespace DEP.Repository.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public int CourseNumber { get; set; }
        public int ModuleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CourseType CourseType { get; set; }


        public Module? Module { get; set; }
        public List<PersonCourse> PersonCourses { get; set; } = new List<PersonCourse>();
    }
}
