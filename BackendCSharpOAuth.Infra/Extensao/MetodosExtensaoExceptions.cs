using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Infra.Extensao
{
    public static class MetodosExtensaoExceptions
    {
        public static string TratarErro(this System.Exception valor)
        {
            string ret = string.Empty;

            if (valor.InnerException != null)
            {
                ret = valor.InnerException.Message;
            }
            else
            {
                ret = valor.Message;
            }

            return ret;
        }
    }
}
