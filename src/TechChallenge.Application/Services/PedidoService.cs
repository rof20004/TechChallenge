using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces.Infra;
using TechChallenge.Domain.Interfaces.Services;
using TechChallenge.Domain.Enums;

namespace TechChallenge.Application.Services;
public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;

    public PedidoService(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public async Task<int> CreatePedido(string idCliente, List<int> idProdutos)
    {

        var idPedido = await _pedidoRepository.CreatePedido(idCliente);

        await _pedidoRepository.CreatePedidoProduto(idPedido, idProdutos);
        return idPedido;
    }

    public async Task<Pedido> GetPedido(int idPedido)
    {
        var pedido = await _pedidoRepository.GetPedido(idPedido);

        if (pedido is null)
        {
            return null;
        }


        foreach (var item in pedido.Produtos)
        {
            if (item is null)
            {
                pedido = null;
            }
            else
            {
                pedido.TotalPedido += item.Valor;
            }
        }

        return pedido;
    }

    public async Task<List<Pedido>> GetPedidos()
    {
        var pedidos = await _pedidoRepository.GetPedidos();

        foreach (var pedido in pedidos.ToArray())
        {
            if (pedido.Produtos.Contains(null)
                || pedido.Status == StatusPedidoEnum.Finalizado.ToString())
            {
                pedidos.Remove(pedido);
            }
            else
            {
                foreach (var item in pedido.Produtos)
                {
                    pedido.TotalPedido += item.Valor;
                }
            }
        }

        return pedidos.OrderBy(x => x.Status == StatusPedidoEnum.Pronto.ToString() ? 0 : x.Status == StatusPedidoEnum.Preparando.ToString() ? 1 : 2)
             .ThenBy(x => x.Id).ToList();
    }

    public void PutStatusPedidos(Pedido entidade)
    {
        _pedidoRepository.PutStatusPedidos(entidade);
    }
}
