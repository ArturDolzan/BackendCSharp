using BackendCSharpOAuth.Dominio.Base;
using BackendCSharpOAuth.Infra.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCSharpOAuth.Dominio
{
    public class ServUsuarios : ServicoBase<Usuarios>, IServUsuarios
    {
        public ServUsuarios(IRepUsuarios repositorio) :base(repositorio)
        {
        }

        public Usuarios RecuperarUsuarioParaToken(string usuario, string senha)
        {
            return GetRepositorio<IRepUsuarios>()
                           .Recuperar(new string[] { "AsNoTracking" })
                           .Where(x=>x.Nome == usuario && x.Senha == senha)
                           .FirstOrDefault();
        }

        public override Usuarios Salvar(Usuarios entidade)
        {
            if (entidade.TipoUsuario == EnumTipoUsuariosAdm.Administrador)
            {
                throw new Exception("Usuário do tipo Administrador não pode ser alterado!");
            }

            return base.Salvar(entidade);
        }

        public override Usuarios Remover(Usuarios entidade)
        {
            if (entidade.TipoUsuario == EnumTipoUsuariosAdm.Administrador)
            {
                throw new Exception("Usuário do tipo Administrador não pode ser removido!");
            }

            return base.Remover(entidade);
        }

        public List<Usuarios> ListarFiltro(QueryParamsDTO dto)
        {
            return Repositorio.Recuperar().Where(x => x.Nome.ToUpper().Trim().Contains(dto.Filter.ToUpper().Trim()) )
                                                      .OrderBy(x => x.Id).Skip((dto.Page - 1) * dto.Limit).Take(dto.Limit).ToList();
        }

        public Usuarios RecuperarPorUsuario(NomeUsuarioDTO dto)
        {
            var ret = Repositorio.Recuperar().Where(x => x.Nome.ToUpper().Trim() == dto.Usuario.ToUpper().Trim()).FirstOrDefault();

            if (ret == null)
            {
                throw new Exception("Usuário inválido " + dto.Usuario);
            }

            return ret;
        }

    }
}
