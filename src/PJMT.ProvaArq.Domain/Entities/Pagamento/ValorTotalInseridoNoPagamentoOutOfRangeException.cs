using System;

namespace PJMT.ProvaArq.Domain.Entities.Pagamento
{
    public class ValorTotalInseridoNoPagamentoOutOfRangeException : Exception
    {
        public ValorTotalInseridoNoPagamentoOutOfRangeException() 
            : base("O valor total adicionado à um pagamento não pode ser menor ou igual à zero.")
        {

        }
    }
}
