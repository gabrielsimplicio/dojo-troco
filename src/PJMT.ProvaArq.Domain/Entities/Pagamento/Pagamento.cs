using System;

namespace PJMT.ProvaArq.Domain.Entities.Pagamento
{
    public class Pagamento
    {
        public Guid PagamentoId { get; private set; }
        public decimal ValorTotal { get; private set; }
        public decimal ValorEfetivamentePago { get; private set; }

        public Pagamento(Guid pagamentoId, decimal valorTotal, decimal valorEfetivamentePago)
        {
            if (pagamentoId == Guid.Empty)
                throw new ArgumentOutOfRangeException();

            if (valorTotal <= 0M)
                throw new ValorTotalInseridoNoPagamentoOutOfRangeException();

            if (valorEfetivamentePago <= 0M)
                throw new ValorEfetivamentePagoInseridoNoPagamentoOutOfRangeException();

            if (valorEfetivamentePago < valorTotal)
                throw new ValorEfetivamentePagoMenorQueValorTotalException();

            PagamentoId = pagamentoId;
            ValorTotal = valorTotal;
            ValorEfetivamentePago = valorEfetivamentePago;
        }
    }
}
