namespace PJMT.ProvaArq.Domain.ValueObjects.Dinheiro.Moeda
{
    public class UmCentavo : IMoeda
    {
        public decimal Valor => 0.01M;

        public override string ToString() => "Um Centavo";
    }
}
