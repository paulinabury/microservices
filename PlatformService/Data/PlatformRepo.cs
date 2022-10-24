using PlatformService.Models;

namespace PlatformService.Data 
{
    public class PlatformRepo : IPlatformRepo
    {
        //Dependency Injection of db context
        private readonly AppDbContext _context;

        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            //if something was saved it will return true
            return(_context.SaveChanges() >= 0);
        }

        public IEnumerable<Platform> GetAllPlarforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            var platform = _context.Platforms.FirstOrDefault(p => p.Id == id);
            if(platform is null) 
            {
                throw new NullReferenceException($"Platform with id={id} Not Found.");
            }

            return platform;
        }

        public void CreatePlatform(Platform platform)
        {
            if(platform == null)
            {
                throw new ArgumentNullException("Cannot create platform. ", nameof(platform));
            }
            _context.Platforms.Add(platform);
        }
    }
}