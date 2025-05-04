using Microsoft.EntityFrameworkCore;

namespace VTSAPI.Model
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options) 
        {
                
        }
        public DbSet<UserMaster> Users { get; set; }
        public DbSet<UserVehicleDetails> vehicleDetails { get; set; }
    }
}
