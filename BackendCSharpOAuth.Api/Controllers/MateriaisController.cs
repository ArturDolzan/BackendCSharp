using BackendCSharpOAuth.Api.Controllers.Base;
using BackendCSharpOAuth.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendCSharpOAuth.Api.Controllers
{
    public class MateriaisController : ControllerBase<Materiais>
    {
        public MateriaisController(IServMateriais servMateriais) : base(servMateriais)
        {
        }
    }
}