using PlatformService.Models;

namespace PlatformService.Data 
{
    public interface IPlatformRepo 
    {
        bool SaveChanges();

        //geting all the platforms
        IEnumerable<Platform> GetAllPlarforms();

        //return one platform by id
        Platform GetPlatformById(int id);

        //create a platform
        void CreatePlatform(Platform platform);
    }
}