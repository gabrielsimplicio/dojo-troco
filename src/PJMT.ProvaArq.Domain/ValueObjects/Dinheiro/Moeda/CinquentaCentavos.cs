namespace PJMT.ProvaArq.Domain.ValueObjects.Dinheiro.Moeda
{
    public class CinquentaCentavos : IMoeda
    {
        public decimal Valor => 0.5M;

        public override string ToString() => "Cinquenta Centavos";
    }
}
