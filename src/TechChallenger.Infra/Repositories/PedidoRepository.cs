using Microsoft.EntityFrameworkCore;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Enums;
using TechChallenge.Domain.Interfaces.Infra;
using TechChallenge.Infra.Data;

namespace TechChallenge.Infra.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApiDbContext _context;

        public PedidoRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreatePedido(string idCliente)
        {
            Pedido pedido = new Pedido() { IdCliente = idCliente, Status = StatusPedidoEnum.Recebido.ToString(), StatusPagamento = StatusPagamentoPedidoEnum.Aguardando.ToString() };
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return (await _context.Pedidos.Where(x => x.IdCliente.Equals(idCliente)).OrderByDescending(x => x.Id).FirstAsync()).Id;
        }

        public async Task CreatePedidoProduto(int idPedido, List<int> idProdutos)
        {
            foreach (var idProduto in idProdutos)
            {
                PedidoProduto pedidoProduto = new PedidoProduto()
                {
                    IdPedido = idPedido,
                    IdProduto = idProduto
                };
                _context.PedidoProduto.AddRange(pedidoProduto);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Pedido> GetPedido(int idPedido)
        {
            var pedido = await _context.Pedidos.Where(x => x.Id.Equals(idPedido)).FirstOrDefaultAsync();

            var pedidoProtudos = await _context.PedidoProduto.Where(x => x.IdPedido.Equals(idPedido)).ToListAsync();

             if (pedido is null || pedidoProtudos.Count.Equals(0))
            {
                return null;
            }

            pedido.Produtos = new List<Produto>();

            foreach (var produto in pedidoProtudos) 
            {
                var item = await _context.Produto.Where(x => x.Id.Equals(produto.IdProduto)).FirstOrDefaultAsync();
                pedido.Produtos.Add(item);
            }

            return pedido;
        }

        public async Task<List<Pedido>> GetPedidos()
        {
            var pedidos = await _context.Pedidos.ToListAsync();

            foreach (var pedido in pedidos) 
            {
                var pedidoProdutos = await _context.PedidoProduto.Where(x => x.IdPedido.Equals(pedido.Id)).ToListAsync();

                if (pedidoProdutos is not null && !pedidoProdutos.Count.Equals(0))
                {
                    pedido.Produtos = new List<Produto>();

                    foreach (var produto in pedidoProdutos)
                    {
                        var item = await _context.Produto.Where(x => x.Id.Equals(produto.IdProduto)).FirstOrDefaultAsync() ?? null;
                        pedido.Produtos.Add(item);
                    }
                }
            }
            return pedidos;
        }

        public void PutStatusPedidos(Pedido entidade)
        {
            _context.Pedidos.Update(entidade);
            _context.SaveChanges();
        }


    }
}