using Microsoft.AspNetCore.Mvc;
using STAPI.Services;
using STAPI.DTOs;
using System.Threading.Tasks;

namespace STAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// ユーザー名でログインし、IDを返す。
        /// </summary>
        /// <param name="userDto">ユーザー名を含むDTO</param>
        /// <returns>ユーザーID</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            var userId = await _userService.LoginAsync(userDto.Name);
            if (userId == null)
                return BadRequest("Invalid username");

            return Ok(new { Id = userId });
        }

        //ユーザーデータ取得
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

    }
}