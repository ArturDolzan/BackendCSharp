using BackendCSharpOAuth.Dominio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace BackendCSharpOAuth.Api.Mensageria
{
    public class DiretorioUsuarioHelper
    {
        public UsuariosFotoDTO CriarFotoUsuarioDiretorioTemp(Usuarios usuario, Boolean gerarFoto)
        {
            var usuariosFotoDTO = new UsuariosFotoDTO()
            {
                Id = usuario.Id,
                NomeCompleto = usuario.NomeCompleto,
                Usuario = usuario.Nome
            };

            string nomeFoto = null;

            if (usuario.Foto != null)
            {
                var diretorio = AppDomain.CurrentDomain.BaseDirectory + @"\tmp\fotos";
                nomeFoto = usuario.Nome + ".jpg";

                if (!Directory.Exists(diretorio))
                {
                    Directory.CreateDirectory(diretorio);
                }

                var arquivo = diretorio + @"\" + nomeFoto;

                if (gerarFoto)
                {
                    if (File.Exists(arquivo))
                    {
                        File.Delete(arquivo);
                        File.WriteAllBytes(arquivo, usuario.Foto);
                    }
                }
                else
                {
                    if (!File.Exists(arquivo))
                    {
                        File.WriteAllBytes(arquivo, usuario.Foto);
                    }
                }
                
                usuariosFotoDTO.Foto = @"\tmp\fotos\" + nomeFoto;
            }

            return usuariosFotoDTO;
        }
    }
}