using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI.Application.Contratos;
using ProjetoAPI.Application.Dtos;
using ProjetoAPI.Extensions;
using System;
using System.Threading.Tasks;

namespace ProjetoAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class InteracoesController : ControllerBase
    {
        private readonly IInteracaoService _interacaoService;
        private readonly IAccountService _accountService;

        public InteracoesController(IInteracaoService interacaoService, IAccountService accountService)
        {
            _interacaoService = interacaoService;
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpGet("comentario/{comentarioId}")]
        public async Task<IActionResult> GetByComentario(int comentarioId)
        {
            try
            {
                var eventos = await _interacaoService.GetInteracoesByComentarioIdAsync(comentarioId);
                if (eventos == null) return NoContent();

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{interacaoId}")]
        public async Task<IActionResult> GetById(int interacaoId)
        {
            try
            {
                var eventos = await _interacaoService.GetInteracaoByIdAsync(interacaoId);
                if (eventos == null) return NoContent();

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpPost("{comentarioId}")]
        public async Task<IActionResult> Post(InteracaoDto model, int comentarioId)
        {
            try
            {
                var interacao = await _interacaoService.AddInteracao(User.GetUserId(), comentarioId, model);
                if (interacao == null) return NoContent();

                return Ok(interacao);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar eventos. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, InteracaoDto model)
        {
            try
            {
                var interacao = await _interacaoService.UpdateInteracao(User.GetUserId(), id, model);
                if (interacao == null) return NoContent();

                return Ok(interacao);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar interações. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var evento = await _interacaoService.GetInteracaoByIdAsync(id);
                if (evento == null) return NoContent();

                if (await _interacaoService.DeleteInteracao(User.GetUserId(), id))
                {
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
