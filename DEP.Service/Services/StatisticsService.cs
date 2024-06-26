using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using DEP.Service.Interfaces;
using DEP.Service.ViewModels.Statistic;

namespace DEP.Service.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IPersonRepository personRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly ILocationRepository locationRepository;
        private readonly IPersonCourseRepository personCourseRepository;

        public StatisticsService(IPersonRepository personRepository, IDepartmentRepository departmentRepository, ILocationRepository locationRepository, IPersonCourseRepository personCourseRepository)
        {
            this.personRepository = personRepository;
            this.departmentRepository = departmentRepository;
            this.locationRepository = locationRepository;
            this.personCourseRepository = personCourseRepository;
        }

        public async Task<List<PersonPerDepartmentViewModel>> GetPersonsPerDepartmentByModule(int moduleId)
        {
            var departments = await departmentRepository.GetDepartments();
            var persons = await personRepository.GetPersonsByModuleId(moduleId);

            // Group persons by DepartmentId and count them
            var personCounts = persons
            .GroupBy(p => p.DepartmentId)
            .Select(g => new
            {
                DepartmentId = g.Key,
                Count = g.Distinct().Count()
            })
            .ToList();

            // Create and populate the view model
            var result = departments
                .Select(d => new PersonPerDepartmentViewModel
                {
                    DepartmentId = d.DepartmentId,
                    DepartmentName = d.Name,
                    TeacherCount = personCounts.FirstOrDefault(pc => pc.DepartmentId == d.DepartmentId)?.Count ?? 0
                })
                .ToList();

            // Handle persons with no department
            var noDepartmentCount = personCounts.FirstOrDefault(pc => pc.DepartmentId == null)?.Count ?? 0;
            if (noDepartmentCount > 0)
            {
                result.Add(new PersonPerDepartmentViewModel
                {
                    DepartmentId = 0,  // Use 0 or any other value to indicate no department
                    DepartmentName = "Uden afdeling",
                    TeacherCount = noDepartmentCount
                });
            }

            return result;
        }

        public async Task<List<PersonPerDepartmentViewModel>> GetPersonsPerDepartment()
        {
            var departments = await departmentRepository.GetDepartments();
            var persons = await personRepository.GetPersons();

            // Group persons by DepartmentId and count them
            var personCounts = persons
            .GroupBy(p => p.DepartmentId)
            .Select(g => new
            {
                DepartmentId = g.Key,
                Count = g.Distinct().Count()
            })
            .ToList();

            // Create and populate the view model
            var result = departments
                .Select(d => new PersonPerDepartmentViewModel
                {
                    DepartmentId = d.DepartmentId,
                    DepartmentName = d.Name,
                    TeacherCount = personCounts.FirstOrDefault(pc => pc.DepartmentId == d.DepartmentId)?.Count ?? 0
                })
                .ToList();

            // Handle persons with no department
            var noDepartmentCount = personCounts.FirstOrDefault(pc => pc.DepartmentId == null)?.Count ?? 0;
            if (noDepartmentCount > 0)
            {
                result.Add(new PersonPerDepartmentViewModel
                {
                    DepartmentId = 0,  // Use 0 or any other value to indicate no department
                    DepartmentName = "Uden afdeling",
                    TeacherCount = noDepartmentCount
                });
            }

            return result;
        }

        public async Task<List<PersonPerLocationViewModel>> GetPersonsPerLocation()
        {
            var locations = await locationRepository.GetLocations();
            var persons = await personRepository.GetPersons();

            // Group persons by LocationId and count them
            var personCounts = persons
            .GroupBy(p => p.LocationId)
            .Select(g => new
            {
                LocationId = g.Key,
                Count = g.Distinct().Count()
            })
            .ToList();

            // Create and populate the view model
            var result = locations
                .Select(l => new PersonPerLocationViewModel
                {
                    LocationId = l.LocationId,
                    LocationName = l.Name,
                    TeacherCount = personCounts.FirstOrDefault(pc => pc.LocationId == l.LocationId)?.Count ?? 0
                })
                .ToList();

            // Handle persons with no location
            var noLocationCount = personCounts.FirstOrDefault(pc => pc.LocationId == null)?.Count ?? 0;
            if (noLocationCount > 0)
            {
                result.Add(new PersonPerLocationViewModel
                {
                    LocationId = 0,  // Use 0 or any other value to indicate no location
                    LocationName = "Uden lokation",
                    TeacherCount = noLocationCount
                });
            }

            return result;
        }

        public async Task<List<CourseStatusCountViewModel>> GetCourseStatusCountByModule(int moduleId)
        {
            var personCourses = await personCourseRepository.GetPersonCoursesByModule(moduleId);

            // Get all possible values of the Status enum
            var allStatuses = Enum.GetValues(typeof(Status)).Cast<Status>();

            // Create a dictionary to hold the count for each status
            var statusCounts = allStatuses.ToDictionary(status => status, status => 0);

            // Populate the dictionary with counts from the personCourses
            foreach (var pc in personCourses)
            {
                if (statusCounts.ContainsKey(pc.Status))
                {
                    statusCounts[pc.Status]++;
                }
            }

            // Create the result list from the statusCounts dictionary
            var result = statusCounts
                .Select(kvp => new CourseStatusCountViewModel
                {
                    StatusId = (int)kvp.Key,
                    CourseStatus = kvp.Key.ToString(),
                    PersonCount = kvp.Value
                }).ToList();

            return result;
        }

        public async Task<PersonPerDepartmentAndLocationViewModel> GetPersonsPerDepartmentAndLocation()
        {
            var departments = await departmentRepository.GetDepartments();
            var locations = await locationRepository.GetLocations();
            var persons = await personRepository.GetPersons();

            // Group persons by DepartmentId and count them
            var personCountsByDepartment = persons
                .GroupBy(p => p.DepartmentId)
                .Select(g => new
                {
                    DepartmentId = g.Key,
                    Count = g.Distinct().Count()
                })
                .ToList();

            // Group persons by LocationId and count them
            var personCountsByLocation = persons
                .GroupBy(p => p.LocationId)
                .Select(g => new
                {
                    LocationId = g.Key,
                    Count = g.Distinct().Count()
                })
                .ToList();

            // Create and populate the department view models
            var departmentResults = departments
                .Select(d => new PersonPerDepartmentViewModel
                {
                    DepartmentId = d.DepartmentId,
                    DepartmentName = d.Name,
                    TeacherCount = personCountsByDepartment.FirstOrDefault(pc => pc.DepartmentId == d.DepartmentId)?.Count ?? 0
                })
                .ToList();

            // Handle persons with no department
            var noDepartmentCount = personCountsByDepartment.FirstOrDefault(pc => pc.DepartmentId == null)?.Count ?? 0;
            if (noDepartmentCount > 0)
            {
                departmentResults.Add(new PersonPerDepartmentViewModel
                {
                    DepartmentId = 0,  // Use 0 or any other value to indicate no department
                    DepartmentName = "Uden afdeling",
                    TeacherCount = noDepartmentCount
                });
            }

            // Create and populate the location view models
            var locationResults = locations
                .Select(l => new PersonPerLocationViewModel
                {
                    LocationId = l.LocationId,
                    LocationName = l.Name,
                    TeacherCount = personCountsByLocation.FirstOrDefault(pc => pc.LocationId == l.LocationId)?.Count ?? 0
                })
                .ToList();

            // Handle persons with no location
            var noLocationCount = personCountsByLocation.FirstOrDefault(pc => pc.LocationId == null)?.Count ?? 0;
            if (noLocationCount > 0)
            {
                locationResults.Add(new PersonPerLocationViewModel
                {
                    LocationId = 0,  // Use 0 or any other value to indicate no location
                    LocationName = "Uden placering",
                    TeacherCount = noLocationCount
                });
            }

            // Combine the results into a single view model
            var result = new PersonPerDepartmentAndLocationViewModel
            {
                Departments = departmentResults,
                Locations = locationResults
            };

            return result;
        }
    }
}
