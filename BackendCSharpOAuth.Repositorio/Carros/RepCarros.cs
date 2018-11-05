using BackendCSharpOAuth.Dominio;
using BackendCSharpOAuth.Repositorio.Base;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Repositorio
{
    public class RepCarros : RepositorioBase<Carros>, IRepCarros
    {
      
        public Carros Salvar(Carros carros)
        {
            var registro = Entidade.FirstOrDefault(x => x.Id == carros.Id);

            //using (var transaction = Entidade.BeginTransaction())
           // {
                if (registro == null)
                {
                    try
                    {
                        registro = Entidade.Add(carros);                        
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.InnerException.InnerException.Message);
                    }
                
                }
                else
                {
                    registro.Descricao = carros.Descricao;
                }
                
              //  transaction.Commit();
           // }

            return registro;
        }

       
    }
}
