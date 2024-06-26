using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using DEP.Service.Interfaces;
using DEP.Service.ViewModels.Statistic;

namespace DEP.Service.Services
{
    public class PersonCourseService : IPersonCourseService
    {
        private readonly IPersonCourseRepository repo;

        public PersonCourseService(IPersonCourseRepository repo)
        {
            this.repo = repo;
        }

        public async Task<PersonCourse> AddPersonCourse(PersonCourse personCourse)
        {
            return await repo.AddPersonCourse(personCourse);
        }

        public async Task<bool> DeletePersonCourse(int personId, int courseId)
        {
            return await repo.DeletePersonCourse(personId, courseId);
        }

        public async Task<List<PersonCourse>> GetAllPersonCourses()
        {
            return await repo.GetAllPersonCourses();
        }

        public async Task<List<PersonCourse>> GetPersonCoursesByCourse(int courseId)
        {
            return await repo.GetPersonCoursesByCourse(courseId);
        }

        public async Task<List<PersonCourse>> GetPersonCoursesByPerson(int personId)
        {
            return await repo.GetPersonCoursesByPerson(personId);
        }

        public async Task<PersonCourse> UpdatePersonCourse(PersonCourse personCourse)
        {
            return await repo.UpdatePersonCourse(personCourse);
        }

        //public async Task<List<CourseStatusCountViewModel>> GetCourseStatusCount(int moduleId)
        //{
        //    var personCourses = await repo.GetPersonCoursesByModule(moduleId);

        //    // Get all possible values of the Status enum
        //    var allStatuses = Enum.GetValues(typeof(Status)).Cast<Status>();

        //    // Create a dictionary to hold the count for each status
        //    var statusCounts = allStatuses.ToDictionary(status => status, status => 0);

        //    // Populate the dictionary with counts from the personCourses
        //    foreach (var pc in personCourses)
        //    {
        //        if (statusCounts.ContainsKey(pc.Status))
        //        {
        //            statusCounts[pc.Status]++;
        //        }
        //    }

        //    // Create the result list from the statusCounts dictionary
        //    var result = statusCounts
        //        .Select(kvp => new CourseStatusCountViewModel
        //        {
        //            StatusId = (int)kvp.Key,
        //            CourseStatus = kvp.Key.ToString(),
        //            PersonCount = kvp.Value
        //        }).ToList();

        //    return result;
        //}
    }
}
