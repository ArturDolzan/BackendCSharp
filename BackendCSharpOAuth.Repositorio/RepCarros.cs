using BackendCSharpOAuth.Dominio;
using BackendCSharpOAuth.Infra;
using BackendCSharpOAuth.Infra.DTOs;
using BackendCSharpOAuth.Repositorio.Base;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Repositorio
{
    public class RepCarros : RepositorioBase, IRepCarros
    {
        public List<Carros> Listar(QueryPaginacaoDTO dto)
        {
            return entidades.Carros.OrderBy(x => x.Id).Skip((dto.Page - 1) * dto.Limit).Take(dto.Limit).ToList();
        }

        public Carros Salvar(Carros carros)
        {
            var registro = entidades.Carros.FirstOrDefault(x => x.Id == carros.Id);
            
            if (registro == null)
            {
                try
                {
                    entidades.Carros.Add(carros);
                    entidades.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.InnerException.InnerException.Message);
                }

                return carros;
            }

            registro.Descricao = carros.Descricao;
            registro.Ativo = carros.Ativo;

            try
            {
                entidades.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.InnerException.Message);
            }

            return registro;
        }
    }
}
