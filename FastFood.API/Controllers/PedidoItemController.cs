using Application.Services;
using Application.Validators;
using Domain.Services;
using Domain.Validators;
using FastFood.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PedidoItemController : Controller
    {
        private readonly IPedidoItemService _pedidoItemService;
        private readonly IPedidoItemValidator _pedidoItemValidator;
        private readonly IPedidoService _pedidoService;
        private readonly IProdutoService _produtoService;

        public PedidoItemController(IPedidoItemService pedidoItemService, 
            IPedidoItemValidator pedidoItemValidator,
            IPedidoService pedidoService,
            IProdutoService produtoService)
        {
            _pedidoItemService = pedidoItemService;
            _pedidoItemValidator = pedidoItemValidator;
            _pedidoService = pedidoService;
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> Incluir(PedidoItemInsert pedidoItemInsert)
        {   
            var pedidoItem = new PedidoItem
            {
                IdPedidoItem = Guid.NewGuid(),
                IdPedido = pedidoItemInsert.IdPedido,
                IdProduto = pedidoItemInsert.IdProduto,
                DataAlteracao = DateTime.Now,
                Ativo = true,
                Quantidade = pedidoItemInsert.Quantidade                
            };

            if(!_pedidoItemValidator.Validate(pedidoItem, out var errors))
            {
                return BadRequest(new { Errors = errors });
            }

            await _pedidoItemService.IncluiPedidoItemAsync(pedidoItem);

            return Ok(pedidoItem);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Alterar(Guid id, PedidoItemUpdate pedidoItemUpdate)
        {
            var pedidoItem = new PedidoItem
            {
                IdPedidoItem = id,
                IdPedido = pedidoItemUpdate.IdPedido,
                IdProduto = pedidoItemUpdate.IdProduto,
                DataAlteracao = DateTime.Now,
                Ativo = pedidoItemUpdate.Ativo,
                Quantidade = pedidoItemUpdate.Quantidade
            };

            if (!_pedidoItemValidator.Validate(pedidoItem, out var errors))
            {
                return BadRequest(new { Errors = errors });
            }

            await _pedidoItemService.EditaPedidoItemAsync(pedidoItem);

            return Ok(pedidoItem);
        }

        [HttpPatch("{id:Guid}/{status:bool}")]
        public async Task<IActionResult> AtivarInativar(Guid id, bool status)
        {
            await _pedidoItemService.AtivarInativarPedidoItemAsync(id, status);

            return Ok(new { mensagem = "Operação realizada com sucesso." });
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> RecuperarPorId(Guid id)
        {
            var pedidoItem = await _pedidoItemService.RecuperaPedidoItemPorIdAsync(id);

            if (pedidoItem == null)
            {
                return NotFound("Item não encontrado.");
            }

            var pedido = await _pedidoService.RecuperaPedidoPorIdAsync(pedidoItem.IdPedido);
            var produto = await _produtoService.RecuperaProdutoPorIdAsync(pedidoItem.IdProduto);

            var item = new
            {
                pedidoItem.IdPedidoItem,
                pedidoItem.IdProduto,
                produto.NomeProduto,
                pedidoItem.IdPedido,
                pedido.NumeroPedido,
                pedidoItem.Quantidade,
                pedidoItem.DataAlteracao
            };

            return Ok(item);
        }

        [HttpGet]
        public async Task<IActionResult> RecuperarListagem()
        {
            var pedidoItem = await _pedidoItemService.RecuperaPedidoItensAsync();
            var produtos = await _produtoService.RecuperaProdutosAsync();
            var pedidos = await _pedidoService.RecuperaPedidosAsync();

            var query = from pi in pedidoItem
                        join pr in produtos on pi.IdProduto equals pr.IdProduto
                        join pd in pedidos on pi.IdPedido equals pd.IdPedido
                        select new
                        {
                            pi.IdPedidoItem,
                            pi.IdProduto,
                            pr.NomeProduto,
                            pi.IdPedido,
                            pd.NumeroPedido,
                            pi.Quantidade,
                            pi.Ativo,
                            pi.DataAlteracao
                        };

            return Ok(query.ToList());
        }



    }
}
