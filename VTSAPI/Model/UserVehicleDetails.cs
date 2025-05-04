using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VTSAPI.Model
{
    [Table("UserVehicleDetails")]
    public class UserVehicleDetails
    {
        [Key]
        public int VehicleID { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public string ChassisNumber { get; set; }
        public string EngineNumber { get; set; }
        public int ManufacturingYear { get; set; }
        public double LoadCarryingCapacity { get; set; }
        public string MakeOfVehicle { get; set; }
        public string ModelNumber { get; set; }
        public string BodyType { get; set; }
        public string OrganizationName { get; set; }
        public int DeviceID { get; set; }
        [ForeignKey("UserMaster")]
        public int UserID { get; set; } // Foreign Key
        [NotMapped]
        public virtual string? UserName { get; set; }

    }
}
