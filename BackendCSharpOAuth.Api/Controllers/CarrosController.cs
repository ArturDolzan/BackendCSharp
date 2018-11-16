using BackendCSharpOAuth.Dominio;
using BackendCSharpOAuth.Api.Controllers.Base;

namespace BackendCSharpOAuth.Api.Controllers
{
    public class CarrosController : ControllerBase<Carros>
    {
        public CarrosController(IServCarros servCarros):base(servCarros)
        {
        }
    }
}