namespace PJMT.ProvaArq.Domain.ValueObjects.Dinheiro.Moeda
{
    public class DezCentavos : IMoeda
    {
        public decimal Valor => 0.1M;

        public override string ToString() => "Dez Centavos";
    }
}
