using DEP.Repository.Interfaces;
using DEP.Repository.Models;
using DEP.Service.Interfaces;
using DEP.Service.ViewModels;

namespace DEP.Service.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository repo;
        private readonly ICourseRepository courseRepo;
        public ModuleService(IModuleRepository repo, ICourseRepository courseRepo) {  this.repo = repo; this.courseRepo = courseRepo; }

        public async Task<bool> AddModule(Module module)
        {
            return await repo.AddModule(module);
        }

        public async Task<Module> DeleteModule(int id)
        {
            return await repo.DeleteModule(id);
        }

        public async Task<List<Module>> GetModules()
        {
            return await repo.GetModules();
        }

        public async Task<List<ModuleWithCourseViewModel>> GetModulesWithCourse()
        {
            var re = await repo.GetModules();
            var modules = new List<ModuleWithCourseViewModel>();

            foreach (var module in re)
            {
                var courses = await courseRepo.GetCourseWithPerson(module.ModuleId);

                var excelModules = new ModuleWithCourseViewModel
                {
                    ModuleId = module.ModuleId,
                    Name = module.Name,
                    Description = module.Description,
                    Courses = courses,
                };
                modules.Add(excelModules);
            }

            return modules;
        }

        public async Task<Module> UpdateModule(Module module)
        {
            return await repo.UpdateModule(module);
        }
    }
}
