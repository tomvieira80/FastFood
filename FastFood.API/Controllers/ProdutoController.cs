using Application.Services;
using Domain.Models;
using Domain.Services;
using Domain.Validators;
using FastFood.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly IProdutoValidator _produtoValidator;
        private readonly ICategoriaService _categoriaService;

        public ProdutoController(IProdutoService produtoService, IProdutoValidator produtoValidator, ICategoriaService categoriaService) 
        {
            _produtoService = produtoService;
            _produtoValidator = produtoValidator;
            _categoriaService = categoriaService;
        }

        [HttpPost]
        public async Task<IActionResult> Incluir(ProdutoInsert produtoInsert) 
        {
            var produto = new Produto
            {                
                IdProduto = Guid.NewGuid(),
                IdCategoria = produtoInsert.IdCategoria,
                NomeProduto = produtoInsert.NomeProduto,
                DataAlteracao = DateTime.Now,
                Ativo = true,
                Preco = produtoInsert.Preco
            };

            if (!_produtoValidator.Validate(produto, out var errors)) {
                return BadRequest(new { Errors = errors });
            }

            await _produtoService.IncluiProdutoAsync(produto);

            return Ok(produto);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Alterar(Guid id, ProdutoUpdate ProdutoUpdate)
        {
            var produto = new Produto
            {
                IdProduto = id,
                IdCategoria = ProdutoUpdate.IdCategoria,
                NomeProduto = ProdutoUpdate.NomeProduto,
                DataAlteracao = DateTime.Now,
                Ativo = ProdutoUpdate.Ativo,
                Preco = ProdutoUpdate.Preco
            };

            if (!_produtoValidator.Validate(produto, out var errors))
            {
                return BadRequest(new { Errors = errors });
            }

            await _produtoService.EditaProdutoAsync(produto);

            return Ok(produto);
        }

        [HttpPatch("{id:Guid}/{status:bool}")]
        public async Task<IActionResult> AtivarInativar(Guid id, bool status)
        {
            await _produtoService.AtivarInativarProdutoAsync(id, status);

            return Ok(new { mensagem = "Operação realizada com sucesso." });
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> RecuperarPorId(Guid id)
        {
            var produto = await _produtoService.RecuperaProdutoPorIdAsync(id);

            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }

            var categoria = await _categoriaService.RecuperaCategoriaPorIdAsync(produto.IdCategoria);

            var prod = new {
                            produto.IdProduto,
                            produto.NomeProduto,
                            produto.Preco,
                            produto.DataAlteracao,
                            produto.Ativo,
                            produto.IdCategoria,
                            categoria.NomeCategoria
                           };

            return Ok(prod);
        }

        [HttpGet]
        public async Task<IActionResult> RecuperarListagem()
        {
            var produtos = await _produtoService.RecuperaProdutosAsync();

            var categorias = await _categoriaService.RecuperaCategoriasAsync();

            var query = from p in produtos
                        join c in categorias on p.IdCategoria equals c.IdCategoria
                        select new
                        {
                            p.IdProduto,
                            p.NomeProduto,
                            p.Preco,
                            p.DataAlteracao,
                            p.Ativo,
                            p.IdCategoria,
                            c.NomeCategoria
                        };

            return Ok(query.ToList());
        }
    }
}
