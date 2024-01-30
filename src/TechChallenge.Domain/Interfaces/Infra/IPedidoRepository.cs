using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Interfaces.Infra
{
    public interface IPedidoRepository
    {
        public Task<Pedido> GetPedido(int idPedido);
        public Task<List<Pedido>> GetPedidos();

        public Task<int> CreatePedido(string idCliente);

        public Task CreatePedidoProduto(int idPedido, List<int> produtos);

        public void PutStatusPedidos(Pedido entidade);
    }
}