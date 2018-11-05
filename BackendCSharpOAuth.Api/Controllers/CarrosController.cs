﻿using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Net.Http;
using System;
using BackendCSharpOAuth.Dominio;
using BackendCSharpOAuth.Infra.DTOs;

namespace BackendCSharpOAuth.Api.Controllers
{
    #if !DEBUG
    [Authorize]
    #endif
    public class CarrosController : ApiController
    {
        private readonly IServCarros _servCarros;

        public CarrosController(IServCarros servCarros)
        {
            _servCarros = servCarros;
        }

        [HttpPost]
        public HttpResponseMessage Listar(QueryPaginacaoDTO dto)
        {
            try
            {
                var ret = _servCarros.Listar(dto);

                return Request.CreateResponse(HttpStatusCode.OK, new { Mensagem = "Registros recuperados com sucesso!", Content = ret });
            }
            catch (System.Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Mensagem = e.Message });
            }
        }

        [HttpPost]
        public HttpResponseMessage Salvar(Carros carros)
        {
            try
            {
                var retorno = _servCarros.Salvar(carros);

                return Request.CreateResponse(HttpStatusCode.OK, new { Content = retorno, Mensagem = "Registro salvo com sucesso!" });
            }
            catch (System.Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Mensagem = e.Message });
            }
        }

        [HttpPost]
        public HttpResponseMessage Remover(Carros carros)
        {
            try
            {
                var retorno = _servCarros.Remover(carros);

                return Request.CreateResponse(HttpStatusCode.OK, new { Content = retorno, Mensagem = "Registro removido com sucesso!" });
            }
            catch (System.Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Mensagem = e.Message });
            }
        }

        /* private readonly IServCarros _servCarros;

         public CarrosController(IServCarros servCarros)
         {
             _servCarros = servCarros;
         }

         public HttpResponseMessage Pesquisar(PesquisaDTO dto)
         {
             try
             {

                 var carros = _servCarros.PesquisarCarro(dto);
                 var totalRegistros = _servCarros.RecuperarTotalRegistrosFiltro(dto);

                 return Request.CreateResponse(HttpStatusCode.OK, new { Content = carros, Quantidade = totalRegistros, Mensagem = "Registros recuperados com sucesso!" });
             }
             catch (System.Exception e)
             {
                 return Request.CreateResponse(HttpStatusCode.BadRequest, new { Mensagem = e.Message });
             }
         }

         public HttpResponseMessage Listar(QueryPaginacaoDTO dto)
         {
             try
             {

                 var carros = _servCarros.Listar(dto);
                 var totalRegistros = _servCarros.RecuperarTotalRegistros();

                 return Request.CreateResponse(HttpStatusCode.OK, new { Content = carros, Quantidade = totalRegistros, Mensagem = "Registros recuperados com sucesso!" });
             }
             catch (System.Exception e)
             {
                 return Request.CreateResponse(HttpStatusCode.BadRequest, new { Mensagem = e.Message });
             }            
         }

         public HttpResponseMessage Salvar(Carros carros)
         {
             try
             {
                 var retorno = _servCarros.Salvar(carros);

                 return Request.CreateResponse(HttpStatusCode.OK, new { Content = retorno, Mensagem = "Registro salvo com sucesso!" });
             }
             catch (System.Exception e)
             {
                 return Request.CreateResponse(HttpStatusCode.BadRequest, new { Mensagem = e.Message });
             }            
         }

         public HttpResponseMessage RecuperarPorId(CodigoPadraoDTO dto)
         {
             try
             {
                 var retorno = _servCarros.RecuperarPorId(dto);

                 return Request.CreateResponse(HttpStatusCode.OK, new { Content = retorno, Mensagem = "Registro recuperado com sucesso!" });
             }
             catch (System.Exception e)
             {
                 return Request.CreateResponse(HttpStatusCode.BadRequest, new { Mensagem = e.Message });
             }
         }

         public HttpResponseMessage Remover(CodigoPadraoDTO dto)
         {
             try
             {
                 _servCarros.Remover(dto);

                 return Request.CreateResponse(HttpStatusCode.OK, new { Mensagem = "Registro removido com sucesso!" });
             }
             catch (System.Exception e)
             {
                 return Request.CreateResponse(HttpStatusCode.BadRequest, new { Mensagem = e.Message });
             }
         }
         */
    }
}