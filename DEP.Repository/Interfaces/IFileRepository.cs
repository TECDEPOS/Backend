
namespace DEP.Repository.Interfaces
{
    public interface IFileRepository
    {
        Task<Models.File> AddFile(Models.File file);

        Task<Models.File> UpdateFile(Models.File file);

        Task<Models.File> DeleteFile(int id);

        Task<List<Models.File>> GetFiles();

        Task<Models.File> GetFileById(int id);

        Task<List<Models.File>> GetFileByName(string name);
    }
}
