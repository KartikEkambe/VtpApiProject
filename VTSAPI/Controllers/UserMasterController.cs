using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VTSAPI.Model;

namespace VTSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMasterController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public UserMasterController(ApplicationDBContext context)
        {
            _dbContext = context;
        }
        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers() 
            {
            return Ok(_dbContext.Users.ToList());
            }


        [HttpGet]
        [Route("GetUsersById/{id}")]
        public IActionResult GetUsersById(int id)
        {
            var lst = _dbContext.Users.Find(id);
            if (lst == null)
            {
                return NotFound();
            }
            return Ok(lst);
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(UserMaster user)
        {
            if (user != null)
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateUser/{id}")]
        public IActionResult Updateusers(int id, UserMaster user)
        {
            var usr = _dbContext.Users.Find(id);
            if (usr is null) { return NotFound(); }
            usr.Name = user.Name;
            usr.MobileNumber = user.MobileNumber;
            usr.Address = user.Address;
            usr.PhotoPath = user.PhotoPath;
            usr.Organization = user.Organization;
            usr.EmailAddress = user.EmailAddress;
            usr.Location = user.Location;
            _dbContext.SaveChanges();
            return Ok(usr);
        }
        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var usr = _dbContext.Users.Find(id);
            if (usr is null) { return NotFound(); }
            _dbContext.Users.Remove(usr);
            _dbContext.SaveChanges();
            return Ok();
        }


        //Methods for User Vehicle Details
        [HttpGet]
        [Route("GetAllUserVehicles")]
        public IActionResult GetAllUserVehicles()
        {
            var user = (from umvd in _dbContext.vehicleDetails
                        from um in _dbContext.Users
                        where umvd.UserID == um.UserID
                        select new UserVehicleDetails
                        {
                           VehicleID = umvd.VehicleID,
                            VehicleNumber = umvd.VehicleNumber,
                            VehicleType = umvd.VehicleType,
                            UserID = umvd.UserID,
                            ChassisNumber = umvd.ChassisNumber,
                            EngineNumber = umvd.EngineNumber,
                            ManufacturingYear = umvd.ManufacturingYear,
                            LoadCarryingCapacity = umvd.LoadCarryingCapacity,
                            MakeOfVehicle = umvd.MakeOfVehicle,
                            ModelNumber = umvd.ModelNumber,
                            BodyType = umvd.BodyType,
                            OrganizationName = umvd.OrganizationName,
                            DeviceID = umvd.DeviceID,
                            UserName = um.Name
                        }).ToList();

            return Ok(user);
        }


        [HttpGet]
        [Route("GetUserVehiclesById/{id}")]
        public IActionResult GetUserVehiclesById(int id)
        {
            var lst = (from umvd in _dbContext.vehicleDetails
                        from um in _dbContext.Users
                        where umvd.UserID == um.UserID
                        && umvd.VehicleID == id
                       select new UserVehicleDetails
                        {
                            VehicleID = umvd.VehicleID,
                            VehicleNumber = umvd.VehicleNumber,
                            VehicleType = umvd.VehicleType,
                            UserID = umvd.UserID,
                            ChassisNumber = umvd.ChassisNumber,
                            EngineNumber = umvd.EngineNumber,
                            ManufacturingYear = umvd.ManufacturingYear,
                            LoadCarryingCapacity = umvd.LoadCarryingCapacity,
                            MakeOfVehicle = umvd.MakeOfVehicle,
                            ModelNumber = umvd.ModelNumber,
                            BodyType = umvd.BodyType,
                            OrganizationName = umvd.OrganizationName,
                            DeviceID = umvd.DeviceID,
                            UserName = um.Name
                        }).FirstOrDefault();
            if (lst == null)
            {
                return NotFound();
            }
            return Ok(lst);
        }

        [HttpPost]
        [Route("AddUserVehicle")]
        public IActionResult AddUserVehicle(UserVehicleDetails vehicleDetails)
        {
            if (vehicleDetails != null)
            {
                _dbContext.vehicleDetails.Add(vehicleDetails);
                _dbContext.SaveChanges();
                return Ok(vehicleDetails);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [Route("UpdateUserVehicles/{id}")]
        public IActionResult UpdateUserVehicles(int id, UserVehicleDetails userVehicle)
        {
            var vehicle = _dbContext.vehicleDetails.Find(id);
            if (vehicle is null) { return NotFound(); }
            vehicle.VehicleNumber = userVehicle.VehicleNumber;
            vehicle.VehicleType = userVehicle.VehicleType;
            vehicle.ChassisNumber = userVehicle.ChassisNumber;
            vehicle.EngineNumber = userVehicle.EngineNumber;
            vehicle.ManufacturingYear = userVehicle.ManufacturingYear;
            vehicle.LoadCarryingCapacity = userVehicle.LoadCarryingCapacity;
            vehicle.MakeOfVehicle = userVehicle.MakeOfVehicle;
            vehicle.ModelNumber = userVehicle.ModelNumber;
            vehicle.BodyType = userVehicle.BodyType;
            vehicle.OrganizationName = userVehicle.OrganizationName;
            vehicle.DeviceID = userVehicle.DeviceID;
            vehicle.UserID = userVehicle.UserID;

            _dbContext.SaveChanges();
            return Ok(vehicle);
        }


        [HttpDelete]
        [Route("DeleteUserVehicle/{id}")]
        public IActionResult DeleteUserVehicle(int id)
        {
            var vehicle = _dbContext.vehicleDetails.Find(id);
            if (vehicle is null) { return NotFound(); }
            _dbContext.vehicleDetails.Remove(vehicle);
            _dbContext.SaveChanges();
            return Ok();
        }

    }
}
