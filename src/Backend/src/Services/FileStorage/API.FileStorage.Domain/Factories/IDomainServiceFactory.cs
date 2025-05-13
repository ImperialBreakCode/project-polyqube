using API.FileStorage.Domain.Services;

namespace API.FileStorage.Domain.Factories
{
    public interface IDomainServiceFactory
    {
        FileService CreateFileService();
    }
}
