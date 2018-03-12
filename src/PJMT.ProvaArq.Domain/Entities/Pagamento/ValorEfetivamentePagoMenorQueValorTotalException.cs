using System;

namespace PJMT.ProvaArq.Domain.Entities.Pagamento
{
    public class ValorEfetivamentePagoMenorQueValorTotalException : Exception
    {
        public ValorEfetivamentePagoMenorQueValorTotalException()
            : base("O valor efetivamente pago não pode ser menor que o valor total.")
        {

        }
    }
}
