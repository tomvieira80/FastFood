using Application.Services;
using Domain.Repositories;
using Domain.Services;
using FastFood.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PedidoController : Controller
    {
        private readonly IPedidoService _pedidoService;
        private readonly IClienteService _clienteService;
        private readonly IPedidoStatusService _pedidoStatusService;
        private readonly IPedidoItemService _pedidoItemService;
        private readonly IProdutoService _produtoService;
        private readonly IPagamentoService _pagamentoService;


        public PedidoController(IPedidoService pedidoService, 
            IPedidoStatusService pedidoStatusService, 
            IClienteService clienteService, 
            IPedidoItemService pedidoItemService,
            IProdutoService produtoService,
            IPagamentoService pagamentoService) 
        {
            _pedidoService = pedidoService;
            _clienteService = clienteService;
            _pedidoStatusService = pedidoStatusService;
            _pedidoItemService = pedidoItemService;
            _produtoService = produtoService;
            _pagamentoService = pagamentoService;
        }

        [HttpPost]
        public async Task<IActionResult> Incluir(PedidoInsert pedidoInsert)
        {
            Random random = new Random();
            int randomNumber = random.Next(10000, 100000); // Gera um número aleatório entre 10000 e 99999

            var clienteIdentificado = pedidoInsert.ClienteIdentificado ? pedidoInsert.IdCliente : null;

            var pedido = new Pedido
            {
                IdPedido = Guid.NewGuid(),
                IdCliente = clienteIdentificado,
                NumeroPedido = randomNumber,
                IdPedidoStatus = Guid.Parse("52477561-5223-4a1f-bb22-a16fe8d514bf"), //Aguardando Pagamento
                DataAlteracao = DateTime.Now,
                DataCriacao = DateTime.Now
            };           

            await _pedidoService.IncluiPedidoAsync(pedido);

            return Ok(pedido);
        }

        [HttpPatch("{id:Guid}/{idStatusPedido:Guid}")]
        public async Task<IActionResult> AlterarStatus(Guid id, Guid idStatusPedido)
        {
            await _pedidoService.AlterarStatusPedidoAsync(id, idStatusPedido);

            return Ok(new { mensagem = "Operação realizada com sucesso." });
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> RecuperarPorId(Guid id)
        {
            var pedido = await _pedidoService.RecuperaPedidoPorIdAsync(id);

            if (pedido == null)
            {
                return NotFound("Pedido não encontrado.");
            }                       
           
            return Ok(pedido);
        }

        [HttpGet("{numeroPedido:int}")]
        public async Task<IActionResult> RecuperarPorNumeroPedido(int numeroPedido)
        {
            var pedido = await _pedidoService.RecuperaPedidoPorNrPedidoAsync(numeroPedido);

            if (pedido == null)
            {
                return NotFound("Pedido não encontrado.");
            }

            var cliente = "";

            if (pedido.IdCliente == null)
            {
                cliente = "Não Informado";
            }
            else
            {
                var c = await _clienteService.RecuperaClientePorIdAsync((Guid)pedido.IdCliente);
                cliente = c.Nome;
            }

            var s = await _pedidoStatusService.RecuperaPedidoStatusPorIdAsync(pedido.IdPedidoStatus);
            var pedItens = await _pedidoItemService.RecuperaPedidoItemAtivoPorIdPedidoAsync(pedido.IdPedido);

            var pi = new PedidoItensList
            {
                Cliente = cliente,
                IdPedido = pedido.IdPedido,
                Status = s.Status,
                NumeroPedido = pedido.NumeroPedido,
                Itens = new List<PedidoItensList.Item>()
            };

            foreach (var item in pedItens)
            {
                var produto = await _produtoService.RecuperaProdutoPorIdAsync(item.IdProduto);

                ((List<PedidoItensList.Item>)pi.Itens).Add(new PedidoItensList.Item
                {
                    IdPedidoItem = item.IdPedidoItem,
                    IdProduto = item.IdProduto,
                    NomeProduto = produto.NomeProduto,
                    Quantidade = item.Quantidade
                });

            }

            return Ok(pi);
        }
        [HttpGet]
        public async Task<IActionResult> RecuperarListagem()
        {
            var pedidos = await _pedidoService.RecuperaPedidosAsync();

            var clientes = await _clienteService.RecuperaListagemClienteAsync();

            var pedidoStatus = await _pedidoStatusService.RecuperaPedidoStatusAsync();


            var query = from p in pedidos
                        join s in pedidoStatus on p.IdPedidoStatus equals s.IdPedidoStatus
                        join c in clientes on p.IdCliente equals c.IdCliente into pedidoCliente
                        from c in pedidoCliente.DefaultIfEmpty()
                        select new
                        {
                            p.IdPedido,
                            p.NumeroPedido,
                            p.DataCriacao,
                            p.DataAlteracao,
                            p.IdPedidoStatus,
                            s.Status,
                            p.IdCliente,
                            Nome = c != null ? c.Nome : null
                        };

            return Ok(query.ToList());
        }

        /// <summary>
        /// Apos a confirmação do pagamento envia para proxima fila o pedido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("{id:Guid}")]
        public async Task<IActionResult> PedidoCheckout(Guid id)
        {
            if (!_pagamentoService.ValidarPagamento(id))
            {
                return BadRequest("Erro ao realizar o pagamento");
            }

            //Faz o pedido andar na fila
            await _pedidoService.AlterarStatusPedidoAsync(id, Guid.Parse("3107d3ba-e7ac-40f6-a9d2-494aba21c574")); //Faz o pedido andar na fila

            return Ok(new { mensagem = "Operação realizada com sucesso." });

        }

    }
}
