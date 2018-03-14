namespace PJMT.ProvaArq.Domain.ValueObjects.Dinheiro.Moeda
{
    public class CincoCentavos : IMoeda
    {
        public decimal Valor => 0.05M;

        public override string ToString() => "Cinco Centavos";
    }
}
