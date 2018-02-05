using Microsoft.EntityFrameworkCore;

namespace DemoEFCore.BaseRepository
{
    public class DemoEFCoreContext : DbContext
    {
        public DemoEFCoreContext(DbContextOptions<DemoEFCoreContext> options)
              : base(options)
        { }
    }
}
