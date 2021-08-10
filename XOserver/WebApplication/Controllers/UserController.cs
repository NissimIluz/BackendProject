using Contracts;
using Microsoft.AspNetCore.Mvc;
using UserServiceImpl;
using UserServiceDTO;
using DALContract;

namespace WebApplication.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService, IDAL Idal)
        {
            _userService = userService;
            _userService.Idal = Idal;

    }
        public RegisterRespondDTO SignUp([FromBody] RegisterDTO register)
        {
            RegisterRespondDTO retval = new RegisterRespondDTO();
            retval.Response = "Registration successful";
            retval.Success = _userService.RegisterUser(register.ID, register.Name);
            if (!retval.Success)
                if(_userService.UserExistsCheck(register.ID))
                    retval.Response = "User already exists"; 
                else
                    retval.Response = "Unknown error";

            return retval;
        }
        public RegisterRespondDTO Login ([FromBody] RegisterDTO register)
        {
            var retval = new RegisterRespondDTO();
            retval.Success = _userService.Login(register.ID, register.Name);
            if (retval.Success)
                retval.Response = "Welcome " + register.Name;
            else
                retval.Response = "User does not exist or incorrect login details.";
            return retval;
        }
    }
}
