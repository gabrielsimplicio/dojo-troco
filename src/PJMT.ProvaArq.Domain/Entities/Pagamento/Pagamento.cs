namespace PJMT.ProvaArq.Domain.Entities.Pagamento
{
    public class Pagamento
    {
        public decimal ValorTotal { get; private set; }
        public decimal ValorEfetivamentePago { get; private set; }

        public Pagamento(decimal valorTotal, decimal valorEfetivamentePago)
        {
            if (valorTotal <= 0M)
                throw new ValorTotalInseridoNoPagamentoOutOfRangeException();

            if (valorEfetivamentePago <= 0M)
                throw new ValorEfetivamentePagoInseridoNoPagamentoOutOfRangeException();

            if (valorEfetivamentePago < valorTotal)
                throw new ValorEfetivamentePagoMenorQueValorTotalException();

            ValorTotal = valorTotal;
            ValorEfetivamentePago = valorEfetivamentePago;
        }
    }
}
