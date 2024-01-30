using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallenge.Domain.Enums
{
    public enum StatusPedidoEnum
    {
        Recebido = 1,
        Preparando = 2,
        Pronto = 3,
        Finalizado = 4

    }

    public enum StatusPagamentoPedidoEnum
    { 
        Aguardando = 1,
        EmProcessamento = 2,
        Pago = 3,
        Recusado = 4
    }
}

