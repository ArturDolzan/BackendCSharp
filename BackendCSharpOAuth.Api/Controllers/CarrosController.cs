using BackendCSharpOAuth.Dominio;
using BackendCSharpOAuth.Api.Controllers.Base;
using BackendCSharpOAuth.Infra.DTOs;
using System.Net.Http;
using BackendCSharpOAuth.IoC;
using BackendCSharpOAuth.IoC.App_Start;

namespace BackendCSharpOAuth.Api.Controllers
{
    public class CarrosController : ControllerBase<Carros>
    {
        public CarrosController(IServCarros servCarros):base(servCarros)
        {
        }
    }
}