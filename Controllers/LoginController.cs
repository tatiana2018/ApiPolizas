using Microsoft.AspNetCore.Mvc;
using Poliza.Models;
using Poliza.Repositories;
using Poliza.Repositories.Interfaces;
using Poliza.Shared;

namespace Poliza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {

        private readonly ILoginRepository _iloginRepository;
        private readonly JwtService _jwtService;

        public LoginController(LoginRepository loginRepository, JwtService jwtService)
        {
            _iloginRepository = loginRepository;
            _jwtService = jwtService;
        }

        // POST: api/Login
        [HttpPost]
        public async Task<IActionResult> Login(UserEntity request)
        {
            // Aquí se obtien el usuario desde el repositorio de usuario
            var user = await _iloginRepository.GetUser(request.Name, request.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            // Verifica que el usuario tenga el rol válido
            if (user.Role != "Administrador")
            {
                return Unauthorized();
            }

            var token = _jwtService.GenerateToken(request.Name, user.Role);


            // Devuelve el token JWT al usuario
            return Ok(new {token});
        }
    }
}
