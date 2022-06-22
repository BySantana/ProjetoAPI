using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ProjetoAPI.Application.Contratos;
using ProjetoAPI.Controllers.Helpers;
using ProjetoAPI.Models.Identity;
using ProjetoAPI.Extensions;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using ProjetoAPI.Application.Dtos;

namespace ProjetoAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IUtil _util;
        //private readonly IAccount _accountService;

        private readonly string _destino = "Images";

        public PostsController(IPostService postService, IUtil util)
        {
            _postService = postService;
            _util = util;
            //_accountService = accountService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                var posts = await _postService.GetAllPostAsync();
                if (posts == null) return NoContent();

                return Ok(posts);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Posts. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var evento = await _postService.GetPostByIdAsync(id);
                if (evento == null) return NoContent();

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{userId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdUserId(int userId)
        {
            try
            {
                var evento = await _postService.GetAllPostByUserIdAsync(User.GetUserId());
                if (evento == null) return NoContent();

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        //[HttpGet("{tag}")]
        //public async Task<IActionResult> GetByTag(string tag)
        //{
        //    try
        //    {
        //        var evento = await _postService.GetPostByTagAsync(User.GetUserId(), tag);
        //        if (evento == null) return NoContent();

        //        return Ok(evento);
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.StatusCode(StatusCodes.Status500InternalServerError,
        //            $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
        //    }
        //}

        [HttpGet("{titulo}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByTitulo(string titulo)
        {
            try
            {
                var evento = await _postService.GetPostByTituloAsync(User.GetUserId(), titulo);
                if (evento == null) return NoContent();

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }



        [HttpPost("upload-image/{postId}")]
        public async Task<IActionResult> UploadImage(int postId)
        {
            try
            {
                var post = await _postService.GetPostByIdAsync(postId);
                if (post == null) return NoContent();

                var file = Request.Form.Files[0];
                if (file.Length > 0)
                {
                    _util.DeleteImage(post.ImagemURL, _destino);
                    post.ImagemURL = await _util.SaveImage(file, _destino);
                }
                var EventoRetorno = await _postService.UpdatePost(User.GetUserId(), postId, post);

                return Ok(EventoRetorno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar realizar upload de foto do evento. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(PostDto model)
        {
            try
            {
                var evento = await _postService.AddPost(User.GetUserId(), model);
                if (evento == null) return NoContent();

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar eventos. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Put(int id, PostDto model)
        {
            try
            {
                var evento = await _postService.UpdatePost(User.GetUserId(), id, model);
                if (evento == null) return NoContent();

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar eventos. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var evento = await _postService.GetPostByIdAsync(id);
                if (evento == null) return NoContent();

                if (await _postService.DeletePost(id))
                {
                    _util.DeleteImage(evento.ImagemURL, _destino);
                    return Ok(new { message = "Deletado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problem não específico ao tentar deletar Evento.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar eventos. Erro: {ex.Message}");
            }
        }
    }
}
