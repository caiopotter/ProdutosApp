using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Application.Dtos.Requests;
using ProdutosApp.Application.Dtos.Responses;
using ProdutosApp.Application.Interfaces;
using ProdutosApp.Application.Services;
using System.Net;

namespace ProdutosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController (IProdutoAppService _produtoAppService): ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ProdutoResponse), 201)]
        public async Task<IActionResult> Adicionar([FromBody] ProdutoRequest request)
        {
            return StatusCode(201, await _produtoAppService.Adicionar(request));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProdutoResponse), 200)]
        public async Task<IActionResult> Atualizar(Guid? id, [FromBody] ProdutoRequest request)
        {
            return Ok(await _produtoAppService.Atualizar(id, request));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProdutoResponse), 200)]
        public async Task<IActionResult> Inativar(Guid? id)
        {
            return Ok(await _produtoAppService.Inativar(id));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutoResponse), 200)]
        public async Task<IActionResult> ObterPorId(Guid? id)
        {
            var produto = await _produtoAppService.ObterPorId(id);
            if (produto == null)
            {
                return NoContent();
            }
            return Ok(produto);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutoResponse>), 200)]
        public async Task<IActionResult> ObterTodos()
        {
            var produtos = await _produtoAppService.ObterTodos();
            return Ok(produtos);
        }
    }
}
