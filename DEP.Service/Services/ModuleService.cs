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

        public async Task<Module> AddModule(Module module)
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

        public async Task<List<ModuleExcelViewModel>> GetModulesExcel()
        {
            var re = await repo.GetModules();
            var modules = new List<ModuleExcelViewModel>();

            foreach (var module in re)
            {
                var courses = await courseRepo.GetCourseExcel(module.ModuleId);

                var excelModules = new ModuleExcelViewModel
                {
                    ModuleId = module.ModuleId,
                    Name = module.Name,
                    Description = module.Description,
                    Courses = courses,
                };
            }

            return modules;
        }

        public async Task<Module> UpdateModule(Module module)
        {
            return await repo.UpdateModule(module);
        }
    }
}
