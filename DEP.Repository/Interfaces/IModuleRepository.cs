﻿using DEP.Repository.Models;

namespace DEP.Repository.Interfaces
{
    public interface IModuleRepository
    {
        Task<List<Module>> GetModules();
        Task<Module> AddModule(Module module);
        Task<Module> UpdateModule(Module module);
        Task<Module> DeleteModule(int id);
    }
}
