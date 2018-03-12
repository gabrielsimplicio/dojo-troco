using System;

namespace PJMT.ProvaArq.Domain.Entities.Pagamento
{
    public class ValorEfetivamentePagoInseridoNoPagamentoOutOfRangeException : Exception
    {
        public ValorEfetivamentePagoInseridoNoPagamentoOutOfRangeException()
            : base("O valor efetivamente pago adicionado à um pagamento não pode ser menor ou igual à zero.")
        {

        }
    }
}
